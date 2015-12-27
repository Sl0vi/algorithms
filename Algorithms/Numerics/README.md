Generic Numeric Type
================================================================================

The numeric type is a workaround for the fact that numbers in C# do not share a
common interface or class. This limitation often creates problems when writing 
code that works with numbers, where you may want to reuse the same code for 
different number types.

This means that you will often end up duplicating the code, either manually or
with code generation.

If you for example want to create 2D vector type. You'll want to store the 
direction in an x and a y number variable. First you implement a vector type 
using 32 bit integers. Later you might want to create a vector type using floats 
instead.

Unfortunately in C# you cannot define a generic constraint for both int and 
float. So you'll have to write the same code twice only replacing the types.

If you even later want to add even more number types, like double or long, you
have to rewrite the same code again and again.

Dynamic to the rescue
--------------------------------------------------------------------------------

We can abuse dynamic typing to tell the compiler to ignore the bits of the code
that are having issues with the limitations of the type system.

For example, when adding two generic number values using the add(+) operator, 
the compiler will complain. If we cast the addition to dynamic, the compiler
will happily ignore the type issue and compile our code.

Unfortunately, this also means that we lose some of the type safety that C#
provides and using dynamic comes at a small performance cost.

How to use
--------------------------------------------------------------------------------

The numeric type is a generic struct. You just specify the number type you want
to use as a generic type parameter. The struct implicitly converts both to and
from the base type. All binary and comparison operators that are shared across
number types can be used between both numeric types and the base type. The 
numeric type also implements all the same interfaces that C# numbers types do,
so you can do almost anything with it that you can do with normal numbers.

    var x = new Numeric<int>(2);
    var y = x + 7;

    Console.WriteLine("x: {0}, y: {1}", x, y);

    // output: x: 2, y: 9

    var z = new Numeric<int>(10);
    if (z > y)
        Console.WriteLine("z is larger than y");
    else
        Console.WriteLine("z is smaller than y");

    // output: z is larger than y

The place where the numeric type is most useful is as a generic parameter for
some other type. *You'll need to specify all the common interfaces for number
types as a constraint. This also greatly limits the number of incompatible type
parameters you can use, but does not provide complete type safety.*

    struct Vector2d<T>
        where T : 
            struct, 
            IEquatable<T>, 
            IComparable<T>,
            IFormattable,
            IConvertible,
            IComparable
    {
        public Numeric<T> X;
        public Numeric<T> Y;

        public Vector2d(T x, T y)
        {
            X = new Numeric<T>(x);
            Y = new Numeric<T>(y);
        }

        public Vector2d(Numeric<T> x, Numeric<T> y)
        {
            X = x;
            Y = y;
        }

        public Vector2d<T> Multiply(T value)
        {
            return new Vector2d<T>(X * value, Y * value);
        }
    }

    var floatVector = new Vector2d<float>(12.5F, 13F);
    floatVector = floatVector.Multiply(2F); // OK
    var doubleVector = new Vector2d<double>(9.95, 10.0);
    doubleVector = doubleVector.Multiply(2.0) // OK

    var stringVector = new Vector2d<string>("abc", "123"); // Compiler error!

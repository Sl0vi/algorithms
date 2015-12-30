using System;

namespace Algorithms.Numerics
{
    public interface INumeric<T> : 
        IEquatable<T>,
        IComparable<T>,
        IFormattable,
        IConvertible,
        IComparable
        where T : 
            struct, 
            IEquatable<T>, 
            IComparable<T>,
            IFormattable,
            IConvertible,
            IComparable
    {
        T Value { get; }
        Numeric<T> Add(T other);
        Numeric<T> Add(Numeric<T> other);
        Numeric<T> Subtract(T other);
        Numeric<T> Subtract(Numeric<T> other);
        Numeric<T> Multiply(T other);
        Numeric<T> Multiply(Numeric<T> other);
        Numeric<T> Divide(T other);
        Numeric<T> Divide(Numeric<T> other);
        Numeric<T> Modulus(T other);
        Numeric<T> Modulus(Numeric<T> other);
    }
}

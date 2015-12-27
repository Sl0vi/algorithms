using System;
using Algorithms.Numerics;

namespace Algorithms.Tests.Numeric
{
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
}

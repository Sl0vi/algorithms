using System;

namespace Algorithms.Numerics
{
    /// <summary>
    /// A numeric class that works around C#'s limitations by abusing the
    /// dynamic keyword.
    /// </summary>
    public struct Numeric<T> : INumeric<T>
        where T :
            struct,
            IEquatable<T>,
            IComparable<T>,
            IFormattable,
            IConvertible,
            IComparable
    {
        public readonly T Value;

        public Numeric(T value)
        {
            Value = value;
        }

        public Numeric(Numeric<T> numeric)
        {
            Value = numeric.Value;
        }

        public Numeric<T> Add(T other)
        {
            return new Numeric<T>((dynamic)Value + other);
        }

        public Numeric<T> Add(Numeric<T> other)
        {
            return new Numeric<T>((dynamic)Value + other.Value);
        }

        public Numeric<T> Subtract(T other)
        {
            return new Numeric<T>((dynamic)Value - other);
        }

        public Numeric<T> Subtract(Numeric<T> other)
        {
            return new Numeric<T>((dynamic)Value + other.Value);
        }

        public Numeric<T> Multiply(T other)
        {
            return new Numeric<T>((dynamic)Value * other);
        }

        public Numeric<T> Multiply(Numeric<T> other)
        {
            return new Numeric<T>((dynamic)Value * other.Value);
        }

        public Numeric<T> Divide(T other)
        {
            return new Numeric<T>((dynamic)Value / other);
        }

        public Numeric<T> Divide(Numeric<T> other)
        {
            return new Numeric<T>((dynamic)Value / other.Value);
        }

        public Numeric<T> Modulus(T other)
        {
            return new Numeric<T>((dynamic)Value % other);
        }

        public Numeric<T> Modulus(Numeric<T> other)
        {
            return new Numeric<T>((dynamic)Value % other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Numeric<T>)
            {
                var otherNumeric = (Numeric<T>)obj;
                return Value.Equals(otherNumeric.Value);
            }
            if (obj is T)
            {
                var otherValue = (T)obj;
                return Value.Equals(otherValue);
            }
            return false;
        }

        public bool Equals(T other)
        {
            return Value.Equals(other);
        }

        public int CompareTo(object obj)
        {
            if (obj is Numeric<T>)
            {
                var otherNumeric = (Numeric<T>)obj;
                return Value.CompareTo(otherNumeric.Value);
            }
            if (obj is T)
            {
                var otherValue = (T)obj;
                return Value.CompareTo(otherValue);
            }
            throw new InvalidOperationException();
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public string ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider);
        }

        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Value.ToBoolean(provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Value.ToChar(provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Value.ToSByte(provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Value.ToByte(provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Value.ToInt16(provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Value.ToUInt16(provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Value.ToInt32(provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Value.ToUInt32(provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Value.ToInt64(provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Value.ToUInt64(provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Value.ToSingle(provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Value.ToDouble(provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Value.ToDecimal(provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Value.ToDateTime(provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Value.ToType(conversionType, provider);
        }

        public static T Zero()
        {
            return default(T);
        }

        public static implicit operator Numeric<T>(T value)
        {
            return new Numeric<T>(value);
        }

        public static implicit operator T(Numeric<T> numeric)
        {
            return numeric.Value;
        }

        public static bool operator ==(Numeric<T> a, Numeric<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator ==(Numeric<T> a, T b)
        {
            return a.Value.Equals(b);
        }

        public static bool operator ==(T a, Numeric<T> b)
        {
            return a.Equals(b.Value);
        }
        public static bool operator !=(Numeric<T> a, Numeric<T> b)
        {
            return !a.Equals(b);
        }

        public static bool operator !=(Numeric<T> a, T b)
        {
            return !a.Value.Equals(b);
        }

        public static bool operator !=(T a, Numeric<T> b)
        {
            return !a.Equals(b.Value);
        }

        public static bool operator <(Numeric<T> a, Numeric<T> b)
        {
            return a.Value.CompareTo(b.Value) < 0;
        }

        public static bool operator <(Numeric<T> a, T b)
        {
            return a.Value.CompareTo(b) < 0;
        }

        public static bool operator <(T a, Numeric<T> b)
        {
            return a.CompareTo(b.Value) < 0;
        }

        public static bool operator <=(Numeric<T> a, Numeric<T> b)
        {
            return a.Value.CompareTo(b.Value) <= 0;
        }

        public static bool operator <=(Numeric<T> a, T b)
        {
            return a.Value.CompareTo(b) <= 0;
        }

        public static bool operator <=(T a, Numeric<T> b)
        {
            return a.CompareTo(b.Value) <= 0;
        }

        public static bool operator >(Numeric<T> a, Numeric<T> b)
        {
            return a.Value.CompareTo(b.Value) > 0;
        }

        public static bool operator >(Numeric<T> a, T b)
        {
            return a.Value.CompareTo(b) > 0;
        }

        public static bool operator >(T a, Numeric<T> b)
        {
            return a.CompareTo(b.Value) > 0;
        }

        public static bool operator >=(Numeric<T> a, Numeric<T> b)
        {
            return a.Value.CompareTo(b.Value) >= 0;
        }

        public static bool operator >=(Numeric<T> a, T b)
        {
            return a.Value.CompareTo(b) >= 0;
        }

        public static bool operator >=(T a, Numeric<T> b)
        {
            return a.CompareTo(b.Value) >= 0;
        }

        public static Numeric<T> operator +(Numeric<T> a, Numeric<T> b)
        {
            return a.Add(b);
        }

        public static Numeric<T> operator +(Numeric<T> a, T b)
        {
            return a.Add(b);
        }

        public static Numeric<T> operator +(T a, Numeric<T> b)
        {
            return new Numeric<T>(a).Add(b);
        }

        public static Numeric<T> operator -(Numeric<T> a, Numeric<T> b)
        {
            return a.Subtract(b);
        }

        public static Numeric<T> operator -(Numeric<T> a, T b)
        {
            return a.Subtract(b);
        }

        public static Numeric<T> operator -(T a, Numeric<T> b)
        {
            return new Numeric<T>(a).Subtract(b);
        }

        public static Numeric<T> operator *(Numeric<T> a, Numeric<T> b)
        {
            return a.Multiply(b);
        }

        public static Numeric<T> operator *(Numeric<T> a, T b)
        {
            return a.Multiply(b);
        }

        public static Numeric<T> operator *(T a, Numeric<T> b)
        {
            return new Numeric<T>(a).Multiply(b);
        }

        public static Numeric<T> operator /(Numeric<T> a, Numeric<T> b)
        {
            return a.Divide(b);
        }

        public static Numeric<T> operator /(Numeric<T> a, T b)
        {
            return a.Divide(b);
        }

        public static Numeric<T> operator /(T a, Numeric<T> b)
        {
            return new Numeric<T>(a).Divide(b);
        }

        public static Numeric<T> operator %(Numeric<T> a, Numeric<T> b)
        {
            return a.Modulus(b);
        }

        public static Numeric<T> operator %(Numeric<T> a, T b)
        {
            return a.Modulus(b);
        }

        public static Numeric<T> operator %(T a, Numeric<T> b)
        {
            return new Numeric<T>(a).Modulus(b);
        }
    }
}

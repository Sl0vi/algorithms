using System;
using Algorithms.Numerics;
using NUnit.Framework;

namespace Algorithms.Tests.Numeric
{
    [TestFixture]
    public abstract class NumericTests<T>
        where T :
            struct,
            IEquatable<T>,
            IComparable<T>,
            IFormattable,
            IConvertible,
            IComparable
    {
        [Test]
        public void ImplicitCastToNumeric()
        {
            var x = NewValue(15M);
            Numeric<T> y = default(Numeric<T>);
            Assert.DoesNotThrow(() => y = x);
            Assert.That(y.Value, Is.EqualTo(NewValue(15M)));
        }

        [Test]
        public void ImplicitCastFromNumeric()
        {
            var x = NewNumeric(14M);
            T y = default(T);
            Assert.DoesNotThrow(() => y = x);
            Assert.That(y, Is.EqualTo(NewValue(14M)));
        }

        [Test]
        public void Add_value()
        {
            var x = NewNumeric(15M);
            T y = NewValue(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Add(y));
            Assert.That(result, Is.EqualTo(NewValue(20M)));
        }

        [Test]
        public void Add_numeric()
        {
            var x = NewNumeric(15M);
            var y = NewNumeric(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Add(y));
            Assert.That(result, Is.EqualTo(NewNumeric(20M)));
        }

        [Test]
        public void Subtract_value()
        {
            var x = NewNumeric(15M);
            var y = NewValue(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Subtract(y));
            Assert.That(result, Is.EqualTo(NewValue(10M)));

        }

        [Test]
        public void Subtract_numeric()
        {
            var x = NewNumeric(15M);
            var y = NewNumeric(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Subtract(y));
            Assert.That(result, Is.EqualTo(NewNumeric(10M)));
        }

        [Test]
        public void Multiply_value()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Multiply(y));
            Assert.That(result, Is.EqualTo(NewValue(50M)));
        }

        [Test]
        public void Multiply_numeric()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Multiply(y));
            Assert.That(result, Is.EqualTo(NewNumeric(50M)));
        }

        [Test]
        public void Divide_value()
        {
            var x = NewNumeric(50M);
            var y = NewValue(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Divide(y));
            Assert.That(result, Is.EqualTo(NewValue(10M)));
        }

        [Test]
        public void Divide_numeric()
        {
            var x = NewNumeric(50M);
            var y = NewNumeric(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Divide(y));
            Assert.That(result, Is.EqualTo(NewNumeric(10M)));
        }

        [Test]
        public void Modulus_value()
        {
            var x = NewNumeric(12M);
            var y = NewValue(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Modulus(y));
            Assert.That(result, Is.EqualTo(NewValue(2M)));
        }

        [Test]
        public void Modulus_numeric()
        {
            var x = NewNumeric(12M);
            var y = NewNumeric(5M);
            var result = default(Numeric<T>);
            Assert.DoesNotThrow(() => result = x.Modulus(y));
            Assert.That(result, Is.EqualTo(NewNumeric(2M)));
        }

        [Test]
        public void GetHashCode_same_as_value()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
        }

        [Test]
        public void Equals_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x.Equals(y), Is.True);
        }

        [Test]
        public void Equals_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x.Equals(y), Is.True);
        }

        [Test]
        public void Equals_value_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x.Equals(y), Is.False);
        }

        [Test]
        public void Equals_numeric_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x.Equals(y), Is.False);
        }

        [Test]
        public void Equals_wrong_type()
        {
            var x = NewNumeric(10M);
            var y = new WrongType(10);
            Assert.That(x.Equals(y), Is.False);
        }

        [Test]
        public void CompareTo_value_less()
        {
            var x = NewNumeric(10M);
            var y = NewValue(15M);
            Assert.That(x.CompareTo(y), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x.CompareTo(y), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_value_greater()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x.CompareTo(y), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_numeric_less()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(15M);
            Assert.That(x.CompareTo(y), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x.CompareTo(y), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_numeric_greater()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x.CompareTo(y), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_wrong_type()
        {
            var x = NewNumeric(10M);
            var y = new WrongType(5);
            Assert.That(
                () => x.CompareTo(y),
                Throws.InvalidOperationException);
        }

        [Test]
        public void EqualsOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x == y, Is.True);
        }

        [Test]
        public void EqualsOperator_numeric_numeric_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x == y, Is.False);
        }

        [Test]
        public void EqualsOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x == y, Is.True);
        }

        [Test]
        public void EqualsOperator_numeric_value_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x == y, Is.False);
        }

        [Test]
        public void EqualsOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x == y, Is.True);
        }

        [Test]
        public void EqualsOperator_value_numeric_not_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x == y, Is.False);
        }

        [Test]
        public void NotEqualsOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x != y, Is.False);
        }

        [Test]
        public void NotEqualsOperator_numeric_numeric_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x != y, Is.True);
        }

        [Test]
        public void NotEqualsOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x != y, Is.False);
        }

        [Test]
        public void NotEqualsOperator_numeric_value_not_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x != y, Is.True);
        }

        [Test]
        public void NotEqualsOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x != y, Is.False);
        }

        [Test]
        public void NotEqualsOperator_value_numeric_not_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x != y, Is.True);
        }

        [Test]
        public void LessThanOperator_numeric_numeric_less()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x < y, Is.True);
        }

        [Test]
        public void LessThanOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOperator_numeric_numeric_greater()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOperator_numeric_value_less()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x < y, Is.True);
        }

        [Test]
        public void LessThanOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOperator_numeric_value_greater()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOperator_value_numeric_less()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x < y, Is.True);
        }

        [Test]
        public void LessThanOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOperator_value_numeric_greater()
        {
            var x = NewValue(10M);
            var y = NewNumeric(5M);
            Assert.That(x < y, Is.False);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_numeric_less()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_numeric_greater()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x <= y, Is.False);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_value_less()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_numeric_value_greater()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x <= y, Is.False);
        }

        [Test]
        public void LessThanOrEqualOperator_value_numeric_less()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x <= y, Is.True);
        }

        [Test]
        public void LessThanOrEqualOperator_value_numeric_greater()
        {
            var x = NewValue(10M);
            var y = NewNumeric(5M);
            Assert.That(x <= y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_numeric_numeric_less()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_numeric_numeric_greater()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x > y, Is.True);
        }

        [Test]
        public void GreaterThanOperator_numeric_value_less()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_numeric_value_greater()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x > y, Is.True);
        }

        [Test]
        public void GreaterThanOperator_value_numeric_less()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x > y, Is.False);
        }

        [Test]
        public void GreaterThanOperator_value_numeric_greater()
        {
            var x = NewValue(10M);
            var y = NewNumeric(5M);
            Assert.That(x > y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_numeric_less()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(20M);
            Assert.That(x >= y, Is.False);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_numeric_equal()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(10M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_numeric_greater()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_value_less()
        {
            var x = NewNumeric(10M);
            var y = NewValue(20M);
            Assert.That(x >= y, Is.False);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_value_equal()
        {
            var x = NewNumeric(10M);
            var y = NewValue(10M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_numeric_value_greater()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_value_numeric_less()
        {
            var x = NewValue(10M);
            var y = NewNumeric(20M);
            Assert.That(x >= y, Is.False);
        }

        [Test]
        public void GreaterThanOrEqualOperator_value_numeric_equal()
        {
            var x = NewValue(10M);
            var y = NewNumeric(10M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualOperator_value_numeric_greater()
        {
            var x = NewValue(10M);
            var y = NewNumeric(5M);
            Assert.That(x >= y, Is.True);
        }

        [Test]
        public void AddOperator_numeric_numeric()
        {
            var x = NewNumeric(10M);
            var y = NewNumeric(5M);
            Assert.That(x + y, Is.EqualTo(NewValue(15M)));
        }

        [Test]
        public void AddOperator_numeric_value()
        {
            var x = NewNumeric(10M);
            var y = NewValue(5M);
            Assert.That(x + y, Is.EqualTo(NewValue(15M)));
        }

        [Test]
        public void AddOperator_value_numeric()
        {
            var x = NewValue(10M);
            var y = NewNumeric(5M);
            Assert.That(x + y, Is.EqualTo(NewValue(15M)));
        }

        [Test]
        public void SubtractOperator_numeric_numeric()
        {
            var x = NewNumeric(15M);
            var y = NewNumeric(5M);
            Assert.That(x - y, Is.EqualTo(NewValue(10M)));
        }

        [Test]
        public void SubtractOperator_numeric_value()
        {
            var x = NewNumeric(15M);
            var y = NewValue(5M);
            Assert.That(x - y, Is.EqualTo(NewValue(10M)));
        }

        [Test]
        public void SubtractOperator_value_numeric()
        {
            var x = NewValue(15M);
            var y = NewNumeric(5M);
            Assert.That(x - y, Is.EqualTo(NewValue(10M)));
        }

        [Test]
        public void MultiplyOperator_numeric_numeric()
        {
            var x = NewNumeric(5M);
            var y = NewNumeric(10M);
            Assert.That(x * y, Is.EqualTo(NewValue(50M)));
        }

        [Test]
        public void MultiplyOperator_numeric_value()
        {
            var x = NewNumeric(5M);
            var y = NewValue(10M);
            Assert.That(x * y, Is.EqualTo(NewValue(50M)));
        }

        [Test]
        public void MultiplyOperator_value_numeric()
        {
            var x = NewValue(5M);
            var y = NewNumeric(10M);
            Assert.That(x * y, Is.EqualTo(NewValue(50M)));
        }

        [Test]
        public void DivideOperator_numeric_numeric()
        {
            var x = NewNumeric(50M);
            var y = NewNumeric(10M);
            Assert.That(x / y, Is.EqualTo(NewValue(5M)));
        }

        [Test]
        public void DivideOperator_numeric_value()
        {
            var x = NewNumeric(50M);
            var y = NewValue(10M);
            Assert.That(x / y, Is.EqualTo(NewValue(5M)));
        }

        [Test]
        public void DivideOperator_value_numeric()
        {
            var x = NewValue(50M);
            var y = NewNumeric(10M);
            Assert.That(x / y, Is.EqualTo(NewValue(5M)));
        }

        [Test]
        public void ModulusOperator_numeric_numeric()
        {
            var x = NewNumeric(12M);
            var y = NewNumeric(5M);
            Assert.That(x % y, Is.EqualTo(NewValue(2M)));
        }

        [Test]
        public void ModulusOperator_numeric_value()
        {
            var x = NewNumeric(12M);
            var y = NewValue(5M);
            Assert.That(x % y, Is.EqualTo(NewValue(2M)));
        }

        [Test]
        public void ModulusOperator_value_numeric()
        {
            var x = NewValue(12M);
            var y = NewNumeric(5M);
            Assert.That(x % y, Is.EqualTo(NewValue(2M)));
        }

        public abstract T NewValue(decimal value);
        public abstract Numeric<T> NewNumeric(decimal value);
    }
}

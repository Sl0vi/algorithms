using Algorithms.Numerics;
using NUnit.Framework;

namespace Algorithms.Tests.Numeric
{
    [TestFixture]
    public class NumericDecimalTests : NumericTests<decimal>
    {
        public override decimal NewValue(decimal value)
        {
            return value;
        }

        public override Numeric<decimal> NewNumeric(decimal value)
        {
            return new Numeric<decimal>(value);
        }
    }
}

using Algorithms.Numerics;
using NUnit.Framework;

namespace Algorithms.Tests.Numeric
{
    [TestFixture]
    public class NumericLong : NumericTests<long>
    {
        public override long NewValue(decimal value)
        {
            return (long)value;
        }

        public override Numeric<long> NewNumeric(decimal value)
        {
            return new Numeric<long>((long)value);
        }
    }
}

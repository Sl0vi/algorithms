using NUnit.Framework;
using Algorithms.Numerics;

namespace Algorithms.Tests.Numeric
{
    [TestFixture]
    public class NumericIntTests : NumericTests<int>
    {
        public override int NewValue(decimal value)
        {
            return (int)value;
        }

        public override Numeric<int> NewNumeric(decimal value)
        {
            return new Numeric<int>((int)value);
        }
    }
}

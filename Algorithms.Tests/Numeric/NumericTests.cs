using Algorithms.Numerics;
using NUnit.Framework;

namespace Algorithms.Tests.Numeric
{
    [TestFixture]
    public class NumericTests
    {
        [Test]
        public void NumericPlusNumericInt()
        {
            var x = new Numeric<int>(1);
            var y = new Numeric<int>(2);
            Numeric<int> result = 0;
            Assert.DoesNotThrow(() => result = x + y);
            Assert.That(result, Is.InstanceOf<Numeric<int>>());
            Assert.That(result.Value, Is.EqualTo(3));

            int implicitCast = 0;
            Assert.DoesNotThrow(() => implicitCast = result);
            Assert.That(implicitCast, Is.EqualTo(3));
        }

        [Test]
        public void IntVector2d()
        {
        }
    }
}

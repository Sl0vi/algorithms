using System;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class FisherYatesShuffleTests
    {
        [Test]
        public void Shuffe()
        {
            var random = new Random(243);
            var sorted = new[] { 1, 2, 3, 4, 5, 6 };
            var expected = new[] { 5, 2, 1, 3, 6, 4 };
            int[] shuffled = null;
            Assert.DoesNotThrow(() => shuffled = sorted.Shuffle(random).ToArray());
            Assert.That(shuffled, Is.Not.Null);
            Assert.That(shuffled.Length, Is.EqualTo(sorted.Length));
            Assert.That(shuffled, Is.EqualTo(expected));
        }
    }
}

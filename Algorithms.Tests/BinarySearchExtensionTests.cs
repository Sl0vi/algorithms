using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinarySearchExtensionTests
    {
        [Test]
        public void BinarySearch_find_number()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = 0;
            Assert.DoesNotThrow(() => result = numbers.BinarySearch(x => x, 3));
            Assert.That(result, Is.EqualTo(3));
           
        }

        [Test]
        public void BinarySearch_find_string()
        {
            var strings = new[] { "Alice", "Ben", "Bob", "Carl", "Casper", "George", "Luke", "Ned" };
            string result = null;
            Assert.DoesNotThrow(() => result = strings.BinarySearch(x => x, "Ben"));
            Assert.That(result, Is.EqualTo("Ben"));
        }

        [Test]
        public void BinarySearch_throw_ValueNotFoundException()
        {
            var numbers = new [] { 1, 2, 4, 5, 6, 7, 8, 9, 10 };
            Assert.Throws<ValueNotFoundException>(() => numbers.BinarySearch(x => x, 3));
        }
    }
}

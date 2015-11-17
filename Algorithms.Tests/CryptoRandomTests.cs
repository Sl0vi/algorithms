using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class CryptoRandomTests
    {
        [Test]
        public void Next()
        {
            var random = new CryptoRandom();
            int next = -1;
            Assert.DoesNotThrow(() => next = random.Next());
            Assert.That(next, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Next_maxvalue()
        {
            var random = new CryptoRandom();
            int next = -1;
            Assert.DoesNotThrow(() => next = random.Next(1000));
            Assert.That(next, Is.GreaterThanOrEqualTo(0));
            Assert.That(next, Is.LessThan(1000));

            next = -1;
            Assert.DoesNotThrow(() => next = random.Next(500));
            Assert.That(next, Is.GreaterThanOrEqualTo(0));
            Assert.That(next, Is.LessThan(500));
        }

        [Test]
        public void Next_minvalue_maxvalue()
        {
            var random = new CryptoRandom();
            int next = 0;
            Assert.DoesNotThrow(() => next = random.Next(20, 100));
            Assert.That(next, Is.GreaterThanOrEqualTo(20));
            Assert.That(next, Is.LessThan(100));

            next = 0;
            Assert.DoesNotThrow(() => next = random.Next(-40, -20));
            Assert.That(next, Is.GreaterThanOrEqualTo(-40));
            Assert.That(next, Is.LessThan(-20));
        }

        [Test]
        public void NextBytes()
        {
            var random = new CryptoRandom();
            var buffer = new byte[10];
            Assert.DoesNotThrow(() => random.NextBytes(buffer));
        }

        [Test]
        public void NextDouble()
        {
            var random = new CryptoRandom();
            double next = -1.0;
            Assert.DoesNotThrow(() => next = random.NextDouble());
            Assert.That(next, Is.GreaterThanOrEqualTo(0.0));
            Assert.That(next, Is.LessThanOrEqualTo(1.0));

            next = -1.0;
            Assert.DoesNotThrow(() => next = random.NextDouble());
            Assert.That(next, Is.GreaterThanOrEqualTo(0.0));
            Assert.That(next, Is.LessThanOrEqualTo(1.0));
        }

        [Test]
        public void Sample()
        {
            var random = new CryptoRandom();
            double next = -1.0;
            Assert.DoesNotThrow(() => next = random.NextDouble());
            Assert.That(next, Is.GreaterThanOrEqualTo(0.0));
            Assert.That(next, Is.LessThanOrEqualTo(1.0));

            next = -1.0;
            Assert.DoesNotThrow(() => next = random.NextDouble());
            Assert.That(next, Is.GreaterThanOrEqualTo(0.0));
            Assert.That(next, Is.LessThanOrEqualTo(1.0));
        }
    }
}

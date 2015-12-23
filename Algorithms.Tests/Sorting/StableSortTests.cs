using System;
using Algorithms.Sorting;
using NUnit.Framework;
using System.Linq;

namespace Algorithms.Tests.Sorting
{
    /// <summary>
    /// General unit tests for stable sorting algorithms.
    /// </summary>
    [TestFixture]
    public abstract class StableSortTests : SortingAlgorithmTests
    {
        [Test]
        public void MaintainsRelativeSortOrder()
        {
            var list = new[]
            { 
                new SortObject { Number = 24, Text = "Hans" },
                new SortObject { Number = 6, Text = "Olli" },
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" }
            }.Sort(x => x.Number, algorithm).ToArray();
            var sorted = new[]
            {
                new SortObject { Number = 6, Text = "Olli" },
                new SortObject { Number = 6, Text = "Ivan" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 24, Text = "Hans" },
                new SortObject { Number = 24, Text = "Bill" },
            };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            for (var i = 0; i < list.Length; i++)
            {
                Assert.That(list[i].Number, Is.EqualTo(sorted[i].Number));
                Assert.That(list[i].Text, Is.EqualTo(sorted[i].Text));
            }
        }
    }
}

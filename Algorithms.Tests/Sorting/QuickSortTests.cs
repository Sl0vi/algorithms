using System;
using System.Linq;
using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class QuickSortTests
    {
        private SortingAlgorithm algorithm = SortingAlgorithm.QuickSort;

        [Test]
        public void SortNumbers()
        {
            var list = new[] { 5, 1, 24, 12, 6, 233, 23, 44 }
                .Sort(x => x, algorithm).ToArray();
            var sorted = new[] { 1, 5, 6, 12, 23, 24, 44, 233 };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            Assert.That(list, Is.EqualTo(sorted));
        }

        [Test]
        public void SortNumbersDescending()
        {
            var list = new[] { 5, 1, 24, 12, 6, 233, 23, 44 }
                .Sort(x => x, algorithm, SortOrder.Descending).ToArray();
            var sorted = new[] { 233, 44, 24, 23, 12, 6, 5, 1};
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            Assert.That(list, Is.EqualTo(sorted));
        }

        [Test]
        public void SortStrings()
        {
            var list = new[] { "Hans", "Olli", "Bill", "George", "Ivan" }
                .Sort(x => x, algorithm).ToArray();
            var sorted = new[] { "Bill", "George", "Hans", "Ivan", "Olli" };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            Assert.That(list, Is.EqualTo(sorted));
        }

        [Test]
        public void SortStringsDescending()
        {
            var list = new[] { "Hans", "Olli", "Bill", "George", "Ivan" }
                .Sort(x => x, algorithm, SortOrder.Descending).ToArray();
            var sorted = new[] { "Olli", "Ivan", "Hans", "George", "Bill" };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            Assert.That(list, Is.EqualTo(sorted));
        }

        [Test]
        public void SortObjectNumbers()
        {
            var list = new[] 
            { 
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" }
            }.Sort(x => x.Number, algorithm).ToArray();
            var sorted = new[] 
            { 
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 6, Text = "Ivan" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 24, Text = "Bill" }
            };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            for (var i = 0; i < list.Length; i++)
            {
                Assert.That(list[i].Number, Is.EqualTo(sorted[i].Number));
                Assert.That(list[i].Text, Is.EqualTo(sorted[i].Text));
            }
        }

        [Test]
        public void SortObjectNumbersDescending()
        {
            var list = new[] 
            { 
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" }
            }.Sort(x => x.Number, algorithm, SortOrder.Descending).ToArray();
            var sorted = new[] 
            { 
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" },
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 1, Text = "Olli" }
            };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            for (var i = 0; i < list.Length; i++)
            {
                Assert.That(list[i].Number, Is.EqualTo(sorted[i].Number));
                Assert.That(list[i].Text, Is.EqualTo(sorted[i].Text));
            }
        }

        [Test]
        public void SortObjectStrings()
        {
            var list = new[] 
            { 
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" }
            }.Sort(x => x.Text, algorithm).ToArray();
            var sorted = new[] 
            { 
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 6, Text = "Ivan" },
                new SortObject { Number = 1, Text = "Olli" },
            };
            Assert.That(list.Length, Is.EqualTo(sorted.Length));
            for (var i = 0; i < list.Length; i++)
            {
                Assert.That(list[i].Number, Is.EqualTo(sorted[i].Number));
                Assert.That(list[i].Text, Is.EqualTo(sorted[i].Text));
            }
        }

        [Test]
        public void SortObjectStringsDescending()
        {
            var list = new[] 
            { 
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 24, Text = "Bill" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 6, Text = "Ivan" }
            }.Sort(x => x.Text, algorithm, SortOrder.Descending).ToArray();
            var sorted = new[] 
            { 
                new SortObject { Number = 1, Text = "Olli" },
                new SortObject { Number = 6, Text = "Ivan" },
                new SortObject { Number = 5, Text =  "Hans" },
                new SortObject { Number = 12, Text = "George" },
                new SortObject { Number = 24, Text = "Bill" }
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

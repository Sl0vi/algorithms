using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class BubbleSortTests : StableSortTests
    {
        public BubbleSortTests()
        {
            algorithm = SortingAlgorithm.BubbleSort;
        }
    }
}

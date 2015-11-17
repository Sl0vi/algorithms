using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class BubbleSortTests : SortingAlgorithmTests
    {
        public BubbleSortTests()
        {
            algorithm = SortingAlgorithm.BubbleSort;
        }
    }
}

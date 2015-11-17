using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class SelectionSortTests : SortingAlgorithmTests
    {
        public SelectionSortTests()
        {
            algorithm = SortingAlgorithm.SelectionSort;
        }
    }
}

using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class QuickSortTests : SortingAlgorithmTests
    {
        public QuickSortTests()
        {
            algorithm = SortingAlgorithm.QuickSort;
        }
    }
}

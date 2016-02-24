using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class MergeSortTests : SortingAlgorithmTests
    {
        public MergeSortTests()
        {
            algorithm = SortingAlgorithm.MergeSort;
        }
    }
}

using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class QuickSortParallelTests : SortingAlgorithmTests
    {
        public QuickSortParallelTests()
        {
            algorithm = SortingAlgorithm.QuickSortParallel;
        }
    }
}

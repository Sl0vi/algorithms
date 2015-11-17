using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class InsertionSortTests : SortingAlgorithmTests
    {
        public InsertionSortTests()
        {
            algorithm = SortingAlgorithm.InsertionSort;
        }
    }
}

using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class InsertionSortTests : StableSortTests
    {
        public InsertionSortTests()
        {
            algorithm = SortingAlgorithm.InsertionSort;
        }
    }
}

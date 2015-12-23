using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class BubbleSortOmptimizedTests : StableSortTests
    {
        public BubbleSortOmptimizedTests()
        {
            algorithm = SortingAlgorithm.BubbleSortOptimized;
        }
    }
}

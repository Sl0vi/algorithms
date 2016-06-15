using Algorithms.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting
{
    [TestFixture]
    public class ShellSortTests : SortingAlgorithmTests
    {
        public ShellSortTests()
        {
            algorithm = SortingAlgorithm.ShellSort;
        }
    }
}

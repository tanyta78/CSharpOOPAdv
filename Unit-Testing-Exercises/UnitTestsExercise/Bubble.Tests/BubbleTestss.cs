using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Bubble.Tests
{
    [TestFixture]
    public class BubbleTestss
    {
        [Test]
        [TestCase("9, 2, 3, 4, 5, 6, 7, 8, 1")]
        [TestCase("8,7,9,5,6,3,4,1,2")]
        public void BubbleCanSortNumbers(string listString)
        {

            // Arrange
            var list = listString.Split(',')
                .Select(int.Parse)
                .ToList();
            var bubble = new BubbleSort.Bubble();
            var sortedNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            bubble.Sort(list);

            // Assert
            CollectionAssert.AreEqual(sortedNumbers, list);
        }
    }
}
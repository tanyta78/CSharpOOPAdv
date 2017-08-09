using System;
using NUnit.Framework;
using System.Collections.Generic;
using ListIterators;

namespace ListIterators.Tests
{
    [TestFixture]
    public class ListIteratorTests
    {

        private ListIterator listIterator;
        private List<string> collection;

        [SetUp]
        public void TestInit()
        {
           this.collection = new List<string>() { "aaa", "bbb", "ccc" };
            this.listIterator = new ListIterator(this.collection);
        }

       [Test]
        public void InitializationConstructorCannotWorkWithNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

        [Test]
        public void MoveReturnsTrueWhenSuccessful()
        {
            // Assert
            Assert.AreEqual(true, this.listIterator.Move());
            Assert.AreEqual(true, this.listIterator.Move());
        }

        [Test]
        public void MoveReturnsFalseWhenThereIsNoMoreElements()
        {
            // Act
            this.listIterator.Move();
            this.listIterator.Move();

            // Assert
            Assert.AreEqual(false, this.listIterator.Move());
        }

        [Test]
        public void HasNextReturnsTrueWhenHasNextIndex()
        {
            //Act
            this.listIterator.Move();
            var result = this.listIterator.HasNext();
            //Assert
            Assert.AreEqual(true,result);

        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void PrintReturnsCurrentElement(int elementToPrint)
        {
            // Act
            for (int i = 0; i < elementToPrint; i++)
            {
                this.listIterator.Move();
            }

            // Assert
            Assert.AreEqual(this.collection[elementToPrint],
                this.listIterator.Print(),
                "Print doesn't return correct element");
        }

        [Test]
        public void CannotPrintWithEmptyIterator()
        {
            // Arrange
            this.listIterator = new ListIterator(new List<string>());

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.listIterator.Print());
            Assert.AreEqual("Invalid Operation!", ex.Message, "Attempting to print over empty iterator throws exception with an incorrect message");
        }
    }

    
}
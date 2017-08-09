using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class PersonTests
    {
      
        [Test]
		[TestCase(111,"First")]
        public void ConstructorInitializationWorks(long personId,string personName)
        {
            // Arrange
            var person = new Person(personId, personName);

            // Assert
            Assert.AreNotEqual(null, person,$"Constructor of {typeof(Person)} don't work");
            Assert.AreEqual(personId, person.Id);
            Assert.AreEqual(personName, person.UserName);
        }

        [Test]
        [TestCase(111, "First")]
        public void PersonEquals_TwoEqualPeople(long personId, string personName)
        {
            //  Arrange
            var personOne = new Person(personId, personName);
			var personTwo= new Person(personId, personName);

			//Assert
			Assert.IsTrue(personOne.Equals(personTwo));
        }

        [Test]
        [TestCase(111, "First")]
        public void PersonEquals_NullPerson(long personId, string personName)
        {
            //  Arrange
            var personOne = new Person(personId, personName);
           

            //Assert
            Assert.IsFalse(personOne.Equals(null));
        }

        [Test]
        [TestCase(111, "First",222,"Second")]
        public void PersonEquals_TwoNonEqualPeople(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            //  Arrange
            var personOne = new Person(firstId, firstUsername);
            var personTwo = new Person(secondId, secondUsername);

            //Assert
            Assert.IsFalse(personOne.Equals(personTwo));
        }

        [Test]
        [TestCase(111, "First")]
        public void PersonGetHashCode_TwoEqualPeople(long personId, string personName)
        {
            //  Arrange
            var personOne = new Person(personId, personName);
            var personTwo = new Person(personId, personName);

            //Assert
            Assert.IsTrue(personOne.GetHashCode()==personTwo.GetHashCode());
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void PersonGetHashCode_TwoNonEqualPeople(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            //  Arrange
            var personOne = new Person(firstId, firstUsername);
            var personTwo = new Person(secondId, secondUsername);

            //Assert
            Assert.IsFalse(personOne.GetHashCode() == personTwo.GetHashCode());
        }
    }

}

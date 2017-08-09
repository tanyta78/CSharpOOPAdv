using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDBTests
    {
        private ExtendDatabase database;

        [SetUp]
        public void Initialization()
        {
            this.database = new ExtendDatabase();
        }

        [Test]
        public void CheckCapacity()
        {
            // Assert
            Assert.AreEqual(16, database.Capacity, "Capacity is not sixteen!");
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void DatabaseInitializeConstructorWithCollectionOfPeople(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.AreEqual(2, db.Count, $"Constructor doesn't work with {typeof(Person)} as parameter");
        }

        [Test]
        [TestCase(111, "First")]
        public void AddPerson_ValidCredentials(long firstId, string firstUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);

            // Act
            this.database.Add(firstPerson);

            // Assert
            Assert.AreEqual(1, database.Count, $"Add {typeof(Person)} doesn't work");
        }

        [Test]
        public void AddPersonWhenDBIsFull()
        {
          // Act
            for (int i = 0; i < this.database.Capacity; i++)
            {
                this.database.Add(new Person(1+i,$"{i}1"));
            }

            // Assert

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(this.database.Capacity, $"{this.database.Capacity}1")));

        }


        [Test]
        [TestCase(111, "First", 222, "Second", 111, "Third")]
        public void AddPersonWithSameIdThrowException(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);
            var thirdPerson = new Person(thirdId, thirdUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(thirdPerson), $"Additing person with same id doesn't throw an exception message");
        }

        [Test]
        [TestCase(111, "First", 222, "Second", 333, "First")]
        public void AddPersonWithSameUserNameThrowException(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);
            var thirdPerson = new Person(thirdId, thirdUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(thirdPerson), $"Additing person with same username doesn't throw an exception message");
        }

        [Test]
        [TestCase(111, "First", 222, "Second", 111, "First")]
        public void AddPersonWithSameUserNameAndIdThrowException(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);
            var thirdPerson = new Person(thirdId, thirdUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(thirdPerson), $"Additing person with same id and username doesn't throw an exception message");
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void RemovePersonFromDB(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });
            db.Remove();

            // Assert
            Assert.AreEqual(1, db.Count, $"Remove {typeof(Person)} doesn't work");
        }

        [Test]
        public void RemovePersonFromEmptyDB()
        {
            //Act
            ExtendDatabase db = new ExtendDatabase();
           
            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void RemoveLastPersonFromDB(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });
            db.Remove();

            // Assert
            Assert.AreEqual(firstPerson, db.Elements[0], $"Remove {typeof(Person)} doesn't work");
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void FindByIDExistingPersonInDB(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });
            var searchedById = db.FindById(firstId);

            // Assert
            Assert.AreEqual(firstPerson, searchedById, $"Search {typeof(Person)} by Id doesn't work");
        }

        [Test]
        [TestCase(111, "First", 222, "Second", 333)]
        public void FindByIDNonExistingPersonInDB(long firstId, string firstUsername, long secondId, string secondUsername, long nonexistingId)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.FindById(nonexistingId));
        }

        [Test]
        [TestCase(111, "First", 222, "Second", -333)]
        public void FindByIDNegativeInDB(long firstId, string firstUsername, long secondId, string secondUsername, long negativeId)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(negativeId));
        }

        [Test]
        [TestCase(111, "First", 222, "Second", 333, "Third")]
        public void FindByUserName(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);
            var thirdPerson = new Person(thirdId, thirdUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson ,thirdPerson});
            
            // Assert
            Assert.AreEqual(thirdPerson,db.FindByUsername(thirdUsername),"Find by userName do not work !");
        }


        [Test]
        [TestCase(111, "First", 222, "Second", 333, "Third")]
        public void FindByUserName_PersonNotInDB_ThrowException(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);
            var thirdPerson = new Person(thirdId, thirdUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(thirdUsername), $"Searched person doesn't exist in database");
        }

        [Test]
        [TestCase(111, "First", 222, "Second")]
        public void FindByUserName_NullIDInDB_ThrowException(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null), $"Searched null in database");
        }

        [Test]
        [TestCase(111, "First", 222, "Second", "first")]
        [TestCase(111, "First", 222, "Second", "firSt")]
        [TestCase(111, "First", 222, "Second", "FiRst")]
        public void FindByUserName_Casesensitive_ThrowException(long firstId, string firstUsername, long secondId, string secondUsername, string searchedUserName)
        {
            // Arrange
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            // Act
            ExtendDatabase db = new ExtendDatabase(new List<Person>() { firstPerson, secondPerson });

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(searchedUserName), $"Find by UserName isn't case sensitive!");
        }
    }
}
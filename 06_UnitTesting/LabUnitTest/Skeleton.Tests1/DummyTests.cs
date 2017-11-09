using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int axeAttack = 19;
        private const int axeDurability = 1;
        private const int dummyHealth = 20;
        private const int dummyExperiance = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            // Arrange
            this.axe = new Axe(axeAttack, axeDurability);
            this.dummy = new Dummy(dummyHealth, dummyExperiance);
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                //do something
                //  File.WriteAllText("",);
            }
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.IsTrue(dummy.Health == 15);
        }

        [Test]
        public void DeadDummyThrowExcepIfAttack()
        {
            //Act
            dummy.TakeAttack(20);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Act
            dummy.TakeAttack(21);
            var experiance = dummy.GiveExperience();

            //Assert
            Assert.AreEqual(dummyExperiance, experiance);
        }

        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            //Act
            dummy.TakeAttack(11);
            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
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

        [Test]
        public void AxeLosesDurabilyAfterAttack()
        {
            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(0, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AttackWitBrokenAxe()
        {
            //Act
            axe.Attack(dummy);

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}
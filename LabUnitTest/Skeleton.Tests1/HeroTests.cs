using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGetsExperianceAfterTargetIsDead()
        {
            //Arange
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(h => h.Health).Returns(0);
            fakeTarget.Setup(h => h.GiveExperience()).Returns(20);
            fakeTarget.Setup(h => h.IsDead()).Returns(true);
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero systemUnderTest = new Hero("Pesho", fakeWeapon.Object);
            //Act

            systemUnderTest.Attack(fakeTarget.Object);

            //Assert
            Assert.AreEqual(20, systemUnderTest.Experience, "Hero doesn't get Experiance");
        }

        [Test]
        public void HeroDontGetsExperianceWhenTargetIsStillAllive()
        {
            //Arange
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(h => h.Health).Returns(0);
            fakeTarget.Setup(h => h.GiveExperience()).Returns(20);
            fakeTarget.Setup(h => h.IsDead()).Returns(false);
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero systemUnderTest = new Hero("Pesho", fakeWeapon.Object);
            //Act

            systemUnderTest.Attack(fakeTarget.Object);

            //Assert
            Assert.AreEqual(0, systemUnderTest.Experience, "Hero get Experiance");
        }
    }
}
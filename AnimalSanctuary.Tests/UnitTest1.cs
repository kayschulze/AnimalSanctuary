using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimalSanctuary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTesting()
        {
            //Arrange
            int one = 1;
            int two = 2;

            //Act
            int sum = one + two;

            //Assert
            Assert.AreEqual(3, sum);
        }
    }
}

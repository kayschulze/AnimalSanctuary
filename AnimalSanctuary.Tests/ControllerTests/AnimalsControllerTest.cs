using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using AnimalSanctuary.Controllers;
using Moq;
using System.Linq;

namespace AnimalSanctuary.Tests.ControllerTests
{
    [TestClass]
    public class AnimalsControllerTest
    {
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();

        private void DbSetup()
        {
            mock.Setup(mock => mock.Animals).Returns(new Animal[]
            {
                new Animal { AnimalId = 1, Name = "Ted" },
                new Animal { AnimalId = 2, Name = "Ed" },
                new Animal { AnimalId = 3, Name = "Fred" }
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_Test()  //Confirms route returns view
        {
            //Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}

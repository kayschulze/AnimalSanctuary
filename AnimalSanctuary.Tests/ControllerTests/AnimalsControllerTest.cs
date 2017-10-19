using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        [TestMethod]
        public void Mock_IndexListofAnimals_Test()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new AnimalsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            // Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "Ted";
            testAnimal.AnimalId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Animal>;

            // Assert
            CollectionAssert.Contains(collection, testAnimal);
        }
    }
}


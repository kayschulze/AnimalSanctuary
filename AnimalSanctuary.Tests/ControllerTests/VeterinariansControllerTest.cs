using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using AnimalSanctuary.Controllers;
using Moq;

namespace AnimalSanctuary.Tests.ControllerTests
{
    [TestClass]
    public class VeterinariansControllerTest
    {
        Mock<IVeterinarianRepository> mock = new Mock<IVeterinarianRepository>();

        private void DbSetup()
        {
            mock.Setup(mock => mock.Veterinarians).Returns(new Veterinarian[]
            {
                new Veterinarian { VeterinarianId = 1, Name = "Tessie"},
                new Veterinarian { VeterinarianId = 2, Name = "Bessie"},
                new Veterinarian { VeterinarianId = 3, Name = "Messie"}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_Test()
        {
            //Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexListofVeterinarians_Test()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new VeterinariansController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Veterinarian>)); 

        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            //Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);
            Veterinarian testVeterinarian = new Veterinarian();
            testVeterinarian.Name = "Tessie";
            testVeterinarian.VeterinarianId = 1;

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Veterinarian>;

            //Assert
            CollectionAssert.Contains(collection, testVeterinarian);
        }
    }
}

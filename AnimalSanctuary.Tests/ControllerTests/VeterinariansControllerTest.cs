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
    }
}

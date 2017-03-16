using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndivisibleVCF;
using IndivisibleVCF.Controllers;
using IndivisibleVCF.Models;
using Xunit.Sdk;

namespace IndivisibleVCF.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void GenerateVcfButton()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.GenerateVcfButton() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GenerateVcfButtonResultTest()
        {
            Assert.Fail();
        }
    }
}

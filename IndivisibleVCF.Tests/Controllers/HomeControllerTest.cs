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
using Newtonsoft.Json;
using vCardLib;
using vCardLib.Serializers;
using vCardLib.Collections;
using vCardLib.Helpers;

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

        [TestMethod]
        public void DownloadVcfFileResultTestThatFileIsNotNull()
        {
            HomeController controller = new HomeController();

            RepresentativeSearchResult searchResult = new RepresentativeSearchResult()
            {
                Results = new ReprensentativeContactInfo[3]
                {
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Bob's",
                        LastName = "Your Uncle",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    },
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Annie's",
                        LastName = "Your Aunt",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    },
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Satan's",
                        LastName = "Your Father",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    }
                }
            };

            var file = controller.DownloadVcfFileResult(2);

            Assert.IsNotNull(file);
        }

        [TestMethod]
        public void DownloadVcfFileResultTestThatFileContentTypeIsVcf()
        {
            HomeController controller = new HomeController();

            RepresentativeSearchResult searchResult = new RepresentativeSearchResult()
            {
                Results = new ReprensentativeContactInfo[3]
                {
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Bob's",
                        LastName = "Your Uncle",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    },
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Annie's",
                        LastName = "Your Aunt",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    },
                    new ReprensentativeContactInfo()
                    {
                        FirstName = "Satan's",
                        LastName = "Your Father",
                        Phone = "666-666-6666",
                        OcEmail = "bobsyouruncle@test.com"
                    }
                }
            };

            var file = controller.DownloadVcfFileResult(searchResult, 2);

            Assert.IsTrue(file.ContentType == "vcf");
        }        
    }
}

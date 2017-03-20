using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using IndivisibleVCF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using vCardLib;
using vCardLib.Serializers;
using vCardLib.Collections;
using vCardLib.Helpers;

namespace IndivisibleVCF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //The Authorize Attribute is not enough security
        //I need to protect from signed in users attempting to access other user data other than their own
        [Authorize]
        public ViewResult GenerateVcfButton()
        {
            return View();
        }

        //
        //This was sort of a useless method that I wrote and it just ended up confusing me more than helping
        //

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ViewResult GenerateVcfButtonPost()
        //{
        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        //    var currentUser = manager.FindById(User.Identity.GetUserId());
        //    var userZip = currentUser.ZipCode;

        //    var model = new GenerateVcfButtonViewModel() { ZipCode = userZip };

        //    return View();
        //}

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        //This method should write the files and store them in Memory (TempData?) with an id that corresponds to the index in the array
        //so that when then the download method is called, only an int id is passed as a parameter instead of a large complex object
        public ViewResult GenerateVcfButtonResult()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            GenerateVcfButtonResultViewModel generate = new GenerateVcfButtonResultViewModel();

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var userZip = currentUser.ZipCode;

            generate.ZipCode = userZip;

            var webClient = new WebClient();
            byte[] result = webClient.DownloadData($"https://congress.api.sunlightfoundation.com/legislators/locate?zip={userZip}");

            var values = "";
            using (var stream = new MemoryStream(result))
            using (var reader = new StreamReader(stream))
            {
               values = reader.ReadToEnd();
            }

            RepresentativeSearchResult resultObject = JsonConvert.DeserializeObject<RepresentativeSearchResult>(values);

            generate.RepresentativeSearchResult = resultObject;

            return View(generate);
        }

        //The VCF files should already be written and cached in memory
        //The DownloadVcfFileResult should only recieve an (int)id 
        [Authorize]
        public FileResult DownloadVcfFileResult(ReprensentativeContactInfo reprensentativeContactInfo)
        {
            
            byte[] bytes = new byte[1];
            return File(bytes, "vcf");

            //TODO: Serialize rep contect info into vCard and return FileResult
        }
    }
}
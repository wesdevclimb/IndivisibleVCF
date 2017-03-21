using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using vCardLib.Models;
using Version = vCardLib.Helpers.Version;

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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
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
        
        [Authorize]
        public FileResult DownloadVcfFileResult(ReprensentativeContactInfo reprensentativeContactInfo)
        {
            string vCard = reprensentativeContactInfo.BuildVCard();
            byte[] bytes = Encoding.UTF8.GetBytes(vCard);
                
            return File(bytes, "text/vcard");
            
            //TODO: Implement personalized file info so that the name of the file corresponds to the individual representative
        }
    }
}
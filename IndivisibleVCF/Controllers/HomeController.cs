using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using IndivisibleVCF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndivisibleVCF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "There's so much stuff out the box in this is app that I'm kinda lost.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        //The Authorize Attribute is not enough security
        //I need to protect from signed in users attempting to access other user data other than their own
        [Authorize]
        public ViewResult GenerateVcf()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ViewResult GenerateVcf(GenerateVcfViewModel model)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var userZip = currentUser.ZipCode;

            GenerateVcfViewModel generateVcfViewModel = new GenerateVcfViewModel() { ZipCode = userZip };

            return View(generateVcfViewModel);
        }

        [Authorize]
        public ViewResult GeneratedResultVcf()
        {
            return View();
        }
    }
}
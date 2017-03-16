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
        public ViewResult GenerateVcfButtonPost()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var currentUser = manager.FindById(User.Identity.GetUserId());
            var userZip = currentUser.ZipCode;


            return GenerateVcfButtonResult(userZip);
        }

        [Authorize]
        public ViewResult GenerateVcfButtonResult(int userZip)
        {
            return View();
        }
    }
}
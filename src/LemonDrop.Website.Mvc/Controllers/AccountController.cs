using LemonDrop.Website.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LemonDrop.Website.Mvc.Controllers
{
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationInfoVM vm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                return RedirectToAction("Welcome");
            }

            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult Welcome()
        {
            var model = new WelcomeInfoVM
            {
                Email = "denis@sydq.net",
                FirstName = "Denis",
                LastName = "Qiu"
            };
            return View(model);
        }
    }
}
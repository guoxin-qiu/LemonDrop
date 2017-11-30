using LemonDrop.Website.Mvc.Models;
using LemonDrop.Website.Mvc.ViewModels;
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
                //FormsAuthentication.SetAuthCookie(vm.FullName, false);
                SetUserSession(new UserSession { FullName = vm.FullName, Email = vm.Email });

                return RedirectToAction("Welcome");
            }

            return View(vm);
        }

        public ActionResult Welcome()
        {
            var userInfo = GetUserSession();
            var model = new WelcomeInfoVM
            {
                WelcomeMsg = $"Hello {userInfo.FullName}, welcome to join us!",
                AccountMsg = $"Your account is {userInfo.Email}"
            };
            return View(model);
        }
    }
}
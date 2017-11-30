using LemonDrop.Website.Mvc.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace LemonDrop.Website.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly string UserSessionKey = "USER_SESSION";

        public UserSession GetUserSession()
        {
            if (Session[UserSessionKey] is UserSession us)
            {
                return us;
            }

            var userSession = new UserSession();
            HttpContext.Session[UserSessionKey] = userSession;
            return userSession;
        }

        public void SetUserSession(UserSession userSession)
        {
            Session[UserSessionKey] = userSession;
        }

        public void InvokeValidateModel(object model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            foreach (var result in results)
            {
                var name = result.MemberNames.FirstOrDefault() ?? string.Empty;
                ModelState.AddModelError(name, result.ErrorMessage);
            }
        }
    }
}
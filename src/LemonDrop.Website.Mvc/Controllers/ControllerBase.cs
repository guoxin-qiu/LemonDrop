using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace LemonDrop.Website.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
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
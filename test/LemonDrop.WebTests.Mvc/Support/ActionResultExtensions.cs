using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LemonDrop.WebTests.Mvc.Support
{
    public static class ActionResultExtensions
    {
        public static TModel Model<TModel>(this ActionResult result)
        {
            return result.Should().NotBeNull()
                .And.Subject.Should().BeAssignableTo<ViewResult>()
                .Which.ViewData.Model.Should().NotBeNull()
                .And.Subject.Should().BeAssignableTo<TModel>()
                .Subject;
        }

        public static void ShouldBeRdirectToAction(this ActionResult result, string actionName)
        {
            result.Should().NotBeNull()
                .And.Subject.Should().BeAssignableTo<RedirectToRouteResult>()
                .Subject.RouteValues.Should().ContainKey("action")
                .And.Subject.Values.Should().Contain(actionName);
        }

        public static IEnumerable<string> ErrorMessages(this ActionResult result)
        {
            var errMessages = result.Should().NotBeNull()
                .And.Subject.Should().BeAssignableTo<ViewResult>()
                .Which.ViewData.ModelState.Should().NotBeNull()
                .And.Subject.Should().BeAssignableTo<ModelStateDictionary>()
                .Subject;

            return errMessages.SelectMany(t => t.Value.Errors.Select(s => s.ErrorMessage));
        }
    }
}

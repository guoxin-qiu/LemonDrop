using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

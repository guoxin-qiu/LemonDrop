using Moq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.Support
{
    [Binding]
    public static class HttpContextStub
    {
        private static StubSession SessionStub;

        [BeforeScenario]
        public static void CleanReferenceBooks()
        {
            SessionStub = null;
        }

        public static HttpContextBase Get()
        {
            var httpContextStub = new Mock<HttpContextBase>();
            if (SessionStub == null)
            {
                SessionStub = new StubSession();
            }

            httpContextStub.SetupGet(m => m.Session).Returns(SessionStub);
            return httpContextStub.Object;
        }

        public static void SetupController(Controller controller)
        {
            controller.ControllerContext = new ControllerContext { HttpContext = Get() };
        }

        private class StubSession : HttpSessionStateBase
        {
            private readonly Dictionary<string, object> _state = new Dictionary<string, object>();

            public override object this[string name]
            {
                get => !_state.ContainsKey(name) ? null : _state[name];
                set => _state[name] = value;
            }
        }
    }
}

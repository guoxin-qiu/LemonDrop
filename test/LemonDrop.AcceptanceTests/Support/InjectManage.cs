using BoDi;
using System;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Support
{
    [Binding, Scope(Tag = "BookStore")]
    public class InjectManage
    {
        private readonly IObjectContainer _objectContainer;

        public InjectManage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeClock()
        {
            //_objectContainer.RegisterTypeAs<SystemClock, IClock>();
        }
    }
}

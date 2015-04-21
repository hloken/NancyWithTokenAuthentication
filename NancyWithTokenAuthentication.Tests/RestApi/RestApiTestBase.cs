using Nancy.Testing;
using NancyWithTokenAuthentication.RestApi.Bootstrap;
using NancyWithTokenAuthentication.Tests.Bdd;
using NUnit.Framework;

namespace NancyWithTokenAuthentication.Tests.RestApi
{
    public abstract class RestApiBddTestBase : BddTestBase
    {
        private readonly Browser _browser;

        protected RestApiBddTestBase()
        {
            _browser = new Browser(new Bootstrapper());
        }

        public Browser Browser
        {
            get { return _browser; }
        }

        [SetUp]
        public override void SetUp()
        {
            Given();
            When();
        }
    }
}

using NUnit.Framework;

namespace NancyWithTokenAuthentication.Tests.Bdd
{
    public abstract class BddTestBase
    {
        [SetUp]
        public virtual void SetUp()
        {
            Given();
            When();
        }

        protected abstract void Given();
        protected abstract void When();
    }
}
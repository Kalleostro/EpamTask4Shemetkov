using NUnit.Framework;
using RequestHelperLibrary;

namespace UTGauss
{
    public class GaussTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            HttpServerHelper requestHelper = new HttpServerHelper();
            requestHelper.Test();
            Assert.Pass();
        }
    }
}
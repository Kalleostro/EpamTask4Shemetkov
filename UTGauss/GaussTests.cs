using System.Threading.Tasks;
using NUnit.Framework;
using HttpServerService;

namespace UTGauss
{
    public class GaussTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestServer()
        {
            HttpClient requestClient = new HttpClient();
            HttpServer requestServer = new HttpServer();

            Task.Run(() => { requestServer.InitServer(); });
            
            int expectedResponse = 2;

            Assert.AreEqual(expectedResponse,requestClient.RequestStringForTest());
        }
    }
}
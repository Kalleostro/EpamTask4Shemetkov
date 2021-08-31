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
            
            double[,] expectedResponse = { { 1, -1, -5 },
                { 2, 1, -6} };


            double[,] matrix = { { 1, -1, -5 },
                { 2, 1, -7} };
            
            Assert.AreEqual(expectedResponse,requestClient.RequestMatrixSolution(matrix));
        }
    }
}
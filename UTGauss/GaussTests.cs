using System.Threading.Tasks;
using GausHelperLibrary;
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
            
             Task.Run(() => { requestServer.InitGaussServer(); });

             double[,] matrix = { { 1, -1, -5 },
                 { 2, 1, -7} };
            
             double[] vector = {-4,1};
            
            Assert.AreEqual(vector,requestClient.RequestMatrixSolution(matrix));
        }
    }
}
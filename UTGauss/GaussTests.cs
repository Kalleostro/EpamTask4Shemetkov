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

             double[,] matrix = { { 2,-1,0,0 },
                 { -1,1,4,13},
                 {1,2,3,14}
             };
            
             double[] vector = {1,2,3};
            
            Assert.AreEqual(vector,requestClient.RequestMatrixSolution(matrix));
        }
    }
}
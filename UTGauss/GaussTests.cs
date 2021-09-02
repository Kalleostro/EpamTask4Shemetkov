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

        [Test]
        public void TestMatrix4X4()
        {
            HttpClient requestClient = new HttpClient();
            HttpServer requestServer = new HttpServer();

            Task.Run(() => { requestServer.InitGaussServer(); });

            double[,] matrix =
            {
                { 2, 5, 4, 1, 20 },
                { 1, 3, 2, 1, 11 },
                { 2, 10, 9, 7, 40 },
                { 3, 8, 9, 2, 37 }
            };

            double[] vector = { 1, 2, 2, 0 };

            Assert.AreEqual(vector, requestClient.RequestMatrixSolution(matrix));
        }
        [Test]
        public void TestMatrix5X5()
        {
            HttpClient requestClient = new HttpClient();
            HttpServer requestServer = new HttpServer();

            Task.Run(() => { requestServer.InitGaussServer(); });

            double[,] matrix =
            {
                { 2, 5, 4, 1, 20 },
                { 1, 3, 2, 1, 11 },
                { 2, 10, 9, 7, 40 },
                { 3, 8, 9, 2, 37 }
            };

            double[] vector = { 1, 2, 2, 0 };

            Assert.AreEqual(vector, requestClient.RequestMatrixSolution(matrix));
        }
    }
}
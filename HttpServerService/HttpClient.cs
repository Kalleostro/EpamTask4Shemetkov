using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HttpServerService
{
    public class HttpClient
    {
        private HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/connection/");
        private HttpWebResponse Response { get; set; }
        private Stream RequestStream { get; set; }
        private Stream ResponseStream { get; set; }
        ByteMatrixHelper _byteMatrixHelper = new();

        public HttpClient()
        {
            request.Method = "POST";
            
        }

        public string RequestStringForTest()
        {
            var str = "privet";
            byte[] data = Encoding.UTF8.GetBytes(str);
            RequestStream = request.GetRequestStream();
            RequestStream.Write(data, 0, data.Length);
            RequestStream.Close();
            
            Response = (HttpWebResponse)request.GetResponse();
            ResponseStream = Response.GetResponseStream();
            StreamReader reader = new StreamReader(ResponseStream);
            var reply = reader.ReadToEnd();
            Response.Close();
            return reply;
        }

        public double[] RequestMatrixSolution(double[,] extendedMatrix)
        {
            var resultMatrix = new double[extendedMatrix.Length];
            //byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] data = _byteMatrixHelper.MatrixToByteArray(extendedMatrix);
            RequestStream = request.GetRequestStream();
            RequestStream.Write(data, 0, data.Length);
            RequestStream.Close();
            
            Response = (HttpWebResponse)request.GetResponse();
            MemoryStream ms = new MemoryStream();
            ResponseStream = Response.GetResponseStream();
            ResponseStream.CopyTo(ms);
            StreamReader reader = new StreamReader(ResponseStream);
            resultMatrix = _byteMatrixHelper.ByteArrayToMatrix(ms.ToArray());
            //var reply = reader.ReadToEnd();
            Response.Close();
            return resultMatrix;
        }
    }
}
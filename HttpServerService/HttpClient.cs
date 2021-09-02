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
        /// <summary>
        /// request solution from server
        /// </summary>
        /// <param name="extendedMatrix">matrix</param>
        /// <returns>vector X</returns>
        public double[] RequestMatrixSolution(double[,] extendedMatrix)
        {
            byte[] data = _byteMatrixHelper.MatrixToByteArray(extendedMatrix);
            RequestStream = request.GetRequestStream();
            RequestStream.Write(data, 0, data.Length);
            RequestStream.Close();
            
            Response = (HttpWebResponse)request.GetResponse();
            
            MemoryStream ms = new MemoryStream();
            ResponseStream = Response.GetResponseStream();
            ResponseStream.CopyTo(ms);
            
            var resultVector = _byteMatrixHelper.ByteArrayToVector(ms.ToArray());
            
            Response.Close();
            return resultVector;
        }
    }
}
using System;
using System.IO;
using System.Net;
using GausHelperLibrary;

namespace HttpServerService
{
    public class HttpServer
    {
        /// <summary>
        /// initialize server
        /// </summary>
        public void InitGaussServer()
        {
            HttpListener listener = new HttpListener();
            ByteMatrixHelper helper = new ByteMatrixHelper();
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            Stream requestStream = request.InputStream;
            HttpListenerResponse response = context.Response;
            

            MemoryStream ms = new MemoryStream();
            requestStream.CopyTo(ms);

            double[,] res = helper.ByteArrayToMatrix(ms.ToArray());

            DoubleNullGaussSystem dngs = new DoubleNullGaussSystem();
            
            double[] res1 = dngs.Solve(res);

            byte[] buffer = helper.VectorToByteArray(res1);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
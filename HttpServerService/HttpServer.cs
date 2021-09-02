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
            

            var ms = new MemoryStream();
            requestStream.CopyTo(ms);

            double[,] responseMatrix = helper.ByteArrayToMatrix(ms.ToArray());

            var dngs = new DoubleNullGaussSystem();

            double[] result = dngs.Solve(responseMatrix);

            byte[] buffer = helper.VectorToByteArray(result);

            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
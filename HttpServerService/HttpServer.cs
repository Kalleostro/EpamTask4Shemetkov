using System;
using System.IO;
using System.Net;
using GausHelperLibrary;

namespace HttpServerService
{
    public class HttpServer
    {
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
            
            double[,] a1 = { { 1, -1},
                { 2, 1} };
            double[] a2 = { -5, -7 };
            
            dngs.FillExtendedMatrix(a1,a2);
            
            double[] res1 = dngs.Solve(dngs.ExtendedMatrix);

            byte[] buffer = helper.VectorToByteArray(res1);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
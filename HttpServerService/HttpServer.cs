using System;
using System.IO;
using System.Net;

namespace HttpServerService
{
    public class HttpServer
    {
        public void InitServer()
        {
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
                // StreamReader reader = new StreamReader(requestStream);
                // string responseMatr = reader.ReadToEnd();
                double[,] res = helper.ByteArrayToMatrix(ms.ToArray());
                res[1, 2]++;
                byte[] buffer = helper.MatrixToByteArray(res);
                //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr.ToUpper());
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
        
    }
}
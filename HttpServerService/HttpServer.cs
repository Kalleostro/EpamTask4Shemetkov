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
                listener.Prefixes.Add("http://localhost:8888/connection/");
                listener.Start();
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                Stream requestStream = request.InputStream;
                HttpListenerResponse response = context.Response;

                StreamReader reader = new StreamReader(requestStream);
                string responseStr = reader.ReadToEnd();

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr.ToUpper());
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }

        private string CaseToUpperTest(string text)
        {
            
        }
    }
}
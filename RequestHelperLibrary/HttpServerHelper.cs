using System;
using System.IO;
using System.Net;
using System.Text;

namespace RequestHelperLibrary
{
    public class HttpServerHelper
    {
        public void SendToServer()
        { 
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://localhost:8888/server/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                Stream requestStream = request.InputStream;
                HttpListenerResponse response = context.Response;

                StreamReader reader = new StreamReader(requestStream);
                string responseStr = reader.ReadToEnd();
                responseStr.ToUpper();

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            listener.Stop();
        }
    }
}
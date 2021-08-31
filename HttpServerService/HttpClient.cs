using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpServerService
{
    public class HttpClient
    {
        public string GetRequest()
        {
            var str = "privet";
            byte[] data = Encoding.UTF8.GetBytes(str);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/connection/");
            request.Method = "POST";
            request.ContentType = "text/*";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var reply = reader.ReadToEnd();
            Console.WriteLine(reader.ReadToEnd());
            response.Close();
            return reply;
        }
    }
}
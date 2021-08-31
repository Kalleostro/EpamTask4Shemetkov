using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpServerService
{
    public class HttpClient
    {
        private HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/connection/");
        private HttpWebResponse response { get; set; }
        private Stream requestStream { get; set; }
        private Stream responseStream { get; set; }

        public HttpClient()
        {
            request.Method = "POST";
        }

        public string RequestStringForTest()
        {
            var str = "privet";
            byte[] data = Encoding.UTF8.GetBytes(str);
            requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            
            response = (HttpWebResponse)request.GetResponse();
            responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            var reply = reader.ReadToEnd();
            Console.WriteLine(reader.ReadToEnd());
            response.Close();
            return reply;
        }
    }
}
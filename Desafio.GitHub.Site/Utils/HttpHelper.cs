using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Desafio.GitHub.Site.Utils
{
    public static class HttpHelper<T>
    {
        public static T HttpRequest(string url, object parameters = null, string method = CustomHttpVerbs.Post)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            request.UserAgent = "TestApp"; //https://stackoverflow.com/questions/28781345/listing-all-repositories-using-github-c-sharp

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var content1 = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<T>(content1);
            }
        }


    }

    public static class CustomHttpVerbs
    {
        public const string Get = "GET";
        public const string Head = "HEAD";
        public const string Post = "POST";
        public const string Put = "PUT";
        public const string Delete = "DELETE";
        public const string Connect = "CONNECT";
        public const string Options = "OPTIONS";
        public const string Trace = "TRACE";
        public const string Patch = "PATCH";
    }
}
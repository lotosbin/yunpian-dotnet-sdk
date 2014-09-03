using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace yunpian_dotnet_sdk
{
    static class Helper
    {
        public static T HttpPost<T>(string url, Dictionary<string, string> dic) where T : class ,new()
        {
            string[] strings = dic.Select(d => d.Key + "=" + d.Value).ToArray();
            string parameter = String.Join("&", strings);
            return HttpPost<T>(url, parameter);
        }

        public static T HttpPost<T>(string url, string parameter)where T:class ,new()
        {
            WebRequest req = WebRequest.Create(url);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(parameter); //这里编码设置为utf8
            req.ContentLength = bytes.Length;
            using (Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }
             T result;
            using (WebResponse resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    result = JsonConvert.DeserializeObject<T>(sr.ReadToEnd().Trim());
                }
            }
            return result;
        }
    }
}
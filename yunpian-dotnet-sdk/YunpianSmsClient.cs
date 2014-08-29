using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace yunpian_dotnet_sdk
{
    public class YunpianSmsClient:YunpianClient
    {
        public SendResult tplSendSms(long tpl_id, string tpl_value, string mobile)
        {
            GetApiKey();
            var s = tplSendSms(null, tpl_id, tpl_value, mobile);
            if (string.IsNullOrEmpty(s))
            {
                return new SendResult()
                {
                    Success = true,
                };
            }
            return new SendResult()
            {
                Success = false,
                Message = s,
            };
        }

        public static string sendSms(string apikey, string text, string mobile)
        {
            string parameter = "apikey=" + apikey + "&text=" + text + "&mobile=" + mobile;
            WebRequest req = WebRequest.Create(URI_SEND_SMS);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(parameter); //这里编码设置为utf8
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            WebResponse resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string tplSendSms(string apikey, long tpl_id, string tpl_value, string mobile)
        {
            string encodedTplValue = Uri.EscapeDataString(tpl_value);
            string parameter = "apikey=" + apikey + "&tpl_id=" + tpl_id + "&tpl_value=" + encodedTplValue + "&mobile=" + mobile;
            WebRequest req = WebRequest.Create(URI_TPL_SEND_SMS);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(parameter); //这里编码设置为utf8
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            WebResponse resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static void tplSendSms(string appApikey, string notifyTelephone, int tplId, Dictionary<string, string> dictionary)
        {
            var strings = dictionary.Select(d => String.Format("#{0}#={1}", d.Key, d.Value))
                .ToArray();
            var format = String.Join("&", strings);
            var s = tplSendSms(appApikey, tplId, format, notifyTelephone);
        }
    }
}
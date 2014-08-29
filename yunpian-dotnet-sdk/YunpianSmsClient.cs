using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Binbin.HttpHelper;
using log4net;

namespace yunpian_dotnet_sdk
{
    public class YunpianSmsClient : YunpianClient
    {
        private static ILog log = LogManager.GetLogger(typeof(YunpianSmsClient));
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
        /*URL：http://yunpian.com/v1/sms/get_reply.json 
访问方式：GET 或者 POST 
参数： 
参数名	是否必须	描述	示例
apikey	是	用户唯一标识	9b11127a9701975c734b8aee81ee3526
start_time	是	短信回复开始时间	2013-08-11 00:00:00
end_time	是	短信回复结束时间	2013-08-12 00:00:00
page_num	是	页码，从1开始	1
page_size	是	每页个数，最大100个	20
mobile	否	填写时只查该手机号的回复，不填时查所有的回复	15205201314
return_fields	否	返回字段（暂未开放）	
sort_fields	否	排序字段（暂未开放）	默认按提交时间降序

调用成功的返回值示例：
{
    "code": 0,
    "msg": "OK",
    "sms_reply": [{
        "mobile": "15253878027",         //回复短信的手机号
        "text": "很好用,已收到,谢谢",       //短信的内容
        "reply_time": "2013-07-23 16:14:15" //回复短信的时间
    }, {
        "mobile": "15222043793",
        "text": "很快啊，已经收到了！ ^_^",
        "reply_time": "2013-07-22 20:33:22"
    }, ]
}
              */
        public string get_reply(string apikey, DateTime start_time, DateTime end_time, int page_num = 1, int page_size = 20, string mobile = "")
        {
            var url = BASE_URI + "/" + VERSION + "/sms/get_reply.json";
            var paras = new List<APIParameter>()
            {
                new APIParameter("apikey", apikey),
                new APIParameter("start_time", start_time.ToString("yyyy-MM-dd HH:mm:ss")),
                new APIParameter("end_time", end_time.ToString("yyyy-MM-dd HH:mm:ss")),
                new APIParameter("page_num", page_num.ToString()),
                new APIParameter("page_size", page_size.ToString()),
            };
            if (!string.IsNullOrEmpty(mobile))
                paras.Add(new APIParameter("mobile", mobile));
            var get = new SyncHttpRequest().HttpGet(url, paras);
            log.Info("get_reply:" + get);
            return get;
        }
    }
}
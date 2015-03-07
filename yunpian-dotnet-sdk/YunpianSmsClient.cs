using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Binbin.HttpHelper;
using log4net;

namespace yunpian_dotnet_sdk
{
    public class YunpianSmsClient : YunpianClient
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (YunpianSmsClient));

        public static sendresult sendSms(string apikey, string mobile, string text)
        {
            /*
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
            return sr.ReadToEnd().Trim();*/

            /* var request = new SyncHttpRequest();
            var paras = new List<APIParameter>();

            paras.Add(new APIParameter("apikey", apikey));
            if (!string.IsNullOrEmpty(text))
            {
                paras.Add(new APIParameter("text", text));
            }
            if (!string.IsNullOrEmpty(mobile))
            {
                paras.Add(new APIParameter("mobile", mobile));
            }

            var get = request.HttpPost("http://yunpian.com/v1/sms/send.json", paras
                );
            var result = JsonConvert.DeserializeObject<sendresult>(get);//函数 泛型
            return result;
            * */
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey},
                {"mobile", mobile},
                {"text", text}
            };
            return Helper.HttpPost<sendresult>(URI_SEND_SMS, dic);
        }

        public static sendresult tplSendSms(string apikey, long tpl_id, string tpl_value, string mobile)
        {
            var encodedTplValue = Uri.EscapeDataString(tpl_value);
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey},
                {"tpl_id", tpl_id.ToString()},
                {"tpl_value", tpl_value},
                {"mobile", mobile}
            };
            return Helper.HttpPost<sendresult>(URI_TPL_SEND_SMS, dic);
        }

        public static pullstatusresult tplpullstatus(string apikey)
        {
            // string encodedTplValue = Uri.EscapeDataString(tpl_value);
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey}
            };
            return Helper.HttpPost<pullstatusresult>("http://yunpian.com/v1/sms/pull_status.json", dic);
        }

        public static pullreplyresult tplpullreply(string apikey)
        {
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey}
            };
            return Helper.HttpPost<pullreplyresult>("http://yunpian.com/v1/sms/pull_reply.json", dic);
        }

        public static getblackword tplgetblackword(string apikey, string text)
        {
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey},
                {"text", text}
            };
            return Helper.HttpPost<getblackword>("http://yunpian.com/v1/sms/get_black_word.json", dic);
        }

        public static getreplyresult tplgetreply(string apikey, string start_time, string end_time, int page_num, int page_size, string mobile = null)
        {
            var dic = new Dictionary<string, string>
            {
                {"apikey", apikey},
                {"start_time", start_time},
                {"end_time", end_time},
                {"page_num", page_num.ToString()},
                {"page_size", page_size.ToString()}
            };
            if (!string.IsNullOrEmpty(mobile))
                dic.Add("mobile", mobile);
            return Helper.HttpPost<getreplyresult>("http://yunpian.com/v1/sms/get_reply.json", dic);
        }

        /// <summary>
        ///     http://www.yunpian.com/api/sms.html
        /// </summary>
        /// <param name="appApikey"></param>
        /// <param name="notifyTelephone"></param>
        /// <param name="tplId"></param>
        /// <param name="dictionary"></param>
        public static sendresult tplSendSms(string appApikey, string notifyTelephone, int tplId, Dictionary<string, string> dictionary)
        {
            var strings = dictionary.Select(d => string.Format("#{0}#={1}", d.Key, d.Value))
                .ToArray();
            var format = string.Join("&", strings);
            var s = tplSendSms(appApikey, tplId, format, notifyTelephone);
            return s;
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
            var paras = new List<APIParameter>
            {
                new APIParameter("apikey", apikey),
                new APIParameter("start_time", start_time.ToString("yyyy-MM-dd HH:mm:ss")),
                new APIParameter("end_time", end_time.ToString("yyyy-MM-dd HH:mm:ss")),
                new APIParameter("page_num", page_num.ToString()),
                new APIParameter("page_size", page_size.ToString())
            };
            if (!string.IsNullOrEmpty(mobile))
                paras.Add(new APIParameter("mobile", mobile));
            var get = new SyncHttpRequest().HttpGet(url, paras);
            log.Info("get_reply:" + get);
            return get;
        }

        /* public SendResult tplSendSms(long tpl_id, string tpl_value, string mobile)
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
        }*/

        [DataContract]
        public class Result
        {
            [DataMember]
            public int count { get; set; }

            [DataMember]
            public int fee { get; set; }

            [DataMember]
            public int sid { get; set; }
        }

        [DataContract]
        public class sendresult : YunpianResult
        {
            [DataMember]
            public Result result { get; set; }
        }

        //获取状态报告
        [DataContract]
        public class SmsStatu
        {
            [DataMember]
            public int sid { get; set; }

            [DataMember]
            public object uid { get; set; }

            [DataMember]
            public string user_receive_time { get; set; }

            [DataMember]
            public string error_msg { get; set; }

            [DataMember]
            public string mobile { get; set; }

            [DataMember]
            public string report_status { get; set; }
        }

        [DataContract]
        public class pullstatusresult : YunpianResult
        {
            [DataMember]
            public List<SmsStatu> sms_status { get; set; }
        }

        //获取回复短信
        [DataContract]
        public class SmsReply
        {
            [DataMember]
            public string mobile { get; set; }

            [DataMember]
            public string reply_time { get; set; }

            [DataMember]
            public string text { get; set; }

            [DataMember]
            public string extend { get; set; }

            [DataMember]
            public string base_extend { get; set; }
        }

        [DataContract]
        public class pullreplyresult : YunpianResult
        {
            [DataMember]
            public List<SmsReply> sms_reply { get; set; }
        }

        //推送状态报告
        //推送回复短信

        //查屏蔽词
        [DataContract]
        public class Result1
        {
            [DataMember]
            public string black_word { get; set; }
        }

        [DataContract]
        public class getblackword : YunpianResult
        {
            [DataMember]
            public Result1 result { get; set; }
        }

        //查回复的短信
        [DataContract]
        public class SmsReply1
        {
            [DataMember]
            public string mobile { get; set; }

            [DataMember]
            public string text { get; set; }

            [DataMember]
            public string reply_time { get; set; }
        }

        [DataContract]
        public class getreplyresult : YunpianResult
        {
            [DataMember]
            public List<SmsReply1> sms_reply { get; set; }
        }
    }
}
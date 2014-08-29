using System.Configuration;

namespace yunpian_dotnet_sdk
{
    /// <summary>
    /// www.yunpian.com
    /// </summary>
    public class YunpianClient
    {
        /**
        * 服务http地址
        */
        private static string BASE_URI = "http://yunpian.com";
        /**
        * 服务版本号
        */
        private static string VERSION = "v1";
        /**
        * 查账户信息的http地址
        */
        protected static readonly string URI_GET_USER_INFO = BASE_URI + "/" + VERSION + "/user/get.json";
        /**
        * 通用接口发短信的http地址
        */
        protected static readonly string URI_SEND_SMS = BASE_URI + "/" + VERSION + "/sms/send.json";
        /**
        * 模板接口短信接口的http地址
        */
        protected static readonly string URI_TPL_SEND_SMS = BASE_URI + "/" + VERSION + "/sms/tpl_send.json";

        protected static void GetApiKey()
        {
            var apikey = ConfigurationManager.AppSettings["YunpianApiKey"];
            if (string.IsNullOrEmpty(apikey))
            {
                throw new ConfigurationErrorsException("YunpianApiKey");
            }
        }

    }
}
using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yunpian_dotnet_sdk;

namespace yunpian_dotnet_sdk_test
{
    [TestClass]
    public class YunpianSmsClientTest
    {
        [TestMethod]
        public void get_replyr_test()
        {
            var client = new YunpianSmsClient();
            var r = client.get_reply(GetApiKey(), DateTime.Now.AddHours(-12), DateTime.Now, mobile: GetMobile());
            Debug.WriteLine("r:" + r);
        }

        private static string GetMobile()
        {
            return ConfigurationManager.AppSettings["mobile"];
        }

        private static string GetApiKey()
        {
            return ConfigurationManager.AppSettings["apikey"];
        }
    }
}

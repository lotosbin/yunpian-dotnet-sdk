using System;
using System.Collections.Generic;
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
            var r = client.get_reply(Config.GetApiKey(), DateTime.Now.AddHours(-12), DateTime.Now, mobile: Config.GetMobile());
            Debug.WriteLine("r:" + r);
        }

        [TestMethod]
        public void sendSmsTest()
        {
            YunpianSmsClient.sendSms(Config.GetApiKey(), Config.GetMobile(), "sdfsdf");
        }

        [TestMethod]
        public void tplSendSmsTest()
        {
            var dictionary = new Dictionary<string, string> {{"code", "123456"}};
            YunpianSmsClient.tplSendSms(Config.GetApiKey(), Config.GetMobile(), 702675, dictionary);

        }
    }
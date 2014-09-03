using System;
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
    }
}

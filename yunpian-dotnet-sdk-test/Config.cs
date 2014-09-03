using System.Configuration;

namespace yunpian_dotnet_sdk_test
{
    static class Config
    {
        public static string GetMobile()
        {
            return ConfigurationManager.AppSettings["mobile"];
        }

        public static string GetApiKey()
        {
            return ConfigurationManager.AppSettings["apikey"];
        }
    }
}
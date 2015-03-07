using System.Collections.Generic;

namespace yunpian_dotnet_sdk
{
    public static class YunpianErrorHelper
    {
        /// <summary>
        ///     http://www.yunpian.com/api/retcode.html
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ErrorCodeToMessage(this int code)
        {
            var dictionary = new Dictionary<int, string>
            {
                {0, ""},
                {1, "请求参数缺失"},
                {2, "请求参数格式错误"}
            };
            if (dictionary.ContainsKey(code))
            {
                return dictionary[code];
            }
            if (code <= -50)
            {
                //系统内部错误，请联系技术支持，调查问题原因并获得解决方案。
                return "系统内部错误，请联系技术支持，调查问题原因并获得解决方案";
            }
            if (code <= -1)
            {
                //权限验证失败，需要开发者进行相应的处理。
                return "权限验证失败";
            }
            if (code == 0)
            {
                //正确返回。可以从api返回的对应字段中取数据。
                return string.Empty;
            }
            if (code > 0)
            {
                //调用API时发生错误，需要开发者进行相应的处理。
                return "调用API时发生错误";
            }
        }
    }
}

}
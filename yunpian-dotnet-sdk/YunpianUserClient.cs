using System.IO;
using System.Net;

namespace yunpian_dotnet_sdk
{
    public class YunpianUserClient : YunpianClient
    {
        /*查账户信息
URL：http://yunpian.com/v1/user/get.json 
访问方式：GET 或者 POST 
参数： 
参数名	是否必须	描述	示例
apikey	是	用户唯一标识	9b11127a9701975c734b8aee81ee3526

调用成功的返回值示例：
{
    "code": 0,
    "msg": "OK",
    "user": {
        "nick": "zhangshan",
        "gmt_created": "2012-09-11 15:14:00",
        "mobile": "13812341234",
        "email": "zhangshan@company.com",
        "ip_whitelist": null,                 //IP白名单，推荐使用
        "api_version": "v1",                  //api版本号
        "balance": 1000,                         //短信剩余条数
        "alarm_balance": 100,                   //剩余条数低于该值时提醒
        "emergency_contact": "张三",           //紧急联系人
        "emergency_mobile": "13812341234"     //紧急联系人电话
    }
}                   */

        public void Get(string apikey)
        {

        }
        /*修改账户信息
URL：http://yunpian.com/v1/user/set.json 
访问方式：POST 
参数： 
参数名	是否必须	描述	示例
apikey	是	用户唯一标识	9b11127a9701975c734b8aee81ee3526
emergency_contact	否	紧急联系人	zhangshan
emergency_mobile	否	紧急联系人手机号	13012345678
alarm_balance	否	短信余额提醒阈值。
一天只提示一次	100

修改时，可一次修改emergency_contact、emergency_mobile和alarm_balance中的一个或多个 
调用成功的返回值示例：
{
    "code":0,
    "msg":"OK",
    "detail":null
}                   */

        public void Set(string apikey, string emergency_contact = "", string emergency_mobile = "", int alarm_balance = 100)
        {

        }

        public static string GetReturnText(string apikey)
        {
            WebRequest req = WebRequest.Create(URI_GET_USER_INFO + "?apikey=" + apikey);
            using (WebResponse resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }
    }
}
using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using yunpian_dotnet_sdk;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ypsc = new YunpianSmsClient();
            var yptc = new YunpianTplClient();
            var ypuc = new YunpianUserClient();        
            //查询测试
            /*var ss = ypuc.Get2(Config.GetApiKey());
            Console.WriteLine(ss.Code+ss.Msg+ss.user.nick+ss.user.alarm_balance+ss.user.emergency_mobile);
            Console.ReadLine();*/
            //修改测试
            /*var sss= ypuc.Set2(Config.GetApiKey(),null,null,99);
            Console.WriteLine(sss.Code+sss.Msg+sss.detail);
            var ss = ypuc.Get2(Config.GetApiKey());
            Console.WriteLine(ss.Code + ss.Msg + ss.user.emergency_contact + ss.user.alarm_balance + ss.user.emergency_mobile);
            Console.ReadLine();*/
            //取默认模板

            //var ss = yptc.GetDefault2(Config.GetApiKey());
            //Console.WriteLine(ss.Code + ss.Msg + ss.template.Count);
            //foreach (var template in ss.template)
            //{
            //    Console.WriteLine("------\r\n" + template.tpl_id + "," + template.tpl_content);
            //}
            //Console.ReadLine();
            //带id
            //var ss = yptc.GetDefault2(Config.GetApiKey(),2);
            //Console.WriteLine(ss.Code + ss.Msg +ss.template.tpl_id+ss.template.tpl_content);
            //Console.ReadLine();

            //添加模板
            //var ss = yptc.Add2(Config.GetApiKey(), "您的验证码是【逛吃网】", 2);
            //Console.WriteLine(ss.Code + ss.Msg + ss.template.tpl_id + ss.template.tpl_content+ss.template.check_status);
            //Console.ReadLine();

            //取模板
            //var ss = yptc.Get2(Config.GetApiKey());
            //Console.WriteLine(ss.Code + ss.Msg + ss.template.Count);
            //foreach (var template in ss.template)
            //{
            //    Console.WriteLine("------\r\n" + template.tpl_id + "," + template.tpl_content);
            //}
            //Console.ReadLine();
            //带id
            //var ss = yptc.Get2(Config.GetApiKey(), 2);
            //Console.WriteLine(ss.Code + ss.Msg + ss.template.tpl_id + ss.template.tpl_content);
            //Console.ReadLine();
            //修改模板
            //var ss = yptc.Update2(Config.GetApiKey(),xxxx,"修改测试已添加模板#code#【逛吃网】");
            //Console.WriteLine(ss.Code + ss.Msg +ss.template.tpl_id+ss.template.tpl_content+ss.template.check_status);
            //Console.ReadLine();
            //删除模板
            //var ss = yptc.Delete2(Config.GetApiKey(),xxxx);
            //Console.WriteLine(ss.Code + ss.Msg +ss.detail);
            //Console.ReadLine();

            //发短信
            var ss = YunpianSmsClient.sendSms(Config.GetApiKey(), "18248939256", "您的验证码是#1234#。如非本人操作，请忽略本短信【#逛吃网#】");
            Console.WriteLine(ss.Code + ss.Msg + ss.result.count + ss.result.fee + ss.result.sid);
            Console.ReadLine();
            //模板发送
            //var ss = YunpianSmsClient.tplSendSms(Config.GetApiKey(), "452817",("#code#=1234&#company#=云片网")).sendSms(Config.GetApiKey(), "18248939256");
            //Console.WriteLine(ss.Code + ss.Msg + ss.result.count + ss.result.fee + ss.result.sid);
            //Console.ReadLine();
            //获取状态报告
            //var ss = YunpianSmsClient.tplpullstatus(Config.GetApiKey());
            //Console.WriteLine(ss.Code + ss.Msg + ss.sms_status.Count);
            //foreach (var sms_status in ss.sms_status)
            //{
            //    Console.WriteLine("------\r\n" + sms_status.sid+sms_status.uid+sms_status.mobile+sms_status.report_status+sms_status.user_receive_time);
            //}
            //Console.ReadLine();
            //获取回复短信
            //var ss = YunpianSmsClient.tplpullreply(Config.GetApiKey());
            //Console.WriteLine(ss.Code + ss.Msg + ss.sms_reply.Count);
            //foreach (var sms_reply in ss.sms_reply)
            //{
            //    Console.WriteLine("------\r\n" + sms_reply.mobile + sms_reply.reply_time + sms_reply.text);
            //}
            //Console.ReadLine();
            //推送状态报告
            //推送回复短信
            //查屏蔽词
            //var ss = YunpianSmsClient.tplgetblackword(Config.GetApiKey(), "这是一条测试短信");
            //Console.WriteLine(ss.Code + ss.Msg + ss.result.black_word);
            //Console.ReadLine();
            //查回复的短信
            //var ss = YunpianSmsClient.tplgetreply(Config.GetApiKey(),"2014-09-2 18:00:00","2014-09-3 18:00:00",1,20,null);
            //foreach (var sms_reply in ss.sms_reply )
            //{
            //    Console.WriteLine("------\r\n" + sms_reply.mobile + sms_reply.reply_time + sms_reply.text);
            //}
            ////Console.ReadLine();

        }
    }
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

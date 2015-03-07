using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using Binbin.HttpHelper;
using Newtonsoft.Json;

namespace yunpian_dotnet_sdk
{
    public class YunpianTplClient : YunpianClient
    {
        public GetdeleteResult Delete2(string apikey, int tpl_id)
        {
            var s = Delete(apikey, tpl_id);
            var result = JsonConvert.DeserializeObject<GetdeleteResult>(s); //函数 泛型
            return result;
        }

        public string Delete(string apikey, int tpl_id)
        {
            var request = new SyncHttpRequest();
            var paras = new List<APIParameter>();
            paras.Add(new APIParameter("apikey", apikey));

            paras.Add(new APIParameter("tpl_id", tpl_id.ToString()));

            var get = request.HttpPost("http://yunpian.com/v1/tpl/del.json", paras
                );
            return get;
        }

        [DataContract]
        public class Template
        {
            [DataMember]
            public int tpl_id { get; set; }

            [DataMember]
            public string tpl_content { get; set; }

            [DataMember]
            public string check_status { get; set; }

            [DataMember]
            public string reason { get; set; }
        }

        //删除模板

        [DataContract]
        public class GetdeleteResult : YunpianResult
        {
            [DataMember]
            public string detail { get; set; }
        }

        #region New region

        [DataContract]
        public class GetResult : YunpianResult
        {
            public GetResult()
            {
                template = new Template();
            }

            [DataMember]
            public Template template { get; set; }
        }

        //取默认模板
        public GetResult GetDefault2(string apikey, int tpl_id)
        {
            var s = GetDefault(apikey, tpl_id);
            var result = JsonConvert.DeserializeObject<GetResult>(s); //函数 泛型
            return result;
        }

        public string GetDefault(string apikey, int tpl_id)
        {
            var uriString = "http://yunpian.com/v1/tpl/get_default.json" + "?apikey=" + apikey;

            {
                uriString += "&tpl_id=" + tpl_id;
            }
            var req = WebRequest.Create(uriString);
            using (var resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }

        #endregion

        #region New region

        [DataContract]
        public class GetResult2 : YunpianResult
        {
            public GetResult2()
            {
                template = new List<Template>();
            }

            [DataMember]
            public List<Template> template { get; set; }
        }

        public string GetDefault(string apikey)
        {
            var uriString = "http://yunpian.com/v1/tpl/get_default.json" + "?apikey=" + apikey;


            var req = WebRequest.Create(uriString);
            using (var resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }

        public GetResult2 GetDefault2(string apikey)
        {
            var s = GetDefault(apikey);
            var result = JsonConvert.DeserializeObject<GetResult2>(s); //函数 泛型
            return result;
        }

        #endregion

        //添加模板

        #region new region

        [DataContract]
        public class AddResult : YunpianResult
        {
            public AddResult()
            {
                template = new Template();
            }

            [DataMember]
            public Template template { get; set; }
        }


        public AddResult Add2(string apikey, string tpl_content, int notify_type)
        {
            var s = Add(apikey, tpl_content, notify_type);
            var result = JsonConvert.DeserializeObject<AddResult>(s); //函数 泛型
            return result;
        }

        public string Add(string apikey, string tpl_content, int notify_type)
        {
            var request = new SyncHttpRequest();
            var paras = new List<APIParameter>();
            paras.Add(new APIParameter("apikey", apikey));

            if (!string.IsNullOrEmpty(tpl_content))
            {
                paras.Add(new APIParameter("tpl_content", tpl_content));
            }

            paras.Add(new APIParameter("notify_type", notify_type.ToString()));

            var get = request.HttpPost("http://yunpian.com/v1/tpl/add.json", paras
                );
            return get;
        }

        #endregion

        //取模板

        #region new region

        public GetResult Get2(string apikey, int tpl_id)
        {
            var s = Get(apikey, tpl_id);
            var result = JsonConvert.DeserializeObject<GetResult>(s); //函数 泛型
            return result;
        }

        public string Get(string apikey, int tpl_id)
        {
            var uriString = "http://yunpian.com/v1/tpl/get.json" + "?apikey=" + apikey;

            {
                uriString += "&tpl_id=" + tpl_id;
            }
            var req = WebRequest.Create(uriString);
            using (var resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }

        public string Get(string apikey)
        {
            var uriString = "http://yunpian.com/v1/tpl/get.json" + "?apikey=" + apikey;


            var req = WebRequest.Create(uriString);
            using (var resp = req.GetResponse())
            {
                using (var sr = new StreamReader(resp.GetResponseStream()))
                {
                    return sr.ReadToEnd().Trim();
                }
            }
        }

        public GetResult2 Get2(string apikey)
        {
            var s = Get(apikey);
            var result = JsonConvert.DeserializeObject<GetResult2>(s); //函数 泛型
            return result;
        }

        #endregion

        //修改模板

        #region new region

        public GetResult Update2(string apikey, int tpl_id, string tpl_content)
        {
            var s = Update(apikey, tpl_id, tpl_content);
            var result = JsonConvert.DeserializeObject<GetResult>(s); //函数 泛型
            return result;
        }

        public string Update(string apikey, int tpl_id, string tpl_content)
        {
            var request = new SyncHttpRequest();
            var paras = new List<APIParameter>();
            paras.Add(new APIParameter("apikey", apikey));

            paras.Add(new APIParameter("tpl_id", tpl_id.ToString()));

            if (!string.IsNullOrEmpty(tpl_content))
            {
                paras.Add(new APIParameter("tpl_content", tpl_content));
            }

            var get = request.HttpPost("http://yunpian.com/v1/tpl/update.json", paras
                );
            return get;
        }

        #endregion
    }
}
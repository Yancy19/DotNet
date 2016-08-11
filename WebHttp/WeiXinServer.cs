using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace WebHttp_CL
{
    public class WeiXinServer
    {
        public string Code { get; set; }
        public string WeixinAppId { get; set; }
        public string WeixinAppSecret { get; set; }
        public string RedirectUrl { get; set; }
        /// <summary>
        /// 微信接口调用
        /// </summary>
        public void WeiXin()
        {
            if (!string.IsNullOrEmpty(this.Code)) // 如果用户同意授权
            {
                string result = GetHttp(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", this.WeixinAppId, this.WeixinAppSecret, this.Code));
                if (result.Contains("access_token"))
                {
                    var resultObj = JsonConvert.DeserializeObject(result) as JObject;
                    string userStr = GetHttp("https://api.weixin.qq.com/sns/userinfo?access_token=" + resultObj["access_token"].ToString() + "&openid=" + resultObj["openid"].ToString() + "&lang=zh_CN");
                    if (userStr.Contains("nickname"))
                    {
                        var userObj = JsonConvert.DeserializeObject(userStr) as JObject;
                    }
                }
            }
            else //还没有到用户授权页面
            {
                string url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect"
                    , this.WeixinAppId, System.Web.HttpUtility.UrlEncode(this.RedirectUrl));
                this.RedirectUrl = url;//指定跳转授权页面 
            }
        }
        /// <summary>
        /// Http Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetHttp(string url)
        {
            string result;
            WebRequest req = WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (Stream receiveStream = response.GetResponseStream())
                {
                    using (StreamReader readerOfStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        result = readerOfStream.ReadToEnd();
                    }
                }
            }
            return result;
        }
    }
}

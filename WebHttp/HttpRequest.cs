using System;
using System.IO;
using System.Net;

namespace WebHttp_CL
{
    public class HttpRequest
    {
        /// <summary>
        /// Http Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGet(string url)
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
        /// <summary>
        /// Http Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpPostResult(string url, string postData)
        {
            try
            {
                if (null == postData)
                {
                    postData = "";
                }
                //request
                string returnVal = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";//"text/json;charset=UTF-8"
                request.Accept = "application/json";
                {
                    //方法一
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(postData);
                    }

                    //方法二
                    //byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                    //request.ContentLength = postBytes.Length;
                    //Stream requestStream = request.GetRequestStream();
                    //requestStream.Write(postBytes, 0, postBytes.Length);
                    //requestStream.Close();
                }


                //response
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    returnVal = sr.ReadToEnd();
                    sr.Close();
                    response.Close();
                }
                return returnVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using System;
using System.IO;
using System.Net;
using System.Text;

namespace yoedgeForm.HttpTool
{
    public  class Http
    {
        /// <summary> 
        /// 获取Http请求内容 
        /// </summary> 
        /// <param name="url">目标网站地址</param> 
        /// <returns>请求的内容</returns> 
        public static string GetResponseText(string url)
        {
            return GetResponseText(url, Encoding.UTF8);
        }

        /// <summary> 
        /// 发出Http请求 
        /// </summary> 
        /// <param name="url">目标网站地址</param> 
        /// <param name="encoding">请求所使用的编码</param> 
        /// <returns>请求的内容</returns> 
        public static string GetResponseText(string url, Encoding encoding)
        {
            string html = string.Empty;
            if (string.IsNullOrEmpty(url ?? ""))
            {
                return url;
            }
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Timeout = 15000;
                WebResponse response = request.GetResponse();
                html = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
            }
            catch (Exception ex)
            { }
            return html;
        }
    }
}

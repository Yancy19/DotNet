using System;
using System.Security.Cryptography;

namespace Tools_CL
{
    public class MD5Encrypt
    {
        /// <summary>
        /// UTF-8编码格式加密
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <param name="defaultCharset">字符集(默认UTF8)</param>
        /// <returns></returns>
        public static string Md5_UTF8(string str, string defaultCharset="utf-8")
        {
            var result = String.Empty;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.GetEncoding(defaultCharset).GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            for (var i = 0; i < targetData.Length; i++)
            {
                result += targetData[i].ToString("X").PadLeft(2, '0');
            }
            result = result.ToUpper();
            return result;
        }
    }
}

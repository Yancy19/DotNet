using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_CL
{
    public class AES
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <param name="strAesKey">加密键 32位 ("00000000000000000000000000000000")</param>
        /// <returns></returns>
        public static string AesEncrypt(string str, string strAesKey)
        {
            Byte[] keyArray = new byte[32];
            keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey);
            Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(str);

            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        // AES 解密
        public static string AesDecrypt(string sSrc, string sKey)
        {
            try
            {
                // if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sSrc) || sKey.Length != 16) return null;

                Byte[] toEncryptArray = Convert.FromBase64String(sSrc);

                System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(sKey),
                    Mode = System.Security.Cryptography.CipherMode.ECB,
                    Padding = System.Security.Cryptography.PaddingMode.PKCS7
                };

                System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
                Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return null;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Tools_CL;
using WebHttp_CL;

namespace Cmd
{
    class B
    {
        public static int Y = A.X + 1;
        static B() { }
        static void Main(string[] args)
        {
            //Console.WriteLine("X={0},Y={1}", A.X, B.Y);
            //Console.ReadKey();

            //DateTime? test = null;
            //Console.WriteLine("你输入的是:{0}", test.Value.ToString());
           var obj = new
            {
                notify_url = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                order_num = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                return_url = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                subject = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                total_fee = 100,
            };
           
            Console.WriteLine("obj>string:{0}", JsonConvert.SerializeObject(obj));
            var password = "123123";
            var key ="4876D41EEDE043098F8F62D1BBBA3243";
            var aesPassword = Tools_CL.AES.AesEncrypt(password, key);
            var url = System.Web.HttpUtility.UrlDecode("uid=1&password="+ aesPassword + "&user_type=个人&user_id=yygtest2&mobile=13340675698&salt=asdads&card_type=个人&id=1234567890&key="+ key);
            Console.WriteLine("url:{0}", url);
            
            string strs =MD5Encrypt.Md5_UTF8(url);
            Console.WriteLine("Md5:{0}", strs);
            //清除剪贴板，然后添加指定的格式的数据
            //Clipboard.SetDataObject(strs);












            var str = Console.ReadLine();
            //for (var i = 0; i < int.MaxValue; i++)
            //{
            //    if (str == "q")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("X={0},Y={1},OUT={2}", A.X, B.Y, str);
            //        str = Console.ReadLine();
            //    }
            //}
            do
            {
                Console.WriteLine("你输入的是:{0}", str);
                str = Console.ReadLine();
            } while (str != null && str != "q");




        }

    }
    class A
    {
        public static int X;
        static A()
        {
            X = B.Y + 1;
        }
    }
}

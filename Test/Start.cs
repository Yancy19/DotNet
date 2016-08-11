using Newtonsoft.Json;
using System;
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
            
            var balanceBodata = new
            {
                firm_id = "10000001"
            };
            var url_Balance = "http://foodeco.chinacloudapp.cn/v1/b2b/balance?sign="+ MD5Encrypt.Md5_UTF8(JsonConvert.SerializeObject(balanceBodata) + "&key=test") + "&appid=jiaoyi&bodata="+ JsonConvert.SerializeObject(balanceBodata);
            //var balance_Besponse = HttpRequest.HttpGetResult(url_Balance);
            var balance_Besponse = HttpRequest.HttpPostResult(url_Balance,JsonConvert.SerializeObject(balanceBodata)); 
            Console.WriteLine("Balance_Response:{0}", balance_Besponse);
            var obj = new
            {
                notify_url = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                order_num = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                return_url = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                subject = "382accff-57b2-4d6e-ae84-a61e00a3e3b5",
                total_fee = 100,
            };
            
            var url_Pay = "http://foodeco.chinacloudapp.cn/v1/b2b/pay";
            url_Pay += "?sign=" + MD5Encrypt.Md5_UTF8(JsonConvert.SerializeObject(obj) + "&key=test");
            url_Pay += "&appid=jiaoyi";
            url_Pay += "&bodata=";
            url_Pay += JsonConvert.SerializeObject(obj);
            var pay_Besponse = HttpRequest.HttpGet(url_Pay);
            Console.WriteLine("Pay_Response:{0}", pay_Besponse);


















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

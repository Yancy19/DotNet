using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
namespace WindowsServer
{
    //[RunInstaller(true)]
    [RunInstallerAttribute(true)]
    public class WindowsServer
    {
        public static void Main(string[] args)
        {


            Timer Timer = new Timer();
            //Timer.Interval = 1000 * 60 * 10;//十分钟
            Timer.Interval = 1000 * 60 * 1;//一分钟
            Timer.Enabled = true;
            Timer.Elapsed += new ElapsedEventHandler(RunDateInit);
            //int num = Convert.ToInt32(time2) - Convert.ToInt32(time1) + 1;

            //System.Threading.Thread.Sleep(1000 * 60 * 2);
            //System.Threading.Thread.Sleep(1000 * 60 * 5);
            var thread=System.Threading.Thread.CurrentThread;
            Process[] processes;
            processes=Process.GetProcesses();
            foreach(var p in processes)
            {

                if (p.ProcessName == "WeChat")
                {
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine("进程名称:" +p.ProcessName);
                    ProcessThreadCollection tphread;
                    tphread = p.Threads;
                    foreach (var t in tphread)
                    {
                        Console.WriteLine("线程名称:" + t);
                        
                    }
                   
                }
            }
            Console.Read();
        }
        private static void RunDateInit(object source,ElapsedEventArgs e)
        {
            if(Convert.ToInt32(DateTime.Now.Hour.ToString())>=18&& Convert.ToInt32(DateTime.Now.Hour.ToString()) <= 20)
            {
                Console.WriteLine("马上下班，做好准备噢！");
            }
            Console.WriteLine("继续努力，加油！");
        }
    }
}

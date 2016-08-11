using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        Timer timer;

        protected void Application_Start(object sender, EventArgs e)
        {
            timer = new Timer();
            //Timer.Interval = 1000 * 60 * 10;//十分钟
            timer.Interval = 1000 * 60 * 1;//一分钟
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(runExe);
        }

        private static void runExe(object sender,System.Timers.ElapsedEventArgs e)
        {
            //string path = @"D:\project\DotNet\WindowsServer\bin\Debug\WindowsServer.exe";
            //var cmd = path + @" D:\project\DotNet\WindowsServer\";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            process.Start();
            //process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Close();
            }
        }
    }
}
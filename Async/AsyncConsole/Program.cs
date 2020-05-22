using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("主线程开始");
            //Action action = () => Console.WriteLine("第一个委托");
            ////AsyncCallback是一个委托，参数为IAsyncResult
            //AsyncCallback asyncCallback = ai =>
            //{
            //    Console.WriteLine("异步线程执行完成后调用该委托");
            //    Console.WriteLine(ai.AsyncState);//action.BeginInvoke中的回调状态参数“OK”
            //};
            ////开启一个线程调用action委托。当action执行完成后，产生一个IAsyncResult的一个结果，然后以该结果作为参数去调用asyncCallback委托，执行委托中包含的方法。
            //IAsyncResult asyncResult = action.BeginInvoke(asyncCallback, "OK");
            //Console.WriteLine("主线程结束");
            //Console.Read();

            DownloadPictureAsync(@"https://www.jinchutou.com/p-89809041.html", HtmlReadStyle.Url,  @"F:\正则表达式下载", @"(http|ftp|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)+\.(gif)");
            Console.WriteLine("\n下载结束，按任意键退出");
            Console.ReadKey();
        }
        
    }
}

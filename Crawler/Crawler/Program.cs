using Framework.Http;
using Framework.Log;
using Interface;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper logHelper = new LogHelper(typeof(Program));
            try
            {
              string s=  HttpHelper.DownloadHtml("https://www.jd.com/allSort.aspx");
                ICategory category = new Category();
                category.Crawler(s);
            }
            catch (Exception e)
            {
                logHelper.Error(e.Message, ex: e);
            }


        }
    }
}

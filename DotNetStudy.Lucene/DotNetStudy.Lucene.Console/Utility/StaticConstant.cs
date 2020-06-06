using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Lucene.Console.Utility
{
  public  class StaticConstant
    {
        public static string IndexPath = ConfigurationManager.AppSettings["IndexPath"];

        public static string TestIndexPath = ConfigurationManager.AppSettings["TestIndexPath"];
    }
}

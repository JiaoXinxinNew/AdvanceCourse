using DotNetStudy.Lucene.Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Lucene.Console.DataService
{
    public class ActivityRepository
    {
        public  static List<Activity> QueryList(int pageIndex,int pageSize)
        {
            string sql = $" SELECT * FROM( SELECT TOP {pageSize} * FROM (SELECT TOP {pageSize*pageIndex} * FROM Activity ORDER BY Id ASC ) AS C ORDER BY C.Id DESC) AS D ORDER BY D.ID ASC";
            return SqlHelper.QueryList<Activity>(sql);
        }
    }
}

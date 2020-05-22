using Libraries.Framwork.AttributeExtend;
using Libraries.Framwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.DAL
{
    public class TSqlHelper<T> where T : BaseModel
    {
        static TSqlHelper()
        {
            Type type = typeof(T);
            string properityStr = string.Join(",", type.GetProperties().Select(p => $"[{p.GetCustomProperityName()}]"));
            SQLFindById = $"Select {properityStr} from [{type.Name}] where id=";

            string propStr = string.Join(",", type.GetProperties().Select(p => $"[{p.GetCustomProperityName()}]"));
            SQLFindAll = $"Select {propStr}  from [{type.Name}]";

            SQLDeleteById = $"delete from [{type.Name}] where Id=";
        }
        public static string SQLFindById = null;
        public static string SQLFindAll = null;
        public static string SQLDeleteById = null;
    }
}

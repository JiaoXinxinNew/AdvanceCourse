using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork
{
    public class StaticConstant
    {
        #region Configration
        //数据库链接字符串
        public static string SqlServerConnString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerConn"].ConnectionString;
        #region DAL配置
        private static string DALDll = System.Configuration.ConfigurationManager.AppSettings["DALDllName"];
        public static string DALDllName = DALDll.Split(',')[0];
        public static string DALTypeName = DALDll.Split(',')[1];
        #endregion
        #endregion

        #region CustomField
        public static string EmailRegax = "([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,5})+";
        public static string TelephoneRegax = @"^[1]+[3,5]+\d{9}";
        #endregion

    }
}

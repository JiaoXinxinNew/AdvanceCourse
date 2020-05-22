using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.MVCFilter
{
    public class MVCFilterShow
    {
        public static void Show()
        {
            AOPManager.Invoke("OrderService", "Index", new object[] { 1, "jxx" });
        }
    }
}

using DotNetStudy.IOC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.DAL
{
    public class DBContextDAL<T> : IDBContextDAL<T>
    {
        public void DoNothing()
        {
            Console.WriteLine($"***{typeof(T)}被构造了***");
        }
    }
}

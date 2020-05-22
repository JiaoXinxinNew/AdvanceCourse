using DotNetStudy.IOC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.DAL
{
    public class BaseDAL : IBaseDAL
    {
        public BaseDAL()
        {
            Console.WriteLine($"{nameof(BaseDAL)}被构造。。。。");
        }

        public void Add()
        {
            Console.WriteLine($"{nameof(Add)}");
        }

        public void Delete()
        {
            Console.WriteLine($"{nameof(Delete)}");
        }

        public void Find()
        {
            Console.WriteLine($"{nameof(Find)}");
        }

        public void Update()
        {
            Console.WriteLine($"{nameof(Update)}");
        }
    }
}

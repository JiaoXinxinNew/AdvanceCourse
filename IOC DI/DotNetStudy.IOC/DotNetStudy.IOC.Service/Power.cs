using DotNetStudy.IOC.IBLL;
using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Service
{
    public class Power : IPower
    {
        public Power(IBaseBLL baseBll)
        {
            Console.WriteLine("Power 被构造");
        }
    }
}

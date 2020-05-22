using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Service
{
    public class Headphone : IHeadphone
    {
        public Headphone(IMicrophone microphone)
        {
            Console.WriteLine("Headphone 被构造");
        }
    }
}

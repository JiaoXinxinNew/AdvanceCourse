using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Service
{
   public class AndroidPhone: IPhone
    {
        public IMicrophone IMicrophone { get; set; }
        public IHeadphone IHeadphone { get; set; }
        public IPower iPower { get; set; }

        public AndroidPhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }

        //public AndroidPhone(AbstractPad pad, IHeadphone headphone)
        //{
        //    Console.WriteLine("{0}构造函数", this.GetType().Name);
        //}

        ////[ElevenInjectionConstructor]
        //public AndroidPhone(AbstractPad pad)
        //{
        //    Console.WriteLine("{0}构造函数", this.GetType().Name);
        //}
        //public AndroidPhone(IBaseBll baseBll)
        //{
        //    Console.WriteLine("{0}构造函数", this.GetType().Name);
        //}

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name); ;
        }
    }
}

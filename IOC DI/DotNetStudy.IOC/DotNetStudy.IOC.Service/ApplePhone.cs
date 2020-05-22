using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DotNetStudy.IOC.Service
{
    public class ApplePhone : IPhone
    {
        [Dependency]//属性注入
        public IMicrophone IMicrophone { get; set; }
        [Dependency]//属性注入
        public IPower iPower { get; set; }
        [Dependency]//属性注入
        public IHeadphone IHeadphone { get ; set; }

        [InjectionConstructor]//构造函数注入：默认找参数最多的构造函数
        public ApplePhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }
        [InjectionConstructor]//构造函数注入：默认找参数最多的构造函数
        public ApplePhone(IHeadphone headphone)
        {
            this.IHeadphone = headphone;
            Console.WriteLine("{0}带参数构造函数", this.GetType().Name);
        }


        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name); ;
        }
        [InjectionMethod]//方法注入
        public void Init1234(IPower power)
        {
            this.iPower = power;
        }
    }
}

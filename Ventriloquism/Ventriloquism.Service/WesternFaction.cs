using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism.Interface;

namespace Ventriloquism.Service
{
    public class WesternFaction : VentriloquismShow, ICharge
    {
        public string Rap { get; set; }
        public string _Remark = null;
        public void WesternRap()
        {
            Console.WriteLine("西派Rap。。。");
        }
        public void Charge()
        {
            Console.WriteLine("收费");
        }

        public override void DogVoice()
        {
            Console.WriteLine("狗叫的声音。。。");
        }

        public override void PeopleVoice()
        {
            Console.WriteLine("人的声音。。。");
        }

        public override void WindVoice()
        {
            Console.WriteLine("风的声音。。。");
        }
        public override void Prologue()
        {
            Console.WriteLine("I am western faction prologue");
        }
        public override void Conclusion()
        {
            Console.WriteLine("I am Western faction Conclusion");
        }
    }
}

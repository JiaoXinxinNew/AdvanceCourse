using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism.Interface;

namespace Ventriloquism.Service
{
    public class NorthFaction : VentriloquismShow, ICharge
    {
        public NorthFaction ()
        {
            base.TempratureJudge = t => t > 1000;
        }
        public string Fight { get; set; }
        public string _Remark = null;
        public void NorthFight()
        {
            Console.WriteLine("北派打架。。。");
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
        public override void Conclusion()
        {
            Console.WriteLine("I am north faction Conclusion");
        }
    }
}

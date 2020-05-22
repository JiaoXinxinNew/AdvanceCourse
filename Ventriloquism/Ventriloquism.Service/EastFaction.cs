using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism.Interface;

namespace Ventriloquism.Service
{
    public class EastFaction : VentriloquismShow, ICharge
    {
        public EastFaction()
        {
            base.TempratureJudge = t => t > 800;
        }
        public string _Remark = null;
        public string Sing { get; set; }
        public void EastSing ()
        {
            Console.WriteLine("南派唱歌");
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
    }
}

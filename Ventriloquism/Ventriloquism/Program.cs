using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism.Interface;
using Ventriloquism.Service;

namespace Ventriloquism
{
    class Program
    {
        static void Main(string[] args)
        {
            //NorthFaction northFaction = new NorthFaction()
            //{
            //    Peopel = "北方人",
            //    Chair = "椅子",
            //    Ruler = "尺子"
            //};
            //northFaction.WellSkill(northFaction.NorthFight);
            //Console.WriteLine("******着火*******");
            //northFaction.FireOn += northFaction.DogVoice;
            //northFaction.SetTempratrue(1200);
            // Display<NorthFaction>(northFaction);
           var northFactions= SimpleFactory.CreateFiction<SouthFaction>();
            Console.WriteLine(northFactions.Chair);

            Console.Read(); 
        }
        public static void Display<T>(T model)where T: VentriloquismShow,ICharge
        {
            Type t = model.GetType();
            foreach (var propetry in t.GetProperties())
            {
                Console.WriteLine($"{t.FullName}的属性为{propetry.Name},值为：{propetry.GetValue(model)}");
            }
            foreach (var field in t.GetFields())
            {
                Console.WriteLine($"{t.FullName}类型的字段为{field.Name}，值为：{field.GetValue(model)}");
            }
            model.ShowStart();
            model.Prologue();
            model.PeopleVoice();
            model.DogVoice();
            model.WindVoice();
            model.Conclusion();
            model.Charge();

        }
    }
}

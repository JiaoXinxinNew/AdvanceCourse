using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model
{
    public class Bean : AbstractDish
    {
        public Bean() : base("Config/Bean.json") { }
        public override void Cook()
        {
            Console.WriteLine("我用豆芽做一份豆芽");
        }

        public override void Show()
        {
            Console.WriteLine("我是豆芽");
        }

        public override void Tast()
        {
            Console.WriteLine("我尝起来是豆芽的味道");
        }
    }
}

using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model
{
    public class Potatoes : AbstractDish
    {
        public override void Cook()
        {
            Console.WriteLine("我是用土豆做一份土豆丝的");
        }

        public override void Show()
        {
            Console.WriteLine("我是土豆");
        }

        public override void Tast()
        {
            Console.WriteLine("我尝起来是土豆的味道");
        }
    }
}

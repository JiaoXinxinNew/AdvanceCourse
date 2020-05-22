using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model
{
    public class Bouilli : AbstractDish
    {
        public override void Cook()
        {
            Console.WriteLine("我用猪肉做一份红烧肉");
        }

        public override void Show()
        {
            Console.WriteLine("我是红烧肉");
        }

        public override void Tast()
        {
            Console.WriteLine("我尝起来肥而不腻");
        }
    }
}

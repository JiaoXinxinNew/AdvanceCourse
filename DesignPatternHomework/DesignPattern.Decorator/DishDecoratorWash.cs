using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model.Dish;

namespace DesignPattern.Decorator
{
    public class DishDecoratorWash : BaseDishDecortator
    {
        public DishDecoratorWash(AbstractDish abstractDish) : base(abstractDish)
        {
        }
        public override void Cook()
        {
            Console.WriteLine("洗菜");
            base.Cook();
        }
    }
}

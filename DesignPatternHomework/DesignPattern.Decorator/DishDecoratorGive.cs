using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model.Dish;

namespace DesignPattern.Decorator
{
    public class DishDecoratorGive : BaseDishDecortator
    {
        public DishDecoratorGive(AbstractDish abstractDish) : base(abstractDish)
        {
        }
        public override void Cook()
        {
           
            base.Cook();
            Console.WriteLine("上菜");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model.Dish;

namespace DesignPattern.Decorator
{
    public class DishDecoratorPut : BaseDishDecortator
    {
        public DishDecoratorPut(AbstractDish abstractDish) : base(abstractDish)
        {
        }
        public override void Cook()
        {
            base.Cook();
            Console.WriteLine("摆菜");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model.Dish;

namespace DesignPattern.Decorator
{
    public class DishDecoratorBuy : BaseDishDecortator
    {
        public DishDecoratorBuy(AbstractDish abstractDish) : base(abstractDish)
        {
        }
        public override void Cook()
        {
            Console.WriteLine("买菜");
            base.Cook();
        }
    }
}

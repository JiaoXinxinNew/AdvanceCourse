using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model.Dish;

namespace DesignPattern.Decorator
{
    public class DishDecoratorCut : BaseDishDecortator
    {
        public DishDecoratorCut(AbstractDish abstractDish) : base(abstractDish)
        {
        }
        public override void Cook()
        {
            Console.WriteLine("切菜");
            base.Cook();
        }
    }
}

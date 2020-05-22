using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public abstract class BaseDishDecortator : AbstractDish
    {
        private  AbstractDish _AbstractDish;
        public BaseDishDecortator(AbstractDish abstractDish)
        {
            this._AbstractDish = abstractDish;
        }
        public override void Cook()
        {
            this._AbstractDish.Cook();
        }

        public override void Show()
        {
            this._AbstractDish.Show();
        }

        public override void Tast()
        {
            this._AbstractDish.Tast();
        }
    }
}

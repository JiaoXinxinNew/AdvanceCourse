using DesignPattern.Model;
using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class PotattoesFactory : BaseFactory
    {
        public override AbstractDish CreatFactory()
        {
            return new Potatoes();
        }
    }
}

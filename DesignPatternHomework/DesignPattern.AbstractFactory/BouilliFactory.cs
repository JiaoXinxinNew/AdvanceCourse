using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Model;
using DesignPattern.Model.Dish;

namespace DesignPattern.AbstractFactory
{
    public class BouilliFactory : BaseFactory
    {
        public override AbstractDish CreatFactory()
        {
            return new Bouilli();
        }
    }
}

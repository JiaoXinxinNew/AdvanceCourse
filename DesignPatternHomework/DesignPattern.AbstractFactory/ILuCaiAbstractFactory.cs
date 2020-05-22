using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
   public interface ILuCaiAbstractFactory
    {
        AbstractDish CookPotatoes();
        AbstractDish CookBean();
        AbstractDish  CookBouilli();

        
    }
}

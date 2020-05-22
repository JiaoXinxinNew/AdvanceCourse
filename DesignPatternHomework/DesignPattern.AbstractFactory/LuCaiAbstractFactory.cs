using DesignPattern.Model;
using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class LuCaiAbstractFactory : ILuCaiAbstractFactory
    {
        /*
         * 抽象工厂是对一类对象的创建，抽象工厂针对的是不同类型的产品，每个系列的产品组成一个蔟
         * 优点：抽象工厂使得上端的创建不在依赖具体的类，降低了耦合性，并且可以进行扩展；
         * 缺点：当一个蔟里增加方法时需要修改类，又违背了开闭原则。
         */
        public AbstractDish CookBean()
        {
            return new Bean();
        }

        public AbstractDish CookBouilli()
        {
            return new Bouilli();
        }

        public AbstractDish CookPotatoes()
        {
            return new Potatoes();
        }
    }
}

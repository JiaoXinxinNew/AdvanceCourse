using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public abstract class BaseFactory
    {
        /*  
         *  优点：克服了简单工厂的开闭原则，降低了抽象层与实现层的耦合关系，由一个类创建对象，实现了上端的创建不直接依赖具体的类。缺点：没增加一个子工厂都会相应的增加一个子工厂，增加了开发的成本，而且项目中的子类会越来越多。*/
        public abstract AbstractDish CreatFactory();
    }
}

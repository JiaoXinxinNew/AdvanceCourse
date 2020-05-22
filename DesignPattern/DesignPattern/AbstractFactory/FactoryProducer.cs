using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class FactoryProducer
    {
        public static AbstractFactorys GetAbstract(string choice)
        {
            switch (choice.ToLower())
            {
                case "color":
                    return new ColorFactory();
                case "shape":
                    return new ShapeFactory();
                default:
                    return null;
            }
        }
    }
}

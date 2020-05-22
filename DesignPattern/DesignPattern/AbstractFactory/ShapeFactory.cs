using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class ShapeFactory : AbstractFactorys
    {
        public override IColor GetColor(ColorType colorType)
        {
            return null;
        }

        public override IShape GetShape(ShapeType shapeType)
        {
            IShape shape = null;
            switch (shapeType)
            {
                case ShapeType.Square:
                    shape= new Square();
                    break;
                case ShapeType.Rectangle:
                    shape= new Rectangle();
                    break;
                default:
                    return null;
            }
            return shape;
        }
    }
}

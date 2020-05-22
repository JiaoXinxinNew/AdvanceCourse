using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class ColorFactory : AbstractFactorys
    {
        public override IColor GetColor(ColorType colorType)
        {
            IColor color = null;
            switch (colorType)
            {
                case ColorType.Red:
                    color= new Red();
                    break;
                case ColorType.Green:
                    color=new  Green();
                    break;
                default:
                    return null;
            }
            return color;
        }

        public override IShape GetShape(ShapeType shapeType)
        {
            return null;
        }
    }
}

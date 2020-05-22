using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public abstract class AbstractFactorys
    {
        public abstract IColor GetColor(ColorType color);
        public abstract IShape GetShape(ShapeType shape);
    }
    public enum ShapeType
    {
        Square,
        Rectangle
    }
    public enum ColorType
    {
        Red,
        Green
    }
}

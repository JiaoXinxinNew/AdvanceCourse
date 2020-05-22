using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DecoratorPattern
{
    public abstract class ShapeDecorator : IShape
    {
        protected IShape _Decorator;
        public ShapeDecorator(IShape shape)
        {
            this._Decorator = shape;
        }
        public virtual void Draw()
        {
            _Decorator.Draw();
        }
    }
}

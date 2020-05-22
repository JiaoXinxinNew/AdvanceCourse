using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DecoratorPattern
{
    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape shape) : base(shape)
        {
        }
        public override void Draw()
        {
            Console.WriteLine("Border Color: Red");
            base.Draw();
        }
        public void BeforDraw()
        {
            Console.WriteLine("Draw之前做的事情");
        }
        public void AfterDraw()
        {
            Console.WriteLine("Draw之后做的事情");
        }
    }
}

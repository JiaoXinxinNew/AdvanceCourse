using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DecoratorPattern
{
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I am a Circle");
        }
    }
}

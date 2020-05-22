using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("长方形");
        }
    }
}

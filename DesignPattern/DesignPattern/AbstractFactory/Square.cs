using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("正方形");
        }
    }
}

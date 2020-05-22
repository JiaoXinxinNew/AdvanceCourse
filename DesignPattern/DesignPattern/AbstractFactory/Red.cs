using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("红色");
        }
    }
}

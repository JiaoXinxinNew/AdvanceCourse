using DesignPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Customers
{
    public class Client : ICongratulation
    {
        public void Suprice()
        {
            Console.WriteLine("给我来一份");
        }
    }
}

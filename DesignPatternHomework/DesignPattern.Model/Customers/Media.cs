using DesignPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Customers
{
    public class Media : ICongratulation
    {
        public void Suprice()
        {
            Console.WriteLine("我要报道一下这个点的特色");
        }
    }
}

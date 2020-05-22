using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Class
{
    /// <summary>
    /// War3种族之一
    /// </summary>
    public class Human : IRace
    {
        public Human(int id, DateTime dateTime, string reamrk)
        { }
        public Human()
        { }

        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Sky");
        }
    }
    
}

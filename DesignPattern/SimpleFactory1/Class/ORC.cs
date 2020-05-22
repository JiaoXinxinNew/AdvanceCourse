﻿using SimpleFactory;
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
    public class ORC : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Grubby");
        }
    }
   
}

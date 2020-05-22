using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 装瓶
    /// </summary>
    public class Bottle : IPacking
    {
        public string Packing()
        {
            return "Bottle ";
        }
    }
}

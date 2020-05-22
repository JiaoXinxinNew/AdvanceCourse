using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 用纸包装
    /// </summary>
    public class Wrapper : IPacking
    {
        public string Packing()
        {
            return "Wrapper ";
        }
    }
}

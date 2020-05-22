using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 食物
    /// </summary>
    public interface IItem
    {
         String Name();
         IPacking Packing();
         float Price();
    }
}

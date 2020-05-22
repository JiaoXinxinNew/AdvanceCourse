using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model
{
    public class DishModel
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public double Price { get; set; }
        public int DishSorce { get; set; }
        public string SimpleFactory { get; set; }
    }
}

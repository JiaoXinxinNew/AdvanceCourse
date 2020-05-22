using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
   public class Meal
    {
        private IList<IItem> items = new List<IItem>();
        public void AddItem(IItem item)
        {
            items.Add(item);
        }
        public float GetCost()
        {
            float cost = 0.0f;
            foreach (var item in items)
            {
                cost += item.Price();
            }
            return cost;
        }
        public void ShowItems()
        {
            foreach (IItem item in items)
            {
                Console.WriteLine ("Item : " + item.Name());
                Console.WriteLine(", Packing : " + item.Packing().Packing());
                Console.WriteLine(", Price : " + item.Price());
            }
        }
    }
}

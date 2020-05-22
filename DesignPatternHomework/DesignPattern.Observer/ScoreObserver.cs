using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public class ScoreObserver
    {
        public event Action FullMarkAction;
        public void FunllMarkTrigger(int sorce)
        {
            if (sorce==5&&FullMarkAction!=null)
            {
                FullMarkAction.Invoke();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ObserverPattern
{
    public class Subject
    {
        private List<IObserver> _ObserverAction = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            _ObserverAction.Add(observer);
        }
        public void Excute()
        {
            foreach (var Action in _ObserverAction)
            {
                Action.Action();
            }
        }
        public event Action _ObserverEvent;
        public void ExcuteEvent()
        {
            _ObserverEvent.Invoke();
        }


    }
}

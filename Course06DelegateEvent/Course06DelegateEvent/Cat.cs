using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course06DelegateEvent
{
  public  class Cat
    {
        public delegate void MiaoDelegate();//定义一个委托
        public event MiaoDelegate miaoDelegateEvent;//定义一个字段
        public void Miao()
        {
            Console.WriteLine("miao一下");
            if (miaoDelegateEvent != null)
            {
                this.miaoDelegateEvent.Invoke();
            }
        }
    }
}

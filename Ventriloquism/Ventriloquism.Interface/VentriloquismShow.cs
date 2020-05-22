using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism.Interface
{
    public abstract class VentriloquismShow
    {
        public string Peopel { get; set; }
        public string Table { get; set; }
        public string Chair { get; set; }
        public string Fan { get; set; }
        public string Ruler { get; set; }
        public  void ShowStart()
        {
            Console.WriteLine("********表演开始*********");
        }
        /// <summary>
        /// 事件，哪个类声明哪个类执行
        /// </summary>
        public event Action FireOn;
        /// <summary>
        /// 声明一个受保护的委托用于使用不同的子类温度条件。
        /// </summary>
        protected Func<int, bool> TempratureJudge = t => t > 400;
        public virtual void SetTempratrue(int temprature)
        {
            if (this.TempratureJudge.Invoke(temprature))
            {
                this.FireOn?.Invoke();
            }
        }
        /// <summary>
        /// 使用保护的，子类看不见
        /// </summary>
        /// <param name="act"></param>
        public virtual void WellSkill(Action act)
        {
            Console.WriteLine("绝活开始");
            act.Invoke();
            Console.WriteLine("绝活表演结束");
        }
        public abstract void DogVoice();
        public abstract void PeopleVoice();
        public abstract void WindVoice();
        public virtual void Prologue()
        {
            Console.WriteLine("********开场白*********");
        }
        public virtual void Conclusion()
        {
            Console.WriteLine("*******我是结束语");
        }
    }
}

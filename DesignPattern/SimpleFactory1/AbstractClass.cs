using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    //声明委托
    public delegate void GetStrHandler(string x, string y);

    public class TestA
    {
        //声明事件
        public   GetStrHandler GetStr;
        public void Do(string x, string y)
        {
            GetStr(x, y);
        }
    }

    public class TestB
    {
        private TestA _A;
        public TestB(TestA a)
        {

            _A = a;
            _A.GetStr = null;
            _A.GetStr += OnGetStr;//事件的订阅
        }

        //事件处理方法
        private void OnGetStr(string x, string y)
        {
            Console.WriteLine(string.Format("{0}+{1}", x, y));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            TestA a = new TestA();
            TestB b = new TestB(a);
            a.Do("a", "b");//事件的触发
            Console.ReadKey();
        }
    }

}

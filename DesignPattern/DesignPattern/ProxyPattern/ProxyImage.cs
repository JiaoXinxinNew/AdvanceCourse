using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ProxyPattern
{
   public class ProxyImage:IImage
    {
        private string _fileName;
        private RealImage _realImage;
        public ProxyImage(string fileName)
        {
            this._fileName = fileName;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                //可以直接写死，因为一个代理只服务一个类，但是该类有构造参数。所以通过构造方法传入。
                _realImage = new RealImage(_fileName);
            }
            BeforDisplay();//实现AOP
            _realImage.Display();
            AfterDisplay();//实现AOP
        }
        public void BeforDisplay()
        {
            Console.WriteLine("Display之前做的事情");
        }
        public void AfterDisplay()
        {
            Console.WriteLine("Display之后做的事情");
        }
    }
}

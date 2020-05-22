using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ProxyPattern
{
    public class RealImage : IImage
    {
        private string _fileName;
        public RealImage(string fileName)
        {
            this._fileName = fileName;
        }
        public void Display()
        {
            Console.WriteLine("Displaying"+_fileName);
        }
        private void LoadFromDisk(String fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }
}

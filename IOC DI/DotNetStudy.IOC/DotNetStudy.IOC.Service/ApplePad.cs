using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Service
{
    public class ApplePad : AbstractPad
    {
        public override void Show()
        {
            Console.WriteLine($"This is {nameof(ApplePad)}");
        }
    }
}

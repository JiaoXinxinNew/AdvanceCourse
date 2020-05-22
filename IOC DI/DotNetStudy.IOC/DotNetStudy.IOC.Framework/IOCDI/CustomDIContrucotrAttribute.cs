using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Framework.IOCDI
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class CustomDIContrucotrAttribute : Attribute
    {
        public CustomDIContrucotrAttribute() { }
    }
}

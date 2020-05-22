using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Framework.IOCDI
{
    public class RegisterInfo
    {
        public Type TargetType { get; set; }
        public LifeTimeType LifeTimeType { get; set; }
    }
    public enum LifeTimeType
    {
        Transient=0,
        SingleTon=1,
        PerThread=2
    }
}

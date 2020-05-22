using DotNetStudy.IOC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.Service
{
    public class MiPhone : IPhone
    {
        public IMicrophone IMicrophone { get ; set ; }
        public IHeadphone IHeadphone { get ; set ; }
        public IPower iPower { get ; set ; }
        public MiPhone()
        {

        }

        public void Call()
        {
            throw new NotImplementedException();
        }
    }
}

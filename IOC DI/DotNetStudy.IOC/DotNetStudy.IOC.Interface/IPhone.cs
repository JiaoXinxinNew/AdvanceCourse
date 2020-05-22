using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetStudy.IOC.Interface
{
    public interface IPhone
    {
        void Call();
        IMicrophone IMicrophone { get; set; }
        IHeadphone IHeadphone { get; set; }
        IPower iPower { get; set; }
    }
}

using DotNetStudy.WCF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Service
{
    public class MathService : IMathService
    {
        public int Plus(int i, int j)
        {
            return i + j;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Interface
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int Plus(int i, int j);
    }
}

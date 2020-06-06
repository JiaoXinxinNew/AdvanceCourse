using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Interface
{
    [ServiceContract(CallbackContract = (typeof(ICallBack)))]//设置当协定为双工协议时的回调协定类型
    public interface ICalculatorService
    {
        [OperationContract(IsOneWay =true)]
        void Plus(int i, int j);
    }
}
 
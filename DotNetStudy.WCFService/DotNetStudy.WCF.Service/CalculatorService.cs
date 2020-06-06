using DotNetStudy.WCF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetStudy.WCF.Service
{
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// 完成计算，然后回调
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Plus(int i, int j)
        {
            int result = i + j;
            Thread.Sleep(2000);
            ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callBack.Show(i,j,result);
        }
    }
}

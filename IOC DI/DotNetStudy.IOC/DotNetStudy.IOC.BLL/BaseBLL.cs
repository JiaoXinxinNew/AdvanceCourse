using DotNetStudy.IOC.IBLL;
using DotNetStudy.IOC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.IOC.BLL
{
    public class BaseBLL : IBaseBLL
    {
        private IBaseDAL _BaseDAL = null;
        public BaseBLL(IBaseDAL baseDAL,int id)
        {
            Console.WriteLine($"{nameof(BaseBLL)}被构造,id:{id}");
            this._BaseDAL = baseDAL;
        }
        public void DoSomething()
        {

            _BaseDAL.Add();
            _BaseDAL.Update();
            _BaseDAL.Find();
            _BaseDAL.Delete();
        }
    }
}


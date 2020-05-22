using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.ChainOfResponsibility
{
  public abstract  class Handler
    {
        private Handler _NextHandler;
        public void SetNextHandler(Handler handler)
        {
            this._NextHandler = handler;
        }
        public Handler GetNextHandler()
        {
            return _NextHandler;
        }
        public abstract void HandleRequest(int days);
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetStudy.WebService.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (MyWebService.MyWebServiceSoapClient myWebServiceSoapClient = new MyWebService.MyWebServiceSoapClient())
            {
                int i = myWebServiceSoapClient.Get(1);
            };

        }
    }
}

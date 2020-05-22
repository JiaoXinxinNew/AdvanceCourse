using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism.Common;
using Ventriloquism.Interface;

namespace Ventriloquism
{
    public class SimpleFactory
    {
        public static T CreateFiction<T>() where T:VentriloquismShow,ICharge
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"ConfigFiles\{typeof(T).Name}.Json");
            string typeInfo = File.ReadAllText(jsonPath);
            T model = JsonHelper.JsonToObj<T>(typeInfo);
            return model;
            
        }
    }
}

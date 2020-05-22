﻿
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism.Common
{
    public class StaticConstant
    {
        public static class Constant
        {
            public static string DesKey = AppSettings("DesKey", "ruanmou1");

            private static T AppSettings<T>(string key,T defaultValue)
            {
                var v = ConfigurationManager.AppSettings[key];
                return string.IsNullOrEmpty(v) ? defaultValue : (T)Convert.ChangeType(v, typeof(T)) ;
            }
        }
    }
}

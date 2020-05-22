using DotNetStudy.RedisHelper.CacheFactory;
using DotNetStudy.RedisHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            ICache cache = CacheHelper.CreateCacheConfigRelex();
            cache.Set("1", "2");
            Console.Read();
        }
    }
}

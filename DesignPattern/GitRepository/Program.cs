using SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            //通过简单工厂创建IRace对象
            IRace race = ObjectFactory.CreateRace(RaceType.Human);

            //通过配置文件创建IRace对象
            IRace raceConfig = ObjectFactory.CreateRaceConfig();

            //通过配置文件+反射创建IRace对象
            IRace raceConfigReflex = ObjectFactory.
        }
    }
}

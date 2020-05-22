using SimpleFactory.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace SimpleFactory
{
    public class ObjectFactory
    {
        /// <summary>
        /// 通过简单工程创建对象
        /// </summary>
        /// <param name="raceType"></param>
        /// <returns></returns>
        public static IRace CreateRace(RaceType raceType)
        {
            IRace race = null;
            switch (raceType)
            {
                case RaceType.Human:
                    race = new Human();
                    break;
                case RaceType.NE:
                    race = new NE();
                    break;
                case RaceType.ORC:
                    race = new ORC();
                    break;
                case RaceType.Undead:
                    race = new Undead();
                    break;
            }
            return race;
        }

        private static string IRacTypeConfig = ConfigurationManager.AppSettings["IRacTypeConfig"];//通过配置获取实例化的对象名

        /// <summary>
        /// 通过配置+简单工厂的模式获取对象
        /// </summary>
        /// <returns></returns>
        public static IRace CreateRaceConfig()
        {
            RaceType raceType = (RaceType)Enum.Parse(typeof(RaceType), IRacTypeConfig);
            return CreateRace(raceType);
        }

        private static string IRacTypeConfigReflection = ConfigurationManager.AppSettings["key"];
        private static string DllName = IRacTypeConfigReflection.Split(',')[1];
        private static string TypeName = IRacTypeConfigReflection.Split(',')[0];
        public static IRace CreateRaceConfigRelex()
        {
            Assembly assembly = Assembly.Load(DllName);//加载dll文件
            Type type = assembly.GetType(TypeName);//根据类型名获取dll中的类型
            var race = Activator.CreateInstance(type) as IRace;//根据类型创建实例
            return race;
        }
    }

    /// <summary>
    /// 简单工厂模式的类
    /// </summary>
    public enum RaceType
    {
        Human,
        Undead,
        ORC,
        NE
    }
}

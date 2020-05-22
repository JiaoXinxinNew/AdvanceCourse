using DesignPattern.Common;
using DesignPattern.Model;
using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class AbstractFactory
    {
        #region
        /*
         * 有点：抽象工厂降低了抽象层与实现层的耦合关系，由一个工厂类创建所有对象的实例，实现了上端的创建不依赖于类。
         * 缺点：工厂完成了所有对象的创建，但在修改时仍然需要修改类，违背了开闭原则（对外允许扩展，不允许修改），当我们修改或者增加时都要去增加修改工厂。
         */
        /// <summary>
        /// 利用简单工厂创建菜系
        /// </summary>
        /// <param name="dishName"></param>
        /// <returns></returns>
        public static AbstractDish CreateDishByNormal(DishName dishName)
        {
            AbstractDish abstractDish = null;
            switch (dishName)
            {
                case DishName.Potatoes:
                    abstractDish = new Potatoes();
                    break;
                case DishName.Bouilli:
                    abstractDish = new Bouilli();
                    break;
                case DishName.Bean:
                    abstractDish = new Potatoes();
                    break;
                default:
                    throw new Exception("没有改菜系");
            }
            return abstractDish;
        }
        #endregion

        #region 使用配置文件创建菜系
        /* 使用配置文件创建对象，在不重新发布项目运行的情况下直接修改创建类。*/
        private static readonly string _DishName = ConfigHelper.GetConfig("DishNameConfig");
        /// <summary>
        /// 使用配置文件和简单工厂创建菜系
        /// </summary>
        public static AbstractDish AbstractDishByConfig()
        {
            DishName dishNameInstance = (DishName)Enum.Parse(typeof(DishName), _DishName);
            return CreateDishByNormal(dishNameInstance);
        }
        #endregion

        #region 通过配置文件和反射创建对象
        private static readonly string _AbstractDishTypeConfigReflection = ConfigHelper.GetConfig("DishNameReflection");
        private static readonly string _DllName = _AbstractDishTypeConfigReflection.Split(',')[0];
        private static readonly string _TypeName = _AbstractDishTypeConfigReflection.Split(',')[1];
        public static AbstractDish CreateDishByConfigRelec()
        {
            Assembly assembly = Assembly.Load(_DllName);//加载dll文件 
            Type type = assembly.GetType(_TypeName);//根据类型名获取dll中的类型 
            var dishName = Activator.CreateInstance(type) as AbstractDish;//根据类型创建实例 
            return dishName;
        }
        #endregion

        #region 
        /// <summary>
        /// 通过配置文件和反射创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dllType">dll命名空间，类全称</param>
        /// <returns></returns>
        public static T CreateDishByRefAndConfig<T>(string dllType)
        {
            Assembly assembly = Assembly.Load(dllType.Split(',')[0]);
            Type type = assembly.GetType(dllType.Split(',')[1]);
            return (T)Activator.CreateInstance(type);
        }
        #endregion

    }


    public enum DishName
    {
        Potatoes = 0,
        Bouilli = 1,
        Bean = 2
    }

}

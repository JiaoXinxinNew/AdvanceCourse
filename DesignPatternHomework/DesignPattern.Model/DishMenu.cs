using DesignPattern.Common;
using DesignPattern.Model.Dish;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model
{
    public class DishMenu
    {
        private DishMenu() { }
        private volatile static DishMenu _DishMenu;
        private static readonly object _MenuLock = new object();
        public List<DishModel> DishModels = new List<DishModel>();
        public static DishMenu CreateDishMenu()
        {
            if (_DishMenu== null)
            {
                lock (_MenuLock)
                {
                    if (_DishMenu == null)
                    {
                        string xmlPath = ConfigHelper.GetConfig("XmlDishModel");
                        if (string.IsNullOrWhiteSpace(xmlPath))
                        {
                            throw new Exception("请在配置文件中配置菜单XML路径，路径名为XmlFoodPath");
                        }
                        xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlPath);
                        if (!File.Exists(xmlPath))
                        {
                            throw new Exception("不存在菜品菜单配置文件");
                        }
                        DishModelList dishModelList = XMLHelper.FileToT<DishModelList>(xmlPath);
                        if (dishModelList == null)
                            throw new Exception("读取菜单失败");
                        _DishMenu = new DishMenu
                        {
                            DishModels = dishModelList.DishModels
                        };
                    }
                }
            }
            return _DishMenu;
        }
    }
}

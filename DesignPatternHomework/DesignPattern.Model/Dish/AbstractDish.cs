using DesignPattern.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Dish
{
    public abstract class AbstractDish
    {
        public DishBaseInfo DishBaseInfo { get; set; }
        public AbstractDish() { }
        /// <summary>
        /// 传入菜品的基本信息Json的相对路径
        /// </summary>
        /// <param name="jsonPath"></param>
        public AbstractDish(string jsonPath)
        {
            this.DishBaseInfo = JsonHelper.JsonToObjByPath<DishBaseInfo>(jsonPath,Encoding.Default);
        }
        public abstract void Show();
        /// 品尝
        /// </summary>
        public abstract void Tast();

        /// <summary>
        /// 评价
        /// </summary>
        /// <returns>0-5分</returns>
        public virtual int Evaluate()
        {
            return RandomNum.GetRandomNumber (0,6);
        }

        /// <summary>
        /// 做菜
        /// </summary>
        public abstract void Cook();

    }
}

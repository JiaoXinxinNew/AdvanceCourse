using Libraries.Framwork.AttributeExtend.Validate;
using Libraries.Framwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend
{
    public static class AttributeHelper
    {
        /// <summary>
        /// 获取自定义特性的名字，以匹配数据库
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static string GetCustomProperityName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute columnAttribute = propertyInfo.GetCustomAttribute(typeof(CustomAttribute), true) as CustomAttribute;
                return columnAttribute.GetCustomProperityName();
            }
            else
                return propertyInfo.Name;
        }

        /// <summary>
        /// 统一验证实体类属性是否满足特性
        /// </summary>
        /// <param name="oObject"></param>
        /// <returns></returns>
        public static bool Validate<T>(this T tModel) where T: BaseModel
        {
            Type type = tModel.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    foreach (AbstractValidateAttribute attribute in prop.GetCustomAttributes())
                    {
                        if (!attribute.Validate(prop.GetValue(tModel)))
                        {
                            throw new Exception($"实体类{type.Name}的属性{prop.Name}的值：{prop.GetValue(tModel)} 不满足要求");
                        }
                    }
                }
            }
            return true;
        }
    }
}

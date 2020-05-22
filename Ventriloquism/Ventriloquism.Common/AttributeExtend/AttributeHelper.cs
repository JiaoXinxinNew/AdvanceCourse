using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism.Common.AttributeExtend
{
    public static class AttributeHelper
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetRemark(this PropertyInfo property)
        {
            if (property.IsDefined(property.GetType(), true))
            {
                RemarkAttribute remarkAttribute = property.GetCustomAttribute(typeof(RemarkAttribute), true) as RemarkAttribute;
                return remarkAttribute.GetRemark();
            }
            else
                return property.Name;
        }
    }
}

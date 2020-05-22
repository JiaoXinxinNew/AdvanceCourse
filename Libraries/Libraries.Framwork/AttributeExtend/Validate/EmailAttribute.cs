using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class EmailAttribute : AbstractValidateAttribute
    {
        public override bool Validate<T>(T value)
        {
            if (value != null)
            {
                return Regex.IsMatch(value.ToString(), StaticConstant.EmailRegax);
            }
            return false;
        }
    }
}

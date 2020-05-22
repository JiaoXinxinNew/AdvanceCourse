using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend.Validate
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class LengthAttribute : AbstractValidateAttribute
    {
        private readonly int _Min;
        private readonly int _Max;
        public LengthAttribute(int min, int max)
        {
            this._Min = min;
            this._Max = max;
        }
        public override bool Validate<T>(T value)
        {
            string typeName = typeof(T).Name;
            if (value != null)
            {
                int length = value.ToString().Length;
                if (length > this._Min && length < this._Max)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

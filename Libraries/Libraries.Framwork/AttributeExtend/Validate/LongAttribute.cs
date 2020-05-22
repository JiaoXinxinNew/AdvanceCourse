using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend.Validate
{
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
        public class LongAttribute : AbstractValidateAttribute
        {
            private readonly int _Min;
            private readonly int _Max;
            public LongAttribute(int min,int max)
            {
                this._Min = min;
                this._Max = max;    
            }
            public override bool Validate<T>(T value)
            {
                if (value!=null)
                {
                    if (int.TryParse(value.ToString(),out int result))
                    {
                        if (result>this._Min && result>this._Max)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
}

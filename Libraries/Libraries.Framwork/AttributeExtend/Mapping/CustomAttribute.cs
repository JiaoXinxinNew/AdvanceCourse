using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend
{
    public abstract class CustomAttribute : Attribute
    {
        public abstract string GetCustomProperityName();
    }

    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class ColumnAttribute : CustomAttribute
    {
        private readonly string _Name;
        public ColumnAttribute(string name)
        {
            this._Name = name;
        }
        public override string GetCustomProperityName()
        {
            return this._Name;
        }
    } 

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism.Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class RemarkAttribute : Attribute
    {
        private string _Name;
        public RemarkAttribute(string name)
        {
            this._Name = name;
        }
        public string GetRemark()
        {
            return this._Name;
        }
    }
}

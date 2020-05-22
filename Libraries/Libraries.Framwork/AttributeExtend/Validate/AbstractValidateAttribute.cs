﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Framwork.AttributeExtend.Validate
{
    public abstract class AbstractValidateAttribute:Attribute
    {
        public abstract bool Validate<T>(T value);
    }
}
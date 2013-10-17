using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute
    {
        public ModuleAttribute(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }
}

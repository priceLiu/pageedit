using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
   public  class ModuleInfo
    {
        public IBlockHandler Handler
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Editor
        {
            get;
            set;
        }

        public string Viewer
        {
            get;
            set;
        }

        public ModuleSetting Setting
        {
            get;
            set;
        }
    }
}

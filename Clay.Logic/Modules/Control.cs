using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clay.Enums;

namespace Clay.Logic.Modules
{
    public class Control
    {

        private IList<Control> mControls = new List<Control>();

        public string ID { get; set; }

        public string Width { get; set; }

        public bool Clear { get; set; }

        public FloatType Float
        {
            get;
            set;
        }

        public ControlType Type
        {
            get;
            set;
        }

        public string ModuleName
        {
            get;
            set;
        }

        public bool IsPanel { get; set; }

        public bool IsViewItem { get; set; }

        public IList<Control> Controls
        {
            get
            {
                return mControls;
            }
        }
    }
}

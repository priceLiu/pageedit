using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
    public class BControl
    {
       
        public BControl()
        {
            ID = Guid.NewGuid().ToString("N");
            DisplayUpTab = false;
        }    

        private List<BControl> mControls = new List<BControl>();

        public bool IsEdit
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public Context Context
        {
            get;
            set;
        }

        public IList<BControl> Controls
        {
            get
            {
                return mControls;
            }
        }

        public bool DisplayUpTab
        {
            get;
            set;
        }

        public bool IsPanel { get; set; }
       
        public bool IsViewItem { get; set; }

        protected virtual void RenderBeginTag(System.Web.UI.Page page)
        {

        }

        protected virtual void RenderEndTag(System.Web.UI.Page page)
        {

        }

        public virtual void Render(System.Web.UI.Page page)
        {
            RenderBeginTag(page);
            for (int i = 0; i < Controls.Count; i++)
            {
                BControl control = Controls[i];
                control.Context = Context;
                control.IsEdit = IsEdit;
                control.Render(page);
            }
            RenderEndTag(page);
        }
    }
}

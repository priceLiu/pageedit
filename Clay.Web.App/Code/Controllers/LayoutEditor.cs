using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clay.Web.App.Code
{
    [Peanut.Controller("LayoutEditor/")]
    public class LayoutEditor
    {
        public class PageView : PageEditor
        {

        }
        public class PageEditor : Peanut.IView
        {
            public string PageName
            {
                get;
                set;
            }



            public Body Body
            {
                get;
                set;
            }

            public object Execute(Peanut.RequestType type)
            {
                Clay.Logic.Modules.Control control = Utils.ControlService.Load(PageName);
                if (control != null)
                {
                    LoadChilds(control.Controls, Body);
                }
                Body.ID = PageName;
                Body.IsEdit = true;
                return this;
            }
            private void LoadChilds(IList<Clay.Logic.Modules.Control> controls, BControl bc)
            {
                foreach (Clay.Logic.Modules.Control item in controls)
                {
                    BControl child = null;
                    switch (item.Type)
                    {
                        case Enums.ControlType.Div:
                            child = new Div { ID = item.ID, Float = item.Float, Clear = item.Clear, Width = item.Width, IsViewItem = item.IsViewItem, IsPanel = item.IsPanel };
                            break;
                        case Enums.ControlType.Module:
                            child = new ModuleControl { ID = item.ID, ModuleName = item.ModuleName };
                            break;
                    }
                    bc.Controls.Add(child);
                    LoadChilds(item.Controls, child);
                }
            }
        }
    }
}
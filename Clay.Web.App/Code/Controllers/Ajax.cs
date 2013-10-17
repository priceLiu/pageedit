using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clay.Web.App.Code.Controllers
{
    [Peanut.Controller("ajax/")]
    public class Ajax
    {
        public class AddDiv : Peanut.IView
        {
            
            public string ParentID
            {
                get;
                set;
            }

            public int Columns
            {
                get;
                set;
            }

            public object Execute(Peanut.RequestType type)
            {
                AjaxStatus result = new AjaxStatus();
                try
                {

                    Utils.ControlService.AddControl(ParentID, Columns);
                }
                catch (Exception e)
                {
                    result.Error = e;
                }
                return result;
            }
        }

        public class DivArrowup : Peanut.IView
        {
            public string ControlID
            {
                get;
                set;
            }

            public object Execute(Peanut.RequestType type)
            {
                AjaxStatus result = new AjaxStatus();
                try
                {

                    Utils.ControlService.ControlArrowup(ControlID);
                }
                catch (Exception e)
                {
                    result.Error = e;
                }
                return result;
            }
        }

        public class DelDiv : Peanut.IView
        {

            public string ControlID
            {
                get;
                set;
            }

            public object Execute(Peanut.RequestType type)
            {
                AjaxStatus result = new AjaxStatus();
                try
                {

                    Utils.ControlService.DelControl(ControlID);
                }
                catch (Exception e)
                {
                    result.Error = e;
                }
                return result;
            }
        }

        public class AddModule : Peanut.IView
        {
            public string ParentID
            {
                get;
                set;
            }
            public string ModuleName
            {
                get;
                set;
            }
            public object Execute(Peanut.RequestType type)
            {
                AjaxStatus result = new AjaxStatus();
                try
                {
                    Utils.ControlService.AddModule(ParentID, ModuleName);
                    
                }
                catch (Exception e)
                {
                    result.Error = e;
                }
                return result;
            }
        }

        public class DelModule: Peanut.IView
        {

            public string ControlID
            {
                get;
                set;
            }

            public object Execute(Peanut.RequestType type)
            {
                AjaxStatus result = new AjaxStatus();
                try
                {

                    Utils.ControlService.DelModule(ControlID);
                }
                catch (Exception e)
                {
                    result.Error = e;
                }
                return result;
            }
        }

    }
}
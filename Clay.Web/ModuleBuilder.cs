using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Clay.Web
{
   public  class ModuleBuilder
    {
        internal ModuleBuilder(ModuleInfo info)
        {
            Module = info;

        }

        public ModuleInfo Module
        {
            get;
            set;
        }

       

        public void EditorSave(Context context)
        {
            HttpContext http = HttpContext.Current;
            try
            {
                if (Module.Handler != null)
                    Module.Handler.EditorSave(context, HttpContext.Current.Request.Params);
                http.Response.Write("true");

            }
            catch (Exception e_)
            {
                http.Response.Write(e_.Message);
                Context.GetLog_s<ModuleBuilder>().Error(string.Format("{0} editor save data error!", Module.Name), e_);
            }
            http.Response.Flush();
            http.Response.End();
        }

        public void ViewerReader(Context context, System.Web.UI.Page page)
        {
            Context.Current = context;
            try
            {
                if (Module.Handler != null)
                    Module.Handler.ViewerLoad(context, HttpContext.Current.Request.Params);
            }
            catch (Exception e_)
            {
                Context.GetLog_s<ModuleBuilder>().Error(string.Format("{0} viewer load data error!", Module.Name), e_);
            }
            try
            {

                page.LoadControl(Module.Viewer).RenderControl(new HtmlTextWriter(HttpContext.Current.Response.Output));
            }
            catch (Exception e_)
            {
                Context.GetLog_s<ModuleBuilder>().Error(string.Format("{0} viewer load control error!", Module.Name), e_);
            }
        }

        public void EditorReader(Context context, System.Web.UI.Page page)
        {
            Context.Current = context;            
            try
            {
                if (Module.Handler != null)
                    Module.Handler.EditorLoad(context,  HttpContext.Current.Request.Params);
            }
            catch (Exception e_)
            {
                Context.GetLog_s<ModuleBuilder>().Error(string.Format("{0} editor load data error!", Module.Name), e_);
            }
            try
            {
                page.LoadControl(Module.Editor).RenderControl(new HtmlTextWriter(HttpContext.Current.Response.Output));
            }
            catch (Exception e_)
            {
                Context.GetLog_s<ModuleBuilder>().Error(string.Format("{0} editor load control error!", Module.Name), e_);
            }
        }
    }
}

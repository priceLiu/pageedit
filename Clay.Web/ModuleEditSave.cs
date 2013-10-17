using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace Clay.Web
{
    public class ModuleEditSave : System.Web.SessionState.IRequiresSessionState,
        System.Web.IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(System.Web.HttpContext context)
        {
            try
            {
                string controlid = HttpContext.Current.Request["controlid"];
                string ModuleName = context.Request["ModuleName"];
                ModuleBuilder builder = Clay.Web.Utils.GetModuleBuilder(ModuleName);
                Clay.Context ct = new Context();
                ct["TEXT_MODULE_CONTROLID"] = controlid;
                builder.Module.Handler.EditorSave(ct, HttpContext.Current.Request.Params);
                context.Response.Write("Success");
            }
            catch (Exception e)
            {
                context.Response.Write(e.Message);
            }
            context.Response.Flush();
        }
    }
}

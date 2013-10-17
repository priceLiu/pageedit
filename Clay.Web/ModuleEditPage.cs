using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;

namespace Clay.Web
{
    public class ModuleEditPage : System.Web.SessionState.IRequiresSessionState,
        System.Web.IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(System.Web.HttpContext context)
        {
            string ModuleName = context.Request["ModuleName"];
            string id = context.Request["CONTROLID"];
            Page page = new Page();
            StringWriter output = new StringWriter();
            ModuleBuilder builder = Utils.GetModuleBuilder(ModuleName);
            if (builder != null)
            {

                Context ctx = new Context();
                ctx["CONTROLID"] = id;
                builder.EditorReader(ctx, page);
            }
            else
            {
                Context.GetLog_s<ModuleEditPage>().Error(string.Format( "[{0}] module not found!",ModuleName));
            }
            HttpContext.Current.Server.Execute(page, output, false);
            context.Response.Write(output.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
    public class PageViewFactory : System.Web.UI.PageHandlerFactory
       
    {
        public override System.Web.IHttpHandler GetHandler(System.Web.HttpContext context, string requestType, string virtualPath, string path)
        {
            string aspxname = System.IO.Path.GetFileName(virtualPath).ToLower();
            System.Web.IHttpHandler httphandler = GetCustomHandler(aspxname);
            if (httphandler == null)
            {
                if (IsSystemPage(virtualPath))
                    return base.GetHandler(context, requestType, virtualPath, path);
                virtualPath = context.Request.ApplicationPath + "PageView.aspx";
                path = System.Web.HttpContext.Current.Server.MapPath(virtualPath);
                return base.GetHandler(context, requestType, virtualPath, path);
            }
            return httphandler;
        }
        private bool IsSystemPage(string virtualPate)
        {
            return virtualPate.IndexOf("ajax/", StringComparison.CurrentCultureIgnoreCase) >= 0
                || virtualPate.IndexOf("LayoutEditor/", StringComparison.CurrentCultureIgnoreCase) >= 0
                || virtualPate.IndexOf("admin/", StringComparison.CurrentCultureIgnoreCase )>= 0;
        }
        private System.Web.IHttpHandler GetCustomHandler(string pagename)
        {
            switch (pagename)
            {
                case "moduleviewpage.aspx":
                    return new ModuleViewPage();
                case "moduleeditsave.aspx":
                    return new ModuleEditSave();
                case "moduleedit.aspx":
                    return new ModuleEditPage();

            }
            return null;
        }
    }
}

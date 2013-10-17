using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smark.Data;
using Clay.Modules;
namespace Clay.Web.Module.Text
{
    [ModuleAttribute("HtmlText")]
    public class HtmlTextHandler : Clay.IBlockHandler
    {
        public const string TEXT_MODULE_CONTROLID = "TEXT_MODULE_CONTROLID";
        public const string TEXT_MODULE_HTMLDATA = "TEXT_MODULE_HTMLDATA";
        
        public void EditorLoad(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            string id = values[TEXT_MODULE_CONTROLID];
            context[TEXT_MODULE_HTMLDATA] = DBContext.Load<HtmlTextModule>(id);
        }

        public void EditorSave(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            string id = (string)context[TEXT_MODULE_CONTROLID];
            string value = values[TEXT_MODULE_HTMLDATA];
            HtmlTextModule htm = DBContext.Load<HtmlTextModule>(id);
            if (htm == null)
            {
                htm = new HtmlTextModule();
                htm.ControlID = id;
            }
            htm.Html = value;
            DBContext.Save(htm);
        }

        public void ViewerLoad(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            string id = (string)context[TEXT_MODULE_CONTROLID];
            context[TEXT_MODULE_HTMLDATA] = DBContext.Load<HtmlTextModule>(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clay.Modules;
namespace Clay.Web.Module.Text
{
    [ModuleAttribute("text")]
    public class TextHandler:Clay.IBlockHandler
    {
        public const string TEXT_MODULE_ITEMS = "TEXT_MODULE_ITEMS";
        public const string TEXT_MODULE_ID = "TEXT_MODULE_ID";
        public const string TEXT_ITEM_ID = "TEXT_ITEM_ID";
        public const string TEXT_MODULE_CONTROLID = "TEXT_MODULE_CONTROLID";
        public const string TEXT_MODULE_ITEM = "TEXT_MODULE_ITEM";
        
        public void EditorLoad(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            context[TEXT_MODULE_ITEMS] = new Smark.Data.Expression().List<TextModule>();
        }

        public void EditorSave(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            
        }

        public void ViewerLoad(Context context, System.Collections.Specialized.NameValueCollection values)
        {
            string id = (string)context[TEXT_MODULE_ID];
            context[TEXT_MODULE_ITEM] = (TextModule.iD == ControlLinkText.textID[ControlLinkText.controlID == id]).ListFirst<TextModule>();
            
        }
    }
}

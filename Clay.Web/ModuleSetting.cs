using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Clay.Web
{
   public  class ModuleSetting
    {
        private System.Collections.Specialized.NameValueCollection mProperties = new System.Collections.Specialized.NameValueCollection();

        public System.Collections.Specialized.NameValueCollection Properties
        {
            get
            {
                return mProperties;
            }
        }

        public Layout EditDialog;

        public struct Layout
        {
            public string Width;
            public string Height;
            public string Title;
        }

        public void Load(string file)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(file);
            XmlNode Setting = doc.LastChild;
            
            XmlNode dialog = Setting["EditDialog"];
            EditDialog.Height = dialog.Attributes["height"].Value;
            EditDialog.Width = dialog.Attributes["width"].Value;
            EditDialog.Title = dialog.Attributes["title"].Value;
            foreach (XmlNode item in Setting["Params"].ChildNodes)
            {
                mProperties[item.Attributes["name"].Value] = item.Attributes["value"].Value;
            }

        }
    }
}

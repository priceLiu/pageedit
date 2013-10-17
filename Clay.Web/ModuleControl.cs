using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay.Web
{
    public class ModuleControl : BControl
    {
        public string ModuleName
        {
            get;
            set;
        }
        public ModuleBuilder Builder
        {
            get;
            set;
        }
        public override void Render(System.Web.UI.Page page)
        {
            RenderBeginTag(page);
            Builder = Utils.GetModuleBuilder(ModuleName);
            Context["TEXT_MODULE_CONTROLID"] = ID;
            Builder.ViewerReader(Context, page);
            RenderEndTag(page);
        }

        protected override void RenderBeginTag(System.Web.UI.Page page)
        {
            if (IsEdit)
            {
                page.Response.Write("<div class=\"control_module_edit\">");
                
            }
            else
                page.Response.Write("<div class=\"control_module\">");


        }

        protected override void RenderEndTag(System.Web.UI.Page page)
        {
            if (IsEdit)
            {
                page.Response.Write("<div class=\"module_edit_bar\">");
                page.Response.Write("<a href=\"javascript:void(0)\" class=\"delbutton\" onclick=\"onDelModule('" + ID + "')\">删除</a>");
                page.Response.Write("<a href=\"javascript:void(0)\" class=\"editbutton\" onclick=\"onEditModule('" + ID + "','" + ModuleName + "','" + Builder.Module.Setting.EditDialog.Width + "','" + Builder.Module.Setting.EditDialog.Height + "')\">编辑</a>");
                if (DisplayUpTab)
                    page.Response.Write("<a href=\"javascript:void(0)\" class=\"upcontrol\"  onclick=\"onArrowup('" + ID + "')\"></a>");

                page.Response.Write("</div>");
            }
            page.Response.Write("</div>");
        }
    }
}

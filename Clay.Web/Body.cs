using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace Clay.Web
{
    public class Body:BControl
    {
        public Body()
        {
            Width = "1024px";
        }
        public string Width
        {
            get;
            set;
        }
        protected override void RenderBeginTag(System.Web.UI.Page page)
        {
            if(IsEdit)
                page.Response.Write("<div id=\"_page_body\" class=\"control_body_edit\"");
            else
                page.Response.Write("<div class=\"control_body\"");
            page.Response.Write(" style=\"");
            page.Response.Write("width:" + Width);
            page.Response.Write("\">");
            if (IsEdit)
            {
                page.Response.Write("<div class=\"edit_bar\">");

                page.Response.Write("<a href=\"javascript:void(0)\" class=\"addLayout\" onclick=\"onAddLayout('" + ID + "')\">添加布局</a>");
                page.Response.Write("<a href=\"javascript:void(0)\" class=\"editbutton\" onclick=\"onEditBody('" + ID + "')\">编辑</a>");
                page.Response.Write("</div>");
            }
            
            
        }
        public virtual void Render(System.Web.UI.Page page)
        {
            RenderBeginTag(page);
            for (int i = 0; i < Controls.Count; i++)
            {
                BControl control = Controls[i];
                control.DisplayUpTab = i > 0;
                control.Context = Context;
                control.IsEdit = IsEdit;
                control.Render(page);
            }
            RenderEndTag(page);
        }
        protected override void RenderEndTag(System.Web.UI.Page page)
        {
           
            page.Response.Write("</div>");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clay.Enums;
namespace Clay.Web
{
    public class Div : BControl
    {
        public Div()
        {
            Float = FloatType.none;
            
        }

        public string Width
        {
            get;
            set;
        }

        public string Position
        {
            get;
            set;
        }

        public string Right
        {
            get;
            set;
        }

        public FloatType Float
        {
            get;
            set;
        }

        public bool Clear
        {
            get;
            set;
        }
        
        protected override void RenderBeginTag(System.Web.UI.Page page)
        {
            if (IsEdit)
            {
                page.Response.Write("<div class=\"control_div_edit\"");
                
            }
            else
                page.Response.Write("<div class=\"control_div\"");
            page.Response.Write(" style=\"");
            if (IsViewItem)
                page.Response.Write("min-height:40px;");
            page.Response.Write("width:" + Width + ";float:" + Float + ";Position:" + Position + ";Right:" + Right);
            page.Response.Write("\">");
            if (IsEdit)
            {
               
                page.Response.Write("<div class=\"edit_bar\" >");
                
                if (IsViewItem)
                    page.Response.Write("<a href=\"javascript:void(0)\" class=\"addmodule\" onclick=\"onAddModule('" + ID + "')\">添加模块</a>");
                page.Response.Write("<a href=\"javascript:void(0)\" class=\"editbutton\" onclick=\"onEditLayout('" + ID + "')\">编辑</a>");

                if (IsPanel)
                {
                   
                    page.Response.Write("<a href=\"javascript:void(0)\" class=\"delbutton\" onclick=\"onDelLayout('" + ID + "')\">删除</a>");
                    if (DisplayUpTab)
                        page.Response.Write("<a href=\"javascript:void(0)\" class=\"upcontrol\"  onclick=\"onArrowup('" + ID + "')\"></a>");
                }
                page.Response.Write("</div>");
            }
        }       

        public override void Render(System.Web.UI.Page page)
        {
            if (Controls.Count > 1 && IsPanel)
                Position = "relative";
            RenderBeginTag(page);
            for (int i = 0; i < Controls.Count; i++)
            {
                BControl control = Controls[i];
                if (control is Div && Controls.Count > 1)
                {
                    if (i == Controls.Count - 1)
                    {
                        ((Div)control).Float = FloatType.right;
                        ((Div)control).Right = "0";
                        ((Div)control).Position = "absolute";
                    }
                    else
                        ((Div)control).Float = FloatType.left;
                }
                if (IsViewItem)
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
            if (Controls.Count > 0 && Controls[Controls.Count - 1] is Div)
                page.Response.Write("<div style=\"clear:both\"/>");
        }
    }
}

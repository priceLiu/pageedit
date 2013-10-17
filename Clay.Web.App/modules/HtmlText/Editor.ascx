<%@ Control Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="Clay.Web.Module.Text" %>
<%
    HtmlTextModule module = (HtmlTextModule)Clay.Context.Current[HtmlTextHandler.TEXT_MODULE_HTMLDATA];
 %>
<textarea id="customHtmlEditor"  style="width:770px;height:430px;visibility:hidden;"><%=(module!=null?module.Html:"")%>
</textarea>
    <script>
        function ModuleInit() {
            OnCreateEditory('#customHtmlEditor');
            
        }
        function ModuleData() {
            var obj = { TEXT_MODULE_HTMLDATA: keditor_content.html() }
            return obj;
        }
    </script>
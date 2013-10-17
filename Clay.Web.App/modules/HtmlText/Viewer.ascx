<%@ Control Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="Clay.Web.Module.Text" %>
<%
    HtmlTextModule module = (HtmlTextModule)Clay.Context.Current[HtmlTextHandler.TEXT_MODULE_HTMLDATA];
 %>
 <div>
 <%=(module!=null?module.Html:"")%>
 </div>
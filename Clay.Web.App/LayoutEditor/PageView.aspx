<%@ Page Language="C#" AutoEventWireup="true" %>
<%
    LayoutEditor.PageEditor pageedit = (LayoutEditor.PageEditor)WebContext.Current.View;
     
%>
 <% pageedit.Body.Render(this); %>
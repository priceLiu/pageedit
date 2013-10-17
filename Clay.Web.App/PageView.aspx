<%@ Page Language="C#" AutoEventWireup="true"  %>
<%
    Controller.PageView pageedit = (Controller.PageView)WebContext.Current.View;
     
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
<p style="text-align:center"><a href="LayoutEditor/PageEditor.aspx?pagename=<%=Request.FilePath %>">编辑 </a></p>
   <%if (WebContext.Current.AppError != null)
      { %>
    <p>
        <%=WebContext.Current.AppError.Message %></p>
    <%} %>
    <%  
        pageedit.Body.IsEdit = false;
        pageedit.Body.Render(this); %>
</body>
</html>

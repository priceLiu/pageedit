<%@ Control Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="Clay.Web.Module.Text" %>
<%
    IList<TextModule> items = (IList<TextModule>)Clay.Context.Current[TextHandler.TEXT_MODULE_ITEMS];
    %>
    <ul>
    <%
    HtmlHelper.Each<TextModule>(items, (i, d) => { 
    %>
    <li><input type="radio" value="<%=d.ID %>" name="TEXT_ITEM_ID" /><%=d.Title %></li>
    <%});%>
    </ul>
    <script>
        function ModuleInit() {

        }

        function ModuleData() {
            return {TEXT_ITEM_ID: $('input:radio[name=TEXT_ITEM_ID]:checked').val()};
        }
    </script>
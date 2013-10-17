<%@ Page Language="C#" AutoEventWireup="true"  %>

<div class="editmodules">
<input id="parentid" type="hidden" value="<%=Request["parentid"] %>" />
<ul>
<%foreach(Clay.Web.ModuleBuilder item in Clay.Web.Utils.GetModules){%>
<li>
    <table class="style1">
        <tr>
            <td>
                <input type="radio" name="module" value="<%=item.Module.Name %>" /></td>
                <td>
                <img src="/modules/<%=item.Module.Name %>/icon.png"/></td>
            <td>
                <%=item.Module.Setting.EditDialog.Title %></td>
            
        </tr>
    </table>

</li>
<%} %>

</ul>
</div>
<script>
    function onSaveAddModule() {
        var module = $('input:radio[name=module]:checked').val();
        if (!module) {
            alert('请选择添加的模块!');
            return;
        }
        var value = { parentid: $('#parentid').val(),ModuleName:module };
        $.post("../ajax/AddModule.aspx", value, function (data) {
            if (data == "Success") {
                $('#add_module_dialog').dialog("close");
                onLoadPage();
            }
            else {
                alert(data);
            }
        });
    }
</script>

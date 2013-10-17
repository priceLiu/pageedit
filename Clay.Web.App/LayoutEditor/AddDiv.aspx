<%@ Page Language="C#" AutoEventWireup="true" %>
<form id="form_adddiv">
<input type="hidden" name="parentid" value="<%=Request.QueryString["parentid"]%>" />
<div class="editor_center" style="width: 200px">
    <p>
        <label>
            列数量:</label><input id="layoutColumns" name="columns" type="text" style="width: 60px" value="1" /></p>
    <p>
</div>
</form>
<script>
    function onSaveLayout() {
        if ($('#layoutColumns').val() < 1 || $('#layoutColumns').val()>5) {
            alert('布局列数量必须大于1,小于5!');
            return;
        }
        var value = $('#form_adddiv').serialize()
        $.post("../ajax/adddiv.aspx", value, function (data) {
            if (data == "Success") {
                $('#add_div_dialog').dialog("close");
                onLoadPage();
            }
            else {
                alert(data);
            }
        });
    }
</script>

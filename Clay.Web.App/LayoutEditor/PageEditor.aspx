<%@ Page Language="C#" AutoEventWireup="true" %>

<%
    LayoutEditor.PageEditor pageedit = (LayoutEditor.PageEditor)WebContext.Current.View;
     
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../Styles/editpage.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../KindEditor/kindeditor-all-min.js" type="text/javascript"></script>
    <link href="../KindEditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <script src="../KindEditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../scripts/colorpicker.js" type="text/javascript"></script>
    <link href="../Styles/colorpicker/colorpicker.css" rel="stylesheet" type="text/css" />
    <title>Clay 页面编辑器:<%=pageedit.PageName %></title>
</head>
<body>
<div class="editheader">
<div class="headerbody"><span> <%=pageedit.PageName %></span> </div>
</div>
    <%if (WebContext.Current.AppError != null)
      { %>
    <p>
        <%=WebContext.Current.AppError.Message %></p>
    <%} %>
    <div id="_editcontent">
    <% pageedit.Body.Render(this); %>
    </div>
    <div class="editfooter">
    
    </div>
    <div id="add_div_dialog" title="添加布局">
        <div id="add_div_content">
        </div>
    </div>
    <div id="edit_div_dialog" title="布局编辑">
        <div id="edit_div_content">
        </div>
    </div>
    <div id="add_module_dialog" title="添加模块">
        <div id="add_module_content">
        </div>
    </div>
     <div id="edit_module_dialog" title="编辑模块">
        <div id="edit_module_content">
        </div>
    </div>
    <script>
        var keditor_content;
        var ke_content;
        KindEditor.ready(function (K) {
            ke_content = K;
        });

        $(function () {
            $("#add_div_dialog").dialog({
                resizable: false,
                autoOpen: false,
                height: 150,
                width: 220,
                modal: true,
                buttons: {
                    "确定": function () {
                        onSaveLayout();
                    },
                    "取消": function () {

                        $(this).dialog("close");
                    }
                }
            });

            $("#edit_div_dialog").dialog({
                resizable: false,
                autoOpen: false,
                height: 500,
                width: 500,
                modal: true,
                buttons: {
                    "确定": function () {
                        
                    },
                    "取消": function () {

                        $(this).dialog("close");
                    }
                }
            });

            $("#edit_module_dialog").dialog({
                resizable: false,
                autoOpen: false,
                height: 350,
                width: 500,
                modal: true,
                buttons: {
                    "确定": function () {
                        onSaveModule();
                    },
                    "取消": function () {

                        $(this).dialog("close");
                    }
                }
            });
            $("#add_module_dialog").dialog({
                resizable: false,
                autoOpen: false,
                height: 350,
                width: 500,
                modal: true,
                buttons: {
                    "确定": function () {
                        onSaveAddModule();
                    },
                    "取消": function () {

                        $(this).dialog("close");
                    }
                }
            });
        });

        var pagename = "<%=pageedit.PageName %>";

        function onLoadPage() {
            $('#_editcontent').load('PageView.aspx?pagename=' + pagename + '&tag=' + new Date().valueOf());
        }
        function onAddModule(parentid) {
            $('#add_module_content').load('AddModule.aspx?parentid=' + parentid + "&tag=" + new Date().valueOf(), function () {
                $('#add_module_dialog').dialog("open");
            });
        }
        function onAddLayout(parentid) {
            $('#add_div_content').load('adddiv.aspx?parentid=' + parentid + "&tag=" + new Date().valueOf(), function () {
                $('#add_div_dialog').dialog("open");
            });
        }
        function onArrowup(controlid) {
            $.post("../ajax/DivArrowup.aspx", { ControlID: controlid }, function (data) {
                if (data == "Success") {
                    onLoadPage();
                }
                else {
                    alert(data);
                }
            });
        }
        function onDelLayout(controlid) {
            if (confirm('是否要删除当前布局栏?')) {
                $.post("../ajax/DelDiv.aspx", { ControlID: controlid }, function (data) {
                    if (data == "Success") {
                        onLoadPage();
                    }
                    else {
                        alert(data);
                    }
                });
            }
        }
        function onEditModule(controlid, modulename, width, height, title) {
            module_controlid = controlid;
            module_name = modulename;
            $('#edit_module_content').load('ModuleEdit.aspx?TEXT_MODULE_CONTROLID=' + controlid + '&modulename=' + modulename + '&tag=' + new Date().valueOf(), function () {
                ModuleInit();
                $("#edit_module_dialog").dialog("option", "width", width);
                $("#edit_module_dialog").dialog("option", "height", height);
                $('#edit_module_dialog').dialog("open");
            });
        }
        var module_controlid;
        var module_name;
        function onSaveModule() {
            var data = ModuleData();
            $.post("ModuleEditSave.aspx?ControlID=" + module_controlid + "&ModuleName=" + module_name + '&tag=' + new Date().valueOf(), data, function (data) {
                if (data == "Success") {
                    $('#edit_module_dialog').dialog("close");
                    onLoadPage();
                }
                else {
                    alert(data);
                }
            });
        }
        function onDelModule(controlid) {
            if (confirm('是否要删除当前模块?')) {
                $.post("../ajax/DelModule.aspx", { ControlID: controlid }, function (data) {
                    if (data == "Success") {
                        onLoadPage();
                    }
                    else {
                        alert(data);
                    }
                });
            }
        }
        function onEditLayout(controlid) {
            $('#edit_div_content').load('DivEditor.aspx?controlid=' + controlid + "&tag=" + new Date().valueOf(), function () {
                $('#edit_div_dialog').dialog("open");
                divEditInit();
            });
        }

       

        function OnCreateEditory(id) {
            if (keditor_content)
                keditor_content.remove();
            keditor_content = ke_content.create(id);
        }
    </script>
</body>
</html>

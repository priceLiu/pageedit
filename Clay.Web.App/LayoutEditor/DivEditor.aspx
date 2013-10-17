<%@ Page Language="C#" AutoEventWireup="true"  %>
<table >
    <tr>
        <td style="text-align: right">
            宽度</td>
        <td>
            <input type="text" value="40px" /></td>
            
    </tr>
    <tr>
        <td>
            背景颜色</td>
        <td>
            <input type="text" maxlength="6" size="6" id="divdgcolor" value="" />
            <div id="colorpickerholder2">
                </div>
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            边框</td>
        <td>
            <table class="style1">
                <tr>
                    <td colspan="2" style="text-align: center;width:100px">
                        内边框</td>
                    <td colspan="2" style="text-align: center;width:100px">
                        外边框</td>
                </tr>
                <tr>
                    <td>
                        上</td>
                    <td class="style2">
            <input type="text" value="0px" style="width: 35px" /></td>
                    <td>
                        上</td>
                    <td>
            <input type="text" value="0px" style="width: 35px" /></td>
                </tr>
                <tr>
                    <td>
                        右</td>
                    <td class="style2">
            <input type="text" value="0px" style="width: 35px" /></td>
                    <td>
                        右</td>
                    <td>
            <input type="text" value="0px" style="width: 35px" /></td>
                </tr>
                <tr>
                    <td>
                        低</td>
                    <td class="style2">
            <input type="text" value="0px" style="width: 35px" /></td>
                    <td>
                        低</td>
                    <td>
            <input type="text" value="0px" style="width: 35px" /></td>
                </tr>
                <tr>
                    <td>
                        左</td>
                    <td class="style2">
            <input type="text" value="0px" style="width: 35px" /></td>
                    <td>
                        左</td>
                    <td>
            <input type="text" value="0px" style="width: 35px" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script>
    function divEditInit() {
        $('#colorpickerholder2').ColorPicker({
            flat: true,
            color: '#FFFFFF',
            onChange: function (hsb, hex, rgb) {
                
                $('#divdgcolor').val(hex);
            }
        });

    }

</script>


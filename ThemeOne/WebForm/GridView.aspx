<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="ThemeOne.WebForm.GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/_theme/jqwidgets-ver3.8.1/jqwidgets/styles/jqx.base.css" rel="stylesheet"
        type="text/css" />
    <link href="/_theme/jqwidgets-ver3.8.1/jqwidgetsExtensions/jqxext.css" rel="stylesheet"
        type="text/css" />
    <script src="/_theme/jqwidgets-ver3.8.1/scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
 
 
    <script src="/_theme/jqwidgets-ver3.8.1/jqwidgets/jqx-all.js" type="text/javascript"></script>
    <script src="/_theme/jqwidgets-ver3.8.1/jqwidgetsExtensions/jqxext.js" type="text/javascript"></script>
    <script src="/_theme/jqwidgets-ver3.8.1/jqwidgets/globalization/globalize.js" type="text/javascript"></script>
    <script src="/_theme/jqwidgets-ver3.8.1/jqwidgets/globalization/globalize.culture.zh.js"
        type="text/javascript"></script>
    <script src="/_theme/tool/ejq.js" type="text/javascript"></script>
    <script src="/_theme/tool/jquery-form.min.js" type="text/javascript"></script>
        <script src="/areas/griddemo/views/_js/default.js" type="text/javascript"></script>
    <title></title>
      <%=this.Grid %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="grid">
    </div>
    </form>
</body>
</html>
<div id="editbox" class="hide">
    <div class="savetable">
        <form id="frmtable" class="form">
        <table style="table-layout: fixed; border-style: none;">
            <tr>
                <td align="right">
                    名称:
                </td>
                <td align="left">
                    <input id="id" name="id" type="hidden" value="0" />
                    <input id="name" name="name" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    产品名:
                </td>
                <td align="left">
                    <input id="productname" name="productname" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    数量:
                </td>
                <td align="left">
                    <input id="quantity" name="quantity" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    时间:
                </td>
                <td align="left">
                    <div id="date" name="date" >
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <br />
                    <button id="save" type="button">
                        保存</button>
                    <button style="margin-left: 5px;" type="button" id="cancel">
                        取消</button>
                </td>
            </tr>
        </table>
        </form>
    </div>
</div>
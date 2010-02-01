<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditField.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.EditField" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Field</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout">
    <form id="EditField" method="post" enctype="multipart/form-data" runat="server">
    <div>
        <table class="gbtext" id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" height="38">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr height="30">
                            <td class="GbText" style="width: 23px" align="right" width="23" background="../../../Images/treetopbg.jpg"
                                bgcolor="#c0d9e6">
                                <font color="#003366" size="3">
                                    <img height="16" src="../../../DataImages/DocFlow.gif" width="16"></font>
                            </td>
                            <td class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                <font color="#006699">
                                    <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                        Width="53px">  表单字段类型设计</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </font>&nbsp;</font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <font face="宋体"></font>
                            <td align="right" height="22">
                                <asp:Label ID="lblStyleName" runat="server">字段类型名称：</asp:Label>
                            </td>
                            <td height="22">
                                <asp:TextBox ID="txtFieldName" runat="server" Width="350px" CssClass="inputcss"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtFieldName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:Label ID="lblStyleRemark" runat="server">类型：</asp:Label>
                            </td>
                            <td>
                                &nbsp;<asp:radiobutton id="ddlYes" runat="server" Text="下拉列表" GroupName="Judged" Checked="True"></asp:radiobutton><asp:radiobutton id="ddlNo" runat="server" Text="自动编号" GroupName="Judged"></asp:radiobutton>
                            </td>
                        </tr>  
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" 
                                    Text="确定" onclick="cmdOK_Click">
                                </asp:Button><font face="宋体">&nbsp; </font>
                                <input class="buttoncss" style="width: 60px" onclick="javascript:location.href='SetupField.aspx'"
                                    type="button" value="返回">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

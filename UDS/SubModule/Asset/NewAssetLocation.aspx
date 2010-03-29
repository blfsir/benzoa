<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAssetLocation.aspx.cs" Inherits="UDS.SubModule.Asset.NewAssetLocation" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewAssetLocation</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="JavaScript" src="../../Css/meizzDate.js"></script>

    <style>
        .td
        {
            font-size: 14px;
            color: #0000ff;
        }
    </style>

    <script language="javascript">
		 
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewStaff" method="post" runat="server">
    <center>
            <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" style="table-layout:fixed"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/t5.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width=120"
                align="left">
                <font color="#006699">新增设备存放位置</font>
            </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr>
                <td style="height: 34px" align="right" width="20%" height="34">
                    存放位置:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入存放位置" ControlToValidate="txtName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>  <asp:TextBox ID="lblAssetID" runat="server" Width="0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    备注:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRemark" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="请输入备注" ControlToValidate="txtRemark" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="宋体">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" 
                        Width="60px" Text="确定"
                            Height="20px" onclick="cmdSubmit_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="redButtonCss" style="width: 60px; height: 20px"  
                            type="button" value="返 回" name="cmdReturn"  onclick="javacript:location.href='AssetLocationManage.aspx'" > 
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

<%@ Page Language="c#" CodeBehind="NewDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.NewDocument" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewDocument</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
    <script language="JavaScript" src="../../../Css/meizzDate.js"></script>
    <script type="text/javascript">
    function setTextValue(txtid,ddlid)
    {
        
        document.getElementById(txtid).value = document.getElementById(ddlid).value;
          
    }
    </script>
</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout">
    <form id="NewDocument" method="post" enctype="multipart/form-data" runat="server">
    <input id="PID" type="hidden" value="0" runat="server">
    <asp:Table ID="ht" Style="z-index: 101; left: 8px; position: absolute; top: 100px;
        border-collapse: collapse" runat="server" CellSpacing="1" CellPadding="1" CssClass="GbText"
        BorderWidth="1px" BorderColor="#CCCCCC" BorderStyle="Solid" GridLines="Both"
        Height="33px" Width="100%">
    </asp:Table>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="z-index: 102; left: 615px;
        position: absolute; top: 287px" runat="server" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
    <asp:TextBox ID="TextBox2" Style="z-index: 103; left: 533px; position: absolute;
        top: 292px" runat="server" Height="23px" Width="76px" Visible="False">为了验证加的冗余控件</asp:TextBox>
    <select id="ddlProject" onchange="document.all.PID.value=this.options[this.selectedIndex].value;"
        runat="server">
    </select><asp:Button ID="cmdSave" AccessKey="S" runat="server" CssClass="buttoncss"
        Width="66px" EnableViewState="False" Text="保存"></asp:Button><asp:Button ID="cmdSend"
            AccessKey="T" runat="server" CssClass="buttoncss" Width="66px" EnableViewState="False"
            Text="发送"></asp:Button><asp:Button ID="cmdDelete" AccessKey="D" runat="server" CssClass="ButtonCss"
                Width="66px" EnableViewState="False" Text="删除" CausesValidation="False">
    </asp:Button><asp:Button ID="cmdReturn" AccessKey="R" runat="server" CssClass="ButtonCss"
        Width="66px" EnableViewState="False" Text="返回" CausesValidation="False"></asp:Button>
     
    </form>
</body>
</html>

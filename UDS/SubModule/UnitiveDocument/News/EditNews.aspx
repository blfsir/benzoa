<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.News.EditNews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit News</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script type="text/javascript">
    function TextValidate() 
{ 
    var code; 
    var character; 
    var err_msg = "Text can not contain SPACES or any of these special characters  other than underscore (_) and hyphen (-)."; 
    if (document.all) //判断是否是IE浏览器 
    { 
        code = window.event.keyCode; 
    } 
    else 
    { 
        code = arguments.callee.caller.arguments[0].which; 
    } 
    var character = String.fromCharCode(code); 
     
    var txt=new RegExp("[ ,\\`,\\~,\\!,\\@,\#,\\$,\\%,\\^,\\+,\\*,\\&,\\\\,\\/,\\?,\\|,\\:,\\.,\\<,\\>,\\{,\\},\\(,\\),\\',\\;,\\=,\"]"); 
    //特殊字符正则表达式 
    if (txt.test(character)) 
    { 
        alert("User Name can not contain SPACES or any of these special characters:\n  , ` ~ ! @ # $ % ^ + & * \\ / ? | : . < > {} () [] \" "); 
        if (document.all) 
        { 
            window.event.returnValue = false; 
        } 
        else 
        { 
            arguments.callee.caller.arguments[0].preventDefault(); 
        } 
    } 
}
    </script>

</head>

<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0" style="table-layout:fixed"
        bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">新闻中心</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
            </td>
        </tr>
         <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="10" colspan="3" align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="98%" cellpadding="0" cellspacing="0" class="gbtext" bordercolor="#93bee2" 
                        border="1" style="border-collapse: collapse" align="center" class="GbText" style="background-color: #e8f4ff" 
        id="Table1">
       
        <tr>
            <font face="宋体"></font>
            <td align="left" width="10%">
                <asp:Label ID="lblStyleName" runat="server">新闻标题：</asp:Label>
            </td>
            <td valign="bottom">
                <asp:TextBox ID="txtNewsName" runat="server" Width="95%" CssClass="inputcss"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtNewsName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <asp:Label ID="lblStyleRemark" runat="server">内容：</asp:Label>
            </td>
            <td>
                <input id="SDCDoc" type="hidden" name="SDCDoc" runat="server">
                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="100%" Height="400px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="redbuttoncss" Text="确定"
                    OnClick="cmdOK_Click"></asp:Button><font face="宋体">&nbsp; </font>
                <input class="redbuttoncss" style="width: 60px" onclick="javascript:location.href='NewsManagement.aspx'"
                    type="button" value="返回">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

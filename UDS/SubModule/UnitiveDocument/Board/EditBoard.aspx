<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBoard.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.Board.EditBoard"
    ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Board</title>
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
<%--<body leftmargin="0" topmargin="0" ms_positioning="GridLayout">
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
                                        Width="53px">  公司公告</asp:Label></font>
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
                       <table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#cccccc"
							width="100%" id="AutoNumber2" height="1" class="GbText" align="left">
                        <tr >
                            <font face="宋体"></font>
                            <td align="left" width="10%">
                                <asp:Label ID="lblStyleName" runat="server">公告标题：</asp:Label>
                            </td>
                            <td   valign="bottom">
                                <asp:TextBox ID="txtBoardName" runat="server" Width="95%" CssClass="inputcss"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtBoardName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                      
                        <tr>
                         <td valign="top" align="left">
                                <asp:Label ID="lblStyleRemark" runat="server">内容：</asp:Label>
                            </td>
                            <td  >
                              
                                <input id="SDCDoc" type="hidden" name="SDCDoc" runat="server">
                                <fckeditorv2:fckeditor id="FCKeditor1" runat="server" width="100%" height="500px">
                                                        </fckeditorv2:fckeditor> 
                            </td>
                        </tr>
                       
                        <tr>
                           
                       
                            <td colspan="2" align="center">
                                <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="确定"
                                    OnClick="cmdOK_Click"></asp:Button><font face="宋体">&nbsp; </font>
                                <input class="buttoncss" style="width: 60px" onclick="javascript:location.href='BoardManagement.aspx'"
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
</body>--%>
<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111" style="table-layout:fixed">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">公司公告</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
            </td>
        </tr>
    </table>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
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
        <tr>
            <font face="宋体"></font>
            <td align="left" width="10%">
                <asp:Label ID="lblStyleName" runat="server">公告标题：</asp:Label>
            </td>
            <td valign="bottom">
                <asp:TextBox ID="txtBoardName" runat="server" Width="95%" CssClass="inputcss"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtBoardName"></asp:RequiredFieldValidator>
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
                <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="确定"
                    OnClick="cmdOK_Click"></asp:Button><font face="宋体">&nbsp; </font>
                <input class="buttoncss" style="width: 60px" onclick="javascript:location.href='BoardManagement.aspx'"
                    type="button" value="返回">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

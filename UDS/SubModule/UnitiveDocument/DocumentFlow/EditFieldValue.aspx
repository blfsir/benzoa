<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFieldValue.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.EditFieldValue" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
         <title>Edit Field Value</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

</head>
<body leftmargin="0" topmargin="0" ms_positioning="GridLayout">
    <form id="EditField" method="post" enctype="multipart/form-data" runat="server">
    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td width="20" height="30" align="right" background="../../../Images/treetopbg.jpg"
                                bgcolor="#c0d9e6" class="GbText" style="width: 23px">
                                <font color="#003366" size="3">
                                    <img height="16" src="../../../DataImages/DocFlow.gif" width="16"></font>
                            </td>
                            <td class="GbText" align="center" width="60" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff"><asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
                                        Width="53px">  表单字段类型设计</asp:Label>
                          </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">&nbsp;</td>
                        </tr>
      </table>
<table class="gbtext" id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
      <tr>
          <td valign="top" height="10">
                    
          </td>
      </tr>
      <tr>
          <td>
              <table width="98%" border="1" align="center" cellpadding="3" cellspacing="0" class="gbtext" id="Table2" bordercolor="#93bee2">
                  <tr>
                      <font face="宋体"></font>
                      <td width="120" height="30" align="center" bgcolor="#e8f4ff">
                          <asp:Label ID="lblStyleName" runat="server">名称：</asp:Label>
                      </td>
                      <td height="22">
                          <asp:TextBox ID="txtFieldName" runat="server" Width="350px" CssClass="inputcss"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtFieldName"></asp:RequiredFieldValidator>
                      </td>
                  </tr>   
                  <tr>
                      <td height="30" colspan="2" align="center">
                        
                        <asp:Button ID="cmdOK" runat="server" Width="60px" CssClass="buttoncss" 
                                    Text="确定" onclick="cmdOK_Click">
                        </asp:Button><font face="宋体">&nbsp;&nbsp;</font>
                        <input class="buttoncss" style="width: 60px" onClick="history.back();"
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
    </form>
</body>

</html>

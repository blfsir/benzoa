<%@ Page Language="c#" CodeBehind="NewNote.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Note.NewNote" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewStaff</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <style>
        .td
        {
            font-size: 14px;
            color: #0000ff;
        }
    </style>

    <script language="javascript">
		function ReturnBack(ReturnType)
		{			
			location.href ="NoteManage.aspx";			
		}
		
		/*
去处空格
*/
String.prototype.Trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

		//提交时验证
    function DoValidate()
    {
        //便签内容
        var Contents = document.getElementById("txtContents").value.Trim();
        if(Contents=="" || Contents ==null)
        {
             alert('便签内容不可为空！');
             return false;
        }
        
        return true;
    }
    
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewNote" method="post" runat="server">
    <center>
       <%-- <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font>
                </td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <b><b><b><font face="宋体">新增便签</font></b></b></b>
                </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>--%>
         <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                <font color="#006699">新增便签</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                  &nbsp;</font>
            </td>
        </tr>
    </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
           <%-- <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    用户姓名:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtStaffName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>
                </td>--%>
            </tr>
            
            <tr>
                <td align="right" width="20%" height="30">
                    内容:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtContents" CssClass="InputCss" runat="server" Columns="70"
                        Width="791px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="宋体">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" Width="60px" Text="确定"
                            Height="20px" OnClientClick="return DoValidate();"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="redButtonCss" style="width: 60px; height: 20px" onclick="ReturnBack(<%=ReturnPage%>)"
                            type="button" value="返 回" name="cmdReturn">
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

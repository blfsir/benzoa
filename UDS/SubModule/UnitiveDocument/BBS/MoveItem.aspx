<%@ Page language="c#" Codebehind="MoveItem.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.MoveItem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MoveItem</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="../../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	<body>
		<form id="MoveItem" method="post" runat="server">
			<table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#0066cc" width="50%" height="56" id="AutoNumber1" class="GbText">
				<tr>
					<td width="880" height="9" class="GbText" bgcolor="#0066cc" align="middle">
						<b><font color="#ffffff">移动帖子</font></b></td>
				</tr>
				<tr>
					<td width="880" height="26" bgcolor="#e8f4ff" align="middle">
						<asp:DropDownList id="ddlBoardList" runat="server"></asp:DropDownList>
						<asp:Literal id="ltMessage" runat="server" Visible="False"></asp:Literal>
					</td>
				</tr>
				<tr>
					<td width="880" height="10" bgcolor="#e8f4ff" align="middle">
						<input id="cmdOK" type="submit" class="ButtonCss" value="确 定" runat="server">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

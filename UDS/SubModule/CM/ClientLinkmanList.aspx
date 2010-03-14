<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="UDS.Components"  %>
<%@ Page language="c#" Codebehind="ClientLinkmanList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.ClinetLinkmanList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>联系人列表</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ClinetLinkmanList" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="98%" align="center" border="1" class="gbtext">
					<TR>
						<TD height="30" bgcolor="#E8F4FF">&nbsp;</TD>
					</TR>
					<TR>
						<TD height="30" align="right"><asp:hyperlink id="HyperLink1" runat="server" Target="_blank">添加</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD><asp:radiobuttonlist id="rbl_LinkmanList" runat="server" CssClass="gbtext"></asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD height="30" align="center"><asp:button id="btn_OK" runat="server" Text="确定" CssClass="buttoncss"></asp:button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="RightList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.AssignRule.RightList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RightList</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="RightList" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#93BEE2" cellSpacing="0"
					cellPadding="0" width="100%" align="center" border="1">
					<TR>
						<TD><asp:checkboxlist id="Act" runat="server" BorderColor="#E0E0E0" RepeatLayout="Flow" BorderWidth="1px"
								BorderStyle="Solid" Height="99px" Width="100%"></asp:checkboxlist></TD>
					</TR>
					<TR>
						<TD align="center" height="30"><asp:button id="cmdOK" runat="server" Text="确 定" Width="60px" CssClass="buttoncss"></asp:button>&nbsp;<asp:button id="cmdReturn" runat="server" Text="返 回" Width="60px" CssClass="buttoncss"></asp:button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="ClientHistoryContact.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.ClientHistoryContact" %>
<%@ Register TagPrefix="uc1" TagName="ControlClientContactHistory" Src="../../Inc/ControlClientContactHistory.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientHistoryContact</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ClientHistoryContact" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" class="gbtext" cellSpacing="0" style="BORDER-COLLAPSE: collapse" cellPadding="0"
					width="98%" border="1" bordercolor="#93bee2" align="left">
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF" class="gbtext">&nbsp;客户名称</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_ClientName" runat="server"></asp:Literal></TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;客户简称</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_ClientShortName" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;更新时间</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_UpdateTime" runat="server"></asp:Literal></TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;发现时间</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_Birthday" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;接洽次数</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_ContactTimes" runat="server"></asp:Literal></TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;销售阶段</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_SellPhase" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;成交预估</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_BargainPrognosis" runat="server"></asp:Literal></TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;发生费用</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_Fee" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;销售人员</TD>
						<TD>
							&nbsp;<asp:Literal id="ltl_AddMan" runat="server"></asp:Literal></TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;历史接触记录</TD>
						<TD>&nbsp;</TD>
						<TD width="120" bgcolor="#E8F4FF">&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="4" height="30">
							<uc1:ControlClientContactHistory id="ControlClientContactHistory1" runat="server"></uc1:ControlClientContactHistory></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

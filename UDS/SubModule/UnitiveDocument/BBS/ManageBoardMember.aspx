<%@ Page language="c#" Codebehind="ManageBoardMember.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.ManageBoardMember" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageBoardMember</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="ManageBoardMember" method="post" runat="server">
			<div align="center">
				<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"></FONT></TD>
						<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B>论坛成员管理</B></TD>
					</TR>
				</TABLE>
				<FONT face="宋体">
					<BR>
				</FONT>
				<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="517" height="240" id="AutoNumber1">
					<tr>
						<td width="232" height="240" rowspan="4"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								成&nbsp;&nbsp;&nbsp;&nbsp; 员</FONT>
							<asp:ListBox id="lbBoardMemberList" runat="server" Height="220px" Width="230px" SelectionMode="Multiple"></asp:ListBox>
						</td>
						<td width="50" height="86"><FONT face="宋体"></FONT>
						</td>
						<td width="228" height="240" rowspan="4"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								&nbsp; 人&nbsp;&nbsp; &nbsp; 员</FONT>
							<asp:ListBox id="lbRemainStaffsList" runat="server" Height="221px" Width="240px" SelectionMode="Multiple"></asp:ListBox>
						</td>
					</tr>
					<tr>
						<td width="50" height="10" align="middle">
							<asp:Button id="btn_in" runat="server" Text="<<<" CssClass="redbuttoncss"></asp:Button></td>
					</tr>
					<tr>
						<td width="50" height="35" align="middle">
							<asp:Button id="btn_out" runat="server" Text=">>>" CssClass="redbuttoncss"></asp:Button></td>
					</tr>
					<tr>
						<td width="50" height="100"><FONT face="宋体"></FONT>
						</td>
					</tr>
				</table>
				<FONT face="宋体">
					<BR>
				</FONT>
				<DIV align="center"><asp:HyperLink NavigateUrl='<%# "catalog.aspx?classid="+classid.ToString()%>' Runat=server id=HyperLink1>返回</asp:HyperLink><FONT face="宋体"><BR>
					</FONT>
				</DIV>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><IMG height="25" src="../../../Images/temp.gif" width="250"></TD>
						<TD align="right"><IMG height="25" src="../../../images/endbott.gif" width="279"></TD>
					</TR>
				</TABLE>
			</div>
		</form>
	</body>
</HTML>

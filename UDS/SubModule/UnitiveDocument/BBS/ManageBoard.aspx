<%@ Page language="c#" Codebehind="ManageBoard.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.BBS.ManageBoard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageBoard</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="../../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="ManageBoard" method="post" runat="server">
			<div align="center">
				<TABLE style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"></FONT></TD>
						<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B>��̳������</B></TD>
					</TR>
				</TABLE>
				<table border="0" cellpadding="0" cellspacing="0" bordercolor="#111111" width="100%" id="AutoNumber1" height="200">
					<TR>
						<TD class="Gbtext" align="right" width="100" height="30"></TD>
						<TD class="Gbtext" align="left" height="18"></TD>
					</TR>
					<tr>
						<td height="30" class="Gbtext" align="right" width="100">
							������ƣ�</td>
						<td height="18" class="Gbtext" align="left">&nbsp;
							<asp:TextBox id="TxtBoardName" runat="server" Width="500px" CssClass="inputcss"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvboardname" runat="server" ErrorMessage="����д�������" ControlToValidate="TxtBoardName">����д�������</asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td height="140" class="Gbtext" align="middle" valign="top">
							�����ܣ�</td>
						<td width="551" height="140" class="Gbtext" align="left" valign="top"><FONT face="����">&nbsp;</FONT>
							<asp:TextBox id="TxtBoardDescription" runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox></td>
					</tr>
					<tr>
						<td height="30" class="Gbtext" align="middle">
							������ͣ�</td>
						<td height="13" class="Gbtext" align="left">&nbsp;
							<asp:RadioButton id="RdPublic" runat="server" Text="����" GroupName="boardtype" Checked="True"></asp:RadioButton>
							<asp:RadioButton id="RdPrivate" runat="server" Text="˽��" GroupName="boardtype"></asp:RadioButton></td>
					</tr>
					<tr>
						<td height="13" class="Gbtext" align="right" valign="top">
						</td>
						<td width="551" height="13" class="Gbtext" align="middle" valign="top">&nbsp;
							<asp:Button id="CmdOK" runat="server" Text=" �� �� " CssClass="ButtonCss"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<INPUT class="buttoncss" type="button" value=" �� �� " onclick="javascript:location.href='Catalog.aspx?ClassID=<%=classid%>'">
						</td>
					</tr>
					<tr>
						<td width="636" height="13" class="Gbtext" align="right" colspan="2"><FONT face="����"></FONT></td>
					</tr>
				</table>
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td><img src="../../../Images/temp.gif" width="250" height="25"></td>
						<td align="right"><img src="../../../images/endbott.gif" width="279" height="25"></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>

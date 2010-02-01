<%@ Register TagPrefix="uc1" TagName="ControlRoleTreeView" Src="../../Inc/ControlRoleTreeView.ascx" %>
<%@ Page language="c#" Codebehind="RoleTreeView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Role.RoleTreeView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RoleTreeView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../css/basiclayout.css" rel="stylesheet">
	</HEAD>
	<body style="BACKGROUND-POSITION: right 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat" leftMargin="0" background="../../Images/lefttreebg.gif" topMargin="0" bgcolor="#024289">
		<form id="RoleTreeView" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="center" height="30"><FONT face="宋体">
							<TABLE id="Table1" height="30" cellSpacing="0" cellPadding="0" width="100%" border="0" class="gbtext">
								<TR>
									<TD background="../../Images/treetopbg.jpg">&nbsp;<FONT face="宋体">&nbsp;<A class="linkMenu" href="../UnitiveDocument/Setup/Setup.aspx?classID=77" target="MainFrame">系统设置</FONT></A> 
										-> 角色设置</TD>
									<TD width="1"></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<tr vAlign="top">
					<td><uc1:ControlRoleTreeView id="ControlRoleTreeView1" runat="server"></uc1:ControlRoleTreeView></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

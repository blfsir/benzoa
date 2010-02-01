<%@ Page language="c#" Codebehind="ManageCatalog.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.BBS.ManageCatalog" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageCatalog</title>
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form id="ManageCatalog" method="post" runat="server">
			<div align="center">
				<TABLE id="Table1" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../Images/icon/057.GIF" width="16"></FONT></TD>
						<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B><B>分类管理</B></B></TD>
					</TR>
				</TABLE>
				<FONT face="宋体">
					<BR>
				</FONT>
				<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="200" cellSpacing="0" cellPadding="0" width="640" border="0">
					<tr>
						<td class="Gbtext" align="right" width="100" height="30">分类名称：</td>
						<td class="Gbtext" align="left" width="551" height="18"><input class="InputCss" id="TxtCatalogName" type="text" size="75" runat="server">
							<asp:requiredfieldvalidator id="rfvcatalogname" runat="server" ErrorMessage="请填写分类名称" ControlToValidate="TxtCatalogName"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td class="Gbtext" vAlign="top" align="right" height="140">分类介绍：</td>
						<td class="Gbtext" vAlign="top" align="left" width="551" height="140"><textarea class="InputCss" id="TxtCatalogDescription" rows="10" cols="74" runat="server"></textarea></td>
					</tr>
					<tr align="middle">
						<td class="Gbtext" colSpan="2" height="30"><input class="ButtonCss" id="cmdOK" type="submit" value=" 确 定 " runat="server">
							&nbsp;&nbsp; <input class="ButtonCss" type="button" value=" 返 回 " name="cmdCancel" onclick="javascript:location.href='Catalog.aspx?ClassID=<%=classid%>'"></td>
					</tr>
				</table>
				<FONT face="宋体">
					<BR>
				</FONT>
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

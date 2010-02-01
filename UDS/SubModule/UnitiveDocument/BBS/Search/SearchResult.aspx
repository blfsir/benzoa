<%@ Page language="c#" Codebehind="SearchResult.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.Search.SearchResult" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchResult</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
				width="100%" height="1">
				<tr height="30">
					<td width="3%" bgcolor="#c0d9e6" class="GbText" background="../../../../Images/treetopbg.jpg"><font color="#003366" size="3"><img src="../../../../DataImages/page.gif" width="16" height="16"></font></td>
					<td bgcolor="#c0d9e6" class="GbText" background="../../../../Images/treetopbg.jpg"><b>公司论坛 
							BBS</b> | <a href="">搜索</a> |</td>
				</tr>
			</table>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" style="HEIGHT: 112px">
				<TR>
					<TD align="center"><FONT face="宋体">
							<asp:DataGrid id="dgrd_Result" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="0"
								BorderColor="#93BFF2"></asp:DataGrid></FONT></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:HyperLink id="hlk_Back" runat="server" NavigateUrl="../Catalog.aspx">返回论坛</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

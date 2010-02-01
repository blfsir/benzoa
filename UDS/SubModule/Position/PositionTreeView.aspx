<%@ Page language="c#" Codebehind="PositionTreeView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Position.PositionTreeView" %>
<%@ Register TagPrefix="uc1" TagName="ControlPositionTreeView" Src="../../Inc/ControlPositionTreeView.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PositionTreeView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/basiclayout.css" rel="stylesheet">
		<script type="text/javascript">
		    window.onerror=function(){return true;}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" style="BACKGROUND-POSITION: right 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat" background="../../Images/lefttreebg.gif" bgcolor="#024289">
		
		<form id="PositionTreeView" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="center" height="30"><FONT face="宋体">
							<TABLE id="Table1" height="30" cellSpacing="0" cellPadding="0" width="100%" border="0" class="gbtext">
								<TR>
									<TD background="../../Images/treetopbg.jpg">职位管理</TD>
									<TD width="1"></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<tr vAlign="top">
					<td>
						<uc1:ControlPositionTreeView id="ControlPositionTreeView1" runat="server"></uc1:ControlPositionTreeView></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

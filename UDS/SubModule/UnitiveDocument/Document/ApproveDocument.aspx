<%@ Page language="c#" Codebehind="ApproveDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Document.ApproveDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>批阅文档</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ApproveDocument" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<TR>
					<TD>
						<TABLE id="Table2" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../images/283.GIF" width="16"></FONT></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B><B><B>文档内容</B></B></B></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#cccccc" width="100%" id="AutoNumber2" height="1" class="GbText" align="left">
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">文档标题:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblDocTitle" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">归档人:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblDocApprover" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">归档日期:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblDocApproveDate" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">上传人:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblAddedBy" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">上传日期:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblAddedDate" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">下载次数:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblDocViewedTimes" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">所属项目:</FONT></TD>
								<TD width="81%">&nbsp;
									<asp:Label id="lblClassName" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">文件简介:</FONT></TD>
								<TD width="81%"><FONT face="宋体"></FONT>&nbsp;
									<asp:Label id="lblDocContent" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="25%" height="22">&nbsp;<FONT face="宋体">文件下载:</FONT></TD>
								<TD width="81%"><FONT face="宋体"></FONT>&nbsp;
									<asp:Label id="lblFileVisualPath" runat="server"></asp:Label></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 8pt" vAlign="center" align="middle">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<TR>
								<TD style="HEIGHT: 28px" align="right"><FONT face="宋体">
										<asp:Button id="btnApprove" runat="server" Text="审批" CssClass="buttoncss" Width="60px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT><input type="button" value=" 返  回 " onclick="history.go(-1)" class="buttoncss"></TD>
								<TD style="HEIGHT: 28px" align="right"><IMG height="25" src="../../../images/endbott.gif" width="279"></TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

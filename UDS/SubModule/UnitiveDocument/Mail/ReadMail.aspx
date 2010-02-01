<%@ Page language="c#" Codebehind="ReadMail.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Mail.ReadMail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReadMail</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function downloadfile(destFile)
		{
			self.location="Download.aspx?destFileName="+destFile;
		}
		
		function Incoming(a)
		{
			var ret;
			ret = window.showModalDialog("TreeView.aspx",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");
			if(ret>0)
			return false;
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="ReadMail" method="post" runat="server">
			<input type=hidden name="hdnMailID" value="<%=MailID%>">
			<TABLE id="Table1" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../images/283.GIF" width="16"></FONT></TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B><B>阅读邮件 </B>
						</B>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="GbText" id="AutoNumber2" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="1" cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">发送人:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblSenderName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">收件人:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblReceiverStr" runat="server" Width="538px"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">抄送人:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblCcToAddr" runat="server" Width="538px"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">密抄人:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblBccToAddr" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">所属项目:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblProjectName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">邮件标题:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblSubject" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">发送时间:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblSendDate" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">邮件内容:</FONT></TD>
					<TD>&nbsp;
						<asp:label id="lblBody" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD width="15%" height="24">&nbsp;<FONT face="宋体">附件:</FONT></TD>
					<TD><FONT face="宋体">&nbsp;</FONT><asp:label id="lblAttachFile" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="left"><font size="3"><input class=ButtonCss onclick="javascript:self.location='Compose.aspx?ClassID=0&amp;Action=1&amp;MailID=<%=MailID%>'" type=button value="回 复"><FONT face="宋体">&nbsp;
							</FONT><input class=ButtonCss onclick="javascript:self.location='Compose.aspx?ClassID=0&amp;Action=2&amp;MailID=<%=MailID%>'" type=button value="转 发">&nbsp;<FONT face="宋体">
							</FONT><input class=ButtonCss onclick="javascript:self.location='Index.aspx?FolderType=<%=FolderType%>&CurrentPageIndex=<%=CurrentPageIndex%>'" type=button value="返 回"><FONT face="宋体">&nbsp;
							</FONT>
							<asp:button id="btnDelete" runat="server" CssClass="ButtonCss" Text="删 除"></asp:button>&nbsp;&nbsp;
							<input class="ButtonCss" onclick="Incoming()" type="button" value="归档"> </font>
					</td>
					<td align="right"><IMG height="25" src="../../../images/endbott.gif" width="279"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

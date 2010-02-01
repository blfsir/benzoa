<%@ Page language="c#" Codebehind="Google.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Query.Google" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Google</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Google" method="post" runat="server">
			<FONT face="宋体">
				<TABLE class="gbtext" id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%"
					border="0">
					<TR>
						<TD background="../../Images/treetopbg.jpg" height="30">&nbsp;<font color="#006699">全文检索 
								UDS Search</font></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE class="gbtext" id="Table1" cellSpacing="0" cellPadding="0" width="550" align="center"
								border="0">
								<TR>
									<TD align="center" height="80"><%--<IMG alt="" src="../../Images/udssearch_qwjs.gif">--%></TD>
								</TR>
								<TR>
									<TD align="center"><asp:label id="lblKey" runat="server" Width="53px">关键字：</asp:label><asp:textbox id="txtKey" runat="server" Width="258px" CssClass="inputcss" Height="20px"></asp:textbox>(不填写为全部)&nbsp;
										<asp:button id="cmdSearch" runat="server" Width="60px" CssClass="redbuttoncss" Height="20px"
											Text=" 搜 索 "></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" height="30"><asp:linkbutton id="lbPerference" runat="server" Width="69px" Height="15px">偏好设置<<</asp:linkbutton>&nbsp;
										<asp:checkbox id="chkTitle" runat="server" Text="标题" Checked="True"></asp:checkbox>&nbsp;
										<asp:checkbox id="chkContent" runat="server" Text="正文" Checked="True"></asp:checkbox>&nbsp;
										<asp:checkbox id="chkAuthor" runat="server" Text="作者" Checked="True"></asp:checkbox>&nbsp;<FONT face="宋体">
											<asp:checkbox id="chkAttach" runat="server" Text="附件"></asp:checkbox></FONT></TD>
								</TR>
								<TR>
									<TD align="center"><asp:panel id="panPreference" runat="server" Width="422px" Height="95px" HorizontalAlign="Justify"
											Visible="False" BorderStyle="Solid" BorderWidth="1px">
											<P><BR>
												<BR>
												<asp:CheckBox id="chkDocument" runat="server" Text="文档" Checked="True" DESIGNTIMEDRAGDROP="36"></asp:CheckBox><BR>
												<BR>
												<asp:CheckBox id="chkMail" runat="server" Text="邮件" Checked="True"></asp:CheckBox></P>
											<P>&nbsp;</P>
										</asp:panel></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

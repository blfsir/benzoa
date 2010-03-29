<%@ Page language="c#" Codebehind="TaskStatus.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.TaskStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TaskStatus</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="TaskDetail" method="post" runat="server">
			&nbsp;
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="middle" height="60"><FONT face="宋体"><asp:label id="lblTaskDetailTitle" runat="server" Font-Size="Medium" >任务当前状态</asp:label></FONT></TD>
				</TR>
				<TR>
					<TD align="middle">
						<table class="gbtext" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="60%" align="center" border="1">
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">发起人</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblArrangedBy" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">状态</FONT></TD>
								<TD>&nbsp;&nbsp; <FONT face="宋体">
										<BR>
									</FONT>
									<asp:datagrid id="dgList" runat="server" Width="280px" AutoGenerateColumns="False" ShowHeader="False">
										<ItemStyle Font-Size="X-Small"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" ForeColor="Maroon" BackColor="White"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="执行人">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.Username").ToString()) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="状态">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" ForeColor="#FF0033"></ItemStyle>
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# GetStatus(DataBinder.Eval(Container, "DataItem.IsConfirm").ToString()) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid><BR>
								</TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">任务评论</FONT></TD>
								<TD><IFRAME id="TaskCommentFrm" style="WIDTH: 99.22%; HEIGHT: 204px" width="100%" scrolling="auto" runat="server" frameborder="0">
									</IFRAME>
								</TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;</TD>
								<TD><FONT face="宋体"><BR>
										&nbsp;</FONT></TD>
							</TR>
						</table>
						<FONT face="宋体">
							<BR>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="50">
						<table width="75%" border="0">
							<tr>
								<td align="middle" colSpan="1" rowSpan="1"><FONT face="宋体"></FONT></td>
								<td align="middle"></td>
								<td align="middle"></td>
								<td align="middle"></td>
							</tr>
							<tr>
								<td align="middle" colSpan="4">&nbsp;<input class="buttoncss" style="WIDTH: 288px; HEIGHT: 20px" onclick="window.close()" type="button" value=" 关 闭 "></td>
							</tr>
						</table>
						<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

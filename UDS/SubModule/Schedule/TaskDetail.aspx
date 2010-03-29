<%@ Page language="c#" Codebehind="TaskDetail.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.TaskDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TaskDetail</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="TaskDetail" method="post" runat="server">
			&nbsp;
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="middle" height="28" style="HEIGHT: 28px"><FONT face="宋体"><asp:label id="lblTaskDetailTitle" runat="server"  Font-Size="Medium">任务详细情况</asp:label></FONT></TD>
				</TR>
				<TR>
					<TD align="middle">
						<table class="gbtext" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="60%" align="center" border="1">
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">发起人</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblArrangedBy" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">类型</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblType" runat="server"></asp:label></TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">属性</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblAttribute" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">协同人</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblCooperator" runat="server"></asp:label></TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">开始日期</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblStartTime" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">结束日期</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblEndTime" runat="server"></asp:label></TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">所属项目</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblProjectID" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">主题</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblSubject" runat="server"></asp:label></TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">详情</FONT></TD>
								<TD>&nbsp;&nbsp;<asp:label id="lblDetail" runat="server"></asp:label></TD>
							</TR>
							<TR bgColor="#e8f4ff" height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">任务评论</FONT></TD>
								<TD><IFRAME id="TaskCommentFrm" style="WIDTH: 99.22%; HEIGHT: 132px" width="100%" runat="server" scrolling="auto" frameBorder="0">
									</IFRAME>
								</TD>
							</TR>
							<TR height="24">
								<TD style="WIDTH: 102px">&nbsp;<FONT face="宋体">评论添加</FONT></TD>
								<TD>
									<asp:TextBox id="txtComment" runat="server" Width="288px" TextMode="MultiLine" Height="69px"></asp:TextBox><FONT face="宋体"><BR>
										&nbsp;
										<asp:Button id="btnAddCom" runat="server" Text="评论添加" CssClass="buttoncss"></asp:Button></FONT></TD>
							</TR>
						</table>
						<FONT face="宋体">
							<BR>
							<TABLE width="75%" border="0">
								<TR>
									<TD align="middle" colSpan="1" rowSpan="1">&nbsp;
										<asp:button id="btnDelete" runat="server" Text=" 删  除 " Width="70px" Visible="False" CssClass="buttoncss"></asp:button></TD>
									<TD align="middle">&nbsp;
										<asp:button id="btnAccept" runat="server" Text="接  受" Width="70px" CssClass="buttoncss"></asp:button></TD>
									<TD align="middle">&nbsp;
										<asp:button id="btnFinish" runat="server" Text=" 完  成" Width="70px" CssClass="buttoncss" Visible="False"></asp:button></TD>
									<TD align="middle">&nbsp;
										<asp:button id="btnCancel" runat="server" Text=" 取  消" Width="70px" CssClass="buttoncss"></asp:button></TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="4">&nbsp; <INPUT class="buttoncss" style="WIDTH: 288px; HEIGHT: 20px" onclick="window.close()" type="button" value=" 关 闭 "></TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="50">
						<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

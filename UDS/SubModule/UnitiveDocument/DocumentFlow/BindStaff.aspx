<%@ Page language="c#" Codebehind="BindStaff.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.BindStaff" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BangdingRole</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="BangdingRole" method="post" runat="server">
			<FONT face="宋体">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD vAlign="middle" height="87" align="center" style="COLOR: #006699; FONT-FAMILY: 'Arial Black'; HEIGHT: 87px">
							<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR height="30">
									<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
										bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD class="GbText" align="left" width="63" background="../../../Images/treetopbg.jpg"
										bgColor="#e8f4ff" style="WIDTH: 63px"><FONT color="#006699">人员绑定：</FONT></TD>
									<TD class="GbText" align="left" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff">
										<asp:Label id="labTitle" runat="server" Width="543px"></asp:Label></TD>
								</TR>
							</TABLE>
							<P><FONT face="宋体">可用下面四种方法中任意一种或多种选择所需要的人</FONT>
							</P>
						</TD>
					</TR>
					<TR>
						<TD align="center" style="HEIGHT: 780px">
							<TABLE class="gbtext" cellSpacing="0" cellPadding="0" width="444" border="0" style="WIDTH: 444px; HEIGHT: 777px"
								align="center">
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 21px" align="center" width="47" bgColor="#eee7f2">1</TD>
									<TD width="143" style="WIDTH: 143px; HEIGHT: 21px" align="left" bgcolor="#eee7f2">
										<asp:label id="Label2" runat="server" Height="15px" Width="66px">已选角色：</asp:label></TD>
									<TD width="35" style="WIDTH: 35px; HEIGHT: 21px" align="center" bgcolor="#eee7f2" colSpan="1"
										rowSpan="1"></TD>
									<TD width="91" style="WIDTH: 91px; HEIGHT: 21px" align="left" bgcolor="#eee7f2">
										<asp:label id="Label1" runat="server" Height="15px" Width="83px">待选角色：</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 117px" vAlign="middle"></TD>
									<TD style="WIDTH: 143px; HEIGHT: 117px" valign="middle">
										<asp:listbox id="lstCurRole" runat="server" Width="159px" Height="130px" SelectionMode="Multiple"></asp:listbox></TD>
									<TD style="WIDTH: 35px; HEIGHT: 117px">
										<asp:button id="cmdAdd" runat="server" Height="24px" Width="26px" CssClass="buttoncss" Text="<<"></asp:button><BR>
										<BR>
										<asp:button id="cmdDelete" runat="server" Height="24px" Width="26px" CssClass="buttoncss" Text=">>"></asp:button></TD>
									<TD style="WIDTH: 91px; HEIGHT: 117px"><asp:listbox id="lstAllRole" runat="server" Width="165px" Height="130px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 18px" vAlign="middle" align="center" bgColor="#eee7f2">2</TD>
									<TD style="WIDTH: 143px; HEIGHT: 16px" vAlign="middle" bgColor="#eee7f2">
										<asp:label id="Label3" runat="server" Width="56px" Height="15px">已选职位</asp:label></TD>
									<TD style="WIDTH: 35px; HEIGHT: 16px" bgColor="#eee7f2"><FONT style="BACKGROUND-COLOR: #ffffff"></FONT></TD>
									<TD style="WIDTH: 91px; HEIGHT: 16px" bgColor="#eee7f2">
										<asp:label id="Label4" runat="server" Width="110px" Height="15px">待选职位</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 139px" vAlign="middle"></TD>
									<TD style="WIDTH: 143px; HEIGHT: 139px" vAlign="middle">
										<asp:listbox id="lstCurPosition" runat="server" Height="130px" Width="159px" SelectionMode="Multiple"></asp:listbox></TD>
									<TD style="WIDTH: 35px; HEIGHT: 139px">
										<P>
											<asp:button id="cmdAddPositon" runat="server" Height="24" Width="26" CssClass="buttoncss" Text="<<"></asp:button></P>
										<P>
											<asp:button id="cmdDeletePosition" runat="server" Height="24" Width="26" CssClass="buttoncss"
												Text=">>"></asp:button></P>
									</TD>
									<TD style="WIDTH: 91px; HEIGHT: 139px">
										<asp:listbox id="lstAllPosition" runat="server" Height="130px" Width="167px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 18px" vAlign="middle" align="center" bgColor="#eee7f2">3</TD>
									<TD style="WIDTH: 143px; HEIGHT: 18px" vAlign="middle" bgColor="#eee7f2">
										<asp:label id="Label8" runat="server" Width="110px" Height="15px">已选项目：（成员）</asp:label></TD>
									<TD bgColor="#eee7f2"></TD>
									<TD bgColor="#eee7f2">
										<asp:label id="Label5" runat="server" Width="110px" Height="15px">待选项目：</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 87px" vAlign="middle"></TD>
									<TD style="WIDTH: 143px; HEIGHT: 87px" vAlign="middle">
										<asp:listbox id="lstCurTeam" runat="server" Height="133px" Width="161px" SelectionMode="Multiple"></asp:listbox></TD>
									<TD style="WIDTH: 35px; HEIGHT: 87px">
										<asp:button id="cmdAddTeam" runat="server" Height="24" Width="26" CssClass="buttoncss" Text="<<"></asp:button>
										<asp:button id="cmdDeleteTeam" runat="server" Height="24" Width="26" CssClass="buttoncss" Text=">>"></asp:button></TD>
									<TD style="WIDTH: 91px; HEIGHT: 87px">
										<asp:listbox id="lstAllTeam" runat="server" Height="133px" Width="166px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 4px" align="center"><FONT style="BACKGROUND-COLOR: #eee7f2"></FONT></TD>
									<TD style="WIDTH: 143px; HEIGHT: 4px" bgcolor="#eee7f2" align="left">
										<asp:Label id="Label9" runat="server" Width="118px">已选项目：（组长）</asp:Label></TD>
									<TD style="WIDTH: 35px; HEIGHT: 4px" align="center" bgcolor="#eee7f2"></TD>
									<TD bgcolor="#eee7f2" align="left">
										<asp:label id="Label10" runat="server" Width="71px" Height="15px">待选项目：</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 139px" vAlign="middle"></TD>
									<TD style="WIDTH: 143px; HEIGHT: 139px" valign="middle">
										<asp:listbox id="lstCurTeamLeader" runat="server" Width="161px" Height="133px" SelectionMode="Multiple"></asp:listbox></TD>
									<TD style="WIDTH: 35px; HEIGHT: 139px"><BR>
										<BR>
										<asp:button id="cmdAddTeamLeader" runat="server" Width="26" Height="24" Text="<<" CssClass="buttoncss"></asp:button>
										<asp:button id="cmdDeleteTeamLeader" runat="server" Width="26" Height="24" Text=">>" CssClass="buttoncss"></asp:button></TD>
									<TD style="WIDTH: 91px; HEIGHT: 139px">
										<asp:listbox id="lstAllTeamLeader" runat="server" Width="166px" Height="133px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 18px" vAlign="middle" align="center" bgColor="#eee7f2">4</TD>
									<TD style="WIDTH: 143px; HEIGHT: 18px" vAlign="middle" bgColor="#eee7f2">
										<asp:label id="Label6" runat="server" Width="105px" Height="15px">已选人员：</asp:label></TD>
									<TD style="WIDTH: 35px; HEIGHT: 18px" bgColor="#eee7f2"></TD>
									<TD style="WIDTH: 91px; HEIGHT: 18px" bgColor="#eee7f2">
										<asp:label id="Label7" runat="server" Width="110px" Height="15px">待选人员</asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 47px; HEIGHT: 139px" vAlign="middle"></TD>
									<TD style="WIDTH: 143px; HEIGHT: 139px" vAlign="middle"><asp:listbox id="lstCurStaff" runat="server" Width="159px" Height="133px" SelectionMode="Multiple"></asp:listbox></TD>
									<TD style="WIDTH: 35px; HEIGHT: 139px">
										<asp:button id="cmdAddStaff" runat="server" Height="24" Width="26" CssClass="buttoncss" Text="<<"></asp:button>
										<asp:button id="cmdDeleteStaff" runat="server" Height="24" Width="26" CssClass="buttoncss" Text=">>"></asp:button></TD>
									<TD style="WIDTH: 91px; HEIGHT: 139px">
										<asp:listbox id="lstAllStaff" runat="server" Height="133px" Width="168px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" height="19" bgColor="#eee7f2" style="HEIGHT: 19px"><font face="宋体" size="2">所有选定人员</font></TD>
					</TR>
					<TR>
						<TD align="center" height="40">
							<asp:ListBox id="lstAllMember" runat="server" Width="389px" Height="128px"></asp:ListBox></TD>
					</TR>
					<TR>
						<TD align="center" height="40">
							<asp:button id="cmdReturn" runat="server" Width="80px" Text="返回" CssClass="buttoncss"></asp:button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

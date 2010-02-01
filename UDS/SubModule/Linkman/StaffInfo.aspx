<%@ Page language="c#" Codebehind="StaffInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.StaffInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StaffInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="5" leftmargin="5">
		<form id="StaffInfo" method="post" runat="server">
			<FONT face="宋体">
				<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="24" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/myLinkman.gif" width="16"></FONT></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="80" align="right"><font color="#006699">联系人资料</font></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right">&nbsp;</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="1" class="gbtext">
					<TR>
						<TD style="WIDTH: 105px" height="30" bgcolor="#e8f4ff">&nbsp;姓名</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Name" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 97px" height="30" bgcolor="#e8f4ff">&nbsp;性别</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Gender" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 105px" height="30" bgcolor="#e8f4ff">&nbsp;手机</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Mobile" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 97px" height="30" bgcolor="#e8f4ff">&nbsp;Email</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Email" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 105px" height="30" bgcolor="#e8f4ff">&nbsp;公司电话</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_UnitTelephone" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 97px" height="30" bgcolor="#e8f4ff">&nbsp;出生日期</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Birthday" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 105px" height="30" bgcolor="#e8f4ff">&nbsp;所属部门</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_Position" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 97px" height="30" bgcolor="#e8f4ff">&nbsp;注册日期</TD>
						<TD height="30">&nbsp;
							<asp:Literal id="ltl_RD" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD  align="middle" colSpan="4" height="30"><a href="javascript:close();">关闭窗口</a></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

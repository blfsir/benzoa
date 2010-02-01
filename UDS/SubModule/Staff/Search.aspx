<%@ Page language="c#" Codebehind="Search.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.Search" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Search</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="table_Other" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 424px; POSITION: absolute; TOP: 120px; HEIGHT: 66px"
					cellSpacing="1" cellPadding="1" width="424" border="1" runat="server">
					<TR>
						<TD>手机</TD>
						<TD>
							<asp:TextBox id="tbx_Mobile" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Email</TD>
						<TD>
							<asp:TextBox id="tbx_Email" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>性别</TD>
						<TD>
							<asp:DropDownList id="ddl_Gender" runat="server">
								<asp:ListItem Value="male">男</asp:ListItem>
								<asp:ListItem Value="female">女</asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" style="WIDTH: 424px; HEIGHT: 66px" cellSpacing="1" cellPadding="1" width="424"
					border="1">
					<TR>
						<TD style="WIDTH: 104px">员工查询</TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 104px">姓名/登陆名</TD>
						<TD>
							<asp:TextBox id="tbx_Name" runat="server"></asp:TextBox></TD>
						<TD>
							<asp:Button id="btn_Search" runat="server" Text="查询" CssClass="buttoncss"></asp:Button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 104px">所在职位</TD>
						<TD>
							<asp:DropDownList id="ddl_Position" runat="server"></asp:DropDownList></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 104px">
							<asp:LinkButton id="lbtn_Others" runat="server">其它查询>>></asp:LinkButton></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

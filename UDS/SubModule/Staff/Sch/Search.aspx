<%@ Page language="c#" Codebehind="Search.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.Sch.Search" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Search</title>
		<meta name="vs_snapToGrid" content="True">
		<meta name="vs_showGrid" content="True">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myLinkman.gif" width="16"></FONT></TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="75"
						align="right" style="WIDTH: 75px">员工查询</TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right">&nbsp;</TD>
				</TR>
			</TABLE>
			<FONT face="宋体">
				<br>
				<TABLE id="Table1" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
					<TR>
						<TD style="WIDTH: 104px" height="24">姓名/登陆名</TD>
						<TD height="24"><asp:textbox id="tbx_Name" runat="server" CssClass="inputcss"></asp:textbox></TD>
						<TD height="24">所在职位</TD>
						<TD height="24"><asp:dropdownlist id="ddl_Position" runat="server" Width="130px"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 104px" height="24"><INPUT class="buttoncss" type="button" value="返  回" onclick="javascript:location.href='../ManageStaff.aspx'"></TD>
						<TD height="24"><asp:button id="btn_Search" runat="server" Text="查  询" CssClass="buttoncss"></asp:button></TD>
						<TD height="24"><asp:linkbutton id="lbtn_Others" runat="server">其它查询选项>>></asp:linkbutton></TD>
						<TD height="24"><asp:linkbutton id="lbtn_SelectField" runat="server">选择显示字段>>></asp:linkbutton></TD>
					</TR>
					<TR>
						<TD colSpan="4" height="24">&nbsp;
							<TABLE class="GbText" id="table_Other" borderColor="#93bee2" cellSpacing="0" cellPadding="0"
								width="100%" border="1" runat="server" style="BORDER-COLLAPSE: collapse">
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Mobile" runat="server" Text="手机"></asp:checkbox></TD>
									<TD height="24">
										<asp:textbox id="tbx_Mobile" runat="server" CssClass="inputcss" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Email" runat="server" Text="Email"></asp:checkbox></TD>
									<TD height="24">
										<asp:textbox id="tbx_Email" runat="server" CssClass="inputcss" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Gender" runat="server" Text="性别"></asp:checkbox></TD>
									<TD height="24">
										<asp:dropdownlist id="ddl_Gender" runat="server" Width="130px" Enabled="False">
											<asp:ListItem Value="male">男</asp:ListItem>
											<asp:ListItem Value="female">女</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 91px" height="24">查询范围</TD>
									<TD height="24">
										<asp:DropDownList id="ddl_SearchBound" runat="server">
											<asp:ListItem Value="all">所有员工</asp:ListItem>
											<asp:ListItem Value="on">在职员工</asp:ListItem>
											<asp:ListItem Value="off">离职员工</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
							</TABLE>
							<TABLE class="GbText" id="table_Field" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
								<TR>
									<TD vAlign="top" align="center" rowSpan="3">
										<asp:listbox id="lbx_Fields" runat="server" Width="200px" Height="130px"></asp:listbox></TD>
									<TD align="center">
										<asp:button id="btn_In" runat="server" CssClass="buttoncss" Text=">>>"></asp:button></TD>
									<TD vAlign="top" align="center" rowSpan="3">
										<asp:listbox id="lbx_SelectedFields" runat="server" Width="200px" Height="130px"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 61px" align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 61px" align="center">
										<asp:button id="btn_Out" runat="server" CssClass="buttoncss" Text="<<<"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<br>
			</FONT>
		</form>
	</body>
</HTML>

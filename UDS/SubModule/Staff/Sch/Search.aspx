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
			 <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/ClientManage.gif" width="16">
            </td>
            <td width="60" height="30" align="left" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                &nbsp;<font color="#006699">Ա����ѯ</font>
            </td>
            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6">&nbsp;
                </td>
        </tr>
    </table>
			<FONT face="����">
				<br>
				<TABLE id="Table1" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
					<TR>
						<TD style="WIDTH: 104px" height="24">����/��½��</TD>
						<TD height="24"><asp:textbox id="tbx_Name" runat="server" CssClass="inputcss"></asp:textbox></TD>
						<TD height="24">����ְλ</TD>
						<TD height="24"><asp:dropdownlist id="ddl_Position" runat="server" Width="130px"></asp:dropdownlist></TD>
						<TD height="24" style="WIDTH: 91px">
										<%--<asp:checkbox id="cbx_Dept" runat="server" Text="����"  ></asp:checkbox>--%>����</TD>
									<TD height="24">
										<asp:dropdownlist id="ddl_Dept" runat="server" Width="130px"  >
											 
										</asp:dropdownlist></TD>
					</TR>
					<tr>
					<td colspan="6">
					 
					<table id="tableMobile"  runat="server"  class="GbText"  borderColor="#93bee2" cellSpacing="0" cellPadding="0"
								width="100%" border="1" runat="server" style="BORDER-COLLAPSE: collapse" visible="false">
					<tr>
						<TD height="24" style="WIDTH: 102px">�ֻ�</TD>
					<td colspan="3"><asp:textbox id="tbx_Mobile" runat="server" CssClass="inputcss" Enabled="True"></asp:textbox></td></tr>
					</table> 
					
					<table id="tableEmail"  runat="server"  class="GbText"  borderColor="#93bee2" cellSpacing="0" cellPadding="0"
								width="100%" border="1" runat="server" style="BORDER-COLLAPSE: collapse" visible="false">
					<tr>
						<TD height="24" style="WIDTH: 102px">Email</TD>
					<td colspan="3"><asp:textbox id="tbx_Email" runat="server" CssClass="inputcss"  ></asp:textbox></td></tr>
					</table> 
					
					<table id="tableGender"  runat="server"  class="GbText"  borderColor="#93bee2" cellSpacing="0" cellPadding="0"
								width="100%" border="1" runat="server" style="BORDER-COLLAPSE: collapse" visible="false">
					<tr>
						<TD height="24" style="WIDTH: 102px">�Ա�</TD>
					<td colspan="3"><asp:dropdownlist id="ddl_Gender" runat="server" Width="130px" >
											<asp:ListItem Value="male">��</asp:ListItem>
											<asp:ListItem Value="female">Ů</asp:ListItem>
										</asp:dropdownlist></td></tr>
					</table> 
					
					</td>
					</tr>
					<TR>
						<TD style="WIDTH: 104px" height="24"><INPUT class="buttoncss" type="button" value="��  ��" onclick="javascript:location.href='../ManageStaff.aspx'"></TD>
						<TD height="24"><asp:button id="btn_Search" runat="server" Text="��  ѯ" CssClass="buttoncss"></asp:button></TD>
						<TD height="24"><asp:linkbutton id="lbtn_Others" runat="server">������ѯѡ��>>></asp:linkbutton></TD>
						<TD height="24" colspan="3"><asp:linkbutton id="lbtn_SelectField" runat="server">ѡ����ʾ�ֶ�>>></asp:linkbutton></TD>
					</TR>
					<TR>
						<TD colSpan="6" height="24">&nbsp;
							<TABLE class="GbText" id="table_Other" borderColor="#93bee2" cellSpacing="0" cellPadding="0"
								width="100%" border="1" runat="server" style="BORDER-COLLAPSE: collapse">
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Mobile" runat="server" Text="�ֻ�" 
                                            oncheckedchanged="cbx_Mobile_CheckedChanged" AutoPostBack="true"></asp:checkbox></TD>
									<TD height="24">
										</TD>
								</TR>
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Email" runat="server" Text="Email" AutoPostBack="true" 
                                            oncheckedchanged="cbx_Email_CheckedChanged" ></asp:checkbox></TD>
									<TD height="24">
										</TD>
								</TR>
								<TR>
									<TD height="24" style="WIDTH: 91px">
										<asp:checkbox id="cbx_Gender" runat="server" Text="�Ա�" AutoPostBack="true" 
                                            oncheckedchanged="cbx_Gender_CheckedChanged"></asp:checkbox></TD>
									<TD height="24">
										</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 91px" height="24">��ѯ��Χ<TD style="WIDTH: 91px" height="24">��ѯ��Χ</TD>
									<TD height="24">
										<asp:DropDownList id="ddl_SearchBound" runat="server">
											<asp:ListItem Value="all">����Ա��</asp:ListItem>
											<asp:ListItem Value="on">��ְԱ��</asp:ListItem>
											<asp:ListItem Value="off">��ְԱ��</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
							</TABLE>
							<TABLE class="GbText" id="table_Field" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
								<TR>
									<TD vAlign="top" align="center" rowSpan="3">
										<asp:listbox id="lbx_Fields" runat="server" Width="200px" Height="430px"></asp:listbox></TD>
									<TD align="center">
										<asp:button id="btn_In" runat="server" CssClass="buttoncss" Text=">>>"></asp:button></TD>
									<TD vAlign="top" align="center" rowSpan="3">
										<asp:listbox id="lbx_SelectedFields" runat="server" Width="200px" Height="430px"></asp:listbox></TD>
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

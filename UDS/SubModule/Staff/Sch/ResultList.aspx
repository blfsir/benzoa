<%@ Page language="c#" Codebehind="ResultList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.Sch.ResultList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ResultList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin=0 topmargin=0>
		<form id="Form1" method="post" runat="server">
					<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myLinkman.gif" width="16"></FONT></TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="75"
						align="right" style="WIDTH: 75px">Ա����ѯ</TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="left">&nbsp;<FONT face="����">��ѯ���</FONT></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="100%" border="1"
					style="BORDER-COLLAPSE: collapse" class="GbText">
				<TR>
					<TD><asp:datagrid id="dgrd_StaffList" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
							PageSize="20" AllowPaging="True" BorderColor="#93BEE2" BorderWidth="1px">
<AlternatingItemStyle BackColor="#E8F4FF">
</AlternatingItemStyle>

<ItemStyle Font-Size="X-Small">
</ItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Staff_Name" SortExpression="Staff_Name" HeaderText="��½��"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="RealName" SortExpression="RealName" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Mobile" SortExpression="Mobile" HeaderText="�ֻ�����"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="SexName" SortExpression="SexName" HeaderText="�Ա�"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Email" SortExpression="Email" HeaderText="Email"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Position_Name" SortExpression="Position_Name" HeaderText="ְλ"></asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Right" Mode="NumericPages">
</PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="right"><FONT face="����">
							<asp:Button id="btn_Print" runat="server" Text="��ӡ" CssClass="buttoncss"></asp:Button><INPUT class="buttoncss" type="button" onclick="javascript:location.href='Search.aspx'" value="����"></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

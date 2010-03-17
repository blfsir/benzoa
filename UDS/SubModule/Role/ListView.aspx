<%@ Page language="c#" Codebehind="ListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Role.ListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function SelectItem()
			{
				var i = 0;
				var e;

				for( i = 0 ; i < ListView.elements.length ; i ++ )
				{
					e = ListView.elements[ i ];
					if( e.type == "checkbox" )	e.checked = !e.checked;
				}
			}

			
			// ��������
			function high( which )
			{ 
				which.style.background = "#C0D9E6";
				which.style.font.color = "red";
			} 

			// ȡ����������
			function low( which )
			{ 
				which.style.background = "#FFFFFF";
				which.style.font.color = "black";
			}
		</script>
	</HEAD>
	<body text="#000000" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="ListView" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0" align="center">
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24">
									<asp:LinkButton id="lbMember" runat="server" CssClass="Newbutton">��ɫ��Ա</asp:LinkButton></TD>
								<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' height="24">
									<asp:LinkButton id="lbNonMember" runat="server" CssClass="Newbutton">�ǳ�Ա</asp:LinkButton></TD>
								<TD align="right">
									<asp:Button id="cmdManageRole" runat="server" Width="68px" Text="��ɫ����" Height="20px" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdManageRight" runat="server" Width="72px" Text="Ȩ�޹���" Height="19px" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdDeleteStaffFromRole" runat="server" Width="74px" Text="�����ɫ" Height="20px"
										CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdAddToRole" runat="server" Width="73px" Text="�����ɫ" Height="20px" CssClass="redbuttoncss"></asp:Button>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dbStaffList" runat="server" DataKeyField="Staff_ID" AllowPaging="True" Width="100%"
							AutoGenerateColumns="False" PageSize="15" BorderWidth="1px" BackColor="White" BorderColor="#93BEE2"
							BorderStyle="None" CellPadding="3" OnPageIndexChanged="DataGrid_PageChanged">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle Width="20px"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="Staff_ID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="��ʵ����" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../Position/NewStaff.aspx?StaffID={0}&amp;ReturnPage=0"
									DataTextField="RealName" HeaderText="��ʵ����">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="Mobile" HeaderText="�ֻ�">
									<HeaderStyle Width="60px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Age" HeaderText="����">
									<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SexName" HeaderText="�Ա�">
									<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Email" HeaderText="EMAIL">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Position_Name" HeaderText="����ְλ">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RQ" HeaderText="ע������">
									<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="ListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Department.ListView" %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ListView</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
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
		<script language="javascript">
			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../images/maillistbutton2.gif';
		nonactive.src = '../../images/maillistbutton1.gif';

		function onMouseOver(img)
		{
			document.images[img].src = ball2.src;
		}

		function onMouseOut(img)
		{
			document.images[img].src = ball1.src;
		}

		function onOverBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+active.src+")";
				
			}
		}

		function onOutBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+nonactive.src+")";
			}
		}
		
		function selectAll(){
			var len=document.MailList.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.MailList.elements[i].type=="checkbox"){
		        document.MailList.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.MailList.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.MailList.elements[i].type=="checkbox"){
	                  document.MailList.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
	</HEAD>
	<body leftMargin="3" topMargin="3" MS_POSITIONING="GridLayout">
		<form id="ListView" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="middle" width="90" 
          background='<% Response.Write(DisplayType==1?"../../images/maillistbutton1.gif":"../../images/maillistbutton2.gif"); %>'  height="24"><asp:linkbutton id="lbOnline" runat="server" Font-Size="X-Small">��ְԱ��</asp:linkbutton></TD>
								<TD align="middle" width="90"  background='<% Response.Write(DisplayType==0?"../../images/maillistbutton1.gif":"../../images/maillistbutton2.gif"); %>' height="24"><asp:linkbutton id="lbOffLine" runat="server" Font-Size="X-Small">��ְԱ��</asp:linkbutton></TD>
								<TD align="right">
									<asp:Button id="cmdNewStaff" runat="server" Text="��Ա��" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdDepartmentOperate" runat="server" Text="ְλ����" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdSetRight" runat="server" Text="Ȩ�޹���" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdOnDepartment" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdOffDepartment" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:Button>
									<asp:Button id="cmdChangeDepartment" runat="server" Text="��ְ" CssClass="redbuttoncss"></asp:Button>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dbStaffList" runat="server" Width="100%" CellPadding="3" BackColor="White" BorderStyle="None" BorderColor="#93BEE2" BorderWidth="1px" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" DataKeyField="Staff_ID" OnPageIndexChanged="DataGrid_PageChanged">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle Width="20px"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="Staff_ID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="��ʵ����" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../Department/NewStaff.aspx?StaffID={0}&amp;ReturnPage=0" DataTextField="RealName" HeaderText="��ʵ����">
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
								<asp:BoundColumn DataField="Department_Name" HeaderText="���ڲ���">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RQ" HeaderText="ע������">
									<HeaderStyle HorizontalAlign="Right" Width="80px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="ManageStaff.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.ManageStaff" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageStaff</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="ManageStaff" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
							<td vAlign="top" ><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR height="30">
											<TD class="GbText" width="20" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/staff.gif" width="16"></FONT></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
												align="right"><font color="#006699">人员管理</font></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right" width=85%></TD>
			</TD></TR></TBODY></TABLE></TD></TR>
						<tr><TD>
							<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24"><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton">在职员工</asp:linkbutton></TD>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' height="24"><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton">离职员工</asp:linkbutton></TD>
									<TD align="right">
										<asp:CheckBox id="cbRemind" runat="server" Text="提醒公司全体员工" Width="240px" Font-Size="X-Small" Height="16px"></asp:CheckBox>&nbsp;&nbsp;&nbsp;<asp:button id="cmdNewStaff" runat="server" Text="新员工" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdDimission" runat="server" Text="离职" CssClass="redbuttoncss"></asp:button><asp:button id="cmdRehab" runat="server" Text="复职" CssClass="redbuttoncss"></asp:button>
										<asp:button id="cmdChangePosition" runat="server" Text="调职" CssClass="redbuttoncss"></asp:button>
										<asp:Button id="btn_Search" runat="server" CssClass="redbuttoncss" Text="查询"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dbStaffList" runat="server" OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
								AutoGenerateColumns="False" DataKeyField="Staff_ID" Width="100%">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ID">
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkStaff_ID" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn Text="真实姓名" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../position/NewStaff.aspx?StaffID={0}&amp;ReturnPage=1"
										DataTextField="RealName" HeaderText="真实姓名">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:HyperLinkColumn>
									<asp:BoundColumn DataField="Mobile" HeaderText="手机">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Age" HeaderText="年龄">
										<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SexName" HeaderText="性别">
										<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Email" HeaderText="EMAIL">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="position_Name" HeaderText="所在部门">
										<HeaderStyle Width="150px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RQ" HeaderText="注册日期">
										<HeaderStyle HorizontalAlign="Right" Width="80px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

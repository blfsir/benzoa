<%@ Page language="c#" Codebehind="CarManage.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Vehicle.CarManage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CarManage</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		 <script language="JavaScript" src="../../Css/meizzDate.js"></script>
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
		<form id="CarManage" method="post" runat="server">
			<FONT face="宋体">
            <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR>
											<TD width="20" height="30" align="right" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366"><IMG height="16" src="../../DataImages/staff.gif" width="16"></FONT></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
												align="center" >车辆管理</TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff"></TD>
			           </TR></TBODY></TABLE>
				<TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" id="Table1">
					<tr>
							<td vAlign="top"  height="10"></TD></TR>
						<tr>
						  <TD><TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
						      <TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24">车辆</TD>
						      <TD align="right"><asp:button id="btnAdd" runat="server" Text="新增" CssClass="redbuttoncss"></asp:button>
						        <asp:Button id="btnDelete" runat="server" CssClass="redbuttoncss" Text="删除"></asp:Button></TD>
					        </TR>
					      </TABLE></TD>
					</TR>
					
					<TR>
						<TD>
						<asp:datagrid id="dbCarList" runat="server" OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
								AutoGenerateColumns="False" DataKeyField="ID" Width="100%">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ID">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkID" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:BoundColumn DataField="CarType" HeaderText="车型" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CarNum" HeaderText="车号" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Memo" HeaderText="备注" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="40%"></HeaderStyle>
									</asp:BoundColumn>
									
									<asp:TemplateColumn HeaderText="编辑">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<a href='NewCar.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>' target="_self">编辑</a>
										</ItemTemplate>
										<HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<asp:Label runat="server" ID="LabelPageInfo" Font-Size=X-Small></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

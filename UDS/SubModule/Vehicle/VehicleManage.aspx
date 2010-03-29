<%@ Page language="c#" Codebehind="VehicleManage.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Vehicle.VehicleManage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VehicleManage</title>
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

function ock_Search(){  
	var strAlert="";
	strBeginTime = document.all.txtBeginDate.value;
	strEndTime = document.all.txtEndDate.value;
	if (strBeginTime!="" & strEndTime!=""){		
		if (!CompareDate(strBeginTime,strEndTime)){
			strAlert = strAlert + "��ֹ����Ӧ���ڵ�����ʼ���ڡ�\n"
		}		
	}
    if (strAlert!=""){
		alert(strAlert);
		return false;
    }
}

		</script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="VehicleManage" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
							<td vAlign="top" ><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR height="30">
											<TD class="GbText" width="20" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/staff.gif" width="16"></FONT></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="100"
												align="right" id="td_title" runat=server><font color="#006699">����ʹ�ò�ѯ</font></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right" width=85%></TD>
			            </TD></TR></TBODY></TABLE></TD></TR>
						<tr><TD>
							<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' height="24">����ʹ�ò�ѯ</TD>
									
									<TD align="right">
										
										&nbsp;
										</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr id="tr_Tj" runat=server bgcolor="#e8f4ff"><td align=left>
					<TABLE class="gbtext" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr><td align=right>������</td>
					<td><%--<asp:TextBox ID="txtMeetingType" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ></asp:TextBox>--%>
                        
                        <asp:DropDownList ID="ddlApplyCar" runat="server" Width="120">
                        </asp:DropDownList>
                        </td>
                        <td align=right>�ó����ţ�</td>
					<td>
					    <asp:TextBox ID="txtDepartment" CssClass="InputCss" runat="server" Columns="70"
                            Width="200"></asp:TextBox></td>
                    
                      
                        </tr>
					<tr>
					 <td align="right">�ó����ڣ�</td>
                        <td height="30">
                        <asp:TextBox ID="txtUseTime" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                        
                        </td>
                    
                    <td align="right">�ó����ʣ�</td>
                    <td height="30">
                    <asp:DropDownList ID="ddlNature" runat="server" CssClass="InputCss" Width=50>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>��</asp:ListItem>
                        <asp:ListItem>˽</asp:ListItem>
                    </asp:DropDownList></td>
                        <td><asp:Button id="btnSearch" runat="server" CssClass="redbuttoncss" Text="��ѯ" OnClientClick="return ock_Search();"></asp:Button></td>
                        </tr>
                        
                        </TABLE>
					</td></tr>
					<TR>
						<TD>
						<asp:datagrid id="dbVehicleList" runat="server" OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" PageSize="15" AllowPaging="True"
								AutoGenerateColumns="False" DataKeyField="ID" Width="100%">
								<SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small"  ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
								<Columns>
									
									<asp:BoundColumn DataField="CarName" HeaderText="����" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Department" HeaderText="�ó�����" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="12%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UsePeople" HeaderText="�ó���" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Telephone" HeaderText="��ϵ�绰" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Task" HeaderText="��������" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									
									<asp:BoundColumn DataField="UseTime" HeaderText="�ó�ʱ��"  DataFormatString="{0:yyyy-MM-dd HH:mm}" >
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Times" HeaderText="��ʱ"  HeaderStyle-HorizontalAlign=Center >
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									
									<asp:BoundColumn DataField="PeopleNum" HeaderText="�ó�����" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Nature" HeaderText="�ó�����" HeaderStyle-HorizontalAlign=Center>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									
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

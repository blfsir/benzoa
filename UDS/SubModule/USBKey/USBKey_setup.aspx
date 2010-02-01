<%@ Page language="c#" Codebehind="USBKey_setup.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.USBKey.USBKey_setup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>USBKey_setup</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
		<script language="JavaScript" src="../../Css/calendar.js"></script>
		<script language="javascript">
			var t=false;
			function selectAll(){
			var len=document.Form1.elements.length;
			var i;
			t=!t;	
		    for (i=0;i<len;i++){
			if (document.Form1.elements[i].type=="checkbox"){
		        document.Form1.elements[i].checked=t;							
					}
				}
		    }
		    
						//设置Datagrid列宽可以被拖动的函数
						function SyDG_moveOnTd(td)
						{
							if(event.offsetX>td.offsetWidth-10)
								td.style.cursor='w-resize';
							else
								td.style.cursor='default';
							if(td.mouseDown!=null && td.mouseDown==true)
							{
								if(td.oldWidth+(event.x-td.oldX)>0)
									td.width=td.oldWidth+(event.x-td.oldX);
								td.style.width=td.width;
								td.style.cursor='w-resize';

								table=td;
								while(table.tagName!='TABLE') table=table.parentElement;
								table.width=td.tableWidth+(td.offsetWidth-td.oldWidth);table.style.width=table.width;
							}
						}
						function SyDG_downOnTd(td)
						{
							if(event.offsetX>td.offsetWidth-10)
							{
								td.mouseDown=true;
								td.oldX=event.x;
								td.oldWidth=td.offsetWidth;
								table=td;while(table.tagName!='TABLE')table=table.parentElement;
								td.tableWidth=table.offsetWidth;
							}
						}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 32px" cellSpacing="0"
					cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD>
								<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD align=center width=90 
          background='<% Response.Write(DisplayType==1?"../../images/maillistbutton1.gif":"../../images/maillistbutton2.gif"); %>' 
          height=24 style="WIDTH: 90px"><asp:linkbutton id="lbOnline" runat="server" CssClass="Newbutton">没有KEY</asp:linkbutton></TD>
										<TD align=center width=90 
          background='<% Response.Write(DisplayType==0?"../../images/maillistbutton1.gif":"../../images/maillistbutton2.gif"); %>' 
          height=24><asp:linkbutton id="lbOffLine" runat="server" CssClass="Newbutton">有KEY</asp:linkbutton></TD>
										<TD align="right"><asp:checkbox id="cb_selectAll" runat="server" Text="全选"></asp:checkbox>&nbsp;
											<asp:button id="cmdUsR_key" runat="server" CssClass="redbuttoncss" Text="开始使用KEY" Width="100px"></asp:button>&nbsp;<asp:button id="cmdNotUse_key" runat="server" CssClass="redbuttoncss" Text="停止使用KEY" Width="100px"></asp:button>&nbsp;&nbsp;</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="dbStaffList" runat="server" Width="100%" CellPadding="3" BackColor="White" BorderStyle="None"
									BorderColor="#93BEE2" BorderWidth="1px" PageSize="15" AutoGenerateColumns="False" AllowPaging="True"
									DataKeyField="Staff_ID" OnPageIndexChanged="DataGrid_PageChanged">
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
										<asp:BoundColumn DataField="RealName" HeaderText="真实姓名"></asp:BoundColumn>
										<asp:BoundColumn DataField="Position_Name" HeaderText="所在职位">
											<HeaderStyle Width="150px"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RQ" HeaderText="注册日期">
											<HeaderStyle Width="80px"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF"
										Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
					</TBODY>
				</TABLE>
				<TABLE id="Table3" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 0px" borderColor="#111111"
					height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="18" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"
							style="WIDTH: 18px"><FONT color="#003366" size="3"><IMG alt="" src="../../DataImages/usbkey2.gif"></FONT></TD>
						<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><font color="#006699">USB_KEY 
									管理</font></TD>
					</TR>
				</TABLE>
		</form>
		</FONT>
	</body>
</HTML>

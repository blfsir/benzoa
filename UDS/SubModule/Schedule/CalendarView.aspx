<%@ Page language="c#" Codebehind="CalendarView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.CalendarView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CalendarList</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function dialwinprocess(CurrDate,CurrTime,whichPg,TaskID)
			{
			   if(whichPg==1)
				var newdialoguewin = window.showModalDialog("Manage.aspx?CurrDate="+CurrDate+"&CurrTime="+CurrTime,window,"dialogWidth:1000px;DialogHeight=700px;status:no");
			   else
			   var newdialoguewin = window.showModalDialog("TaskDetail.aspx?TaskID="+TaskID,window,"dialogWidth:1000px;DialogHeight=700px;status:no");
			}
	


			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../../images/maillistbutton2.gif';
		nonactive.src = '../../../images/maillistbutton1.gif';

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
		<style>A.linkFooter:link { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkFooter:visited { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkFooter:hover { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: underline }
	A.linkFooter:active { FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #646464; LINE-HEIGHT: 25px; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	A.linkMenu:link { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkMenu:visited { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkMenu:active { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; LINE-HEIGHT: 10px; FONT-FAMILY: "宋体"; TEXT-DECORATION: underline }
	A.linkMenu:hover { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	BODY { SCROLLBAR-FACE-COLOR: #ffffff; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; SCROLLBAR-SHADOW-COLOR: #ffffff; SCROLLBAR-3DLIGHT-COLOR: #ffffff; SCROLLBAR-ARROW-COLOR: #949494; SCROLLBAR-TRACK-COLOR: #ffffff; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; SCROLLBAR-BASE-COLOR: #ffffff }
	.borderMenuLayer { BORDER-LEFT-COLOR: #c9c9c9; BORDER-BOTTOM-COLOR: #c9c9c9; BORDER-TOP-COLOR: #c9c9c9; BORDER-RIGHT-COLOR: #c9c9c9 }
	.borderMenuLayerOver { FONT-SIZE: 9pt; BORDER-LEFT-COLOR: #949494; BORDER-BOTTOM-COLOR: #949494; BORDER-TOP-COLOR: #949494; BORDER-RIGHT-COLOR: #949494 }
	.textWhite { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #999999; LINE-HEIGHT: 22px; FONT-FAMILY: "宋体" }
	.top { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #000000; FONT-FAMILY: "Arial", "Helvetica", "sans-serif"; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="CalendarList" method="post" runat="server">
			<asp:dropdownlist id="listStaff" style="Z-INDEX: 102; LEFT: 487px; POSITION: absolute; TOP: 293px" runat="server" AutoPostBack="True" Visible="False"></asp:dropdownlist>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<TABLE id="tblContainer" height="25" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td id="bar1" align="middle" width="90" background="../../images/maillistbutton1.gif">&nbsp;<FONT face="宋体"><asp:linkbutton id="lnkbtnToday" runat="server" ForeColor="Black" BackColor="Transparent" Font-Size="X-Small">今日未完成</asp:linkbutton></FONT>
								</td>
								<td id="bar2" align="middle" width="90" background="../../images/maillistbutton1.gif">&nbsp;<asp:linkbutton id="lnkbtnHistory" runat="server" ForeColor="Black" BackColor="Transparent" Font-Size="X-Small">历史未完成</asp:linkbutton></td>
								<td id="bar3" align="middle" width="90" background="../../images/maillistbutton1.gif"><asp:linkbutton id="lnkbtnFinished" runat="server" ForeColor="Black" BackColor="Transparent" Font-Size="X-Small">已完成</asp:linkbutton>&nbsp;</td>
								<td><FONT face="宋体"><asp:linkbutton id="lnkbtnReturn" runat="server" Visible="False" Font-Size="X-Small">返回</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton id="lnkbtnNew" runat="server" Font-Size="X-Small">新建</asp:LinkButton>&nbsp;&nbsp;
										<asp:linkbutton id="lnkbtnAccept" runat="server" Visible="False" Font-Size="X-Small">接受</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lnkbtnCancel" runat="server" Visible="False" Font-Size="X-Small">取消</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lnkbtnFinish" runat="server" Visible="False" Font-Size="X-Small">完成</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="lnkbtnAdd" runat="server" Visible="False" Font-Size="X-Small">任务安排</asp:linkbutton>&nbsp;</FONT></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT face="宋体">&nbsp;</FONT>&nbsp;<FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT><FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT><FONT face="宋体">&nbsp;&nbsp;</FONT><asp:table id="Table1" runat="server" Width="711px" Height="195px" BorderWidth="0px"></asp:table><asp:datagrid id="dgList" runat="server" BackColor="White" Width="100%" BorderWidth="1px" BorderColor="#93BEE2" CssClass="top" DataKeyField="ID" OnPageIndexChanged="DataGrid_PageChanged" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" PageSize="15">
							<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="选择">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="grpID" Checked="False" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="日期">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.Date").ToString()).ToShortDateString() %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="时段">
									<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString())) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="内容">
									<HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<a href="#" onclick='javascript:return dialwinprocess("","","2","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject") %>'></a>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="状态">
									<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetStatus(DataBinder.Eval(Container, "DataItem.IsConfirm").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CooperatorList" HeaderText="协同人员">
									<HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<TR>
					<TD style="WIDTH: 150px">&nbsp;&nbsp;</TD>
				</TR>
			</table>
		</form>
		<SCRIPT language="javascript">
		
		<!--
		// 高亮背景
		function high( which )
		{ 
			which.style.background = "#87F977";
			which.style.font.color = "#000000";
		}
		// 取消背景高亮
		function low( which )
		{ 
			which.style.background = "#FFF8F7";
			which.style.font.color = "#000000";
		}
		-->

		   
		</SCRIPT>
	</body>
</HTML>

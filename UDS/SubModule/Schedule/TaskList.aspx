<%@ Page language="c#" Codebehind="TaskList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.TaskList" %>
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
			   else if(whichPg==2)
			   var newdialoguewin = window.showModalDialog("TaskDetail.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
			   else if(whichPg==3)
			   var newdialoguewin = window.showModalDialog("TaskStatus.aspx?TaskID="+TaskID+"&Date="+CurrDate,window,"dialogWidth:700px;DialogHeight=600px;status:no");
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
		<style>BODY { SCROLLBAR-FACE-COLOR: #ffffff; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; SCROLLBAR-SHADOW-COLOR: #ffffff; SCROLLBAR-3DLIGHT-COLOR: #ffffff; SCROLLBAR-ARROW-COLOR: #949494; SCROLLBAR-TRACK-COLOR: #ffffff; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; SCROLLBAR-BASE-COLOR: #ffffff }
	.borderMenuLayer { BORDER-LEFT-COLOR: #c9c9c9; BORDER-BOTTOM-COLOR: #c9c9c9; BORDER-TOP-COLOR: #c9c9c9; BORDER-RIGHT-COLOR: #c9c9c9 }
	.borderMenuLayerOver { FONT-SIZE: 9pt; BORDER-LEFT-COLOR: #949494; BORDER-BOTTOM-COLOR: #949494; BORDER-TOP-COLOR: #949494; BORDER-RIGHT-COLOR: #949494 }
	.textWhite { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #999999; LINE-HEIGHT: 22px; FONT-FAMILY: "宋体" }
	.top { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #000000; FONT-FAMILY: "Arial", "Helvetica", "sans-serif"; TEXT-DECORATION: none }
		</style>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="TaskList" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="38"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="20" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"
									align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/MyTask.gif" width="16"></FONT></TD>
								<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right"><font color="#006699">我的任务</font></TD>
								<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体"><asp:button id="btnNew" runat="server" CssClass="redButtonCss" Text="新 建"></asp:button>&nbsp;
										<asp:button id="btnAccept" runat="server" CssClass="redButtonCss" Text="接 受"></asp:button>&nbsp;
										<asp:button id="btnCancel" runat="server" CssClass="redButtonCss" Text="取 消"></asp:button>&nbsp;
										<asp:button id="btnSubscribe" runat="server" CssClass="redButtonCss" Text="订 阅" Visible="False"></asp:button>&nbsp;观察视角:<asp:dropdownlist id="listStaff" runat="server" Width="105px" AutoPostBack="true" OnSelectedIndexChanged="listStaff_SelectedIndexChanged"></asp:dropdownlist></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="tblContainer" height="25" cellSpacing="0" cellPadding="0" width="100%" border="0"
							runat="server">
							<tr>
								<td id="bar1" align="center" width="90" background="../../images/maillistbutton1.gif">&nbsp;<FONT face="宋体"><asp:linkbutton id="lnkbtnToday" runat="server" CssClass=Newbutton>待完成</asp:linkbutton></FONT>
								</td>
								<td id="bar2" align="center" width="90" background="../../images/maillistbutton1.gif">&nbsp;<asp:linkbutton id="lnkbtnHistory" runat="server" CssClass=Newbutton>未完成</asp:linkbutton></td>
								<td id="bar3" align="center" width="90" background="../../images/maillistbutton1.gif"><asp:linkbutton id="lnkbtnFinished" runat="server" CssClass=Newbutton>已完成</asp:linkbutton>&nbsp;</td>
								<td id="bar4" align="center" width="90" background="../../images/maillistbutton1.gif"><FONT face="宋体">&nbsp;
									</FONT>
									<asp:linkbutton id="Linkbutton1" runat="server" CssClass=Newbutton>我的订阅</asp:linkbutton>&nbsp;</td>
								<td id="bar5" align="center" width="90" background="../../images/maillistbutton1.gif"
									style="WIDTH: 91px"><FONT face="宋体"> &nbsp;<asp:LinkButton id="lnkbtnArranged" runat="server" Width="59px"  CssClass=Newbutton>我的发起</asp:LinkButton></FONT></td>
								<td align="right"><FONT face="宋体">
										<asp:button id="btnWeeklyView" runat="server" Text="周览" CssClass="greenButtonCss"></asp:button>
										<asp:Button id="btnCancelSubscription" runat="server" Text="取消订阅" CssClass="greenButtonCss"
											Visible="False"></asp:Button></FONT></td>
							</tr>
						</TABLE>
						<asp:datagrid id="dgList" runat="server" Font-Size="X-Small" BackColor="White" CssClass="top"
							Width="100%" AllowPaging="True" CellPadding="3" AutoGenerateColumns="False" PagerStyle-Mode="NumericPages"
							PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="DataGrid_PageChanged" DataKeyField="ID"
							BorderColor="#93BEE2" BorderWidth="1px">
							<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="选择">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" Height="20px" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="grpID" Checked="False" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="时段">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.Date").ToString()).ToShortDateString()+"  "+GetPeriodByPeriodID(DataBinder.Eval(Container, "DataItem.EndTime").ToString(),DataBinder.Eval(Container, "DataItem.beginPeriodID").ToString(),(DataBinder.Eval(Container, "DataItem.endPeriodID").ToString())) %>' ID="Label2" NAME="Label2">
										</asp:Label>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date").ToString() %>' ID="Label1" NAME="Label2" Visible = "false">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="内容">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<a href="#" onclick='javascript:return dialwinprocess("<%# DataBinder.Eval(Container, "DataItem.Date") %>","","2","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject") %>' ID="Label3" NAME="Label3"></a>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="状态">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetStatus(DataBinder.Eval(Container, "DataItem.IsConfirm").ToString()) %>' ID="Label4" NAME="Label4">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="所有人">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetRealName(DataBinder.Eval(Container, "DataItem.ArrangedBy").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="执行人">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetRealNameStr(DataBinder.Eval(Container, "DataItem.CooperatorList").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CooperatorList") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="类型">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetType(DataBinder.Eval(Container, "DataItem.Type").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="所属项目">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetProjectName(DataBinder.Eval(Container, "DataItem.ProjectID").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="评论">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<a href="#" onclick='javascript:return dialwinprocess("<%# DataBinder.Eval(Container, "DataItem.Date") %>","","3","<%# DataBinder.Eval(Container, "DataItem.TaskID") %>")'>
											评论</a>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<td align="left"><FONT face="宋体"><asp:table id="Table1" runat="server" CssClass="top" Visible="False" Width="100%" BorderWidth="0px"
								Height="195px"></asp:table><asp:label id="lblInstru" runat="server" Font-Size="X-Small"><%--待办: !  待定: ?  完成: √--%> </asp:label></FONT></td>
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

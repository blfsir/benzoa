<%@ Page language="c#" Codebehind="MemberListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.MemberListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberListView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="5" leftmargin="5">
		<form id="MemberListView" method="post" runat="server">
			<FONT face="宋体">
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr height="25">
									<td style="HEIGHT: 25px" width="1"></td>
									<td id=bar1 style="HEIGHT: 25px" align=center width=90 
          background='<% Response.Write(DisplayType=="0"?"../../images/maillistbutton2.gif":"../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<A class=Newbutton href="MemberListView.aspx?TeamID=<%=ClassID%>" >项目成员</A></td>
									<td id=bar2 style="HEIGHT: 25px" align=center width=90 
          background='<% Response.Write(DisplayType=="1"?"../../images/maillistbutton2.gif":"../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<A class=Newbutton href="MemberListView.aspx?TeamID=<%=ClassID%>&amp;DisplayType=1" >非成员</A></td>
									<td id=bar3 style="HEIGHT: 25px" align=center width=90 
          background='<% Response.Write(DisplayType=="2"?"../../images/maillistbutton2.gif":"../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<a class=Newbutton href="MemberListView.aspx?TeamID=<%=ClassID%>&amp;DisplayType=2">订阅人</a></td>
									<td style="HEIGHT: 25px" align="right"><font size="2">
											<asp:CheckBox id="cbRemind" runat="server" Text="提醒本人及小组成员" Width="146px" Font-Size="X-Small"></asp:CheckBox>&nbsp;
											<input type=button onclick="javascript:self.location='Switch.aspx?Action=1&amp;ClassID=<%=ClassID%>'" value="返回" class=redButtonCss>&nbsp;
										</font>
										<asp:Button id="cmdDelete" runat="server" Text="脱离组" CssClass="redbuttoncss"></asp:Button>&nbsp;
										<asp:Button id="btnLeader" runat="server" CssClass="redButtonCss" Text="设置为组长"></asp:Button>
										<asp:Button id="btnAdd" runat="server" CssClass="redButtonCss" Text="加入组"></asp:Button>&nbsp;&nbsp;
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<asp:datagrid id="dgMemberList" runat="server" DataKeyField="staff_id" OnPageIndexChanged="DataGrid_PageChanged"
								PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True" AutoGenerateColumns="False"
								AllowSorting="True" Width="100%" BorderWidth="1px" CellPadding="3" PageSize="15" 
                                BorderColor="#93BEE2" onsortcommand="dgMemberList_SortCommand">
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White" VerticalAlign="Top"
									BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" VerticalAlign="Bottom"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="选择">
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="grpMailID" Checked="False" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="ID" SortExpression="Staff_Name">
										<ItemStyle Font-Size="X-Small"></ItemStyle>
										<ItemTemplate>
											<a href='DisplayStaffInfo.aspx?StaffID=<%# DataBinder.Eval(Container.DataItem,"staff_id") %>'>
												<%# DataBinder.Eval(Container.DataItem,"Staff_Name") %>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="RealName" HeaderText="真实姓名" SortExpression="RealName" >
										<ItemStyle Font-Size="X-Small"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="身份">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsLeader").ToString()=="1"?"组长":"成员" %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="position_name" HeaderText="所任职位" SortExpression="position_name" >
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Font-Size="X-Small"></FooterStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
									BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
				</table>
			</FONT>
		</form>
	</body>
</HTML>

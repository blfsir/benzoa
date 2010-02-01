<%@ Page language="c#" Codebehind="ListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.ListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>联系人列表</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script>
		function selectAll()
		{
			var len=document.ListView.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.ListView.elements[i].type=="checkbox"){
		        document.ListView.elements[i].checked=!document.ListView.elements[i].checked;								
						 }
					}
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="ListView" method="post" runat="server">
			<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="24" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						style="HEIGHT: 29px"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/myLinkMan.GIF" width="16"></FONT></TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="80"
						align="right" style="HEIGHT: 29px"><font color="#006699">我的联系人</font></TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"
						style="HEIGHT: 29px">
						<asp:dropdownlist id="ddl_CustomLinkmanType" runat="server" Visible="False" AutoPostBack="True" Width="100px"></asp:dropdownlist>&nbsp;<INPUT type="button" value="查 询" class="redbuttoncss" onclick="location.href='Search/index.aspx'">
						<INPUT id="btn_SelAll" onclick="selectAll()" type="button" value="全 选" class="redbuttoncss">&nbsp;
						<asp:button id="btn_Del" runat="server" Text="删 除" CssClass="redbuttoncss"></asp:button></TD>
				</TR>
				<tr>
					<td height="8" colspan="3"></td>
				<tr>
				</tr>
			</TABLE>
			<FONT face="宋体">
				<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>
							<TABLE class="gbtext" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="center" width="90" background="../../images/maillistbutton1.gif" height="24"
										id="td_Staff" runat="server">&nbsp;&nbsp;<asp:linkbutton id="lbtn_Staff" runat="server" CommandArgument="1" CssClass="Newbutton">员工联系人</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../images/maillistbutton1.gif" height="24"
										id="td_Client" runat="server">&nbsp;<asp:linkbutton id="lbtn_Client" runat="server" CommandArgument="2" CssClass="Newbutton">客户联系人</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../images/maillistbutton1.gif" height="24"
										id="td_Custom" runat="server">&nbsp;<asp:linkbutton id="lbtn_Custom" runat="server" CommandArgument="3" CssClass="Newbutton">自定义联系人</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../images/maillistbutton1.gif" height="24"
										id="td_Add" runat="server">&nbsp;<asp:hyperlink id="lbtn_AddLinkman" runat="server" NavigateUrl="AddLinkman.aspx"
											CssClass="Newbutton">添加联系人</asp:hyperlink></TD>
									<TD align="right">&nbsp;</TD>
								</TR>
							</TABLE>
							<asp:datagrid id="dgrd_CustomLinkman" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3" PageSize="15">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' NavigateUrl='<%# "CustomLinkmanInfo.aspx?ID="+DataBinder.Eval(Container,"DataItem.ID") %>' Target=_blank>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="sexname" HeaderText="性别"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="unitaddress" HeaderText="单位地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="unittelephone" HeaderText="单位电话"></asp:BoundColumn>
									<asp:HyperLinkColumn Text="详细" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="CustomLinkmanInfo.aspx?ID={0}">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:HyperLinkColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<asp:datagrid id="dgrd_ClientLinkman" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3" PageSize="15">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' NavigateUrl='<%# "../CM/Linkman.aspx?LinkmanID="+DataBinder.Eval(Container,"DataItem.ID")+"&from=mylinkman"%>' Target=_blank>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="telephone" HeaderText="电话"></asp:BoundColumn>
									<asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="unitname" HeaderText="单位"></asp:BoundColumn>
									<asp:BoundColumn DataField="position" HeaderText="职务"></asp:BoundColumn>
									<asp:BoundColumn DataField="address" HeaderText="家庭地址"></asp:BoundColumn>
									<asp:HyperLinkColumn Text="详细" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="../CM/Linkman.aspx?LinkmanID={0}&amp;from=mylinkman">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:HyperLinkColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="dgrd_StaffLinkman" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3" PageSize="15">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="真实姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.realname") %>' NavigateUrl='<%# "../UnitiveDocument/Mail/Compose.aspx?Action=3&ClassID=0&Username="+ DataBinder.Eval(Container.DataItem,"staff_Name")+"&Name="+DataBinder.Eval(Container,"DataItem.RealName") %>' Target=_blank >
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Age" HeaderText="年龄"></asp:BoundColumn>
									<asp:BoundColumn DataField="SexName" HeaderText="性别"></asp:BoundColumn>
									<asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="Position_Name" HeaderText="所属职位"></asp:BoundColumn>
									<asp:BoundColumn DataField="RQ" HeaderText="注册日期"></asp:BoundColumn>
									<asp:HyperLinkColumn Text="详细" Target="_blank" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="StaffInfo.aspx?Staff_ID={0}">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:HyperLinkColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

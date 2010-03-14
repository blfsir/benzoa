<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.Search.index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>index</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
						align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myLinkman.gif" width="16"></FONT></TD>
					<TD width="60" height="30"
						align="center" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" class="GbText" style="WIDTH: 75px">联系人管理</TD>
					<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right">&nbsp;</TD>
				</TR>
			</TABLE>
			<FONT face="宋体">
				<TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" borderColor="#93bee2" class="GbText" id="Table1"
					style="BORDER-COLLAPSE: collapse">
					<TR>
						<TD style="WIDTH: 100px" colSpan="2" align="center" height="36">联系人查询</TD>
						<TD height="36">请选择联系人类型
							<asp:DropDownList id="ddl_SearchType" runat="server" AutoPostBack="True">
								<asp:ListItem Value="staff">员工联系人</asp:ListItem>
								<asp:ListItem Value="linkman">客户联系人</asp:ListItem>
								<asp:ListItem Value="custom">自定义联系人</asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<TABLE id="tbl_StaffSearch" borderColor="#93bee2" cellSpacing="0" cellPadding="3" width="100%"
								border="1" style="BORDER-COLLAPSE: collapse" class="GbText" runat="server">
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">姓名</TD>
									<TD height="30">
							    <asp:TextBox id="tbx_StaffName" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">手机</TD>
									<TD height="30">
										<asp:TextBox id="tbx_StaffMobile" runat="server" CssClass="inputcss"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">性别</TD>
									<TD height="30">
									  <asp:DropDownList id="ddl_StaffGender" runat="server" Width="130px">
											<asp:ListItem Value="0">无限制</asp:ListItem>
											<asp:ListItem Value="male">男</asp:ListItem>
											<asp:ListItem Value="female">女</asp:ListItem>
										</asp:DropDownList></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">Email</TD>
									<TD height="30">
										<asp:TextBox id="tbx_StaffEmail" runat="server" CssClass="inputcss"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">职位</TD>
									<TD height="30">
							    <asp:DropDownList id="ddl_StaffPosition" runat="server" Width="130px"></asp:DropDownList></TD>
									<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;</TD>
									<TD height="30">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE id="tbl_LinkmanSearch" borderColor="#93bee2" cellSpacing="0" cellPadding="3" width="100%"
								border="1" style="BORDER-COLLAPSE: collapse" class="GbText" runat="server">
<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">姓名</TD>
									<TD height="30">
										<asp:TextBox id="tbx_LinkmanName" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">性别</TD>
									<TD height="30">
										<asp:DropDownList id="ddl_LinkmanGender" runat="server" Width="130px">
											<asp:ListItem Value="0">无限制</asp:ListItem>
											<asp:ListItem Value="male">男</asp:ListItem>
											<asp:ListItem Value="female">女</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">电话</TD>
									<TD height="30">
										<asp:TextBox id="tbx_Telephone" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">Email</TD>
									<TD height="30">
										<asp:TextBox id="tbx_LinkmanEmail" runat="server" CssClass="inputcss"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">单位</TD>
									<TD height="30">
										<asp:TextBox id="tbx_LinkmanUnit" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">职务</TD>
									<TD height="30">
										<asp:TextBox id="tbx_LinkmanPosition" runat="server" CssClass="inputcss"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">手机</TD>
									<TD height="30">
										<asp:TextBox id="tbx_LinkmanMobile" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;</TD>
									<TD height="30">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE id="tbl_CutomSearch" borderColor="#93bee2" cellSpacing="0" cellPadding="3" width="100%"
								border="1" style="BORDER-COLLAPSE: collapse" class="GbText" runat="server">
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">姓名</TD>
									<TD height="30">
										<asp:TextBox id="tbx_CutomName" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">性别</TD>
									<TD height="30">
										<asp:DropDownList id="ddl_CustomGender" runat="server" Width="130px">
											<asp:ListItem Value="0">无限制</asp:ListItem>
											<asp:ListItem Value="male">男</asp:ListItem>
											<asp:ListItem Value="female">女</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">手机</TD>
									<TD height="30">
										<asp:TextBox id="tbx_CutomMobile" runat="server" CssClass="inputcss"></asp:TextBox></TD>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">Email</TD>
									<TD height="30">
										<asp:TextBox id="tbx_CutomEmail" runat="server" CssClass="inputcss"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="120" height="30" align="center" bgcolor="#E8F4FF">类别</TD>
									<TD height="30">
										<asp:DropDownList id="ddl_CustomCatalog" runat="server" Width="130px"></asp:DropDownList></TD>
									<TD width="120" height="30" bgcolor="#E8F4FF">&nbsp;</TD>
									<TD height="30">&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3" height="30">
							<asp:Button id="btn_OK" runat="server" Text=" 查  询 " CssClass="buttoncss" Width="80px"></asp:Button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="98%" border="0" align="center">
			  <TR>
						<TD colSpan="2">
							<asp:DataGrid id="dgrd_Staff" runat="server" Width="100%" AutoGenerateColumns="False" Visible="False">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server" ID="Checkbox1"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="真实姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.realname") %>' NavigateUrl='<%# "../../UnitiveDocument/Mail/Compose.aspx?Action=3&ClassID=0&Username="+ DataBinder.Eval(Container.DataItem,"staff_Name")+"&Name="+DataBinder.Eval(Container,"DataItem.RealName") %>' Target=_blank ID="Hyperlink1">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>' ID="Label1">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Age" HeaderText="年龄"></asp:BoundColumn>
									<asp:BoundColumn DataField="SexName" HeaderText="性别"></asp:BoundColumn>
									<asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="Position_Name" HeaderText="所属职位"></asp:BoundColumn>
									<asp:BoundColumn DataField="RQ" HeaderText="注册日期"></asp:BoundColumn>
									<asp:HyperLinkColumn Text="详细" Target="_blank" DataNavigateUrlField="staff_id" DataNavigateUrlFormatString="../StaffInfo.aspx?Staff_ID={0}">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:HyperLinkColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="dgrd_Linkman" runat="server" Width="100%" AutoGenerateColumns="False" Visible="False">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server" ID="Checkbox3"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' NavigateUrl='<%# "../../CM/Linkman.aspx?LinkmanID="+DataBinder.Eval(Container,"DataItem.ID")+"&from=mylinkman"%>' Target=_blank ID="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>' ID="Label2">
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>' ID="Textbox2">
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
							</asp:DataGrid>
							<asp:DataGrid id="dgrd_Custom" runat="server" Width="100%" AutoGenerateColumns="False" Visible="False">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="20px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox name="cbx_" Runat="server" ID="Checkbox2"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="姓名">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>' NavigateUrl='<%# "CustomLinkmanInfo.aspx?ID="+DataBinder.Eval(Container,"DataItem.ID") %>' Target=_blank ID="Hyperlink3">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="sexname" HeaderText="性别"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="手机">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>' ID="Label3">
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.mobile") %>' ID="Textbox1">
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
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

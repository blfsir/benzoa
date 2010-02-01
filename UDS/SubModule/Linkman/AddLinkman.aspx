<%@ Page language="c#" Codebehind="AddLinkman.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.AddLinkman" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>添加联系人</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="AddLinkman" method="post" runat="server">
			<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="30">
					<TD class="GbText" width="24" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../Images/icon/057.GIF" width="16"></FONT></TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="80"
						align="right"><font color="#006699">我的联系人</font></TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right">
						选择联系人类别
						<asp:dropdownlist id="ddl_LinkmanType" runat="server" AutoPostBack="True">
							<asp:ListItem Value="staff">公司员工</asp:ListItem>
							<asp:ListItem Value="client">客户联系人</asp:ListItem>
							<asp:ListItem Value="custom">自定义</asp:ListItem>
						</asp:dropdownlist>&nbsp;
						<asp:Button id="btn_Back" runat="server" Text="返 回" CssClass="redbuttoncss" CausesValidation="False"></asp:Button>&nbsp;
						<asp:button id="btn_AddList" runat="server" Text="添 加" CssClass="redbuttoncss"></asp:button></TD>
				</TR>
				<tr>
					<td height="8" colspan="3"></td>
				<tr>
				</tr>
			</TABLE>
			<FONT face="宋体">
				<TABLE style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0"
					width="100%" align="center" border="0" class="gbtext">
					<TR>
						<TD width="100%" colSpan="3">
							<TABLE class="gbtext" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="center" width="90" background="../../images/maillistbutton2.gif" height="24"
										class="Newbutton">&nbsp;添加联系人</TD>
									<TD align="right" style="WIDTH: 211px">&nbsp;&nbsp;&nbsp;</TD>
									<TD align="right">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="right" width="100%" colSpan="3">
							<TABLE id="tbl_Select" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
								<TR>
									<TD width="100%" colSpan="2"><asp:datagrid id="dgrd_List" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
											Visible="False" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3" PageSize="15">
											<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<ItemTemplate>
														<asp:CheckBox Runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="真实姓名">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Realname")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="手机">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Mobile")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="年龄">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Age")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="性别">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"SexName")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Email">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Email")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="所在职位">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Position_Name")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="注册日期">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"RQ")%>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
										</asp:datagrid><asp:datagrid id="dgrd_Linkman" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
											Visible="False" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3">
											<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" ForeColor="#FFFFFF" BackColor="#337FB2"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<ItemTemplate>
														<asp:CheckBox Runat="server" ID="Checkbox1"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="姓名">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Name")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="手机">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Mobile")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="电话">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Telephone")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Email">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Email")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="单位">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"UnitName")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="职务">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Position")%>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="家庭住址">
													<ItemTemplate>
														<%#  DataBinder.Eval(Container.DataItem,"Address")%>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
							<TABLE id="tbl_Custom" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0"
								cellPadding="0" width="100%" align="center" border="1" class="gbtext" runat="server">
								<TR>
									<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;姓名</TD>
									<TD height="24" style="WIDTH: 82px">&nbsp;<asp:textbox id="tbx_Name" runat="server" CssClass="inputcss"></asp:textbox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空" ControlToValidate="tbx_Name"
											Display="Dynamic"></asp:RequiredFieldValidator></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;性别</TD>
									<TD height="24" style="WIDTH: 128px">&nbsp;<SELECT id="ddl_Gender" name="Select1" runat="server">
											<OPTION value="1" selected>男</OPTION>
											<OPTION value="0">女</OPTION>
										</SELECT></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;年&nbsp;&nbsp;&nbsp; 龄</TD>
									<TD height="24">&nbsp;<asp:textbox id="tbx_Age" runat="server" CssClass="inputcss" Width="56px"></asp:textbox>
										<asp:RangeValidator id="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="tbx_Age"
											ErrorMessage="年龄错误" MinimumValue="1" MaximumValue="200" Type="Integer"></asp:RangeValidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;单位地址</TD>
									<TD height="24" style="WIDTH: 82px">&nbsp;<asp:textbox id="tbx_UnitAddress" runat="server" CssClass="inputcss"></asp:textbox></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;单位电话</TD>
									<TD height="24" style="WIDTH: 128px">&nbsp;<asp:textbox id="tbx_UnitTelephone" runat="server" CssClass="inputcss"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="输入数字" ControlToValidate="tbx_UnitTelephone"
											Display="Dynamic" ValidationExpression="\d*"></asp:RegularExpressionValidator></TD>
									<TD align="left" height="24" bgcolor="#e8f4ff">&nbsp;单位邮编</TD>
									<TD height="24">&nbsp;<asp:textbox id="tbx_UnitZip" runat="server" CssClass="inputcss" Width="57px"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ErrorMessage="邮编错误" ControlToValidate="tbx_UnitZip"
											Display="Dynamic" ValidationExpression="\d{6}"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;家庭地址</TD>
									<TD height="24" style="WIDTH: 82px">&nbsp;<asp:textbox id="tbx_FamilyAddress" runat="server" CssClass="inputcss"></asp:textbox></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;家庭电话</TD>
									<TD height="24" style="WIDTH: 128px">&nbsp;<asp:textbox id="tbx_FamilyTelephone" runat="server" CssClass="inputcss"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="输入数字" ControlToValidate="tbx_FamilyTelephone"
											Display="Dynamic" ValidationExpression="\d*"></asp:RegularExpressionValidator></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;家庭邮编</TD>
									<TD height="24">&nbsp;<asp:textbox id="tbx_FamilyZip" runat="server" CssClass="inputcss" Width="59px"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" ErrorMessage="邮编错误" ControlToValidate="tbx_FamilyZip"
											Display="Dynamic" ValidationExpression="\d{6}"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;手机</TD>
									<TD height="24" style="WIDTH: 82px">&nbsp;<asp:textbox id="tbx_Mobile" runat="server" CssClass="inputcss"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="输入数字" ControlToValidate="tbx_Mobile"
											ValidationExpression="\d*" Display="Dynamic"></asp:RegularExpressionValidator></TD>
									<TD height="24" bgcolor="#e8f4ff">&nbsp;E-Mail</TD>
									<TD height="24" style="WIDTH: 128px">&nbsp;<asp:textbox id="tbx_Email" runat="server" CssClass="inputcss"></asp:textbox>
										<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="格式错误" Display="Dynamic"
											ControlToValidate="tbx_Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
									<TD height="24"></TD>
									<TD height="24"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;类别</TD>
									<TD colSpan="5" height="24"><asp:datalist id="dlt_Type" runat="server" RepeatDirection="Horizontal" RepeatColumns="10" HorizontalAlign="Left"
											Font-Size="X-Small">
											<ItemTemplate>
												<asp:CheckBox Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Type") %>' EnableViewState=True>
												</asp:CheckBox>
											</ItemTemplate>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 73px; HEIGHT: 99px" vAlign="top" align="left" bgcolor="#e8f4ff">&nbsp;备注</TD>
									<TD style="HEIGHT: 99px" vAlign="top" colSpan="5"><asp:textbox id="tbx_Memo" runat="server" Width="581px" Height="95px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="6" height="40"><asp:button id="btn_OK" runat="server" Text=" 确 认 " CssClass="buttoncss"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

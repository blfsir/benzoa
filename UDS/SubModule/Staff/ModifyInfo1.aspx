<%@ Page language="c#" Codebehind="ModifyInfo1.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.ModifyInfo" %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ModifyInfo</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			//全选checkbox
			function SelectItem()
			{
				var i = 0;
				var e;

				for( i = 0 ; i < ListView.elements.length ; i ++ )
				{
					e = ListView.elements[ i ];
					if( e.type == "checkbox" )	e.checked = !e.checked;
				}
			}
			
			// 高亮背景
			function high( which )
			{ 
				which.style.background = "#C0D9E6";
				which.style.font.color = "red";
			} 

			// 取消背景高亮
			function low( which )
			{ 
				which.style.background = "#FFFFFF";
				which.style.font.color = "black";
			}
			
		</script>
		<script language="csharp" runat="server">
		public string GetSex(string sex,string id)
		{	
			if(id!="")
				return((sex=="True")?"女":"男");
			else
				return("");			
		}
		public string GetAge(string birthday)
		{
			if((birthday!="")&&(DateTime.Parse(birthday)!=DateTime.Parse("1900-1-1")))
				return(((int)(DateTime.Now.Year-(DateTime.Parse(birthday)).Year)+1).ToString());
			else
				return("");
		}
		public int GetSexList(string sex,string id)
		{
			if(id!="")
			{
				return((sex=="True")?1:0);
			}
			else
				return(0);
		}
		</script>
	</HEAD>
	<body text="#000000" leftMargin="2" topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="ListView" runat="server">
			<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#ccccc" height="13" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="HEIGHT: 185px" width="100%" colSpan="8" height="185">
						<table id="AutoNumber2" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="55" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="100%" colSpan="8">
									<table id="AutoNumber4" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="GbText" width="3%" bgColor="#c0d9e6"><IMG height="16" src="../../Images/icon/07.gif" width="16"></td>
											<td class="GbText" width="16%" bgColor="#c0d9e6" height="1"><b><A title="刷新" href="javascript:location.reload()">人力资源列表</A>
												</b>
											</td>
											<td class="GbText" width="5%" bgColor="#c0d9e6"><b><A title="返回主界面" href="../UnitiveDocument/index.asp" target="main">返回</A></b></td>
											<td width="21%" background="../../images/line1.gif" height="1">&nbsp;
											</td>
											<td width="96%" height="1">
												<table id="AutoNumber5" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td align=middle width="8%" 
                      bgColor='<% if(displaytype==false) Response.Write("#C0D9E6");%>' 
                      >
															<P><FONT face="宋体"><A title="显示在职人员列表" href="ModifyInfo.aspx?displayType=0">在职人员</A></FONT></P>
														</td>
														<td align=middle width="8%" 
                      bgColor='<% if(displaytype==true) Response.Write("#C0D9E6");%>' 
                      height=1><FONT face="宋体"><A title="显示离职人员列表" href="ModifyInfo.aspx?displayType=1">离职人员</A></FONT>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr bgColor="#c0d9e6">
								<td width="100%" colSpan="8"><asp:datagrid id="StaffList" runat="server" PageSize="20" AutoGenerateColumns="False" Width="100%" AllowPaging="True" DataKeyField="Staff_ID">
										<ItemStyle Font-Size="Smaller" ForeColor="Black"></ItemStyle>
										<HeaderStyle Font-Size="Smaller" Font-Names="宋体" HorizontalAlign="Center" ForeColor="Blue" VerticalAlign="Bottom" BackColor="LightBlue"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="Staff_ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="用户名">
												<ItemTemplate>
													<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.staff_name") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="10%"></ItemStyle>
												<HeaderTemplate>
													真实姓名
												</HeaderTemplate>
												<ItemTemplate>
													<%# ((DataRowView)Container.DataItem)["RealName"]%>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox ID="realname" TextMode=SingleLine Text='<%# ((DataRowView)Container.DataItem)["RealName"]%>' Columns="10" Runat=server>
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="10%"></ItemStyle>
												<HeaderTemplate>
													手机
												</HeaderTemplate>
												<ItemTemplate>
													<%# ((DataRowView)Container.DataItem)["Mobile"]%>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox ID="mobile" TextMode=SingleLine Text='<%# ((DataRowView)Container.DataItem)["Mobile"]%>' Columns="15" Runat=server>
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="年龄">
												<ItemTemplate>
													<asp:Literal ID="old" Runat="server" Text='<%# GetAge(((DataRowView)Container.DataItem)["Birthday"].ToString()) %>'>
													</asp:Literal>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="性别">
												<ItemStyle Width="5%"></ItemStyle>
												<ItemTemplate>
													<asp:Literal ID="sex" Runat="server" Text='<%# GetSex(((DataRowView)Container.DataItem)["sex"].ToString(),((DataRowView)Container.DataItem)["Staff_ID"].ToString()) %>'>
													</asp:Literal>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="gender" Runat="server" SelectedIndex = '<%# GetSexList(((DataRowView)Container.DataItem)["sex"].ToString(),((DataRowView)Container.DataItem)["Staff_ID"].ToString()) %>'>
														<asp:ListItem Value="false">男</asp:ListItem>
														<asp:ListItem Value="true">女</asp:ListItem>
													</asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="10%"></ItemStyle>
												<HeaderTemplate>
													EMAIL
												</HeaderTemplate>
												<ItemTemplate>
													<%#((DataRowView)Container.DataItem)["Email"]%>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:TextBox ID="email" Text='<%#((DataRowView)Container.DataItem)["Email"]%>' Columns="15" Runat=server>
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="10%"></ItemStyle>
												<HeaderTemplate>
													所在部门
												</HeaderTemplate>
												<ItemTemplate>
													<%#((DataRowView)Container.DataItem)["Department_Name"]%>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList ID="department" Runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle Width="20%"></ItemStyle>
												<HeaderTemplate>
													注册日期
												</HeaderTemplate>
												<ItemTemplate>
													<%#((DataRowView)Container.DataItem)["RegistedDate"]%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Department_ID" ReadOnly="True"></asp:BoundColumn>
											<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="修改" CancelText="" EditText="选择"></asp:EditCommandColumn>
										</Columns>
										<PagerStyle Visible="False" Font-Size="Smaller" Font-Names="宋体" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr bgColor="#c0d9e6">
					<td class="GbText" style="HEIGHT: 31px" width="83%" bgColor="#c0d9e6" height="31">&nbsp;<input class="ButtonCss" id="btn_Go" style="WIDTH: 36px; HEIGHT: 20px" type="button" value="转到" name="btn_Go" runat="server">
						第<asp:textbox id="txb_PageNo" Width="20" Runat="server" CssClass="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #fffffb 1px solid; BORDER-LEFT: #ffffff 1px solid; COLOR: #5e5e5e; BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center" TextMode="SingleLine"></asp:textbox>
						页,每页显示<asp:textbox id="txb_ItemPerPage" onmouseover="high( this );" onmouseout="low( this );" Width="20" Runat="server" CssClass="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #fffffb 1px solid; BORDER-LEFT: #ffffff 1px solid; COLOR: #5e5e5e; BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center" TextMode="SingleLine"></asp:textbox>条记录,共有
						<asp:label id="lbl_totalrecord" runat="server" Width="10px" Height="8px"></asp:label>页记录.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_first" runat="server" Width="23" Height="23" BorderWidth="0" ImageUrl="../../Images/top.gif" CommandArgument="first" ToolTip="第一页"></asp:imagebutton></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_pre" Width="23" Runat="server" BorderWidth="0" ImageUrl="../../Images/prev.gif" CommandArgument="pre" ToolTip="前一页"></asp:imagebutton></td>
					<td class="GbText" style="HEIGHT: 31px" align="middle" width="8%" height="31"><asp:label id="lbl_curpage" runat="server">Label</asp:label>/
						<asp:label id="lbl_totalpage" runat="server">Label</asp:label></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_next" Width="23" Runat="server" Height="23" BorderWidth="0" ImageUrl="../../Images/next.gif" CommandArgument="next" ToolTip="下一页"></asp:imagebutton></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_last" Width="23" Runat="server" Height="23" BorderWidth="0" ImageUrl="../../Images/end.gif" CommandArgument="last" ToolTip="最后一页"></asp:imagebutton></td>
				</tr>
				<tr>
					<td width="100%" colSpan="8">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td></td>
								<td align="right"><IMG height="25" src="../../images/endbott.gif" width="279"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

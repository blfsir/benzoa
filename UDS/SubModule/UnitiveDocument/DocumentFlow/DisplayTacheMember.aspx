<%@ Page language="c#" Codebehind="DisplayTacheMember.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.DisplayTacheMember" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DisplayTacheMember</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function ReturnBack(ReturnPage)
		{
			if(ReturnPage<=3)
				location.href ="ListDocument.aspx?DisplayType=" + ReturnPage;
			else
				location.href ="FlowTemplate.aspx";
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="DisplayTacheMember" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>
							<TABLE id="Table2" height="24" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif' 
          >&nbsp;
										<asp:linkbutton id="lbAllMember" runat="server">全体成员</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          >&nbsp;
										<asp:linkbutton id="lbReceiver" runat="server">呈送人员</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          >&nbsp;
										<asp:linkbutton id="lbSignIner" runat="server">已签人员</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' 
          >&nbsp;
										<asp:linkbutton id="lbUnSignIner" runat="server">未签人员</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,4));%>.gif' 
          >&nbsp;
										<asp:linkbutton id="lbPostiler" runat="server">已批人员</asp:linkbutton></TD>
									<TD align="right"><INPUT class=redButtonCss style="WIDTH: 64px; HEIGHT: 20px" onclick="ReturnBack(<%=ReturnPage%>)" type=button value=返回>&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dbStaffList" runat="server" Width="100%" DataKeyField="Staff_ID" AllowPaging="True"
								AutoGenerateColumns="False" PageSize="15" BorderWidth="1px" BackColor="White" BorderColor="#93BEE2"
								BorderStyle="None" CellPadding="3" OnPageIndexChanged="DataGrid_PageChanged">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ID">
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Staff_ID" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="真实姓名">
										<HeaderStyle HorizontalAlign="Left" Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<A href='../Mail/Compose.aspx?Action=3&amp;ClassID=0&amp;&amp;UserName=<%# DataBinder.Eval(Container, "DataItem.Staff_Name") %>&amp;Name=<%# DataBinder.Eval(Container, "DataItem.RealName") %>' title='发送内部邮件'>
												<%# DataBinder.Eval(Container, "DataItem.RealName") %>
											</A>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SexName" HeaderText="性别">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="EMAIL">
										<HeaderStyle HorizontalAlign="Left" Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<a href='mailto:<%# DataBinder.Eval(Container, "DataItem.Email") %>' title='发送外部邮件'>
												<%# DataBinder.Eval(Container, "DataItem.Email") %>
											</a>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Position_Name" HeaderText="职位">
										<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF"
									Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="onlineperson.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.onlineperson" %>
<%@ Import namespace = "System" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>������Ա</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private TimeSpan GetOnlineTime(DateTime logintime,DateTime activetime)
		{
			return(activetime - logintime);
		}
		</script>
		<script language="javascript">
		function SendMsg(username,realname)
		{
			window.opener.parent.parent.MainFrame.location='../SM/MsgSend.aspx?SendTo='+username+'&SendToRealName='+realname;
			window.close();
		}
		</script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="onlineperson" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD background="../../Images/treetopbg.jpg" height="30"><font size="2">����������ϸ</font></TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgrd_OnlinePerson" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
								BorderWidth="1px" BorderStyle="None" BorderColor="#93BEE2" class="gbtext" CellPadding="2">
								<HeaderStyle Font-Size="X-Small" Height="24px" BackColor="#E8F4FF"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="����">
										<ItemTemplate>
											<a href="#" onclick='javascript:SendMsg("<%# DataBinder.Eval(Container, "DataItem.Staff_Name") %>","<%# DataBinder.Eval(Container, "DataItem.realname") %>")'>
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.realname") %>'>
												</asp:Label></a> </asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.realname") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="LoginTime" HeaderText="��½ʱ��">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DateTime.Parse(DataBinder.Eval(Container, "DataItem.LoginTime").ToString()).ToShortTimeString() %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="����ʱ��">
										<ItemTemplate>
											<%#  GetOnlineTime(DateTime.Parse(DataBinder.Eval(Container.DataItem,"LoginTime").ToString()),DateTime.Parse(DataBinder.Eval(Container.DataItem,"ActiveTime").ToString())).ToString()%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="IpAddr" HeaderText="IP��ַ"></asp:BoundColumn>
									<asp:BoundColumn DataField="Position_Name" SortExpression="Position_Name" HeaderText="ְλ"></asp:BoundColumn>
									<asp:BoundColumn DataField="activeclass" SortExpression="ActiveClass" HeaderText="λ��"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

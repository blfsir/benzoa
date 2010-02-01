<%@ Import namespace="System" %>
<%@ Import Namespace="System.Data" %>
<%@ Page language="c#" Codebehind="LinkmanListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.LinkmanListView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>LinkmanListView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="C#" runat="server">
		private string GetGender(bool sex)
		{
			if(sex==true)
			{
				return ("男");
			}
			else
				return ("女");
		}
		</script>
</HEAD>
	<body>
		<form id="LinkmanListView" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="gbtext">
					<TR>
						<TD>共
							<asp:literal id="ltl_Count" runat="server"></asp:literal>条记录&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:hyperlink id="hlk_Add" runat="server" NavigateUrl="Linkman.aspx" Target="_blank" Font-Size="X-Small">添加</asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:HyperLink id="hlk_Mod" NavigateUrl="Linkman.aspx" runat="server" Target="_blank" Font-Size="X-Small">修改</asp:HyperLink>&nbsp;&nbsp;&nbsp;
							<asp:HyperLink id="hlk_Search" runat="server" Font-Size="X-Small">查询</asp:HyperLink></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_Linkman" runat="server" AutoGenerateColumns="False" AllowPaging="True"
								Width="100%" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3" PageSize="15" CssClass="gbtext">
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="X-Small"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="姓名">
										<HeaderStyle Font-Size="X-Small"></HeaderStyle>
										<ItemStyle Font-Size="X-Small"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="性别">
										<ItemTemplate>
											<%# GetGender(Convert.ToBoolean(((DataRowView)Container.DataItem)["Gender"]))%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Mobile" HeaderText="手机"></asp:BoundColumn>
									<asp:BoundColumn DataField="LastContactTime" HeaderText="最近接触时间"></asp:BoundColumn>
									<asp:BoundColumn DataField="ClientName" HeaderText="客户名称"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="上一页" PrevPageText="下一页" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

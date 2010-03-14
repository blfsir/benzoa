<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="ContactedClient.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.ContactedClient" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ContactedClient</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private string GetLinkMan(DataRow[] row)
		{
			if(row.Length!=0)
			{
				return(row[0]["Name"].ToString());
			}
			else
				return ("");
		}
		private string GetCurStatus(string curstatus)
		{
			switch(curstatus.Split(',')[0].ToString())
			{
				case "trace":
					return ("跟踪");
					break;
				case "boot":
					return ("启动");
					break;
				case "commend":
					return ("产品推荐");
					break;
				case "requirement":
					return ("需求定义");
					break;
				case "submit":
					return ("方案提交");
					break;
				case "negotiate":
					return ("商务谈判");
					break;
				case "actualize":
					return ("项目实施");
					break;
				case "traceservice":
					return ("跟踪服务");
					break;
				case "last":
					return ("收尾款");
					break;
			}
			return("");
		}
		private string GetAddMan(DataRow[] row)
		{
			if(row.Length!=0)
			{
				return(row[0]["realname"].ToString());
			}
			else
				return ("");
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftMargin="0" topmargin="0">
		<form id="ContactedClient" method="post" runat="server">
			<FONT face="宋体">
				<TABLE width="98%" border="1" align="center" cellPadding="1" cellSpacing="1" id="Table1">
					<TR>
						<TD>共接触
							<asp:Literal id="ltl_Client" runat="server"></asp:Literal>位客户</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_Client" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
								CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ID" HeaderText="编号"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="客户名称">
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Target="_blank" NavigateUrl='<%# "../Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
											</asp:HyperLink>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ContactTimes" HeaderText="接触次数"></asp:BoundColumn>
									<asp:BoundColumn DataField="BargainPrognosis" HeaderText="成交预估"></asp:BoundColumn>
									<asp:BoundColumn DataField="UpdateTime" HeaderText="更新时间"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="接触状态">
										<ItemTemplate>
											<%# GetCurStatus(DataBinder.Eval(Container.DataItem,"CurStatus").ToString()) %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="添加人">
										<ItemTemplate>
											<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("StaffID_Staff")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

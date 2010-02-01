<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="ContactInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.ContactInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ContactInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../Css/meizzDate.js"></script>
		<script language="C#" runat="server">
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
				return(row[0]["Staff_Name"].ToString());
			}
			else
				return ("");
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ContactInfo" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 12px" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>查询条件：
							<asp:DropDownList id="ddl_search" runat="server" AutoPostBack="True">
								<asp:ListItem Value="销售人员姓名">销售人员姓名</asp:ListItem>
								<asp:ListItem Value="客户名称">客户名称</asp:ListItem>
								<asp:ListItem Value="客户编号">客户编号</asp:ListItem>
								<asp:ListItem Value="销售阶段">销售阶段</asp:ListItem>
								<asp:ListItem Value="成交预估">成交预估</asp:ListItem>
								<asp:ListItem Value="已接洽次数">已接洽次数</asp:ListItem>
								<asp:ListItem Value="接洽对象职务">接洽对象职务</asp:ListItem>
								<asp:ListItem Value="首次接洽时间">首次接洽时间</asp:ListItem>
								<asp:ListItem Value="最后一次接洽时间">最后一次接洽时间</asp:ListItem>
								<asp:ListItem Value="下次约见时间">下次约见时间</asp:ListItem>
								<asp:ListItem Value="本周新增记录">本周新增记录</asp:ListItem>
								<asp:ListItem Value="本月新增记录">本月新增记录</asp:ListItem>
							</asp:DropDownList>
							<asp:TextBox id="tbx_searchvalue" runat="server"></asp:TextBox>
							<asp:RadioButtonList id="rbl_searchvalue" runat="server"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btn_addsearch" runat="server" Text="添加"></asp:Button>&nbsp;
							<asp:Button id="btn_Del" runat="server" Text="删除"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:ListBox id="lbx_search" runat="server" Width="523px"></asp:ListBox>
							<asp:Button id="btn_OK" runat="server" Text="查询"></asp:Button></TD>
					</TR>
					<TR>
						<TD>共查到
							<asp:Literal id="ltl_Client" runat="server"></asp:Literal>位符合条件的客户</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_ContactList" Width="100%" runat="server" AutoGenerateColumns="False" AllowPaging="True">
								<Columns>
									<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="编号"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="NAME" HeaderText="客户名称">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' NavigateUrl='<%# "Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Target="_blank" ID="Hyperlink1">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ContactTimes" SortExpression="ContactTimes" HeaderText="接触次数"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="成交预估">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BargainPrognosis") %>' NavigateUrl='<%# "ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Target="_blank" ID="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="UpdateTime" SortExpression="UpdateTime" HeaderText="更新时间"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="接触状态">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# GetCurStatus(DataBinder.Eval(Container,"DataItem.Curstatus").ToString()) %>' NavigateUrl='<%# "ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' ID="Hyperlink3" NAME="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="添加人">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientAddMan_Staff")) %>' ID="Label1">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="上一页" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

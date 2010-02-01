<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="UDS.Components"  %>
<%@ Page language="c#" Codebehind="Fee.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.Fee" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Fee</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../Css/meizzDate.js"></script>
		<script language="javascript">
		function fillstring(str)
		{
			if(str.length==1)
			{
				str = "0" + str; 
			}
			return(str);
		}
		function quickseldate(type)
		{
			var begintime,endtime;
			var oneminute = 60*1000;
			var onehour   = 60*oneminute;
			var oneday    = 24*onehour;
			var oneweek   = 7*oneday;
			
			var todayDate = new Date();
			var date = todayDate.getDate();
			var month= todayDate.getMonth() +1;
			var year= todayDate.getYear();
			var day = todayDate.getDay();
			if(navigator.appName == "Netscape")
			{
				year = 1900 + year;
			}

			//-->
						
			if(type=="day")
			{
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				endtime = begintime;
			}
			else if(type=="week")
			{
				var daytoMon = day-1;
				if(day==0) 
					daytoMon = 6;
				
				todayDate.setTime(todayDate.getTime()-daytoMon*oneday);
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				day = todayDate.getDay();
				
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				
				todayDate.setTime(todayDate.getTime()+6*oneday);
				
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				
				endtime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
			}
			else if(type=="month")
			{
				var dateto1 = date-1;
				
				todayDate.setTime(todayDate.getTime()-dateto1*oneday);
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				day = todayDate.getDay();
				
				begintime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());
				
				todayDate.setMonth(month);
				todayDate.setTime(todayDate.getTime()-oneday);
				
				date = todayDate.getDate();
				month= todayDate.getMonth() +1;
				year= todayDate.getYear();
				
				endtime = year.toString() + "-" + fillstring(month.toString()) + "-" + fillstring(date.toString());

			}

			document.getElementById("tbx_begintime").value = begintime;
			document.getElementById("tbx_endtime").value = endtime;
		
		}
		</script>
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
		private int GetFee(DataRow[] row)
		{
			int fee = 0;
			if(row.Length!=0)
			{
				foreach(DataRow datarow in row)
				{
					fee += Int32.Parse(datarow["fee"].ToString());
				}
				totalfee += fee;
				return(fee);
			}
			else
				return(0);
		
		}
		private string GetTravel(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			return(cm.GetTravelFeeBySellmanID(sellmanid,begintime,endtime).ToString());
		}
		private string GetFood(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			return(cm.GetFoodFeeBySellmanID(sellmanid,begintime,endtime).ToString());
		}
		private string GetGift(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			return(cm.GetGiftFeeBySellmanID(sellmanid,begintime,endtime).ToString());
		}
		private string GetOuter(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			return(cm.GetOuterFeeBySellmanID(sellmanid,begintime,endtime).ToString());
		}
		private string GetContactTimes(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			SqlDataReader dr = cm.GetContactBySellmanID(sellmanid,begintime,endtime);
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			return(dt.Rows.Count.ToString());
		}
		private string GetContactedClient(int sellmanid,DateTime begintime,DateTime endtime)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			SqlDataReader dr = cm.GetContactedClientBySellmanID(sellmanid,begintime,endtime);
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			return(dt.Rows.Count.ToString());
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Fee" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD align="right"><asp:dropdownlist id="ddl_order" runat="server">
								<asp:ListItem Value="client">按客户发生费用总量排列</asp:ListItem>
								<asp:ListItem Value="sellman">按销售人员费用总量排列</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>开始时间
							<asp:textbox id="tbx_begintime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="tbx_begintime"></asp:requiredfieldvalidator>结束时间
							<asp:textbox id="tbx_endtime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbx_endtime"></asp:requiredfieldvalidator><asp:radiobutton id="rbtn_thisweek" onclick="quickseldate('week');" runat="server" GroupName="quickselect"
								Text="本周"></asp:radiobutton><asp:radiobutton id="rbtn_thismonth" onclick="quickseldate('month');" runat="server" GroupName="quickselect"
								Text="本月"></asp:radiobutton><asp:button id="btn_OK" runat="server" Text="确定"></asp:button></TD>
					</TR>
					<TR>
						<TD>共
							<asp:literal id="ltl_Client" runat="server"></asp:literal>位客户，共发生费用
							<asp:literal id="ltl_Fee" runat="server"></asp:literal>元</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgrd_clientfee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%" CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="编号"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="NAME" HeaderText="客户名称">
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' Target="_blank" NavigateUrl='<%# "../Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="联系人">
										<ItemTemplate>
											<A>
												<%# GetLinkMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientLinkman_Staff")) %>
											</A>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接触次数">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Client_Contact").Length %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="发生费用">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetFee(((DataRowView)Container.DataItem).Row.GetChildRows("Client_Contact")).ToString() %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接触状态">
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink3 runat="server" Target=_blank Text='<%# GetCurStatus(DataBinder.Eval(Container,"DataItem.Curstatus").ToString()) %>' NavigateUrl='<%# "../ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' NAME="Hyperlink2">
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
							</asp:datagrid><asp:datagrid id="dgrd_sellmanfee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%" Visible="False" CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="销售人员">
										<ItemTemplate>
											<%# ((DataRowView)Container.DataItem).Row.GetChildRows("StaffID_RealName")[0]["realname"].ToString() %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="发生费用">
										<ItemTemplate>
											<%# ((DataRowView)Container.DataItem)["Fee"].ToString()%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="差旅">
										<ItemTemplate>
											<%#  GetTravel(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="餐饮">
										<ItemTemplate>
											<%#  GetFood(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="礼品">
										<ItemTemplate>
											<%#  GetGift(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="公关">
										<ItemTemplate>
											<%#  GetOuter(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接触次数">
										<ItemTemplate>
											<%#  GetContactTimes(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接触客户数量">
										<ItemTemplate>
											<%#  GetContactedClient(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages" HorizontalAlign="Right"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="center">&nbsp;</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

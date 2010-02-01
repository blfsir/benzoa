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
					return ("����");
					break;
				case "boot":
					return ("����");
					break;
				case "commend":
					return ("��Ʒ�Ƽ�");
					break;
				case "requirement":
					return ("������");
					break;
				case "submit":
					return ("�����ύ");
					break;
				case "negotiate":
					return ("����̸��");
					break;
				case "actualize":
					return ("��Ŀʵʩ");
					break;
				case "traceservice":
					return ("���ٷ���");
					break;
				case "last":
					return ("��β��");
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
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD align="right"><asp:dropdownlist id="ddl_order" runat="server">
								<asp:ListItem Value="client">���ͻ�����������������</asp:ListItem>
								<asp:ListItem Value="sellman">��������Ա������������</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>��ʼʱ��
							<asp:textbox id="tbx_begintime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="tbx_begintime"></asp:requiredfieldvalidator>����ʱ��
							<asp:textbox id="tbx_endtime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbx_endtime"></asp:requiredfieldvalidator><asp:radiobutton id="rbtn_thisweek" onclick="quickseldate('week');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton><asp:radiobutton id="rbtn_thismonth" onclick="quickseldate('month');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton><asp:button id="btn_OK" runat="server" Text="ȷ��"></asp:button></TD>
					</TR>
					<TR>
						<TD>��
							<asp:literal id="ltl_Client" runat="server"></asp:literal>λ�ͻ�������������
							<asp:literal id="ltl_Fee" runat="server"></asp:literal>Ԫ</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgrd_clientfee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%" CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="���"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="NAME" HeaderText="�ͻ�����">
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' Target="_blank" NavigateUrl='<%# "../Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>'>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="��ϵ��">
										<ItemTemplate>
											<A>
												<%# GetLinkMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientLinkman_Staff")) %>
											</A>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�Ӵ�����">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Client_Contact").Length %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="��������">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetFee(((DataRowView)Container.DataItem).Row.GetChildRows("Client_Contact")).ToString() %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�Ӵ�״̬">
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink3 runat="server" Target=_blank Text='<%# GetCurStatus(DataBinder.Eval(Container,"DataItem.Curstatus").ToString()) %>' NavigateUrl='<%# "../ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' NAME="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�����">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientAddMan_Staff")) %>' ID="Label1">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:datagrid id="dgrd_sellmanfee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								Width="100%" Visible="False" CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="������Ա">
										<ItemTemplate>
											<%# ((DataRowView)Container.DataItem).Row.GetChildRows("StaffID_RealName")[0]["realname"].ToString() %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="��������">
										<ItemTemplate>
											<%# ((DataRowView)Container.DataItem)["Fee"].ToString()%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="����">
										<ItemTemplate>
											<%#  GetTravel(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="����">
										<ItemTemplate>
											<%#  GetFood(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="��Ʒ">
										<ItemTemplate>
											<%#  GetGift(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="����">
										<ItemTemplate>
											<%#  GetOuter(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�Ӵ�����">
										<ItemTemplate>
											<%#  GetContactTimes(Int32.Parse(((DataRowView)Container.DataItem)["sellmanid"].ToString()),begintime,endtime)%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�Ӵ��ͻ�����">
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

<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="sellman.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.sellman" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>sellman</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="sellman" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>开始时间
							<asp:TextBox id="tbx_begintime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="tbx_begintime"></asp:RequiredFieldValidator>结束时间
							<asp:TextBox id="tbx_endtime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbx_endtime"></asp:RequiredFieldValidator>
							<asp:RadioButton id="rbtn_thisweek" onclick="quickseldate('week');" runat="server" GroupName="quickselect" Text="本周"></asp:RadioButton>
							<asp:RadioButton id="rbtn_thismonth" onclick="quickseldate('month');" runat="server" GroupName="quickselect" Text="本月"></asp:RadioButton>
							<asp:Button id="btn_OK" runat="server" Text="确定"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_sellman" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
								<Columns>
									<asp:TemplateColumn HeaderText="销售人员姓名">
										<ItemTemplate>
											<%# ((DataRowView)Container.DataItem).Row.GetChildRows("staffid_realname")[0]["realname"].ToString()%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接触次数">
										<ItemTemplate>
											<a href='<%# "sellmancontact.aspx?SellmanID=" + ((DataRowView)Container.DataItem)["sellmanid"].ToString() + "&Begintime=" + begintime.ToShortDateString() + "&Endtime=" + endtime.ToShortDateString() + "&type=all"%>' target=_blank>
												<%# ((DataRowView)Container.DataItem).Row.GetChildRows("sellman_contact").Length%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="拜访次数">
										<ItemTemplate>
											<a href='<%# "sellmancontact.aspx?SellmanID=" + ((DataRowView)Container.DataItem)["sellmanid"].ToString() + "&Begintime=" + begintime.ToShortDateString() + "&Endtime=" + endtime.ToShortDateString() + "&type=callin"%>' target=_blank>
												<%# ((DataRowView)Container.DataItem).Row.GetChildRows("sellman_callincontact").Length%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="新发现客户">
										<ItemTemplate>
											<a href='<%# "sellmanclient.aspx?SellmanID=" + ((DataRowView)Container.DataItem)["sellmanid"].ToString() + "&Begintime=" + begintime.ToShortDateString() + "&Endtime=" + endtime.ToShortDateString() + "&type=all"%>' target=_blank >
												<%# ((DataRowView)Container.DataItem).Row.GetChildRows("sellman_newclient").Length%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="新增3星以上客户">
										<ItemTemplate>
											<a href='<%# "sellmanclient.aspx?SellmanID=" + ((DataRowView)Container.DataItem)["sellmanid"].ToString() + "&Begintime=" + begintime.ToShortDateString() + "&Endtime=" + endtime.ToShortDateString() + "&type=3stars"%>' target=_blank>
												<%# ((DataRowView)Container.DataItem).Row.GetChildRows("sellman_new3client").Length%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="发生费用">
										<ItemTemplate>
											<a href='<%# "sellmanfee.aspx?SellmanID=" + ((DataRowView)Container.DataItem)["sellmanid"].ToString() + "&Begintime=" + begintime.ToShortDateString() + "&Endtime=" + endtime.ToShortDateString() %>' target=_blank>
												<%# ((DataRowView)Container.DataItem)["Fee"].ToString()%>
											</a>
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

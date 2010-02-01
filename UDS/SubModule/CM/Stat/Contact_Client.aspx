<%@ Page language="c#" Codebehind="Contact_Client.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.Contact_Client" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Contact_Client</title>
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Contact_Client" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>��ʼʱ��
							<asp:textbox id="tbx_begintime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox>&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_begintime" Display="Dynamic"
								ErrorMessage="*"></asp:requiredfieldvalidator>����ʱ��
							<asp:textbox id="tbx_endtime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox>&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_endtime" ErrorMessage="*"></asp:requiredfieldvalidator><asp:radiobutton id="rbtn_thisweek" onclick="quickseldate('week');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton><asp:radiobutton id="rbtn_thismonth" onclick="quickseldate('month');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton>&nbsp;
							<asp:Button id="btn_OK" runat="server" Text="ȷ��" CssClass="redbuttoncss" Width="48px"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="center">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD style="WIDTH: 248px" align="center" bgColor="beige">��ϸ</TD>
									<TD align="center" bgColor="#f5f5dc" colSpan="" rowSpan="">������ֲ鿴����</TD>
									<TD style="WIDTH: 274px" align="center" bgColor="#f5f5dc" colSpan="" rowSpan="">��ϸ</TD>
									<TD align="center" bgColor="#f5f5dc" colSpan="" rowSpan="">������ֲ鿴����</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">��ӽӴ���¼��������Ա����</TD>
									<TD><A onclick="javascript:window.open('sellman.aspx?begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_AddContactSellman" runat="server"></asp:literal></A>
									</TD>
									<TD style="WIDTH: 274px">�Ӵ�������
									</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=ac&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_Contact" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">�ݷÿͻ�������
									</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=cc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_CallinContact" runat="server"></asp:literal></A></TD>
									<TD style="WIDTH: 274px">�·��ֿͻ�����</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=nc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NewClient" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">��������̸�еĿͻ������£���</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=neonc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NegotiateClient_New" runat="server"></asp:literal></A></TD>
									<TD style="WIDTH: 274px">3�����ϵĿͻ��������£���</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=n3c&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_New3Client_New" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">��������̸�еĿͻ������ܣ���</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=neoc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NegotiateClient_Total" runat="server"></asp:literal></A></TD>
									<TD style="WIDTH: 274px">3�����ϵĿͻ��������ܣ���</TD>
									<TD><A onclick="javascript:window.open('contactedclient.aspx?type=3c&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_New3Client_Total" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">��������������</TD>
									<TD><A onclick="javascript:window.open('fee.aspx?type=client&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_Fee" runat="server"></asp:literal></A></TD>
									<TD style="WIDTH: 274px">�������ô�����</TD>
									<TD><A onclick="javascript:window.open('fee.aspx?type=sellman&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeTimes" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 248px">�������ÿͻ�����</TD>
									<TD><A onclick="javascript:window.open('fee.aspx?type=client&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeClient" runat="server"></asp:literal></A></TD>
									<TD style="WIDTH: 274px">��������������Ա����</TD>
									<TD><A onclick="javascript:window.open('fee.aspx?type=sellman&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeSellman" runat="server"></asp:literal></A></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

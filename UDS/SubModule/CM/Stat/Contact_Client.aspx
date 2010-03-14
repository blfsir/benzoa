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
	<body MS_POSITIONING="GridLayout" leftMargin="0" topmargin="0">
		<form id="Contact_Client" method="post" runat="server">
			<FONT face="����">
			<TABLE width="98%" border="0" align="center" cellPadding="3" cellSpacing="0" id="Table1">
					<TR>
						<TD height="30">��ʼʱ��
							<asp:textbox id="tbx_begintime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox>&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbx_begintime" Display="Dynamic"
								ErrorMessage="*"></asp:requiredfieldvalidator>����ʱ��
							<asp:textbox id="tbx_endtime" onfocus="setday(this);" runat="server" ReadOnly="True"></asp:textbox>&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbx_endtime" ErrorMessage="*"></asp:requiredfieldvalidator><asp:radiobutton id="rbtn_thisweek" onclick="quickseldate('week');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton><asp:radiobutton id="rbtn_thismonth" onclick="quickseldate('month');" runat="server" GroupName="quickselect"
								Text="����"></asp:radiobutton>&nbsp;
							<asp:Button id="btn_OK" runat="server" Text="ȷ��" CssClass="redbuttoncss" Width="48px"></asp:Button></TD>
			  </TR>
				</TABLE><TABLE width="98%" border="1" align="center" cellPadding="3" cellSpacing="0" borderColor="#93bee2" id="Table2">
								<TR>
									<TD height="30" align="center" bgColor="#93bee2">ϸ��</TD>
									<TD align="center" bgColor="#93bee2" colSpan="" rowSpan="">������ֲ鿴����</TD>
									<TD align="center" bgColor="#93bee2" colSpan="" rowSpan="">��ϸ</TD>
									<TD align="center" bgColor="#93bee2" colSpan="" rowSpan="">������ֲ鿴����</TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">��ӽӴ���¼��������Ա����</TD>
									<TD><A onClick="javascript:window.open('sellman.aspx?begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_AddContactSellman" runat="server"></asp:literal></A>
									</TD>
									<TD width="200" bgcolor="#E8F4FF">�Ӵ�������
									</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=ac&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_Contact" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">�ݷÿͻ�������
									</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=cc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#"><asp:literal id="ltl_CallinContact" runat="server"></asp:literal></A></TD>
									<TD width="200" bgcolor="#E8F4FF">�·��ֿͻ�����</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=nc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NewClient" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">��������̸�еĿͻ������£���</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=neonc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NegotiateClient_New" runat="server"></asp:literal></A></TD>
									<TD width="200" bgcolor="#E8F4FF">3�����ϵĿͻ��������£���</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=n3c&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_New3Client_New" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">��������̸�еĿͻ������ܣ���</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=neoc&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_NegotiateClient_Total" runat="server"></asp:literal></A></TD>
									<TD width="200" bgcolor="#E8F4FF">3�����ϵĿͻ��������ܣ���</TD>
									<TD><A onClick="javascript:window.open('contactedclient.aspx?type=3c&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_New3Client_Total" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">��������������</TD>
									<TD><A onClick="javascript:window.open('fee.aspx?type=client&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_Fee" runat="server"></asp:literal></A></TD>
									<TD width="200" bgcolor="#E8F4FF">�������ô�����</TD>
									<TD><A onClick="javascript:window.open('fee.aspx?type=sellman&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeTimes" runat="server"></asp:literal></A></TD>
								</TR>
								<TR>
									<TD width="200" height="30" bgcolor="#E8F4FF">�������ÿͻ�����</TD>
									<TD><A onClick="javascript:window.open('fee.aspx?type=client&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeClient" runat="server"></asp:literal></A></TD>
									<TD width="200" bgcolor="#E8F4FF">��������������Ա����</TD>
									<TD><A onClick="javascript:window.open('fee.aspx?type=sellman&amp;begintime='+document.Contact_Client.tbx_begintime.value+'&amp;endtime='+document.Contact_Client.tbx_endtime.value),'_blank'"
											href="#">
											<asp:literal id="ltl_FeeSellman" runat="server"></asp:literal></A></TD>
								</TR>
							</TABLE>
		  </FONT>
	</form>
	</body>
</HTML>

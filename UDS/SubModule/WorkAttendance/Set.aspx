<%@ Page language="c#" Codebehind="Set.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance.Set" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Set</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
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

			document.getElementById("txtbegintime").value = begintime;
			document.getElementById("txtendtime").value = endtime;
		
		}
		function checkdutytime(source,arguments)
		{
			var ondutytime,offdutytime;
			var begindate,enddate;
			ondutytime = document.getElementById('tbx_OnDutyTime').value;
			offdutytime = document.getElementById('tbx_OffDutyTime').value;
			begindate = Date.parse('1/1/1900 '+ondutytime);
			enddate = Date.parse('1/1/1900 '+offdutytime);
			if(enddate<begindate)
				arguments.IsValid = false;
			else
				arguments.IsValid = true;
		}
		function checkdutydate()
		{
			var begindate,enddate;
			begindate = document.getElementById('txtbegintime').value;
			enddate = document.getElementById('txtendtime').value;
			if(begindate.replace(' ','')=='' || enddate.replace(' ','')=='')
			{
				alert('���ڲ���Ϊ��');
				return false;
			}
			else
			{
				if(begindate>enddate)
				{
					alert('��ʼʱ�䲻�ܴ��ڽ���ʱ��');
					return false
				}
			}
			return true;
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Set" method="post" runat="server">
		<table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/MyTask.gif" width="16">
            </td>
            <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                height="30" align="left">
                &nbsp;<font color="#006699">��������</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                     &nbsp; 
            </td>
        </tr>
    </table>
			<TABLE class="GBText" id="Table1" style="BORDER-COLLAPSE: collapse; HEIGHT: 109px" borderColor="#93bee2"
				height="109" cellSpacing="1" cellPadding="1" width="100%" border="1" DESIGNTIMEDRAGDROP="56">
				<TR>
					<TD style="WIDTH: 130px; HEIGHT: 54px" align="center">����������</TD>
					<TD style="HEIGHT: 54px">��ʼʱ�䣺
						<asp:textbox id="txtbegintime" onfocus="setday(this);" runat="server" ReadOnly="True" Columns="10"
							CssClass="inputcss"></asp:textbox>--����ʱ��
						<asp:textbox id="txtendtime" onfocus="setday(this);" runat="server" ReadOnly="True" Columns="10"
							CssClass="inputcss"></asp:textbox>&nbsp;
						<asp:comparevalidator id="cvdate" runat="server" ControlToCompare="txtbegintime" Operator="GreaterThanEqual"
							ErrorMessage="����ʱ��Ӧ�ô��ڿ�ʼʱ��" ControlToValidate="txtendtime" Display="None"></asp:comparevalidator>&nbsp;
						<asp:radiobutton id="rbtnthisweek" onclick="quickseldate('week');" runat="server" GroupName="quickdate"
							Text="����"></asp:radiobutton><asp:radiobutton id="rbtnthismonth" onclick="quickseldate('month');" runat="server" GroupName="quickdate"
							Text="����"></asp:radiobutton><input language="javascript" class="buttoncss" id="btnsetdate" title="���ÿ�������" onclick="if (checkdutydate())  window.open('ShowDay.aspx?begintime='+document.Set.txtbegintime.value+'&amp;endtime='+document.Set.txtendtime.value,'_blank','menubar=no,location=no,toolbar=no'); "
							type="button" value="��ϸ���" name="btnsetdate" runat="server"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 130px" align="center"><FONT face="����">���ù�˾����ʱ��</FONT></TD>
					<TD><FONT face="����">�ϰ�ʱ��
							<asp:textbox id="tbx_OnDutyTime" runat="server" CssClass="inputcss" Width="81px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="�ϰ�ʱ�䲻��Ϊ��" ControlToValidate="tbx_OnDutyTime"
								Display="Dynamic"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="ʱ���ʽ����" ControlToValidate="tbx_OnDutyTime"
								Display="Dynamic" ValidationExpression="(((0|1)[0-9])|(2[0-3])|([0-9])):([0-5][0-9])"></asp:regularexpressionvalidator>�°�ʱ��
							<asp:textbox id="tbx_OffDutyTime" runat="server" CssClass="inputcss" Width="79px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="�°�ʱ�䲻��Ϊ��" ControlToValidate="tbx_OffDutyTime"
								Display="Dynamic"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="ʱ���ʽ����" ControlToValidate="tbx_OffDutyTime"
								Display="Dynamic" ValidationExpression="(((0|1)[0-9])|(2[0-3])|([0-9])):([0-5][0-9])"></asp:regularexpressionvalidator><asp:customvalidator id="CustomValidator1" runat="server" ErrorMessage="�°�ʱ�䲻�������ϰ�ʱ��" Display="Dynamic"
								ClientValidationFunction="checkdutytime"></asp:customvalidator>��ʱ���ʽ����09:00��9:00��
							<asp:button id="btn_SetTime" runat="server" CssClass="buttoncss" Text=" ��  ��"></asp:button></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 130px" align="center"><FONT face="����"></FONT></TD>
					<TD><FONT face="����"></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

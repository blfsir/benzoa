<%@ Page language="c#" Codebehind="Manage.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.Manage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�������</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../../Css/calendar.js"></script>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script lang="javascript">
		function ProjectSelect()
		{
	
			var ret;
			ret = window.showModalDialog("../UnitiveDocument/Mail/TreeView.aspx",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");
			if(ret>0)
			return false;
		}
		</script>
	</HEAD>
	<body topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Manage" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="30"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="20" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"
									align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/MyTask.gif" width="16"></FONT></TD>
								<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right">�ҵ�����</TD>
								<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="����">&nbsp;&nbsp;&nbsp;</FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			&nbsp;<TABLE id="Table2" style=" BORDER-COLLAPSE: collapse;  BorderColor="#93BEE2"
				cellSpacing="0" cellPadding="0" width="98%" border="0"   align="center">
				<TR>
					<TD vAlign="top">
						<FONT face="����">
							 
							<TABLE class="gbtext" id="Table3" style="BORDER-COLLAPSE: collapse" BorderColor="#93BEE2"
								cellSpacing="0" cellPadding="0" width="98%" border="1" align="center">
								<TR>
									<TD style="WIDTH: 339px" width="339" height="26" style="background-color:#E8F4FF;">&nbsp;<asp:label id="Label6" runat="server">�� �� �� ��</asp:label></TD>
									<TD style="WIDTH: 187px">&nbsp;
										<asp:textbox id="txtSubject" runat="server" CssClass="input2" Width="99px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Font-Size="X-Small" ErrorMessage="*"
											ControlToValidate="txtSubject"></asp:requiredfieldvalidator></TD>
									<TD style="WIDTH: 124px" width="124" style="background-color:#E8F4FF;">&nbsp;<asp:label id="Label7" runat="server">�� �� �� Ա</asp:label></TD>
									<TD>&nbsp;
										<asp:label id="lblArrangedBy" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px; HEIGHT: 42px;background-color:#E8F4FF" height="42"  >&nbsp;<asp:label id="Label2" runat="server">�� �� �� Ŀ</asp:label></TD>
									<TD style="WIDTH: 187px; HEIGHT: 42px">&nbsp; <INPUT class=InputCss style="WIDTH: 120px; HEIGHT: 22px" readOnly type=text size=14 value="<%=GetClassName() %>" name=txtProjectName 
             width="20"> <INPUT class="greenbuttoncss" style="WIDTH: 18px; HEIGHT: 17px" onclick="ProjectSelect()"
											type="button" value="��"></TD>
									<TD style="WIDTH: 124px; HEIGHT: 42px;background-color:#E8F4FF">&nbsp;<asp:label id="Label1" runat="server">�� �� �� ��</asp:label></TD>
									<TD style="HEIGHT: 42px"><asp:radiobuttonlist id="rbAttribute" runat="server" Height="20px" Width="166px" Font-Size="X-Small"
											AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px; HEIGHT: 36px;background-color:#E8F4FF" height="36">&nbsp;<asp:label id="Label3" runat="server">�� ʼ ʱ ��</asp:label></TD>
									<TD style="WIDTH: 187px; HEIGHT: 36px">&nbsp;<asp:textbox id="txtBeginDate" runat="server" CssClass="input2" Width="68px"></asp:textbox>
										<INPUT class="greenbuttoncss" style="WIDTH: 18px; HEIGHT: 17px" onclick="calendar(document.all.txtBeginDate);document.Manage.txtEndDate.value=document.Manage.txtBeginDate.value;"
											type="button" value="��">
										<asp:dropdownlist id="listBeginTime" runat="server"></asp:dropdownlist></TD>
									<TD style="WIDTH: 124px; HEIGHT: 36px;background-color:#E8F4FF">&nbsp;<asp:label id="Label4" runat="server">�� �� ʱ ��</asp:label></TD>
									<TD style="HEIGHT: 36px">&nbsp;<asp:textbox id="txtEndDate" runat="server" CssClass="input2" Width="68px"></asp:textbox><INPUT class="greenbuttoncss" style="WIDTH: 18px; HEIGHT: 16px" onclick="calendar(document.all.txtEndDate)"
											type="button" value="��">
										<asp:dropdownlist id="listEndTime" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px;background-color:#E8F4FF" height="26"></TD>
									<TD colSpan="3"><asp:checkbox id="cbIsAllDay" runat="server" Text="ȫ���¼�" AutoPostBack="True"></asp:checkbox><asp:checkbox id="cbIsRepeat" runat="server" Text="ѭ����ʱ��" AutoPostBack="True"></asp:checkbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px;background-color:#E8F4FF" height="26">&nbsp;<asp:label id="lblType" runat="server">�� �� �� ��</asp:label></TD>
									<TD colSpan="3"><asp:radiobuttonlist id="rbType" runat="server" Width="285px" Font-Size="X-Small" RepeatDirection="Horizontal"
											RepeatColumns="4"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px;background-color:#E8F4FF" height="26">&nbsp;<asp:label id="Label5" runat="server">ִ �� �� Ա</asp:label></TD>
									<TD colSpan="3">
										<TABLE class="gbtext" id="Table4" cellSpacing="0" cellPadding="0" width="396" border="0"
											style="WIDTH: 396px; HEIGHT: 25px">
											<TR>
												<TD align="center" width="80"><asp:checkbox id="cbNeedCo" runat="server" Text="��ҪЭͬ" AutoPostBack="True"></asp:checkbox></TD>
												<TD align="center" width="115" style="WIDTH: 115px"><asp:listbox id="listCooperator" runat="server" CssClass="inputcss" Height="80px" Width="120px"
														Visible="False" SelectionMode="Multiple"></asp:listbox></TD>
												<TD align="center" width="143" style="WIDTH: 143px"><asp:button id="btnAddUser" runat="server" CssClass="redbuttoncss" Text="����Эͬ��" Visible="False"></asp:button><BR>
													<asp:CheckBox id="cbRemind" runat="server" Text="վ�ڶ���Ϣ����" Font-Size="X-Small" Visible="False"></asp:CheckBox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px;background-color:#E8F4FF" height="26">&nbsp;<asp:label id="Label14" runat="server">�� �� �� ��</asp:label></TD>
									<TD colSpan="3">&nbsp;��ǰ
										<asp:dropdownlist id="listAheadMin" runat="server">
											<asp:ListItem Value="10����" Selected="True">10����</asp:ListItem>
											<asp:ListItem Value="15����">15����</asp:ListItem>
											<asp:ListItem Value="20����">20����</asp:ListItem>
											<asp:ListItem Value="30����">30����</asp:ListItem>
											<asp:ListItem Value="60����">60����</asp:ListItem>
										</asp:dropdownlist>����</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 339px;background-color:#E8F4FF">&nbsp;<asp:label id="Label10" runat="server">�� �� �� ��</asp:label></TD>
									<TD colSpan="3"><asp:textbox id="txtDetail" runat="server" Height="120px" Width="400px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<tr>
								<td colspan="4" align="center" height="90px"><br /> <asp:button id="btnSubmit" runat="server" Width="80px" Text="��      ��" Height="22px" CssClass="redButtonCss"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="btnCheck" runat="server" Width="80px" Text="����ͻ" Height="22px" CssClass="redButtonCss"></asp:button><br /><br /></td>
								</tr>
							</TABLE>
							<P>
						</FONT><FONT face="����">
							<asp:label id="lblMsg" runat="server" Font-Size="Smaller" ForeColor="Red"></asp:label><INPUT 
      class=InputCss style="WIDTH: 29px; HEIGHT: 22px" type=hidden size=1 
      value="<%=ClassID %>" name=hdnProjectID 
      DESIGNTIMEDRAGDROP="490" width="20"><input type=hidden 
      value="<%=UnameStr%>" name=unamestr></FONT> </P>
						<P><FONT face="����">
								</FONT></P>
					</TD>
					<TD vAlign="top"><input type="hidden" value="schedule" name="actflag"><IFRAME id="DayTaskFrm" frameBorder="0" width="100%" scrolling="auto" height="100%" runat="server"
							style="WIDTH: 91.48%; HEIGHT: 480px"> </IFRAME>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

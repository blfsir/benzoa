<%@ Page language="c#" Codebehind="EditTache.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.EditTache" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditTache</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="EditTache" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td vAlign="top" height="38">
							<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR height="30">
									<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
										bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD class="GbText" style="WIDTH: 53px" align="right" width="53" background="../../../Images/treetopbg.jpg"
										bgColor="#e8f4ff"><font color="#006699">�ĵ���ת</font></TD>
									<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="����">&nbsp;&nbsp;</FONT></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD style="HEIGHT: 343px" align="center"><br>
							<TABLE class="gbtext" id="Table3" style="WIDTH: 939px; HEIGHT: 322px" cellSpacing="0" cellPadding="0"
								width="939" border="0">
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 24px" align="right" width="185" background="../../../Images/treetopbg.jpg"
										height="24">�������ƣ�</TD>
									<TD style="HEIGHT: 24px" background="../../../Images/treetopbg.jpg" height="24"><asp:label id="labFlowName" runat="server" Width="384px"></asp:label><asp:label id="labStep" runat="server" Width="91px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 25px" align="right" width="185" height="25"><asp:label id="Label1" runat="server" Width="70px" Height="12px">�������ƣ�</asp:label></TD>
									<TD style="HEIGHT: 25px" height="25"><asp:textbox id="txtTacheName" runat="server" Width="483px" Height="21px" CssClass="inputcss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Width="166px" ErrorMessage="�����벽������"
											ControlToValidate="txtTacheName"></asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 28px" align="right" height="28"><asp:label id="Label2" runat="server">�Ƿ������</asp:label></TD>
									<TD style="HEIGHT: 28px" height="28"><asp:radiobutton id="chkFinishYes" runat="server" Width="43px" Text="��" GroupName="cboFinish"></asp:radiobutton><asp:radiobutton id="chkFinishNO" runat="server" Text="��" GroupName="cboFinish" Checked="True"></asp:radiobutton>&nbsp;&nbsp; 
										(˵�����ò�����������Ƿ����ǿ�������������)</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 26px" align="right" height="26"><asp:label id="Label5" runat="server">�Ƿ��ǩ��</asp:label></TD>
									<TD style="HEIGHT: 26px" height="26"><asp:radiobutton id="radPassNumYes" runat="server" Text="��ǩ" GroupName="PassNum" AutoPostBack="True"></asp:radiobutton><asp:radiobutton id="radPassNumNo" runat="server" Text="����ǩ" GroupName="PassNum" Checked="True" AutoPostBack="True"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<span id="PassNum" style="DISPLAY: none" runat="server">��ǩ����:
											<asp:textbox id="txtPassNum" runat="server" Width="46px" Height="19px" CssClass="inputcss">0</asp:textbox><input id="chkAllPass" onclick="if(this.checked)document.all.txtPassNum.value='-1';else document.all.txtPassNum.value='0';"
												type="checkbox" name="chkAllMember" runat="server">ȫ��ͨ�� </span>
										<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="����������" ControlToValidate="txtPassNum"
											ValidationExpression="-{0,1}\d+"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 24px" align="right" height="24"><asp:label id="Label3" runat="server" Width="65px" Height="9px">��ת����</asp:label></TD>
									<TD style="HEIGHT: 24px" height="24"><asp:dropdownlist id="cboFlowRule" runat="server" Width="488px">
											<asp:ListItem Value="0">����Ա</asp:ListItem>
											<asp:ListItem Value="1">��ְλ</asp:ListItem>
											<asp:ListItem Value="2" Selected="True">����Ŀ</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 146px" vAlign="top" align="right"><asp:label id="Label4" runat="server" Width="72px" Height="6px">�����飺</asp:label></TD>
									<TD style="HEIGHT: 146px"><asp:textbox id="txtRemark" runat="server" Width="491px" Height="155px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 12px" vAlign="middle" align="right">
										<P>����һ���������Ϣ�������ã�</P>
									</TD>
									<TD style="HEIGHT: 12px"><asp:checkbox id="chkLocalAlert" runat="server" Text="�̶�����"></asp:checkbox><SPAN id="spanAlert" style="DISPLAY: none" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</SPAN></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 185px; HEIGHT: 12px" vAlign="middle" align="right">��һ��ʱ����δ����������ѣ�</TD>
									<TD style="HEIGHT: 12px">
										<asp:checkbox id="chkUrgencyAlert" runat="server" Text="�߰�����" AutoPostBack="True"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										���ʱ��:
										<asp:textbox id="txtBaseHour" runat="server" Width="42px" Height="18px"></asp:textbox>����&nbsp; 
										����:
										<asp:textbox id="txtPeriod" runat="server" Width="31px" Height="18px"></asp:textbox>����&nbsp; 
										����:
										<asp:textbox id="txtCycTimes" runat="server" Width="37px" Height="18px"></asp:textbox>
										<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtBaseHour"
											ErrorMessage="��д��ȷ��Сʱ" ValidationExpression="\d+"></asp:regularexpressionvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtPeriod" ErrorMessage="��д��ȷ������"
											ValidationExpression="\d+"></asp:regularexpressionvalidator>
										<asp:regularexpressionvalidator id="RegularExpressionValidator4" runat="server" ControlToValidate="txtCycTimes"
											ErrorMessage="��д��ȷ�Ĵ���" ValidationExpression="\d+"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 58px" align="right" colSpan="2" height="58"><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="����ѭ������" ControlToValidate="txtBaseHour"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="��������" ControlToValidate="txtPeriod"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="�������ʱ��" ControlToValidate="txtCycTimes"></asp:requiredfieldvalidator>
										<hr boarder="1">
										<asp:button id="cmdPrevious" accessKey="P" runat="server" Width="58px" CssClass="buttoncss"
											Text="��һ��" CausesValidation="False"></asp:button>&nbsp;
										<asp:button id="cmdNext" accessKey="N" runat="server" Width="60px" CssClass="buttoncss" Text="��һ��"></asp:button>&nbsp;
										<asp:button id="cmdDelete" accessKey="D" runat="server" Width="58px" CssClass="buttoncss" Text="ɾ��"
											CausesValidation="False"></asp:button>&nbsp;
										<asp:button id="cmdFinish" accessKey="F" runat="server" Width="73px" CssClass="buttoncss" Text="������"></asp:button>&nbsp;
										<asp:button id="cmdCancel" accessKey="C" runat="server" Width="74px" CssClass="buttoncss" Text="ȡ�����"
											CausesValidation="False"></asp:button>&nbsp;
										<asp:button id="cmdReturn" accessKey="C" runat="server" Width="55px" CssClass="buttoncss" Text="����"
											CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

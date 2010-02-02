<%@ Page language="c#" Codebehind="NewStaff.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Department.NewStaff" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NewStaff</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
		<style>.td { FONT-SIZE: 14px; COLOR: #0000ff }
		</style>
	</HEAD>
	<body>
		<form id="NewStaff" method="post" runat="server">
			<TABLE class="gbtext" id="Table1" cellSpacing="0" cellPadding="0" width="590" border="0">
				<TR>
					<TD align="middle" width="90" background="../../images/maillistbutton2.gif" height="24"><FONT face="����">Ա��ע��</FONT></TD>
					<TD align="right" width=500><asp:literal id="message" runat="server" EnableViewState="False"></asp:literal>
					</TD>
				</TR>
			</TABLE>
			<CENTER>
				<table id="AutoNumber1" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
					<tr bgcolor="#e8f4ff">
						<td align="right" width="20%" height="34" style="HEIGHT: 34px">�û�����:</td>
						<td height="34" style="HEIGHT: 34px">&nbsp;<asp:textbox id="txtStaffName" Width="382" Columns="70" Runat="server" CssClass="InputCss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Font-Size="X-Small" ControlToValidate="txtStaffName" ErrorMessage="����������"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%" height="30">��ʵ����:</td>
						<td height="30">&nbsp;<asp:textbox id="txtRealName" Width="382" Columns="70" Runat="server" CssClass="InputCss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Font-Size="X-Small" ControlToValidate="txtRealName" ErrorMessage="��������ʵ����"></asp:requiredfieldvalidator></td>
					</tr>
					<tr bgcolor="#e8f4ff">
						<td align="right" width="20%" height="30">�Ա�:</td>
						<td height="30">&nbsp;<asp:radiobutton id="rb_male" Runat="server" Text="��" Checked="True" GroupName="rSex"></asp:radiobutton><asp:radiobutton id="rb_female" Runat="server" Text="Ů" Checked="False" GroupName="rSex"></asp:radiobutton></td>
					</tr>
					<tr>
						<td align="right" width="20%" height="30">��������:</td>
						<td height="30">&nbsp;<asp:textbox id="txtBirthday" onfocus="setday(this)" Width="383" Columns="70" Runat="server" CssClass="InputCss" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr bgcolor="#e8f4ff">
						<td align="right" width="20%" height="30">����:</td>
						<td height="30">&nbsp;<asp:textbox id="txtPassword" runat="server" Width="383px" CssClass="InputCss" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Font-Size="X-Small" ControlToValidate="txtPassword" ErrorMessage="���벻��Ϊ��"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%" height="30">�ظ�����:</td>
						<td height="30">&nbsp;<asp:textbox id="txtRePassword" runat="server" Width="382px" CssClass="InputCss" TextMode="Password"></asp:textbox><asp:comparevalidator id="CompareValidator1" runat="server" Font-Size="X-Small" ControlToValidate="txtRePassword" ErrorMessage="����ȷ�ϴ���" ControlToCompare="txtPassword"></asp:comparevalidator></td>
					</tr>
					<TR bgcolor="#e8f4ff">
						<td align="right" width="20%" height="30">�����ʼ�:</td>
						<td height="30">&nbsp;<asp:textbox id="txtEmail" Width="382" Columns="70" Runat="server" CssClass="InputCss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="X-Small" ControlToValidate="txtEmail" ErrorMessage="����д�����ʼ���ַ" Display="Dynamic"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="checkmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="�����EMAIL��ʽ" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:regularexpressionvalidator></td>
					</TR>
					<tr>
						<td align="right" width="20%" height="30">��˾�绰:</td>
						<td height="30">&nbsp;<asp:textbox id="txtPhone" Width="382" Columns="70" Runat="server" CssClass="InputCss"></asp:textbox><asp:regularexpressionvalidator id="checkphone" runat="server" Font-Size="X-Small" ControlToValidate="txtPhone" ErrorMessage="�绰�������" ValidationExpression="\d*"></asp:regularexpressionvalidator></td>
					</tr>
					<tr bgcolor="#e8f4ff">
						<td align="right" width="20%" height="30">�ƶ��绰:</td>
						<td height="30">&nbsp;<asp:textbox id="txtMobile" Width="382" Columns="70" Runat="server" CssClass="InputCss"></asp:textbox><asp:regularexpressionvalidator id="checkmobile" runat="server" Font-Size="X-Small" ControlToValidate="txtMobile" ErrorMessage="�ֻ��Ŵ���" ValidationExpression="\d*"></asp:regularexpressionvalidator></td>
					</tr>
					<tr id="mydepartment" runat="server">
						<td align="right" width="20%" height="30">��������:</td>
						<td height="30"><FONT face="����">&nbsp;<asp:dropdownlist id="cboDepartment" runat="server" Width="383px"></asp:dropdownlist></FONT></td>
					</tr>
					<TR>
						<TD align="middle" colspan="2" height="35"><FONT face="����"><asp:button id="cmdSubmit" runat="server" Width="60px" CssClass="redButtonCss" Text="ȷ��" Height="20px"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
								<INPUT class="redButtonCss" style="WIDTH: 60px; HEIGHT: 20px" onclick="history.back()" type="button" value="�� ��" name="cmdReturn">
							</FONT>
						</TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>

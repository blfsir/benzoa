<%@ Page language="c#" Codebehind="CustomLinkmanInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Linkman.CustomLinkman" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�Զ�����ϵ��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="CustomLinkman" method="post" runat="server">
			<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR >
					<TD width="24" height="30" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/myLinkman.gif" width="16"></FONT></TD>
				  <TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" width="70" align="center">��ϵ������</TD>
					<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"><FONT face="����">&nbsp;
						</FONT>&nbsp;</TD>
				</TR>
			</TABLE>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<TABLE id="tbl_Custom" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0" cellPadding="0" width="98%" align="center" border="1" runat="server" class="gbtext">
				<TR>
					<TD  bgcolor="#e8f4ff">&nbsp;����</TD>
					<TD height="35" ><FONT face="����">&nbsp;</FONT>
						<asp:textbox id="tbx_Name" runat="server" CssClass="inputcss"></asp:textbox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="����Ϊ��" ControlToValidate="tbx_Name" Display="Dynamic"></asp:RequiredFieldValidator></TD>
					<TD  bgcolor="#e8f4ff">&nbsp;�Ա�</TD>
					<TD height="35" style="WIDTH: 151px; HEIGHT: 35px"><FONT face="����">&nbsp;</FONT><SELECT id="ddl_Gender" name="Select1" runat="server">
							<OPTION value="1" selected>��</OPTION>
							<OPTION value="0">Ů</OPTION>
						</SELECT></TD>
					<TD  bgcolor="#e8f4ff">&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						��</TD>
					<TD height="35" style="HEIGHT: 35px"><FONT face="����">&nbsp;</FONT>
						<asp:textbox id="tbx_Age" runat="server" CssClass="inputcss" Width="36px"></asp:textbox><FONT face="����">&nbsp;
							<asp:RangeValidator id="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="tbx_Age" ErrorMessage="�������" MinimumValue="1" MaximumValue="200" Type="Integer"></asp:RangeValidator></FONT></TD>
				</TR>
				<TR>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��λ��ַ</TD>
					<TD height="24" style="WIDTH: 154px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_UnitAddress" runat="server" CssClass="inputcss"></asp:textbox></TD>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��λ�绰</TD>
					<TD height="24" style="WIDTH: 151px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_UnitTelephone" runat="server" CssClass="inputcss"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="��������" ControlToValidate="tbx_UnitTelephone" ValidationExpression="\d*" Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��λ�ʱ�</TD>
					<TD height="24"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_UnitZip" runat="server" CssClass="inputcss" Width="69px"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ErrorMessage="�ʱ����" ControlToValidate="tbx_UnitZip" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��ͥ��ַ</TD>
					<TD height="24" style="WIDTH: 154px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_FamilyAddress" runat="server" CssClass="inputcss"></asp:textbox></TD>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��ͥ�绰</TD>
					<TD height="24" style="WIDTH: 151px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_FamilyTelephone" runat="server" CssClass="inputcss"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="��������" ControlToValidate="tbx_FamilyTelephone" Display="Dynamic" ValidationExpression="\d*"></asp:RegularExpressionValidator></TD>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;��ͥ�ʱ�</TD>
					<TD height="24"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_FamilyZip" runat="server" CssClass="inputcss" Width="72px"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ErrorMessage="�ʱ����" ControlToValidate="tbx_FamilyZip" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;�ֻ�</TD>
					<TD height="24" style="WIDTH: 154px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_Mobile" runat="server" CssClass="inputcss"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="��������" ControlToValidate="tbx_Mobile" ValidationExpression="\d*" Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD height="24" bgcolor="#e8f4ff">&nbsp;E-Mail</TD>
					<TD height="24" style="WIDTH: 151px"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_Email" runat="server" CssClass="inputcss"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="��ʽ����" ControlToValidate="tbx_Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD height="24"></TD>
					<TD height="24"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 73px" height="24" bgcolor="#e8f4ff">&nbsp;���</TD>
					<TD colSpan="5" height="24"><asp:datalist id="dlt_Type" runat="server" RepeatDirection="Horizontal" RepeatColumns="10" HorizontalAlign="Left" Font-Size="X-Small">
							<ItemTemplate>
								<asp:CheckBox Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Type") %>' EnableViewState=True ID="Checkbox1">
								</asp:CheckBox>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" height="24" bgcolor="#e8f4ff">&nbsp;��ע</TD>
					<TD vAlign="top" colSpan="5" height="24"><FONT face="����">&nbsp;</FONT><asp:textbox id="tbx_Memo" runat="server" Width="581px" Height="95px" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6" height="40"><asp:button id="btn_OK" runat="server" Text=" ȷ �� " CssClass="buttoncss"></asp:button></TD>
				</TR>
			</TABLE>
			<DIV align="center" ms_positioning="FlowLayout"><a href="javascript:close();">�رմ���</a></DIV>
		</form>
	</body>
</HTML>

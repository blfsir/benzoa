<%@ Page language="c#" Codebehind="DefineStyle.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.DefineStyle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefineStyle</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="DefineStyle" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td vAlign="top" height="34">
							<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="20" height="30" align="right" background="../../../Images/treetopbg.jpg"
										bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
								  <TD class="GbText" align="center" width="60" background="../../../Images/treetopbg.jpg"
										bgColor="#e8f4ff">�ĵ���ת</TD>
									<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="����">&nbsp;&nbsp;&nbsp; 
											&nbsp;</FONT></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TABLE>
				<asp:table id="tabDemo" style="Z-INDEX: 109; LEFT: 0px; POSITION: absolute; TOP: 174px; BORDER-COLLAPSE: collapse"
					runat="server" Width="98%" Height="33px" CellSpacing="1" CellPadding="1" align="center" CssClass="GbText"
					BorderWidth="1px" bordercolor="#CCCCCC" BorderStyle="Solid" GridLines="Both"></asp:table>
				<TABLE width="98%" border="1" align="center" cellPadding="3"
					cellSpacing="0" bordercolor="#93bee2" class="gbtext" id="Table1" style="BORDER-COLLAPSE: collapse" >
					<TR>
						<TD width="120" height="30" bgcolor="#e8f4ff">&nbsp;�ֶ�����</TD>
				    <TD style="WIDTH: 411px" height="24"><asp:dropdownlist id="ddlFieldName" runat="server" Width="152px" CssClass="InputCss"></asp:dropdownlist></TD>
						<TD width="120" height="30" bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;��ȣ�</TD>
						<TD height="24"><asp:textbox id="tbWidth" runat="server" CssClass="InputCss">100</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="\d+" ControlToValidate="tbWidth"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbWidth"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="����ȷ������" ControlToValidate="tbWidth"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#e8f4ff">&nbsp;�ֶ����壺</TD>
					  <TD style="WIDTH: 411px" height="24"><asp:textbox id="tbFieldDescription" runat="server" Width="148px" CssClass="InputCss"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�������ֶ�����" ControlToValidate="tbFieldDescription"></asp:RequiredFieldValidator></TD>
						<TD width="120" height="30" noWrap bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;�߶ȣ�</TD>
						<TD noWrap height="24"><asp:textbox id="tbHeight" runat="server" CssClass="InputCss">20</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ValidationExpression="\d+" ControlToValidate="tbHeight"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="tbHeight"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ErrorMessage="����ȷ����߶�" ControlToValidate="tbHeight"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#e8f4ff">&nbsp;�ֶ����ͣ�</TD>
						<TD style="WIDTH: 411px" height="24">
						    <%--<asp:radiobutton id="rdbChar" runat="server" Text="�ַ���"   GroupName="FieldType" Checked="True"></asp:radiobutton>
						    <asp:radiobutton id="rdbDate" runat="server" Text="������" GroupName="FieldType"></asp:radiobutton>
						    <asp:radiobutton id="rdbNumber" runat="server" Text="��ֵ��" GroupName="FieldType"></asp:radiobutton>--%>
					      <asp:DropDownList ID="ddlFieldType" runat="server"></asp:DropDownList>
						    
						</TD>
						<TD width="120" height="30" bgcolor="#e8f4ff">&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;�����жϣ�</TD>
				    <TD style="WIDTH: 411px" height="24"><asp:radiobutton id="JudgedYes" runat="server" Text="�ж�" GroupName="Judged" Checked="True"></asp:radiobutton>
				      <asp:RadioButton ID="JudgedNo" runat="server" Text="���ж�" GroupName="Judged"></asp:RadioButton></TD>
						<TD width="120" height="30" bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;λ�ã�</TD>
						<TD height="24"><asp:textbox id="tbPosition" runat="server" CssClass="InputCss">0</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ValidationExpression="\d+" ControlToValidate="tbPosition"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="tbPosition"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ErrorMessage="����ȷ����λ��" ControlToValidate="tbPosition"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD width="120" height="30" bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;���ݣ�</TD>
						<TD style="WIDTH: 411px" height="24">
					    <asp:radiobutton id="MultiLineYes" runat="server" Checked="True" GroupName="MultiLine" Text="����"></asp:radiobutton>
							<asp:radiobutton id="MultiLineNo" runat="server" GroupName="MultiLine" Text="����"></asp:radiobutton></TD>
						<TD width="120" height="30" bgcolor="#e8f4ff" style="WIDTH: 107px">&nbsp;���ʾ����</TD>
						<TD height="24">
							<asp:textbox id="tbExample" runat="server" CssClass="InputCss"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="120" height="30" style="WIDTH: 107px"></TD>
						<TD style="WIDTH: 411px" height="30">
							<asp:button id="cmdAdd" runat="server" CssClass="ButtonCss" Width="64px" Text="���"></asp:button>&nbsp;
							<INPUT class="ButtonCss" style="WIDTH: 63px; HEIGHT: 20px" onClick="javascript:location.href ='ManageStyle.aspx'"
								type="button" value="����"></TD>
						<TD width="120" height="30" style="WIDTH: 107px">
							<asp:button id="cmdUpdate" runat="server" CssClass="ButtonCss" Width="67px" Text="�޸�"></asp:button></TD>
						<TD height="30">
							<asp:button id="cmdDelete" runat="server" CssClass="ButtonCss" Width="65px" Text="ɾ��"></asp:button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

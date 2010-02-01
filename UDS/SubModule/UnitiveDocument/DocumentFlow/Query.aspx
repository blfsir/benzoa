<%@ Page language="c#" Codebehind="Query.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.Query" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Query</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����">
				<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
							bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
						<TD class="GbText" style="WIDTH: 75px" align="right" width="75" background="../../../Images/treetopbg.jpg"
							bgColor="#e8f4ff"><FONT color="#003366" size="2">�ĵ���ת</FONT></TD>
						<TD class="GbText" align="left" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT color="#003366" size="2">-��ѯ&nbsp;</FONT></TD>
					</TR>
				</TABLE>
				<table class="GbText" style="BORDER-COLLAPSE: collapse" borderColor="#c3d9ff" cellSpacing="0"
					cellPadding="0" width="100%" border="1">
					<tr>
						<td width="56" style="WIDTH: 56px; HEIGHT: 31px"><FONT color="#003366" size="2">������</FONT></td>
						<td width="1" style="WIDTH: 1px; HEIGHT: 31px"><asp:dropdownlist id="ddlFlow" runat="server" AutoPostBack="True" Width="150px"></asp:dropdownlist></td>
						<td width="56" style="WIDTH: 156px; HEIGHT: 31px" align="right"><FONT color="#003366" size="2">�ж�����</FONT>&nbsp;
						</td>
						<td colspan="2" style="HEIGHT: 31px"><asp:dropdownlist id="ddlCondition" runat="server" Width="120px"></asp:dropdownlist>
							<asp:dropdownlist id="ddlCompare" runat="server" Width="60px" Height="20px">
								<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
								<asp:ListItem Value="=">=</asp:ListItem>
								<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
								<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
								<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
								<asp:ListItem Value="&lt;&gt;">&lt;&gt;</asp:ListItem>
								<asp:ListItem Value=" Like "> ����</asp:ListItem>
							</asp:dropdownlist><asp:textbox id="txtValue" runat="server" Width="100px"></asp:textbox>ͳ��:
							<asp:DropDownList id="ddlStatistic" runat="server" Width="108px"></asp:DropDownList></td>
					</tr>
					<tr>
						<td style="WIDTH: 56px" vAlign="top" rowSpan="2"><FONT color="#003366" size="2">��ʾ��</FONT></td>
						<td style="WIDTH: 1px" vAlign="top" rowSpan="2" borderColor="#ffffff"><asp:checkboxlist id="cblDisplay" runat="server" Width="150px" Height="122px" BorderColor="#99ccff"
								BorderStyle="Solid" BorderWidth="1px" Font-Size="10"></asp:checkboxlist></td>
						<td colspan="2" vAlign="middle" align="right" style="HEIGHT: 20px" borderColor="#ffffff"><asp:button id="cmdAdd" runat="server" Width="75px" CssClass="redButtonCss" Text="����>>"></asp:button></td>
						<td width="285" rowspan="2" vAlign="middle" style="WIDTH: 250px" borderColor="#ffffff">
							<asp:listbox id="lbCondition" runat="server" Width="141px" Height="163px"></asp:listbox>
						</td>
					</tr>
					<tr>
						<td colspan="2" vAlign="middle" align="right" borderColor="#ffffff">
							<asp:button id="cmdDelete" runat="server" Width="75px" CssClass="redButtonCss" Text="ɾ��<<"></asp:button></td>
					</tr>
				</table>
				<table class="GbText" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2" cellSpacing="0"
					cellPadding="0" width="100%" border="1">
					<tr>
						<td align="center" colSpan="5" height="30" borderColor="#ffffff"><asp:button id="cmdQuery" runat="server" Width="56px" CssClass="redButtonCss" Text="��ѯ"></asp:button></td>
					</tr>
					<tr>
						<td style="WIDTH: 929px" vAlign="top" colSpan="5"><FONT color="#003366" size="2">
								<asp:table id="tabResult" runat="server" Width="100%" Height="16px" BorderStyle="Solid" BorderWidth="1px"
									BorderColor="#8080FF">
									<asp:TableRow>
										<asp:TableCell Font-Size="10pt" HorizontalAlign="Center" Text="�Զ����ѯ"></asp:TableCell>
									</asp:TableRow>
								</asp:table>
							</FONT>
						</td>
					</tr>
				</table>
			</FONT>
		</form>
		</TR></TABLE>
	</body>
</HTML>

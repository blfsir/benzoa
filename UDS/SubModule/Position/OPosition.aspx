<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" Codebehind="OPosition.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Position.OPosition" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OPosition</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="OPosition" method="post" runat="server">
			<TABLE id="tabMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<TABLE class="gbtext" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background="../../images/maillistbutton2.gif" height="24"><FONT face="����" class="Newbutton">ְλ����</FONT></TD>
								<TD align="right">
									<asp:LinkButton id="lbAddPosition" runat="server">�����¼�ְλ</asp:LinkButton>
									<asp:LinkButton id="lbDeletePosition" runat="server">ɾ����ǰְλ</asp:LinkButton>
									<asp:LinkButton id="lbModifyPosition" runat="server">�޸�ְλ</asp:LinkButton>
									<asp:LinkButton id="lbMovePosition" runat="server">ְλ���ƶ�</asp:LinkButton>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD valign="top"><FONT face="����">
							<TABLE id="tabAdd" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server"
								class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" height="24" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;�ϼ�ְλ��</FONT></TD>
									<TD id="TD1" runat="server"><FONT face="����">&nbsp;
											<asp:Label id="addPositionName" runat="server"></asp:Label></FONT></TD>
								</TR>
								<TR>
									<TD height="24" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;ְλ���ƣ�</FONT></TD>
									<TD><FONT face="����">&nbsp;
											<asp:TextBox id="txtAPositionName" runat="server" CssClass="inputcss" Columns="86"></asp:TextBox>
											<asp:Literal id="litAMessage" runat="server"></asp:Literal></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" valign="top" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;ְλ��飺</FONT></TD>
									<TD><FONT id="FONT2" face="����" runat="server">&nbsp;
											<asp:TextBox id="txtAPositionRemark" runat="server" CssClass="inputsta" Columns="87" Rows="5"
												TextMode="MultiLine"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;����ʱ�䣺</FONT></TD>
									<TD>&nbsp;
										<asp:TextBox id="txtOnDutyTime" runat="server" CssClass="inputcss" Columns="10" Rows="5" Width="150px"></asp:TextBox>
										<asp:RegularExpressionValidator id="rev_OnDutyTime" runat="server" ErrorMessage="�������" ControlToValidate="txtOnDutyTime"
											Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator><FONT face="����">-</FONT>
										<asp:TextBox id="txtOffDutyTime" runat="server" CssClass="inputcss" Columns="10" Rows="5" Width="150px"></asp:TextBox>
										<asp:RegularExpressionValidator id="rev_OffDutyTime" runat="server" ErrorMessage="�������" ControlToValidate="txtOffDutyTime"
											Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>(hh:mm)</TD>
								</TR>
								<TR>
									<TD colspan="2" align="center" height="36"><FONT id="FONT1" face="����" runat="server"> <INPUT class="ButtonCss " id="cmdAdd" accessKey="o" type="submit" value=" ȷ �� " runat="server"
												size="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdAddReturn" runat="server" CssClass="ButtonCss" Text=" �� �� "></asp:Button></FONT></TD>
								</TR>
							</TABLE>
							<TABLE id="tabDelete" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server"
								class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" height="24" align="right"><FONT face="����">&nbsp;ɾ��ְλ��</FONT></TD>
									<TD>&nbsp;
										<asp:Label id="delPositionName" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD colspan="2" align="center" height="36"><FONT face="����"> <INPUT class="ButtonCss" id="cmdDelete" type="submit" value=" ɾ �� " runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdDeleteReturn" runat="server" CssClass="ButtonCss" Text=" �� �� "></asp:Button></FONT></TD>
								</TR>
							</TABLE>
							<TABLE id="tabModify" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server"
								class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" height="24" align="right"><FONT face="����">&nbsp;ְλ���ƣ�</FONT></TD>
									<TD>&nbsp;
										<asp:TextBox id="txtPositionName" runat="server" CssClass="inputcss" Columns="90"></asp:TextBox>
										<asp:Literal id="litMMessage" runat="server"></asp:Literal></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" valign="top" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;ְλ��飺</FONT></TD>
									<TD><FONT face="����">&nbsp;
											<asp:TextBox id="txtMPositionRemark" runat="server" CssClass="Inputcss" Columns="90" Rows="5"
												TextMode="MultiLine"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" align="right"><FONT face="����">&nbsp;����ʱ�䣺</FONT></TD>
									<TD><FONT face="����">&nbsp;
											<asp:TextBox id="txtuOnDutyTime" runat="server" CssClass="inputsta" Columns="10" Rows="5">9:00</asp:TextBox>
											<asp:RegularExpressionValidator id="rev_uOnDutyTime" runat="server" ErrorMessage="�������" ControlToValidate="txtuOnDutyTime"
												Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>-
											<asp:TextBox id="txtuOffDutyTime" runat="server" CssClass="inputsta" Columns="10" Rows="5">17:00</asp:TextBox>
											<asp:RegularExpressionValidator id="rev_uOffDutyTime" runat="server" ErrorMessage="�������" ControlToValidate="txtuOffDutyTime"
												Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>(hh:mm)</FONT></TD>
								</TR>
								<TR>
									<TD colspan="2" align="center" height="36">
										<INPUT class="ButtonCss" id="cmdModify" type="submit" value=" �� �� " runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="cmdModifyReturn" runat="server" CssClass="ButtonCss" Text=" �� �� "></asp:Button></TD>
								</TR>
							</TABLE>
						</FONT>
						<P><FONT face="����">
								<TABLE id="tabMove" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server"
									class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
									<TR>
										<TD style="WIDTH: 94px; HEIGHT: 28px" bgcolor="#e8f4ff" align="right">ְλ���ƣ�</TD>
										<TD style="HEIGHT: 28px">&nbsp;
											<asp:Label id="lblPosition" runat="server" Width="213px"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 94px" valign="top" bgcolor="#e8f4ff" align="right">&nbsp;�ƶ�����</TD>
										<TD>&nbsp;
											<asp:ListBox id="lstDeparment" runat="server" Width="427px" Height="104px"></asp:ListBox></TD>
									</TR>
									<TR>
										<TD colspan="2" align="center" height="36">
											<asp:Button id="cmdMove" runat="server" CssClass="ButtonCss" Text=" ȷ �� "></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdMoveReturn" runat="server" CssClass="ButtonCss" Text=" �� �� "></asp:Button></TD>
									</TR>
								</TABLE>
							</FONT>
						</P>
					</TD>
				</TR>
			</TABLE>
			-&nbsp;</INPUT>&nbsp;
			<P><FONT face="����"></FONT>
			</P>
		</form>
	</BODY>
</HTML>

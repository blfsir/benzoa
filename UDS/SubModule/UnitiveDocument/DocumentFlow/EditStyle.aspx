<%@ Page language="c#" Codebehind="EditStyle.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.EditStyle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditStyle</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="EditStyle" method="post" encType="multipart/form-data" runat="server">
			<TABLE class="gbtext" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="38">
						<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" style="WIDTH: 23px" align="right" width="23" background="../../../Images/treetopbg.jpg"
									bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
								<TD class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
									bgColor="#e8f4ff"><font color="#006699"><asp:label id="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
											Width="53px">  表单设计</asp:label></font></TD>
								<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT>&nbsp;</FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<FONT face="宋体"></FONT>
								<TD align="right" height="22"><asp:label id="lblStyleName" runat="server">表单名称：</asp:label></TD>
								<TD height="22"><asp:textbox id="txtStyleName" runat="server" Width="350px" CssClass="inputcss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtStyleName"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="right"><asp:label id="lblStyleRemark" runat="server">表单介绍：</asp:label></TD>
								<TD><FONT face="宋体"><asp:textbox id="txtStyleRemark" runat="server" Width="350px" Height="100px" TextMode="MultiLine"></asp:textbox></FONT></TD>
							</TR>
							<TR id="Template" runat="server">
								<TD style="HEIGHT: 24px" align="right" height="24"><asp:label id="Label1" runat="server">原 模 板：</asp:label></TD>
								<TD style="HEIGHT: 24px" height="24"><asp:label id="lblTemplate" runat="server" Width="346px"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right" height="22"><asp:label id="lblStyleTeamlate" runat="server">表单模板：</asp:label></TD>
								<TD height="22"><INPUT class="inputcss" id="fileTemplate" style="WIDTH: 350px; HEIGHT: 22px" type="file"
										size="40" name="fileTemplate" runat="server"></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:button id="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="确定"></asp:button><FONT face="宋体">&nbsp;
									</FONT><INPUT class="buttoncss" style="WIDTH: 60px" onclick="javascript:location.href='ManageStyle.aspx'"
										type="button" value="返回"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

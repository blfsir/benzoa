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
        <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="23" height="30" align="right" background="../../../Images/treetopbg.jpg"
									bgColor="#c0d9e6" class="GbText" style="WIDTH: 23px"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
						    <TD class="GbText" align="center" width="60" background="../../../Images/treetopbg.jpg"
									bgColor="#e8f4ff"><asp:label id="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体" Font-Size="X-Small"
											Width="53px">  表单设计</asp:label></TD>
								<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT>&nbsp;</FONT></TD>
							</TR>
						</TABLE>
			<TABLE class="gbtext" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="10"></td>
				</tr>
				<TR>
					<TD>
						<TABLE width="98%" border="1" align="center" cellPadding="3" cellSpacing="0" class="gbtext" id="Table2" bordercolor="#93bee2">
							<TR>
								<FONT face="宋体"></FONT>
								<TD width="120" height="30" align="center" bgcolor="#e8f4ff"><asp:label id="lblStyleName" runat="server">表单名称：</asp:label></TD>
								<TD ><asp:textbox id="txtStyleName" runat="server" Width="350px" CssClass="inputcss"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtStyleName"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="120" height="30" align="center" bgcolor="#e8f4ff"><asp:label id="lblStyleRemark" runat="server">表单介绍：</asp:label></TD>
								<TD><FONT face="宋体"><asp:textbox id="txtStyleRemark" runat="server" Width="350px" Height="100px" TextMode="MultiLine"></asp:textbox></FONT></TD>
							</TR>
							<TR id="Template" runat="server">
								<TD width="120" height="30" align="center" bgcolor="#e8f4ff" ><asp:label id="Label1" runat="server">原 模 板：</asp:label></TD>
								<TD  height="24"><asp:label id="lblTemplate" runat="server" Width="346px"></asp:label></TD>
							</TR>
							<TR>
								<TD width="120" height="30" align="center" bgcolor="#e8f4ff"><asp:label id="lblStyleTeamlate" runat="server">表单模板：</asp:label></TD>
								<TD ><INPUT class="inputcss" id="fileTemplate" style="WIDTH: 350px; HEIGHT: 22px" type="file"
										size="40" name="fileTemplate" runat="server"></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:button id="cmdOK" runat="server" Width="60px" CssClass="buttoncss" Text="确定"></asp:button><FONT face="宋体">&nbsp;
									</FONT><INPUT class="buttoncss" style="WIDTH: 60px" onClick="javascript:location.href='ManageStyle.aspx'"
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

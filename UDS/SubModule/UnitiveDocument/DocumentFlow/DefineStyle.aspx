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
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td vAlign="top" height="34">
							<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR height="30">
									<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
										bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
										bgColor="#e8f4ff"><font color="#006699">文档流转</font></TD>
									<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="宋体">&nbsp;&nbsp;&nbsp; 
											&nbsp;</FONT></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TABLE>
				<asp:table id="tabDemo" style="Z-INDEX: 109; LEFT: 0px; POSITION: absolute; TOP: 174px; BORDER-COLLAPSE: collapse"
					runat="server" Width="100%" Height="33px" CellSpacing="1" CellPadding="1" CssClass="GbText"
					BorderWidth="1px" bordercolor="#CCCCCC" BorderStyle="Solid" GridLines="Both"></asp:table>
				<TABLE class="gbtext" id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc"
					cellSpacing="0" cellPadding="0" width="100%" border="1">
					<TR>
						<TD height="24">&nbsp;字段名：</TD>
						<TD style="WIDTH: 411px" height="24"><asp:dropdownlist id="ddlFieldName" runat="server" Width="152px" CssClass="InputCss"></asp:dropdownlist></TD>
						<TD style="WIDTH: 107px" height="24">&nbsp;宽度：</TD>
						<TD height="24"><asp:textbox id="tbWidth" runat="server" CssClass="InputCss">100</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="\d+" ControlToValidate="tbWidth"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbWidth"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="请正确输入宽度" ControlToValidate="tbWidth"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD height="24">&nbsp;字段意义：</TD>
						<TD style="WIDTH: 411px" height="24"><asp:textbox id="tbFieldDescription" runat="server" Width="148px" CssClass="InputCss"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="请输入字段意义" ControlToValidate="tbFieldDescription"></asp:RequiredFieldValidator></TD>
						<TD style="WIDTH: 107px" noWrap height="24">&nbsp;高度：</TD>
						<TD noWrap height="24"><asp:textbox id="tbHeight" runat="server" CssClass="InputCss">20</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ValidationExpression="\d+" ControlToValidate="tbHeight"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="tbHeight"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ErrorMessage="请正确输入高度" ControlToValidate="tbHeight"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD height="24">&nbsp;字段类型：</TD>
						<TD style="WIDTH: 411px" height="24">
						    <%--<asp:radiobutton id="rdbChar" runat="server" Text="字符型"   GroupName="FieldType" Checked="True"></asp:radiobutton>
						    <asp:radiobutton id="rdbDate" runat="server" Text="日期型" GroupName="FieldType"></asp:radiobutton>
						    <asp:radiobutton id="rdbNumber" runat="server" Text="数值型" GroupName="FieldType"></asp:radiobutton>--%>
						    <asp:DropDownList ID="ddlFieldType" runat="server"></asp:DropDownList>
						    
						</TD>
						<TD   </TD>
						<TD  </TD>
					</TR>
					<TR>
						<TD style="WIDTH: 107px" height="24">&nbsp;参与判断：</TD>
						<TD style="WIDTH: 411px" height="24"><asp:radiobutton id="JudgedYes" runat="server" Text="判断" GroupName="Judged" Checked="True"></asp:radiobutton><asp:radiobutton id="JudgedNo" runat="server" Text="不判断" GroupName="Judged"></asp:radiobutton></TD>
						<TD style="WIDTH: 107px" height="24">&nbsp;位置：</TD>
						<TD height="24"><asp:textbox id="tbPosition" runat="server" CssClass="InputCss">0</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ValidationExpression="\d+" ControlToValidate="tbPosition"
								ErrorMessage="*"></asp:regularexpressionvalidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="tbPosition"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ErrorMessage="请正确输入位置" ControlToValidate="tbPosition"
								ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 107px" height="24">&nbsp;内容：</TD>
						<TD style="WIDTH: 411px" height="24">
							<asp:radiobutton id="MultiLineYes" runat="server" Checked="True" GroupName="MultiLine" Text="多行"></asp:radiobutton>
							<asp:radiobutton id="MultiLineNo" runat="server" GroupName="MultiLine" Text="单行"></asp:radiobutton></TD>
						<TD style="WIDTH: 107px" height="24">&nbsp;填表示例：</TD>
						<TD height="24">
							<asp:textbox id="tbExample" runat="server" CssClass="InputCss"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 107px" height="30"></TD>
						<TD style="WIDTH: 411px" height="30">
							<asp:button id="cmdAdd" runat="server" CssClass="ButtonCss" Width="64px" Text="添加"></asp:button>&nbsp;
							<INPUT class="ButtonCss" style="WIDTH: 63px; HEIGHT: 20px" onclick="javascript:location.href ='ManageStyle.aspx'"
								type="button" value="返回"></TD>
						<TD style="WIDTH: 107px" height="30">
							<asp:button id="cmdUpdate" runat="server" CssClass="ButtonCss" Width="67px" Text="修改"></asp:button></TD>
						<TD height="30">
							<asp:button id="cmdDelete" runat="server" CssClass="ButtonCss" Width="65px" Text="删除"></asp:button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

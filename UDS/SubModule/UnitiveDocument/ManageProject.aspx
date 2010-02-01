<%@ Page language="c#" Codebehind="ManageProject.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.ManagerProject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManagerProject</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="ManagerProject" method="post" runat="server">
			<table id="AutoNumber4" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr height="30">
					<td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><font color="#003366" size="3"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/flag.gif" width="16"></FONT></font></td>
					<td class="GbText" width="80" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><b><B>项目管理</B></b></td>
					<TD class="GbText" align="right" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6">
						<TABLE class="gbtext" id="AutoNumber1" style="WIDTH: 461px; HEIGHT: 17px" height="17" cellSpacing="0"
							cellPadding="0" width="461" border="0">
							<TR>
								<TD style="WIDTH: 168px" align="center" width="168" height="1"><A href="ManageProject.aspx?Action=1&amp;ClassID=<%=ClassID%>" ><asp:label id="lblCreate" runat="server">创建下级项目</asp:label></A><FONT face="宋体"></FONT></TD>
								<TD style="WIDTH: 161px" align="center" width="161" height="1"><A href="ManageProject.aspx?Action=2&amp;ClassID=<%=ClassID%>"  ?><asp:label id="lblDelete" runat="server">删除项目</asp:label></A></TD>
								<TD style="WIDTH: 101px" align="center" width="101" height="1" DESIGNTIMEURL="ManageProject.aspx?Action=2&amp;ClassID"><A href="ManageProject.aspx?Action=3&amp;ClassID=<%=ClassID%>" ><asp:label id="lblRevise" runat="server">修改项目</asp:label></A></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
			</table>
			<table class="gbtext" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="283"
				cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td style="WIDTH: 67px" align="right" width="67" height="29">项目名称：</td>
					<td width="78%" colSpan="4" height="19"><input class="inputcss" id="txtClassName" maxlength="20" type="text" size="34" name="ClassName"
							runat="server" style="WIDTH: 240px; HEIGHT: 19px">
						<asp:requiredfieldvalidator id="rfv1" runat="server" ErrorMessage="*" ControlToValidate="txtClassName"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td style="WIDTH: 67px" align="right" width="67" height="29">开始时间：</td>
					<td width="78%" colSpan="4" height="19"><asp:textbox id="txtStartDate" onfocus="setday(this)" runat="server" CssClass="inputcss" readOnly
							Width="88px" AutoPostBack="true"></asp:textbox><asp:requiredfieldvalidator id="rfv2" runat="server" ErrorMessage="*" ControlToValidate="txtStartDate"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td style="WIDTH: 67px" align="right" width="67" height="29">结束时间：</td>
					<td width="78%" colSpan="4" height="19"><asp:textbox id="txtEndDate" onfocus="setday(this)" runat="server" CssClass="inputcss" readOnly
							Width="88px"></asp:textbox><asp:requiredfieldvalidator id="rfv3" runat="server" ErrorMessage="*" ControlToValidate="txtEndDate"></asp:requiredfieldvalidator></td>
				</tr>
				<TR>
					<td style="WIDTH: 67px" align="right" width="67" height="29">占用比例：</td>
					<td width="78%" colSpan="4" height="19">百分之：<input class="inputcss" onkeypress="var  k=event.keyCode;  if ((k==46) || (k<=57 &amp;&amp; k>=48)) return true; else return false"
							onpaste="return false" id="txtScale" type="text" size="1" name="Scale" runat="server" style="WIDTH: 40px; HEIGHT: 16px" maxLength="3"
							value="20">
						<asp:requiredfieldvalidator id="rfv4" runat="server" ErrorMessage="*" ControlToValidate="txtScale"></asp:requiredfieldvalidator></td>
				</TR>
				<tr>
					<td style="WIDTH: 67px; HEIGHT: 30px" align="right" width="67" height="30">项目状态：</td>
					<td width="78%" colSpan="4" height="30" style="HEIGHT: 30px" vAlign="middle" align="left">
						<asp:radiobuttonlist id="Status" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" Height="16px"></asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td style="WIDTH: 67px" vAlign="top" align="right" width="67" height="134">项目简介：</td>
					<td width="78%" colSpan="4" height="134"><textarea id="txtBrief" name="Remark" rows="10" cols="77" runat="server"></textarea></td>
				</tr>
				<tr>
					<td style="WIDTH: 67px" align="right" width="67" height="21"></td>
					<td width="78%" colSpan="4" height="30"><asp:button id="btnSubmit" runat="server" CssClass="ButtonCss" Text="提 交"></asp:button><asp:button id="btnRevise" runat="server" CssClass="ButtonCss" Text="修 改"></asp:button><FONT face="宋体">&nbsp;
							<asp:button id="btnDelete" runat="server" CssClass="ButtonCss" Text="删除" Visible="False" CausesValidation="False"></asp:button></FONT><input class=ButtonCss onclick="javascript:self.location='Project.aspx?classID=<%=ClassID%>'" type=button value="返 回" name=cmdReturn></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

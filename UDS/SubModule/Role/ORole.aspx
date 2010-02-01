<%@ Page language="c#" Codebehind="ORole.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Role.ORole" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ORole</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function ReturnBack()
		{
			location.href ="Listview.aspx?Role_ID=<%=RoleID%>&DisplayType=<%=DisplayType%>"
		}
		function PageChange(DisplayType)
		{
			location.href ="oRole.aspx?Role_ID=<%=RoleID%>&DisplayType=<%=DisplayType%>"
		}		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<TABLE class="gbtext" id="Table2" height="30" cellSpacing="0" cellPadding="0" width="100%"
			border="0">
			<TR>
				<TD style="WIDTH: 966px" background="../../Images/treetopbg.jpg" height="30">&nbsp;<FONT color="#006699">&nbsp;&nbsp;&nbsp; 
						角色管理</FONT></TD>
			</TR>
		</TABLE>
		<form id="ORole" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr height="25">
					<td style="HEIGHT: 25px" width="1"></td>
					<TD id="bar1" style="BACKGROUND-POSITION: left top; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat; HEIGHT: 25px"
						align="center" width="90" background="../../images/maillistbutton2.gif"><A 
      href="oRole.aspx?Role_ID=<%=RoleID%>&amp;DisplayType=0" class=Newbutton>创建角色</A></TD>
					<td style="BACKGROUND-POSITION: left top; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat; HEIGHT: 25px"
						id="bar1" align="center" width="90" background="../../images/maillistbutton2.gif"
						><a href="oRole.aspx?Role_ID=<%=RoleID%>&amp;DisplayType=2" class=Newbutton>修改角色</a></td>
					<TD id="bar1" style="BACKGROUND-POSITION: left top; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat; HEIGHT: 25px"
						align="center" width="90" background="../../images/maillistbutton2.gif"><A 
      onclick=PageChange(1) 
      href="oRole.aspx?Role_ID=<%=RoleID%>&amp;DisplayType=1" class=Newbutton>删除角色</A></TD>
					<TD>&nbsp;</TD>
				</tr>
			</table>
			<TABLE class="gbtext" id="tabModify" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="1" runat="server">
				<TR>
					<TD style="WIDTH: 91px"><FONT face="宋体">角色名称</FONT></TD>
					<TD><FONT face="宋体">&nbsp;</FONT>
						<asp:textbox id="txtMRoleName" Width="463px" EnableViewState="true" Columns="90" CssClass="inputsta"
							Runat="server"></asp:textbox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtMRoleName" ErrorMessage="请输入角色名"></asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px"><FONT face="宋体">角色简介：</FONT></TD>
					<TD><FONT face="宋体">&nbsp;
							<asp:textbox id="txtMRoleDescription" Width="462px" Columns="90" Runat="server" cssclass="InputSta"
								Rows="5" TextMode="MultiLine"></asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 91px"><FONT face="宋体"></FONT></TD>
					<TD><FONT face="宋体">&nbsp;&nbsp;<INPUT class="ButtonCss" id="cmdModify" type="submit" value="修改角色" name="cmdModify" runat="server">
							<INPUT class="ButtonCss" onclick="ReturnBack();" type="button" value="返回" name="cmdModifyBack"></FONT></TD>
				</TR>
			</TABLE>
			<TABLE class="gbtext" id="tabDelete" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="1" runat="server">
				<TR>
					<TD style="WIDTH: 96px"><FONT face="宋体">角色名称：</FONT></TD>
					<TD><FONT face="宋体">&nbsp;</FONT>
						<asp:label id="delRoleName" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 96px"><FONT face="宋体"></FONT></TD>
					<TD>&nbsp;<INPUT class="ButtonCss" id="cmdDelete" type="submit" value="删除角色" name="cmdDelete" runat="server">
						<INPUT class="ButtonCss" onclick="ReturnBack();" type="button" value="返回" name="Reset"></TD>
				</TR>
			</TABLE>
			<TABLE class="gbtext" id="tabAdd" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="1" runat="server">
				<TR>
					<TD style="WIDTH: 94px"><FONT face="宋体">角色名称：</FONT></TD>
					<TD><FONT face="宋体">&nbsp;</FONT>
						<asp:textbox id="txtARoleName" Columns="86" CssClass="inputsta" Runat="server"></asp:textbox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtARoleName" ErrorMessage="请输入角色名"></asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px"><FONT face="宋体">角色简介：</FONT></TD>
					<TD><FONT face="宋体"></FONT><FONT face="宋体">&nbsp;
							<asp:textbox id="txtARoleDescription" Columns="87" CssClass="inputsta" Runat="server" Rows="5"
								TextMode="MultiLine"></asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px"><FONT face="宋体"></FONT></TD>
					<TD><FONT face="宋体">&nbsp;&nbsp;<INPUT class="ButtonCss " id="cmdAdd" accessKey="o" type="submit" value="添加角色" name="cmdAdd"
								runat="server"> <INPUT class="ButtonCss" onclick="ReturnBack()" type="button" value="返回" name="cmdAddBack"></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

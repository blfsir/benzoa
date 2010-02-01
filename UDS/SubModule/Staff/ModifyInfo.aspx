<%@ Page language="c#" Codebehind="ModifyInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Staff.ModifyInfo1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ModifyInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../Css/meizzDate.js"></script>
		<style>.td { FONT-SIZE: 14px; COLOR: #0000ff }
		</style>

	</HEAD>
	<body>
		<form id="NewStaff" method="post" runat="server">
			<font face="楷体_GB2312" color="#0000ff">
				<CENTER><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><br>
					<STRONG><font size="5">员工注册</font> </STRONG>
				</CENTER>
				<FONT size="5"></FONT></font>
			<CENTER>
				<HR width="100%" SIZE="1">
			</CENTER>
			<font face="宋体" color="red">
				<CENTER><asp:literal id="message" runat="server" EnableViewState="False"></asp:literal></CENTER>
				<CENTER>&nbsp;</CENTER>
			</font>
			<CENTER>
				<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#eeeeee" cellSpacing="2" cellPadding="0" width="100%" border="0">
					<tr>
						<td align="right" width="25%">用户姓名:</td>
						<td width="80%"><asp:textbox id="txtStaffName" CssClass="InputCss" Runat="server" Columns="70" Width="382"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">真实姓名:</td>
						<td width="80%"><asp:textbox id="txtRealName" CssClass="InputCss" Runat="server" Columns="70" Width="382"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="请输入真实姓名" ControlToValidate="txtRealName" Font-Size="X-Small"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">性&nbsp;&nbsp;&nbsp; 别:</td>
						<td width="80%"><asp:radiobutton id="rb_male" Runat="server" GroupName="rSex" Checked="True" Text="男"></asp:radiobutton><asp:radiobutton id="rb_female" Runat="server" GroupName="rSex" Checked="False" Text="女"></asp:radiobutton></td>
					</tr>
					<tr>
						<td align="right" width="20%">出生日期:</td>
						<td width="80%"><asp:textbox id="txtBirthday" onfocus="setday(this)" CssClass="InputCss" Runat="server" Columns="70" Width="382" ReadOnly="True"></asp:textbox><asp:regularexpressionvalidator id="datecheck" runat="server" ErrorMessage="日期输入错误" ControlToValidate="txtBirthday" ValidationExpression="\d{4}-((0[1-9])|(1[0-2]))-((0[1-9])|([1-2][0-9])|3[0-1])"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">密&nbsp;&nbsp;&nbsp; 码:</td>
						<td width="80%"><input class="InputCss" id="txtPassword" style="WIDTH: 382px" type="password" size="70" runat="server" NAME="txtPassword">
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="密码不能为空" ControlToValidate="txtPassword" Font-Size="X-Small"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">重复密码:</td>
						<td width="80%"><input class="InputCss" id="txtRePassword" style="WIDTH: 382px" type="password" size="70" runat="server" NAME="txtRePassword">
							<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="密码确认错误" ControlToValidate="txtRePassword" ControlToCompare="txtPassword" Font-Size="X-Small"></asp:comparevalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">Email:</td>
						<td width="80%"><asp:textbox id="txtEmail" CssClass="InputCss" Runat="server" Columns="70" Width="382"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="请填写电子邮件地址" ControlToValidate="txtEmail" Display="Dynamic" Font-Size="X-Small"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="checkmail" runat="server" ErrorMessage="错误的EMAIL格式" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">公司电话:</td>
						<td width="80%"><asp:textbox id="txtPhone" CssClass="InputCss" Runat="server" Columns="70" Width="382"></asp:textbox><asp:regularexpressionvalidator id="checkphone" runat="server" ErrorMessage="电话号码错误" ControlToValidate="txtPhone" ValidationExpression="\d*" Font-Size="X-Small"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td align="right" width="20%">手机</td>
						<td width="80%"><asp:textbox id="txtMobile" CssClass="InputCss" Runat="server" Columns="70" Width="382"></asp:textbox><asp:regularexpressionvalidator id="checkmobile" runat="server" ErrorMessage="手机号错误" ControlToValidate="txtMobile" ValidationExpression="\d*" Font-Size="X-Small"></asp:regularexpressionvalidator></td>
					</tr>
					<tr id="mydepartment" runat="server">
						<td align="right" width="20%">所属部门:</td>
						<td width="80%"><FONT face="宋体"><asp:dropdownlist id="cboDepartment" runat="server" Width="383px"></asp:dropdownlist></FONT></td>
					</tr>
					<TR>
						<TD align="right" width="20%"></TD>
						<TD align="left" width="80%"><FONT face="宋体">&nbsp; </FONT>
						</TD>
						<TD align="middle" width="80%"></TD>
					</TR>
				</table>
			</CENTER>
			<HR width="100%" SIZE="1">
			<div align="center"><INPUT class="ButtonCss" id="cmdSubmit" type="button" value="确 定" runat="server" NAME="cmdSubmit">&nbsp;&nbsp;&nbsp;
				<INPUT class="ButtonCss" onclick="history.back();" type="button" value="返 回" name="cmdReturn">
			</div>
		</form>
	</body>
</HTML>

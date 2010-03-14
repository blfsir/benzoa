<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetMove.aspx.cs" Inherits="UDS.SubModule.Asset.AssetMove" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeDepartment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	<body>
		<form id="ChangeDepartment" method="post" runat="server">
			<span class="BlueTextBX"><font face="楷体_GB2312" color="#0000ff" size="5">
					<CENTER><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<br>
						<STRONG><U>设备转移到</U></STRONG>
				</font></span><font face="楷体_GB2312" color="#0000ff"><STRONG><U></U></STRONG></font>
			<br>
			<br>
			<asp:Label id="Label1" runat="server" Width="140px" Height="18px" Font-Size="X-Small">请选择要转移到的人员:</asp:Label>
			<asp:DropDownList ID="ddlBuyUser" runat="server">
                    </asp:DropDownList>
                    <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="" name="txtSendTo"><A onclick="dialwinprocess('txtSendTo')" href="#"><img src="../../DataImages/staff.gif" border="0"><FONT face="宋体">选择人员</FONT></A>
			<select id="cboPosition" style="WIDTH:408px; HEIGHT:261px" size="1" runat="server" EnableViewState="true">
			</select></CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>
				<input type="submit" value="确 定" id="cmdSubmit" OnClick="SubmitMe()" class="redButtonCss"
					runat="server">&nbsp;&nbsp; <input type="button" value="返 回" name="cmdReturn" OnClick="history.back()" class="redButtonCss">
			</CENTER>
			<CENTER>
				<CENTER>
					<asp:CheckBox id="cbRemind" runat="server" Font-Size="X-Small" Height="16px" Width="240px" Text="站内短消息提醒(提醒公司全体员工)"></asp:CheckBox></CENTER>
				<br>
			</CENTER>
		</form>
	</body>
</HTML>

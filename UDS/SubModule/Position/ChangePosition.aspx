<%@ Page language="c#" Codebehind="ChangePosition.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Position.ChangePosition" %>
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
			<span class="BlueTextBX"><font face="����_GB2312" color="#0000ff" size="5">
					<CENTER><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
						<br>
						<STRONG><U>Ա����ְ��</U></STRONG>
				</font></span><font face="����_GB2312" color="#0000ff"><STRONG><U></U></STRONG></font>
			<br>
			<br>
			<asp:Label id="Label1" runat="server" Width="140px" Height="18px" Font-Size="X-Small">��ѡ��Ҫת�Ƶ��Ĳ���:</asp:Label>
			<select id="cboPosition" style="WIDTH:408px; HEIGHT:261px" size="1" runat="server" EnableViewState="true">
			</select></CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>
				<input type="submit" value="ȷ ��" id="cmdSubmit" OnClick="SubmitMe()" class="redButtonCss"
					runat="server">&nbsp;&nbsp; <input type="button" value="�� ��" name="cmdReturn" OnClick="history.back()" class="redButtonCss">
			</CENTER>
			<CENTER>
				<CENTER>
					<asp:CheckBox id="cbRemind" runat="server" Font-Size="X-Small" Height="16px" Width="240px" Text="վ�ڶ���Ϣ����(���ѹ�˾ȫ��Ա��)"></asp:CheckBox></CENTER>
				<br>
			</CENTER>
		</form>
	</body>
</HTML>

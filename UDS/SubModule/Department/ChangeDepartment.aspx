<%@ Page language="c#" Codebehind="ChangeDepartment.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Department.ChangeDepartment" %>
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
			<center>
				<span class="BlueTextBX"><u><b><font face="楷体_GB2312" color="#0000ff" size="5">
								<br>
								员工调职到</font></b></u></span><u><b><font face="楷体_GB2312" color="#0000ff"> </font>
					</b></u>
				<br>
				<br>
				<asp:Label id="Label1" runat="server" Width="140px" Height="18px" Font-Size="X-Small">请选择要转移到的部门:</asp:Label>
				<select id="Department" style="WIDTH:408px; HEIGHT:261px" size="1" runat="server" EnableViewState="true">
				</select><p>
				</p>
				<p>
					<input type="submit" value="确 定" id="cmdSubmit" OnClick="SubmitMe()" class="redButtonCss" runat="server">&nbsp;&nbsp;
					<input type="button" value="返 回" name="cmdReturn" OnClick="history.back()" class="redButtonCss">
					<br>
				</p>
			</center>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="UpdateCaste.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Position.UpdateCaste" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UpdateCaste</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 322px; POSITION: absolute; TOP: 73px" runat="server"
					Width="256px" Height="23px">批量修改职位级别</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 200px; POSITION: absolute; TOP: 160px" runat="server">职位级别：</asp:Label>
				<asp:TextBox id="tbNewCaste" style="Z-INDEX: 103; LEFT: 266px; POSITION: absolute; TOP: 157px"
					runat="server" Width="247px" CssClass="InputCss"></asp:TextBox>
				<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 201px; POSITION: absolute; TOP: 132px" runat="server"
					Width="60px" Height="8px">职位名称：</asp:Label>
				<asp:Label id="labPositionName" style="Z-INDEX: 105; LEFT: 270px; POSITION: absolute; TOP: 133px"
					runat="server" Width="237px"></asp:Label>
				<asp:Button id="cmdOK" style="Z-INDEX: 106; LEFT: 307px; POSITION: absolute; TOP: 196px" runat="server"
					Width="69px" Height="22px" Text="确定" CssClass="ButtonCss"></asp:Button>
				<asp:Button id="cmdReturn" style="Z-INDEX: 107; LEFT: 396px; POSITION: absolute; TOP: 196px"
					runat="server" Width="69px" Height="22px" Text="返回" CausesValidation="False" CssClass="ButtonCss"></asp:Button>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 108; LEFT: 516px; POSITION: absolute; TOP: 163px"
					runat="server" ErrorMessage="*" ControlToValidate="tbNewCaste"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 109; LEFT: 524px; POSITION: absolute; TOP: 163px"
					runat="server" ErrorMessage="请输入正确的数字" ControlToValidate="tbNewCaste" ValidationExpression="\d*"></asp:RegularExpressionValidator></FONT>
		</form>
	</body>
</HTML>

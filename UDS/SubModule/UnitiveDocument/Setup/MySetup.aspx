<%@ Page language="c#" Codebehind="MySetup.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Setup.MySetup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MySetup</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="MySetup" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="lblOldPassword" style="Z-INDEX: 101; LEFT: 126px; POSITION: absolute; TOP: 66px" runat="server" Width="62px" Height="18px">原密码：</asp:Label>
				<TABLE id="Table1" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR height="30">
						<TD class="GbText" width="3%" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../Images/icon/057.GIF" width="16"></FONT></TD>
						<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><B><B>我的设置</B></B></TD>
					</TR>
				</TABLE>
				<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 127px; POSITION: absolute; TOP: 95px" runat="server" Width="56px" Height="18px">新密码：</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 106px; POSITION: absolute; TOP: 123px" runat="server" Width="85px" Height="14px">确认新密码：</asp:Label>
				<asp:TextBox id="txtOldPassword" style="Z-INDEX: 104; LEFT: 202px; POSITION: absolute; TOP: 61px" runat="server" Width="227px" Height="24px" TextMode="Password" CssClass="inputcss"></asp:TextBox>
				<asp:TextBox id="txtNewPassword" style="Z-INDEX: 105; LEFT: 202px; POSITION: absolute; TOP: 89px" runat="server" Width="227px" Height="24px" TextMode="Password" CssClass="inputcss"></asp:TextBox>
				<asp:TextBox id="txtReNewPassword" style="Z-INDEX: 106; LEFT: 202px; POSITION: absolute; TOP: 118px" runat="server" Width="226px" TextMode="Password" Height="24px" CssClass="inputcss"></asp:TextBox>
				<asp:Button id="cmdOK" style="Z-INDEX: 107; LEFT: 209px; POSITION: absolute; TOP: 159px" runat="server" Width="80px" Text="确  定" CssClass="buttoncss"></asp:Button>
				<asp:Button id="cmdCancel" style="Z-INDEX: 108; LEFT: 313px; POSITION: absolute; TOP: 159px" runat="server" Width="80px" Text="取  消" CssClass="buttoncss"></asp:Button>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="DisplayDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.SignDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SignDocument</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript"> 
		function OpenDialog(DocID,Operation)
			{
				var newdialoguewin = window.showModalDialog("PostilDocument.aspx?DocID="+DocID+"&Operation="+Operation,"","dialogWidth:540px;DialogHeight=260px;status:no");
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<FORM id="PostilDocument" method="post" runat="server">
			<input type="hidden" id="PID" value="0" runat="server" style="WIDTH: 34px; HEIGHT: 22px"
				size="1">
			<select id="ddlProject" runat="server" onchange="document.all.PID.value=this.options[this.selectedIndex].value;">
			</select>
			<asp:table id="tabDispDocument" style="Z-INDEX: 101; LEFT: 17px; POSITION: absolute; TOP: 233px; BORDER-COLLAPSE: collapse"
				runat="server" CssClass="GbText" Width="100%" Height="36px" GridLines="Both" BorderColor="#0066CC"
				CellPadding="3" EnableViewState="False">
		    </asp:table>
			<asp:button id="cmdSignIn" runat="server" CssClass="redButtonCss" Text="签收" Width="72px" EnableViewState="False"></asp:button>
			<asp:button id="cmdBack" runat="server" CssClass="redButtonCss" Text="回退" Width="72px" EnableViewState="False"></asp:button>
			<asp:button id="cmdPostilNext" runat="server" CssClass="redButtonCss" Text="同意" Width="72px" 	EnableViewState="False"></asp:button>
			<asp:button id="cmdPostilFaile" runat="server" CssClass="redButtonCss" Text="拒绝" Width="72px"				EnableViewState="False"></asp:button>
			<asp:button id="cmdPostilFinish" runat="server" CssClass="redButtonCss" Text="完成" Width="72px"				EnableViewState="False"></asp:button>
			<asp:button id="cmdCancelSignIn" runat="server" CssClass="redButtonCss" Text="取消签收" Width="72px"				EnableViewState="False"></asp:button>
			<asp:button id="cmdReturn" runat="server" CssClass="redButtonCss" Text="返回" Width="72px" CausesValidation="False"				EnableViewState="False"></asp:button></FORM>
	</body>
</HTML>

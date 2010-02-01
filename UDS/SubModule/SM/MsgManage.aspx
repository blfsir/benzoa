<%@ Page language="c#" Codebehind="MsgManage.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.SM.MsgManage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>消息中心</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript">
		function LoadEvent()
		{
			if(document.MsgManage.btnNext!=null)
			{//查看状态	
				CloseTimer();	
				document.MsgManage.btnReply.focus();
			}
			else
			{//回复状态
				TimeShow.innerHTML = "";
				words.innerHTML = "";
				document.MsgManage.txtContent.focus();		
			}		
			
						
		}

		TimeStart=20;
		function CloseTimer()
		{
			if(TimeStart==0)
			window.close();

			TimeShow.innerHTML=TimeStart;
			TimeStart--;

			var timer=setTimeout("CloseTimer()",1000);
		}
		
		
		function Reply()
		{
			if(event.keyCode==10)
			{
				document.MsgManage.btnReply.click();
			}
		}
		</SCRIPT>
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="LoadEvent()" MS_POSITIONING="GridLayout" topmargin=0 leftmargin=0>
		<form id="MsgManage" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0" height=30>
				<tr>
					<td background="../../Images/treetopbg.jpg">
						<table class="GbText" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="center" width="30"><IMG height="16" src="../../Images/page.gif" width="16"></td>
								<td>&nbsp;
									<asp:Label id="lblInstruction" runat="server">最新消息</asp:Label><span id="TimeShow" style="FONT-WEIGHT: bold; COLOR: #ff0000">
									</span><span id="words">&nbsp;秒后关闭</span></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE id="dgMailList" style="BORDER-RIGHT: #93bee2 1px; BORDER-TOP: #93bee2 1px; BORDER-LEFT: #93bee2 1px; WIDTH: 100%; BORDER-BOTTOM: #93bee2 1px; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: white"
							borderColor="#93bee2" cellSpacing="0" cellPadding="3" rules="all" border="1">
							<TBODY>
								<TR style="FONT-SIZE: x-small; COLOR: black; BACKGROUND-COLOR: #e8f4ff" vAlign="middle"
									align="center">
									<TD align="center" bgColor="#93bee2" height="4"><FONT face="宋体"></FONT></TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE id="tnb" style="BORDER-RIGHT: #93bee2 1px; BORDER-TOP: #93bee2 1px; BORDER-LEFT: #93bee2 1px; WIDTH: 100%; BORDER-BOTTOM: #93bee2 1px; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: white"
							borderColor="#93bee2" cellSpacing="0" cellPadding="3" rules="all" border="1">
							<TR style="FONT-SIZE: x-small; COLOR: black; BACKGROUND-COLOR: #e8f4ff" vAlign="middle"
								align="center">
								<TD style="FONT-SIZE: x-small; WIDTH: 50px" align="left" width="50"><FONT face="宋体"><asp:label id="lblSender" runat="server" Font-Size="X-Small">发送者</asp:label></FONT></TD>
								<TD style="FONT-SIZE: x-small" align="left"><FONT face="宋体">&nbsp; </FONT>
									<asp:textbox id="txtRealName" runat="server" Width="77px" CssClass="InputCss"></asp:textbox><asp:textbox id="txtMsgID" runat="server" Visible="False" Width="7px"></asp:textbox><asp:textbox id="txtSender" runat="server" Visible="False" Width="9px"></asp:textbox></TD>
							</TR>
							<TR style="FONT-SIZE: x-small; COLOR: black; BACKGROUND-COLOR: white" vAlign="middle"
								align="center">
								<TD style="FONT-SIZE: x-small; WIDTH: 50px" align="left"><FONT face="宋体">
										<asp:label id="lblContent" runat="server" Font-Size="X-Small">内  容</asp:label></FONT></TD>
								<TD style="FONT-SIZE: x-small" align="left"><FONT face="宋体">&nbsp; </FONT>
									<asp:textbox onkeypress="Reply()" id="txtContent" runat="server" Width="280px" Height="120px"
										TextMode="MultiLine" CssClass="InputCss"></asp:textbox><BR>
									<FONT face="宋体">&nbsp; </FONT>
									<asp:label id="lblShortCut" runat="server" Font-Size="X-Small"></asp:label></TD>
							</TR>
							<TR style="FONT-SIZE: x-small; COLOR: black; BACKGROUND-COLOR: white" vAlign="middle"
								align="center">
								<TD style="FONT-SIZE: x-small; WIDTH: 50px" align="left">
									<asp:button id="btnHistory" runat="server" Enabled="False" Text="历史记录" CssClass="greenButtonCss"></asp:button></TD>
								<TD align="left" style="FONT-SIZE: x-small">&nbsp;
									<asp:button id="btnReply" runat="server" Enabled="False" Text="回复" CssClass="redButtonCss"></asp:button>&nbsp;
									<asp:button id="btnNext" runat="server" Enabled="False" Text="下一条" CssClass="redButtonCss"></asp:button>&nbsp;
									<asp:button id="btnRead" runat="server" Text="我知道啦!" CssClass="redButtonCss"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

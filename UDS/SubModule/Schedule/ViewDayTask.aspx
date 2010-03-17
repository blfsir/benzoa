<%@ Page language="c#" Codebehind="ViewDayTask.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Schedule.ViewDayTask" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewDayTask</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style>A.linkFooter:link { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkFooter:visited { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkFooter:hover { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #646464; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: underline }
	A.linkFooter:active { FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #646464; LINE-HEIGHT: 25px; FONT-FAMILY: "宋体"; TEXT-DECORATION: none }
	A.linkMenu:link { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkMenu:visited { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A.linkMenu:active { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #838383; LINE-HEIGHT: 10px; FONT-FAMILY: "宋体"; TEXT-DECORATION: underline }
	A.linkMenu:hover { FONT-WEIGHT: normal; FONT-SIZE: 9px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	BODY { SCROLLBAR-FACE-COLOR: #ffffff; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; SCROLLBAR-SHADOW-COLOR: #ffffff; SCROLLBAR-3DLIGHT-COLOR: #ffffff; SCROLLBAR-ARROW-COLOR: #949494; SCROLLBAR-TRACK-COLOR: #ffffff; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; SCROLLBAR-BASE-COLOR: #ffffff }
	.borderMenuLayer { BORDER-LEFT-COLOR: #c9c9c9; BORDER-BOTTOM-COLOR: #c9c9c9; BORDER-TOP-COLOR: #c9c9c9; BORDER-RIGHT-COLOR: #c9c9c9 }
	.borderMenuLayerOver { FONT-SIZE: 9pt; BORDER-LEFT-COLOR: #949494; BORDER-BOTTOM-COLOR: #949494; BORDER-TOP-COLOR: #949494; BORDER-RIGHT-COLOR: #949494 }
	.textWhite { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #999999; LINE-HEIGHT: 22px; FONT-FAMILY: "宋体" }
	.top { FONT-WEIGHT: normal; FONT-SIZE: 9pt; COLOR: #000000; FONT-FAMILY: "Arial", "Helvetica", "sans-serif"; TEXT-DECORATION: none }
	.newtable {line-height:20px; border-color:#93bee2; text-indent:4px; }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="ViewDayTask" method="post" runat="server">
			<asp:table CssClass="newtable" id="Table1" style="Z-INDEX: 101; LEFT: 3px; width:98%; POSITION: absolute; TOP: 22px;  font-size:12px;"  cellpadding="0" cellspacing="3" runat="server"
				BorderWidth="0px" Height="116px"></asp:table>
			<asp:Label id="lblTitle" style="Z-INDEX: 102; LEFT: 3px; POSITION: absolute; TOP: 1px" runat="server"
				Font-Size="12px" BackColor="White" Height="7px" Width="94px">执行人日程表:</asp:Label>
		</form>
	</body>
</HTML>

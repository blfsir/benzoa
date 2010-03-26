<%@ Page language="c#" Codebehind="Online.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Online" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Online</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function SetCookie(sName, sValue)
		{
			document.cookie = sName + "=" + escape(sValue) + "; ";
		}
	
		function GetCookie(sName)
		{
			var aCookie = document.cookie.split("; ");
			for (var i=0; i < aCookie.length; i++)
			{
				
				var aCrumb = aCookie[i].split("=");
				if (sName == aCrumb[0]) 
				return unescape(aCrumb[1]);
			}
			
		
		}

		function opendialwin()
		{
				var newdialoguewin = window.showModalDialog("../SM/Setup.aspx",window,"dialogWidth:500px;DialogHeight=140px;status:no");
				if(newdialoguewin!=null){
					
				}
		}

		function show_sm()
		{
			if (typeof(msgwin)!="undefined" && msgwin.open && !meizz.closed)
			{
				msgwin.focus();
			}
			else
			{
				mytop=screen.availHeight-246;
				myleft=0;
				var msgwin = window.open("../SM/MsgManage.aspx","auto_call_show","height=170,width=350,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
			}
		}

		function showonline()
		{
			onlinewin=window.open("onlineperson.aspx","online","width:500,height:800,toolbar=no,status=no,resizable=yes")
			onlinewin.moveTo(20,20)
			onlinewin.resizeTo(600,500)

		}
		function re()
		{
			location.reload();
		}
		function setup()
		{
			opendialwin();
		}

		</script>
	</HEAD>
	<body style="BACKGROUND-POSITION: right 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat"
		leftMargin="0" background="../../Images/lefttreebg.gif" topMargin="0" bgcolor="#337fb2"
		onload='setInterval("re()",(GetCookie("UDS_RefreshTime"))==null?30000:GetCookie("UDS_RefreshTime"))'>
		<form id="Online" method="post" runat="server">
			<table width="222" border="0" height="29" style="WIDTH: 222px; HEIGHT: 29px">
				<tr>
					<td width="12%" style="WIDTH: 33px">&nbsp;<a href="#" onclick="setup()"><img src="../../Images/person.gif" border="0" style="WIDTH: 20px; HEIGHT: 19px" height="19"
								width="20"></a></td>
					<td width="34%"><FONT size="2" color=white>在线人数:</FONT></td>
					<td width="15%"><a href="javascript:showonline()">
							<asp:Label id="lblOnlineCount" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label></a></td>
					<td width="39%">	<asp:Literal id="lit" runat="server"></asp:Literal></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

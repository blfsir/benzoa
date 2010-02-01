<%@ Page language="c#" Codebehind="NewItem.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.NewItem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>发贴</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
<!--
	function addcontent(str1,str2)
	{
		NewItem.Content.focus();
		if ((document.selection)&&(document.selection.type== "Text"))
		{
			var range= document.selection.createRange();
			var ch_text=range.text;
			range.text= str1 + ch_text + str2;
		} 
		else
		{
			document.NewItem.Content.value=document.NewItem.Content.value+str1+str2;
			NewItem.Content.focus();
		}
	}
	
	function sysbulletin_click()
	{
		document.getElementById('cbx_DeskTop').disabled = !document.getElementById('cbx_sysbulletin').checked;
	
	}
//-->
		</script>
	</HEAD>
	<body onload="document.getElementById('cbx_DeskTop').disabled=true">
		<form id="NewItem" method="post" encType="multipart/form-data" runat="server">
			<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" height="81" cellSpacing="0" cellPadding="0" width="96%" border="1">
				<tr align="middle" bgcolor="#93bee2">
					<td class="Gbtext" vAlign="top" colSpan="2" height="20" style="HEIGHT: 20px"><span class="whiteTextBX"><font size="3">.::发送新贴::.
								<asp:CheckBox id="cbx_bulletin" runat="server" Text="本版公告" Font-Size="X-Small" ForeColor="Red"></asp:CheckBox>
								<asp:CheckBox id="cbx_sysbulletin" runat="server" ForeColor="Red" Font-Size="X-Small" Text="系统公告"></asp:CheckBox>
								<asp:CheckBox id="cbx_DeskTop" runat="server"></asp:CheckBox>
								<asp:Label id="lbl_DeskTop" runat="server" Font-Size="X-Small">桌面提醒</asp:Label>
							</font></span>
					</td>
					<TD class="Gbtext" vAlign="top" height="20" style="HEIGHT: 20px"></TD>
				</tr>
				<tr>
					<td class="Gbtext" align="right" width="100" height="30">主题：</td>
					<td class="Gbtext" align="left" height="18"><input class="InputCss" id="Title" style="WIDTH: 597px; HEIGHT: 19px" type="text" size="94" runat="server">
					</td>
					<TD class="Gbtext" align="left" height="18"></TD>
				</tr>
				<tr bgColor="#e8f4ff">
					<td class="Gbtext" align="right" height="30">排版：</td>
					<td class="Gbtext" align="left" bgColor="#e8f4ff" height="21"><A title="粗体" href="javascript:addcontent('[B]','[/B]');"><IMG height="20" src="ubb/bold.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="斜体" href="javascript:addcontent('[I]','[/I]');"><IMG height="20" src="ubb/italicize.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="下划线" href="javascript:addcontent('[U]','[/U]');"><IMG height="20" src="ubb/underline.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="居中" href="javascript:addcontent('[ALIGN=CENTER]','[/ALIGN]');"><IMG height="20" src="ubb/center.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="链接" href="javascript:addcontent('[URL]','[/URL]');"><IMG height="20" src="ubb/url1.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="邮件" href="javascript:addcontent('[EMAIL]','[/EMAIL]');"><IMG height="20" src="ubb/email1.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="图片" href="javascript:addcontent('[IMG]','[/IMG]');"><IMG height="20" src="ubb/image.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="Flash" href="javascript:addcontent('[FLASH]','[/FLASH]');"><IMG height="20" src="ubb/swf.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="代码" href="javascript:addcontent('[CODE]','[/CODE]');"><IMG height="20" src="ubb/code.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="引用" href="javascript:addcontent('[QUOTE]','[/QUOTE]');"><IMG height="20" src="ubb/quote1.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="飞行" href="javascript:addcontent('[FLY]','[/FLY]');"><IMG height="20" src="ubb/fly.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="移动" href="javascript:addcontent('[MOVE]','[/MOVE]');"><IMG height="20" src="ubb/move.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="发光" href="javascript:addcontent('[GLOW=255,RED,2]','[/GLOW]');"><IMG height="20" src="ubb/glow.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="阴影" href="javascript:addcontent('[SHADOW=255,RED,2]','[/SHADOW]');"><IMG height="20" src="ubb/shadow.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="3号字" href="javascript:addcontent('[SIZE=3]','[/SIZE]');"><IMG height="20" src="ubb/size3.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="蓝色字" href="javascript:addcontent('[COLOR=blue]','[/COLOR]');"><IMG height="20" src="ubb/blue.gif" width="20" align="absMiddle" border="0"></A>
						<A title="红色字" href="javascript:addcontent('[COLOR=red]','[/COLOR]');"><IMG height="20" src="ubb/red.GIF" width="20" align="absMiddle" border="0"></A>
						<A title="插入Media文件" href="javascript:addcontent('[MP=320,240]','[/MP]');"><IMG height="20" src="ubb/media.gif" width="20" align="absMiddle" border="0"></A>
						<A title="插入RealPlay文件" href="javascript:addcontent('[RM=320,240]','[/RM]');"><IMG height="20" src="ubb/real.gif" width="20" align="absMiddle" border="0"></A>
						<a title="使用帮助" href="help.htm" target="_blank">使用帮助</a>
					</td>
					<TD class="Gbtext" align="left" bgColor="#e8f4ff" height="21"></TD>
				</tr>
				<TR>
					<TD class="Gbtext" align="right" height="30"><FONT face="宋体">上传：</FONT></TD>
					<TD class="Gbtext" align="left" height="21"><FONT face="宋体"><INPUT class="INPUTCSS" id="hif" style="WIDTH: 185px; HEIGHT: 19px" type="file" size="11" runat="server">&nbsp;
							<asp:dropdownlist id="ddl_FileType" runat="server">
								<asp:ListItem Value="picture">图片</asp:ListItem>
								<asp:ListItem Value="rm">rm</asp:ListItem>
								<asp:ListItem Value="mp3">mp3</asp:ListItem>
								<asp:ListItem Value="avi">avi</asp:ListItem>
								<asp:ListItem Value="swf">swf</asp:ListItem>
								<asp:ListItem Value="other"> 其他</asp:ListItem>
							</asp:dropdownlist>&nbsp;
							<asp:button id="btn_UpAtt" runat="server" Text="上传" CssClass="inputcss"></asp:button>
							<asp:ListBox id="lbx_AttList" runat="server" Width="140px" Height="66px" SelectionMode="Multiple"></asp:ListBox>
							<asp:Button id="btn_DelAtt" runat="server" Text="删除" CssClass="inputcss"></asp:Button></FONT></TD>
					<TD class="Gbtext" align="left" height="21"></TD>
				</TR>
				<tr>
					<td class="Gbtext" vAlign="top" align="right" height="140">内容：</td>
					<td class="Gbtext" vAlign="top" align="left" height="140"><textarea id="Content" style="WIDTH: 603px; HEIGHT: 144px" rows="9" cols="73" runat="server"></textarea>
					</td>
					<TD class="Gbtext" vAlign="top" align="left" height="140"></TD>
				</tr>
				<tr align="middle" bgColor="#e8f4ff">
					<td class="Gbtext" colSpan="2" height="30"><input class="ButtonCss" id="cmdOK" type="submit" value=" 发 送 " runat="server">
						&nbsp;&nbsp; <input class="ButtonCss" type="reset" value=" 重 写" name="cmdCancel"></td>
					<TD class="Gbtext" height="30"></TD>
				</tr>
				<tr align="middle">
					<td class="Gbtext" colSpan="2" height="30"><A href="javascript:window.close();">关闭窗口</A></td>
					<TD class="Gbtext" height="30"></TD>
				</tr>
			</table>
		</form>
	</body>
</HTML>

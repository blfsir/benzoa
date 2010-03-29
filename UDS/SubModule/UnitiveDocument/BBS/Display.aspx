<%@ Import Namespace="UDS.Components"%>
<%@ Import Namespace="System"%>
<%@ Import Namespace="System.Data"%>
<%@ Page language="c#" Codebehind="Display.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.Display" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=title%>
		</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
<!--
	function addcontent(str1,str2)
	{
		Display.Content.focus();
		if ((document.selection)&&(document.selection.type== "Text"))
		{
			var range= document.selection.createRange();
			var ch_text=range.text;
			range.text= str1 + ch_text + str2;
		} 
		else
		{
			document.Display.Content.value=document.Display.Content.value+str1+str2;
			Display.Content.focus();
		}
	}
//-->
		</script>
		<script language="C#" runat="server">
		private bool GetReplayOpt(string author)
		{
			if((string.Compare(username.Trim(),author.Trim(),true)==0)||(isboardmaster))
			{
				return(true);
			}
			else
				return(false);
		}
		
		</script>
	</HEAD>
	<body>
		<form id="Display" method="post" runat="server" encType="multipart/form-data">
			<div align="center">
				<center>
					<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" height="224" cellSpacing="0"
						cellPadding="3" width="98%" border="1" bordercolor="#93bee2">
						<tr bgcolor="#93bee2">
							<td class="Gbtext" align="center" colSpan="2" height="30"><asp:label id="lblTitle" runat="server"  Font-Names="宋体" Font-Size="Medium"></asp:label><asp:CheckBox ID="cbx_sysBulletin" Text="系统公告" Visible="False" AutoPostBack="True" Runat="server"></asp:CheckBox><asp:CheckBox ID="cbx_DeskTop" Text="桌面显示" Visible="False" AutoPostBack="True" Runat="server"></asp:CheckBox><asp:CheckBox ID="cbx_boardBulletin" Text="板块公告" Visible="False" AutoPostBack="True" Runat="server"></asp:CheckBox></td>
					  </tr>
						<tr>
							<td class="Gbtext" align="left" bgColor="#e8f4ff" height="26" valign="top">
								<B>发送日期</B>：<br>
								<asp:literal id="sendtime" runat="server"></asp:literal><br>
								<B>浏览次数</B>：
								<asp:literal id="browsetime" runat="server"></asp:literal><br>
								<B>回复次数</B>：
								<asp:literal id="replaytimes" runat="server"></asp:literal><br>
								<B>作者</B>：<br>
								<asp:literal id="sendman" runat="server"></asp:literal><br>
							</td>
							<td class="Gbtext" id="itemcontent" vAlign="top" align="left" bgColor="#e8f4ff" height="26"
								runat="server">
							</td>
					  <asp:repeater id="replaylist" Runat="server">
							<ItemTemplate>
								<tr>
									<td height="26" align="left" class="Gbtext" bgcolor='#e8f4ff' valign=top>
										<B>发送日期</B>：<br>
										<asp:Literal id="replaytime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"replay_time")%>'>
										</asp:Literal><br>
										<B>回复人</B>：<br>
										<asp:Literal id="replayer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"replayer")%>'>
										</asp:Literal><br>
									</td>
									<td height="26" align="left" class="Gbtext" bgcolor='#e8f4ff' id="replaycontent" vAlign="top" runat="server">
										<asp:Panel ID = "pnlReplayOp" Visible=<%# GetReplayOpt(DataBinder.Eval(Container.DataItem,"replayer").ToString())%> Runat=server>
							<b>操作：</b>|
<asp:LinkButton id='lbtndelreplay' OnClick='DelReplay' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"replay_id") %>' runat=server>删除回复</asp:LinkButton>|<br><hr color='#C0C0C0' size='1'>
							</asp:Panel>
										<%# FormatTxt(UBB.txtMessage(DataBinder.Eval(Container.DataItem,"content").ToString()))%>
									</td>
								</tr>
							</ItemTemplate>
					  </asp:repeater>
						</tr>
						<tr>
							<td class="Gbtext" width="100" height="30" align="right">排版:&nbsp;</td>
							<td class="Gbtext" align="left" height="16"><A title="粗体" href="javascript:addcontent('[B]','[/B]');"><IMG height="20" src="ubb/bold.GIF" width="20" align="absMiddle" border="0"></A>
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
						</tr>
						<TR>
							<TD class="Gbtext" height="30" width="100" align="right">上传:&nbsp;</TD>
							<TD class="Gbtext" align="left" height="21"><FONT face="宋体"><INPUT class="INPUTCSS" id="hif" style="WIDTH: 422px; HEIGHT: 19px" type="file" size="51"
										NAME="hif" runat="server">&nbsp;
									<asp:dropdownlist id="ddl_FileType" runat="server">
										<asp:ListItem Value="picture">图片</asp:ListItem>
										<asp:ListItem Value="rm">rm</asp:ListItem>
										<asp:ListItem Value="mp3">mp3</asp:ListItem>
										<asp:ListItem Value="avi">avi</asp:ListItem>
										<asp:ListItem Value="swf">swf</asp:ListItem>
										<asp:ListItem Value="other">其他</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:button id="btn_UpAtt" runat="server" Text="上传" CssClass="ButtonCss"  ></asp:button><asp:ListBox id="lbx_AttList" runat="server" Width="140px"   SelectionMode="Multiple" Rows="1"></asp:ListBox>
							<asp:Button id="btn_DelAtt" runat="server" Text="删除" CssClass="inputcss"></asp:Button></FONT></TD>
						</TR>
						<tr>
							<td class="Gbtext" vAlign="top" width="100" height="140" align="right">内容:&nbsp;</td>
							<td class="Gbtext" vAlign="top" align="left" height="140"><textarea id="Content" rows="9" cols="63" runat="server" style="WIDTH: 525px; HEIGHT: 144px"></textarea></td>
						</tr>
						<tr>
							<td class="Gbtext" align="center" bgColor="#e8f4ff" colSpan="2" height="30"><input class="ButtonCss" id="cmdOK" type="submit" value="  发 送  " onserverclick="cmdOK_ServerClick" runat="server">
								&nbsp;&nbsp; <input class="ButtonCss" type="reset" value="  重 写  " name="cmdCancel"></td>
						</tr>
						<tr>
							<td class="Gbtext" align="center" width="736" colSpan="2" height="30"><A href="javascript:window.close();">关闭窗口</A></td>
						</tr>
					</table>
			  </center>
			</div>
		</form>
		</FORM>
	</body>
</HTML>

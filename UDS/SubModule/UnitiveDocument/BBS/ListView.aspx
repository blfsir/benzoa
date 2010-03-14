<%@ Page language="c#" Codebehind="ListView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.ListView" %>
<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
<!--
var bSubmited = false;

// 高亮背景
function high( which )
{ 
	which.style.background = "";
	which.style.font.color = "red";
} 

// 取消背景高亮
function low( which )
{ 
	which.style.background = "";
	which.style.font.color = "black";
}

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function SubmitCurrentPage( )
{
	
}
function OnChangePageInfo( )
{
	if( navigator.appName == "Netscape" )
	{
		if( e.which == 13 )
		{
			SubmitCurrentPage( );
		}
	}
	else
	{
		if( event.keyCode == 13 )
		{
			SubmitCurrentPage( );
		}
	}

}

function SubmitForm( BtObject )
{
	if( bSubmited == false )
	{
		bSubmited = true;
		BtObject.disabled = true;
		BtObject.title = "正在处理数据，请稍等……";
		BtObject.value = "处理中";
		fmAdminPanel.submit( );
	}
}






//-->
		</script>
		<script language="C#" runat="server">
		private string GetImagePath(string hittimes,string sysbulletin,string bulletin)
		{
			
			if(sysbulletin=="True")
			{
				return("../../../images/sysbulletin.gif");
			}
			else	if(bulletin=="True")
			{
				return("../../../images/bulletin.gif");
			
			}
			else	if(hittimes!="")
			{
				if(Int32.Parse(hittimes) > hotitemhittimes)
					return("../../../images/hotfolder.gif");
				else
					return("../../../images/folder.gif");
			}
			
			else
				return("../../../images/folder.gif");
		} 
		private string GetImageAlt(string hittimes)
		{
			if(hittimes!="")
			{
				if(Int32.Parse(hittimes) > hotitemhittimes)
					return("热门贴");
				else
					return("一般贴");
			}
			return("一般贴");
		}
		</script>
	</HEAD>
	<body topmargin=0 leftmargin=0>
		<form id="ListView" method="post" runat="server">
			<table  width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td background="../../../Images/bbsback.jpg"><img src="../../../Images/bbs.jpg"></td><td background="../../../Images/bbsback.jpg"><br><font color=white>|</font> <a  style="color: #ffffff;" href='<%="search/index.aspx?classid="+classid%>'>搜索</a> <font color=white>|</font></td>
					</tr>
				</table><br>
			<table id="AutoNumber4" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="98%" border="0" align="center">
				<tr>
					<td class="BlueTextBX" align="middle" height="1"><asp:Label ID="lblBoardName" Runat="server" Font-Bold="true" Font-Underline="false"></asp:Label></td>
					<td class="BlueTextBX" align="right" height="1"><input type=button onClick="window.open('NewItem.aspx?BoardID=<%=boardid%>');" value="发送新贴" class=redbuttoncss></td>
				</tr>
				<tr>
					<td colspan=2>
						<table width=100% align="center">
							<tr>
					<td width=10%  >系统公告:</td>
					<td >
					<marquee behavior=scroll scrollamount=5 loop=0  onmouseover="this.stop()" onMouseOut="this.start();" direction=left  id="sys_bulletin" runat=server></marquee>
					</td>
				</tr>
				<tr>
					<td >本版公告:</td>
					<td >
					<marquee  behavior=scroll scrollamount=10 loop=0  onmouseover="this.stop()" onMouseOut="this.start();" direction=left  id="mar_bulletin" runat=server></marquee>
					</td>
				</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:datagrid id="ItemList" runat="server" AllowPaging="True" PageSize="15" CellPadding="3" Width="100%" AutoGenerateColumns="False" DataKeyField="item_id" BorderColor=#93BEE2 OnPageIndexChanged = "ItemList_PageIndexChanged" >
				<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White" VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
				<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" BackColor="White" Font-Size="X-Small"></ItemStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="状态">
						<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<img id="image" src='<%# GetImagePath(DataBinder.Eval(Container.DataItem,"hit_times").ToString(),(DataBinder.Eval(Container.DataItem,"sysbulletin").ToString()),(DataBinder.Eval(Container.DataItem,"bulletin").ToString()))%>' runat=server/>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="贴子主题">
						<ItemStyle HorizontalAlign=Left></ItemStyle>
						<ItemTemplate>
							<a onClick="javascript:window.open('display.aspx?ItemID=<%# DataBinder.Eval(Container, "DataItem.item_id") %>&BoardID=<%=boardid%>','_blank','')" href="#" >
								<%# DataBinder.Eval(Container, "DataItem.title") %>
							</a>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.title") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="sender" HeaderText="发布人">
						<HeaderStyle Width="10%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="send_time" HeaderText="发布时间">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="last_replayer" HeaderText="最后回复">
						<HeaderStyle Width="10%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="last_replay_time" HeaderText="最后回复时间">
						<HeaderStyle Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="人气">
						<HeaderStyle Width="10%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"replay_times")%>
							<asp:Label Runat="server" ID="bias" Text="/"></asp:Label><%# DataBinder.Eval(Container.DataItem,"hit_times")%>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Font-Size="12px" BorderStyle="Dotted" HorizontalAlign="Right" ForeColor="#337FB2" BackColor="#e8f4ff" Mode="NumericPages" ></PagerStyle>
			</asp:datagrid>
			
			<table width=98% align="center">
				<tr>
				<!--
					<td class="GbText" style="HEIGHT: 31px" width="83%" bgColor="#c0d9e6" height="31">&nbsp;<input class="ButtonCss" id="btn_Go" style="WIDTH: 36px; HEIGHT: 20px" type="button" value="转到" name="btn_Go" runat="server">
						第<asp:textbox id="txb_PageNo" onmouseover="high( this );this.select();" onmouseout="low( this );this.blur();" Width="20" TextMode="SingleLine" CssClass="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #fffffb 1px solid; BORDER-LEFT: #ffffff 1px solid; COLOR: #5e5e5e; BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center" Runat="server"></asp:textbox>
						页,每页显示<asp:textbox onkeypress="if(event.keycode==13) ListView.submit();" id="txb_ItemPerPage" onmouseover="high( this );this.select();" onmouseout="low( this );this.blur();" Width="20" TextMode="SingleLine" CssClass="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #fffffb 1px solid; BORDER-LEFT: #ffffff 1px solid; COLOR: #5e5e5e; BORDER-BOTTOM: #ffffff 1px solid; TEXT-ALIGN: center" Runat="server"></asp:textbox>条记录,共有
						<asp:label id="lbl_totalrecord" runat="server" Width="10px" Height="8px"></asp:label>页记录.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						
					</td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_first" runat="server" Width="23" Height="23" ToolTip="第一页" CommandArgument="first" ImageUrl="../../../Images/top.gif" BorderWidth="0"></asp:imagebutton></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_pre" Width="23" Runat="server" ToolTip="前一页" CommandArgument="pre" ImageUrl="../../../Images/prev.gif" BorderWidth="0"></asp:imagebutton></td>
					<td class="GbText" style="HEIGHT: 31px" align="middle" width="8%" height="31"><asp:label id="lbl_curpage" runat="server">Label</asp:label>/
						<asp:label id="lbl_totalpage" runat="server">Label</asp:label></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_next" Width="23" Runat="server" Height="23" ToolTip="下一页" CommandArgument="next" ImageUrl="../../../Images/next.gif" BorderWidth="0"></asp:imagebutton></td>
					<td style="HEIGHT: 31px" width="3%" height="31"><asp:imagebutton id="btn_last" Width="23" Runat="server" Height="23" ToolTip="最后一页" CommandArgument="last" ImageUrl="../../../Images/end.gif" BorderWidth="0"></asp:imagebutton></td>
				-->
					<td align=center width=""><a runat=server id="backlink">返回</a></td>
				</tr>
				<tr>
					<td align=left width="" class=gbtext>图例说明<img src="../../../images/sysbulletin.gif">系统公告<img src="../../../images/bulletin.gif">本版公告<img src="../../../images/hotfolder.gif">热门贴（点击多于<%=hotitemhittimes%>）<img src="../../../images/folder.gif">普通贴</td>
				</tr>
			</table>
			
			
		</form>
	</body>
</HTML>

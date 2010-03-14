<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.BBS.Search.index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>index</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private string GetImagePath(string hittimes,string sysbulletin,string bulletin)
		{
			
			if(sysbulletin=="True")
			{
				return("../../../../images/sysbulletin.gif");
			}
			else	if(bulletin=="True")
			{
				return("../../../../images/bulletin.gif");
			
			}
			else	if(hittimes!="")
			{
				if(Int32.Parse(hittimes) > hotitemhittimes)
					return("../../../../images/hotfolder.gif");
				else
					return("../../../../images/folder.gif");
			}
			
			else
				return("../../../../images/folder.gif");
		} 
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="1" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<tr height="30">
					<td class="GbText" width="25" background="../../../../Images/treetopbg.jpg" bgColor="#c0d9e6"><font color="#003366" size="3"><IMG height="16" src="../../../../DataImages/page.gif" width="16"></font></td>
					<td bgcolor="#c0d9e6" class="GbText" background="../../../../Images/treetopbg.jpg">公司论坛 
							BBS | <a href='<%="index.aspx?classid="+classid%>'>搜索</a> |</td>
				</tr>
			</table>
			<TABLE id="Table2"  cellSpacing="0"
				cellPadding="0" width="98%" border="0" align="center">
				<TR>
					<TD>
						<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
						  <tr>
						    <td height="10"></td>
					      </tr>
					  </table>
						<TABLE width="100%" border="1" align="center" cellPadding="0" cellSpacing="0" borderColor="#93bff2" class=gbtext id="tbl_Search" style="BORDER-COLLAPSE: collapse" runat="server">
						  <TR>
								<TD colSpan="2" height=30>&nbsp;输入关键字&nbsp;&nbsp;<asp:textbox id="tbx_Key" runat="server" Width="440" CssClass=inputcss></asp:textbox><FONT face="宋体">&nbsp;&nbsp;<asp:button id="btn_OK" runat="server" Text="开始搜索" CssClass=redbuttoncss Width=80px></asp:button></FONT></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="2" height=30>&nbsp;<FONT face="宋体">高级搜索选项</FONT>&nbsp;<FONT face="宋体"><asp:radiobutton id="rbtn_author" runat="server" Text="搜索作者" GroupName="searchoption" Checked="True"></asp:radiobutton></FONT><asp:radiobutton id="Radiobutton1" runat="server" Text="搜索主题" GroupName="searchoption"></asp:radiobutton>
								&nbsp;&nbsp;日期范围
									<asp:textbox id="tbx_Time" runat="server" Width="80px" CssClass=inputcss></asp:textbox><asp:dropdownlist id="ddl_Time" runat="server" Width=80>
										<asp:ListItem Value="0">全部</asp:ListItem>
										<asp:ListItem Value="w">星期</asp:ListItem>
										<asp:ListItem Value="d">日</asp:ListItem>
										<asp:ListItem Value="m">月</asp:ListItem>
										<asp:ListItem Value="y">年</asp:ListItem>
									</asp:dropdownlist>
									&nbsp;&nbsp;论坛选择
										<asp:DropDownList id="dll_Board" runat="server" Width="80px"></asp:DropDownList></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
					<asp:DataGrid id="dgrd_Result" runat="server" Visible="False" Width="100%" AutoGenerateColumns="False"  BorderColor="#93BFF2">
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White" VerticalAlign="Top"
								BackColor="#337FB2"></HeaderStyle>
							<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" BackColor="White"
								Font-Size="X-Small"></ItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="状态">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<img id="image" src='<%# GetImagePath(DataBinder.Eval(Container.DataItem,"hit_times").ToString(),(DataBinder.Eval(Container.DataItem,"sysbulletin").ToString()),(DataBinder.Eval(Container.DataItem,"bulletin").ToString()))%>' runat=server/>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="贴子主题">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<a onClick="javascript:window.open('../display.aspx?ItemID=<%# DataBinder.Eval(Container, "DataItem.item_id") %>&BoardID=<%# DataBinder.Eval(Container, "DataItem.board_id")%>','_blank','')" href="#" >
											<%# DataBinder.Eval(Container, "DataItem.title") %>
										</a>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.title") %>' ID="Textbox1">
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
							<PagerStyle Font-Size="12px" BorderStyle="Dotted" HorizontalAlign="Right" ForeColor="#93bff2"
								BackColor="#e8f4ff" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<a href='<%="../Catalog.aspx?classid="+classid%>'>返回论坛</a>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>


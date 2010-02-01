<%@ Page language="c#" Codebehind="Catalog.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.BBS.Catalog" %>
<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="UDS.Components"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BBS</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private string GetImageAlt(string str)
		{
			if(Int32.Parse(str)>0 )
				return("有贴子"); 
			else
				return("没有贴子");
		}
		private string GetImagePath(string str)
		{
			if(Int32.Parse(str)>0 )
				return("../../../images/forum_isnews.gif");
			else
				return("../../../images/forum_nonews.gif");
		}
		private string GetTitle(string str)
		{
			int limitwordnumber = 50;
			if(str.Length>limitwordnumber)
				return(str.Substring(0,limitwordnumber-1));
			else
				return(str);
		}
		private bool AdminBoard(int board,string username)
		{
			BBSClass bbs = new BBSClass();
			return(bbs.IsBoardMaster(board,username));
		}
		private string GetBoardMasterRealName(int userid)
		{
			string result = "";
			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr = staff.GetStaffInfo(userid);

            try
            {
                while (dr.Read())
                {
                    result = dr["RealName"].ToString();
                }
            }
            finally
            {
                
                if (dr != null)
                {

                    dr.Close();
                }
            }
			return(result);
		}
		</script>
	</HEAD>
	<body topmargin=0 leftmargin=0>
		<form id="Catalog" method="post" runat="server"><p><br>
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td background="../../../Images/bbsback.jpg"><img src="../../../Images/bbs.jpg"></td><td background="../../../Images/bbsback.jpg"><br><font color=white>|</font> <a  style="color: #ffffff;" href='<%="search/index.aspx?classid="+classid%>'>搜索</a> <font color=white>|</font></td>
					</tr>
				</table><br>
				<table class="GbText" id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#93BEE2" height="80" cellSpacing="0" cellPadding="0" width="98%" border="1" align=center>
					<tr>
						<td class="GbText" style="WIDTH: 259px" align="middle" bgcolor="#e8f4ff" colSpan="2" height="24"><b><font color="#337FB2">论坛</font></b></td>
						<td class="GbText" align="middle" bgcolor="#e8f4ff" height="24"><font color="#337FB2"><b>帖子</b></font></td>
						<td class="GbText" style="WIDTH: 64px" align="middle" width="64" bgcolor="#e8f4ff" height="24"><font color="#337FB2"><b>回复</b></font></td>
						<td class="GbText" align="middle" bgcolor="#e8f4ff" height="24"><font color="#337FB2"><b>最新帖子</b></font></td>
						<td class="GbText" align="middle" bgcolor="#e8f4ff" height="24"><font color="#337FB2"><b>版主</b></font></td>
					</tr>
					<tr>
						<td class="GbText" align="left" width="924" colSpan="6" height="22"><A id="A1" runat=server >添加分类</A></td>
					</tr>
					<asp:repeater id="rpt_catalog" Runat="server">
						<ItemTemplate>
							<tr>
								<td align="middle" width="924" bgColor="#e8f4ff" colSpan="6" height="22"><FONT face="宋体">
										<asp:label id="LCatalog" runat="server" Width="100%" text='<%# DataBinder.Eval(Container.DataItem,"catalog_name") %>'>
										</asp:label>
									</FONT>
								</td>
							</tr>
							<tr>
								<td align="left" width="924" bgColor="white" colSpan="6" height="22"><FONT face="宋体">
										<asp:label id="LCatalog_Description" runat="server" Width="100%"  text='<%# DataBinder.Eval(Container.DataItem,"catalog_description") %>'>
										</asp:label>
									</FONT>
								</td>
							</tr>
							<tr>
								<td align="right" width="924" bgColor="#e8f4ff" colSpan="6" height="22"><asp:Panel ID="adminop" Runat=server Visible='<%# Admin%>'><A  href="ManageBoard.aspx?Action=AddBoard&CatalogID=<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>&classID=<%=classid%>">添加板块</A>|<asp:LinkButton ID="btndelcatalog" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>' OnClick="btndelcatalog_Click" Runat=server>删除分类</asp:LinkButton>|<A  href="ManageCatalog.aspx?Action=ModifyCatalog&CatalogID=<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>&classID=<%=classid%>">
											编辑分类</A>|</asp:Panel></td>
							</tr>
							<asp:Repeater ID="rpt_board" OnItemDataBound="rpt_board_ItemDataBound" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("catolog_board") %>' Runat="server">
								<ItemTemplate>
									<tr>
										<td align="middle" width="60">&nbsp; <img  runat="server" alt='<%# GetImageAlt(DataBinder.Eval(Container.DataItem,"[\"formitems\"]").ToString())%>' src='<%# GetImagePath(DataBinder.Eval(Container.DataItem,"[\"formitems\"]").ToString())%>' />
										<td width="182" height="45" style="WIDTH: 182px"><FONT face="宋体"><P><a href="ListView.aspx?BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&ClassID=<%# Request["ClassID"]%>"><%# DataBinder.Eval(Container.DataItem,"[\"board_name\"]")%></a></P>
												<P>
													<asp:Label id="LBoardDescription" runat="server">
														<%# DataBinder.Eval(Container.DataItem,"[\"board_description\"]")%>
													</asp:Label></P>
											</FONT>
										</td>
										<td align="middle" width="55" height="45"><FONT face="宋体">
												<asp:label id="LForumTimes" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"[\"formitems\"]")%>
												</asp:label></FONT></td>
										<td align="middle" width="50" height="45">
											<asp:label id="LReplays" runat="server">
												<%# DataBinder.Eval(Container.DataItem,"[\"replays\"]")%>
											</asp:label></td>
										<td vAlign="top" align="right" width="304" height="45"><FONT face="宋体"> <a href='<%# "Display.aspx?ItemID="+DataBinder.Eval(Container.DataItem,"[\"item_id\"]").ToString()%>' target=_blank>
													<asp:label id="LForumItem" runat="server">
														<%# GetTitle(DataBinder.Eval(Container.DataItem,"[\"title\"]").ToString())%>
													</asp:label></a>
												<br>
												<asp:Label id="LSender" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"[\"sender\"]")%>
												</asp:Label>
												<br>
												<asp:Label id="LSendTime" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"[\"send_time\"]")%>
												</asp:Label>
											</FONT>
										</td>
										<td align="middle" width="103" height="45">
											<asp:Repeater id="rpt_boardmaster" DataSource='<%# ((DataRow)Container.DataItem).GetChildRows("board_boardmaster")%>' Runat="server">
												<ItemTemplate>
													<a href="../Mail/Compose.aspx?Action=3&ClassID=0&Username=<%# DataBinder.Eval(Container.DataItem,"[\"staff_Name\"]")%>&Name=<%# GetBoardMasterRealName(Int32.Parse(DataBinder.Eval(Container.DataItem,"[\"staff_id\"]").ToString()))%>"><%# DataBinder.Eval(Container.DataItem,"[\"RealName\"]")%></a><br>
												</ItemTemplate>
											</asp:Repeater>
										</td>
									</tr>
									<tr>
										<td width="924" colSpan="6" height="22"><asp:Panel ID="Adminop1" Runat=server Visible='<%# AdminBoard(Int32.Parse(DataBinder.Eval(Container.DataItem,"[\"board_id\"]").ToString()),Username) || Admin %>'><A href="ManageBoardMaster.aspx?BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&classID=<%=classid%>" >设定斑竹</A>|<asp:LinkButton ID="lbtnDelBoard" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>' OnClick="DeleteBoard"  Runat=server>删除板块</asp:LinkButton>|<A href="ManageBoard.aspx?Action=ModifyBoard&BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&classID=<%=classid%>">
													编辑板块</A>|<asp:HyperLink id="SetBoardMember" NavigateUrl='<%# "ManageBoardMember.aspx?BoardID="+DataBinder.Eval(Container.DataItem,"[\"board_id\"]")+"&classid="+classid%>' Visible='<%# !Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"[\"board_type\"]"))%>' runat=server>编辑成员</asp:HyperLink></asp:Panel></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
						</ItemTemplate>
					</asp:repeater></table>
				<table id="AutoNumber2" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="17" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td align="middle" width="100%" height="30">　</td>
					</tr>
				</table>
		</form>
	</body>
</HTML>

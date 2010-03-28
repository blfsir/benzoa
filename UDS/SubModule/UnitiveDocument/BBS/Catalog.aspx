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
		<form id="Catalog" method="post" runat="server">
		<table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td width="23" height="30" align="right" background="../../../Images/treetopbg.jpg"
                                bgcolor="#c0d9e6" class="GbText" style="width: 23px">
                                <font color="#003366" size="3">
                                    <img height="16" src="../../../DataImages/page.gif" width="16"></font>
                            </td>
                            
                          <td width="60" height="30" align="left" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                <font color="#006699">&nbsp;<asp:Label ID="lblTitle" runat="server" ForeColor="#006699" 
                                        Width="53px">公司论坛</asp:Label></font>
            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff"><A id="A1" runat="server" width="80px" class="redButtonCss">&nbsp;&nbsp; 添加分类 &nbsp;&nbsp;</A></td>
                        </tr>
                    </table>
                    
		<%--  <table width="100%" border="0" cellpadding="0" cellspacing="0">
	  <tr>
						<td background="../../../Images/bbsback.jpg"><img src="../../../Images/bbs.jpg"></td><td background="../../../Images/bbsback.jpg"><br><font color=white>|</font> <a  style="color: #ffffff;" href='<%="search/index.aspx?classid="+classid%>'>搜索</a> <font color=white>|</font></td>
					</tr>
				</table>--%>
				<br>
				<table class="GbText" id="AutoNumber1" style="BORDER-COLLAPSE: collapse; line-height:20px;" borderColor="#93BEE2" height="80" cellSpacing="0" cellPadding="5" width="98%" border="1" align=center>
				<%--	<tr>
						<td class="GbText" align="center" bgcolor="#337fb2" colSpan="2" height="24"><b><font color="#ffffff">论坛</font></b></td>
					  <td class="GbText" align="center" bgcolor="#337fb2" height="24"><font color="#ffffff"><b>帖子</b></font></td>
						<td class="GbText" align="center" bgcolor="#337fb2" height="24"><font color="#ffffff"><b>回复</b></font></td>
						<td class="GbText" align="center" bgcolor="#337fb2" height="24"><font color="#ffffff"><b>最新帖子</b></font></td>
						<td class="GbText" align="center" bgcolor="#337fb2" height="24"><font color="#ffffff"><b>版主</b></font></td>
						<td class="GbText" align="center" bgcolor="#337fb2" height="24"><font color="#ffffff"><b>设置</b></font></td>
					</tr>--%>
					 
					<asp:repeater id="rpt_catalog" Runat="server">
						<ItemTemplate>
							<tr>
								<td bgColor="#93BEE2" colSpan="7" height="22"><FONT face="宋体" color=#000000">
										<strong>
										<asp:label id="LCatalog" runat="server" Width="100%" text='<%# DataBinder.Eval(Container.DataItem,"catalog_name") %>'>
									    </asp:label>
										</strong>									<asp:Panel ID="adminop" Runat=server Visible='<%# Admin%>'><A  href="ManageBoard.aspx?Action=AddBoard&CatalogID=<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>&classID=<%=classid%>">添加板块</A>|<asp:LinkButton ID="btndelcatalog" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>' OnClick="btndelcatalog_Click" Runat=server>删除分类</asp:LinkButton>|<A  href="ManageCatalog.aspx?Action=ModifyCatalog&CatalogID=<%# DataBinder.Eval(Container.DataItem,"catalog_id")%>&classID=<%=classid%>">
							  编辑分类</A>|</asp:Panel></FONT>
								</td>
							</tr>
						<%--	<tr>
								<td align="left" bgColor="white" colSpan="6" height="22"><FONT face="宋体"><asp:label id="LCatalog_Description" runat="server" Width="100%"  text='<%# DataBinder.Eval(Container.DataItem,"catalog_description") %>'>
										</asp:label>
									</FONT>
								</td>
							</tr>--%>
							 
							<asp:Repeater ID="rpt_board" OnItemDataBound="rpt_board_ItemDataBound" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("catolog_board") %>' Runat="server">
								<ItemTemplate>
								
								<tr>
						<td class="GbText" align="center" bgcolor="#e8f4ff" colSpan="2" height="24"><b><font color="#93bee2">版块</font></b></td>
					  <td class="GbText" align="center" bgcolor="#e8f4ff" height="24"><font color="#93bee2"><b>帖子</b></font></td>
						<td class="GbText" align="center" bgcolor="#e8f4ff" height="24"><font color="#93bee2"><b>回复</b></font></td>
						<td class="GbText" align="center" bgcolor="#e8f4ff" height="24"><font color="#93bee2"><b>最新帖子</b></font></td>
						<td class="GbText" align="center" bgcolor="#e8f4ff" height="24"><font color="#93bee2"><b>版主</b></font></td>
						<td class="GbText" align="center" bgcolor="#e8f4ff" height="24"><font color="#93bee2"><b>设置</b></font></td>
					</tr>
								
								
								
								
									<tr>
										<td width="60" align="center">&nbsp; <img  runat="server" alt='<%# GetImageAlt(DataBinder.Eval(Container.DataItem,"[\"formitems\"]").ToString())%>' src='<%# GetImagePath(DataBinder.Eval(Container.DataItem,"[\"formitems\"]").ToString())%>' />
<td height="0" valign="top"><FONT face="宋体"><a href="ListView.aspx?BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&ClassID=<%# Request["ClassID"]%>"><%# DataBinder.Eval(Container.DataItem,"[\"board_name\"]")%></a>
												<br>
													<asp:Label id="LBoardDescription" runat="server">
														<%# DataBinder.Eval(Container.DataItem,"[\"board_description\"]")%>
													</asp:Label>
											</FONT>
									  </td>
										<td width="50" height="0" align="center"><FONT face="宋体">
										  <asp:label id="LForumTimes" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"[\"formitems\"]")%>
									    </asp:label></FONT></td>
										<td width="50" height="0" align="center">
							  <asp:label id="LReplays" runat="server">
												<%# DataBinder.Eval(Container.DataItem,"[\"replays\"]")%>
										  </asp:label></td>
										<td vAlign="top" width="300" height="0"><FONT face="宋体"> <a href='<%# "Display.aspx?ItemID="+DataBinder.Eval(Container.DataItem,"[\"item_id\"]").ToString()%>' target=_blank>
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
										<td width="110" height="0" valign="top">
									  <asp:Repeater id="rpt_boardmaster" DataSource='<%# ((DataRow)Container.DataItem).GetChildRows("board_boardmaster")%>' Runat="server">
												<ItemTemplate><a href="../Mail/Compose.aspx?Action=3&ClassID=0&Username=<%# DataBinder.Eval(Container.DataItem,"[\"staff_Name\"]")%>&Name=<%# GetBoardMasterRealName(Int32.Parse(DataBinder.Eval(Container.DataItem,"[\"staff_id\"]").ToString()))%>"><%# DataBinder.Eval(Container.DataItem,"[\"RealName\"]")%></a> / 
												</ItemTemplate>
										  </asp:Repeater>
										</td>
										<td height="22"  align="center" ><asp:Panel ID="Adminop1" Runat=server Visible='<%# AdminBoard(Int32.Parse(DataBinder.Eval(Container.DataItem,"[\"board_id\"]").ToString()),Username) || Admin %>'><A href="ManageBoardMaster.aspx?BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&classID=<%=classid%>" >设定斑竹</A>|<asp:LinkButton ID="lbtnDelBoard" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>' OnClick="DeleteBoard"  Runat=server>删除板块</asp:LinkButton>|<A href="ManageBoard.aspx?Action=ModifyBoard&BoardID=<%# DataBinder.Eval(Container.DataItem,"[\"board_id\"]")%>&classID=<%=classid%>">
									  编辑板块</A>|<asp:HyperLink id="SetBoardMember" NavigateUrl='<%# "ManageBoardMember.aspx?BoardID="+DataBinder.Eval(Container.DataItem,"[\"board_id\"]")+"&classid="+classid%>' Visible='<%# !Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"[\"board_type\"]"))%>' runat=server>编辑成员</asp:HyperLink></asp:Panel></td>
									</tr>
									 
								</ItemTemplate>
							</asp:Repeater>
						</ItemTemplate>
					</asp:repeater></table>
				<table id="AutoNumber2" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="17" cellSpacing="0" cellPadding="0" width="100%" border="0">
<tr>
						<td align="center" width="100%" height="30">　</td>
					</tr>
				</table>
		</form>
	</body>
</HTML>

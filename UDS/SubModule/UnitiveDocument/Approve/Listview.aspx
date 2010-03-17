<%@ Page language="c#" Codebehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Approve.Listview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listview</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		
		function selectAll(){
			var len=document.Approve.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.Approve.elements[i].type=="checkbox"){
		        document.Approve.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.Approve.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Approve.elements[i].type=="checkbox"){
	                  document.Approve.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
		<LINK href="../../../Css/basiclayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form id="Approve" method="post" runat="server">
			<TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
			  <TR>
			    <TD width="20" height="30"
									align="right" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myDoc2.gif" width="16"></FONT></TD>
			    <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="center">我的文档</TD>
			    <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体">
			      <asp:Panel id="PanFunction" runat="server" Height="3px">
			        <INPUT class="redButtonCss" onClick="selectAll()" type="button" value="全部选择"> <INPUT class="redButtonCss" onClick="unSelectAll()" type="button" value="全部取消"> <asp:Button id="btnApproveDocument" runat="server" Text="批阅文档" CssClass="redButtonCss"></asp:Button> <asp:Button id="btnThowAwayDocument" runat="server" Text="丢弃文档" CssClass="redButtonCss"></asp:Button>&nbsp;</asp:Panel>
			      </FONT></TD>
		      </TR>
		  </TABLE>
			<TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" id="Table1">
				<tr>
					<td vAlign="top" height="10"></td>
				</tr>
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background="../../../images/maillistbutton1.gif" height="24">&nbsp;<a href="../NewDoc/Listview.aspx" class="Newbutton">已归档</a>
								</TD>
								<TD align="center" width="90" background="../../../images/maillistbutton2.gif" height="24"
									class="Newbutton">&nbsp;待审批</TD>
								<TD align="right"><FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="dgMyApprove" Width="100%" runat="server" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False" PageSize="15" AllowCustomPaging="True" OnPageIndexChanged="DataGrid_PageChanged"
							DataKeyField="DocID" HorizontalAlign="Left" BorderColor="#93BEE2" BorderWidth="1px" CellPadding="3"
							OnSortCommand="DataGrid_SortCommand">
							<AlternatingItemStyle Font-Size="Smaller" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="Smaller" HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="White" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="◎">
									<HeaderStyle Width="5%"></HeaderStyle>
									<HeaderTemplate>
										◎
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="DocID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="DocID" DataNavigateUrlFormatString="../Document/BrowseDocument.aspx?DocID={0}"
									DataTextField="DocTitle" SortExpression="DocTitle" HeaderText="文档标题">
									<HeaderStyle HorizontalAlign="Left" Width="35%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="DocViewedTimes" SortExpression="DocViewedTimes" HeaderText="浏览次数">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="DocAddedBy" HeaderText="上传人">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetRealNameStr(DataBinder.Eval(Container, "DataItem.DocAddedBy").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ClassName" SortExpression="ClassName" HeaderText="所属项目">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DocAddedDate" SortExpression="DocAddedDate" HeaderText="上传时间">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" Font-Size="Smaller" PrevPageText="上一页" HorizontalAlign="Right"
								ForeColor="White" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

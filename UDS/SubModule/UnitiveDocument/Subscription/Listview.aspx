<%@ Page language="c#" Codebehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Subscription.Subscription" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listview</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		
		function selectAll(){
			var len=document.Subscription.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.Subscription.elements[i].type=="checkbox"){
		        document.Subscription.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.Subscription.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Subscription.elements[i].type=="checkbox"){
	                  document.Subscription.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Subscription" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="38"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
									align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/help_page.gif" width="16"></FONT></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right"><font color="#006699"><FONT color="#006699">我的项目</FONT></font></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体"><input type="button" onclick="selectAll()" value="全部选择" class="redButtonCss">
										&nbsp; <input type="button" onclick="unSelectAll()" value="全部取消" class="redButtonCss">&nbsp;
										<asp:Button id="btnDeleteSubscription" runat="server" Text="删除订阅" CssClass="redButtonCss"></asp:Button></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background="../../../images/maillistbutton1.gif" height="24"
									style="WIDTH: 90px" valign="middle"><a href="../Task/Listview.aspx" class="Newbutton">我的参与</a></TD>
								<TD align="center" width="90" background="../../../images/maillistbutton2.gif" height="24"
									style="WIDTH: 90px" valign="middle"><a href="../Subscription/Listview.aspx" class="Newbutton">我的关注</a></TD>
								<TD align="right"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="dgMySubsciption" runat="server" BorderWidth="1px" HorizontalAlign="Justify"
							Font-Size="X-Small" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
							PageSize="15" OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2" CellPadding="3"
							DataKeyField="ClassID">
							<SelectedItemStyle Font-Size="X-Small"></SelectedItemStyle>
							<EditItemStyle Font-Size="X-Small"></EditItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Height="20px" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="24px" ForeColor="White" VerticalAlign="Middle"
								BackColor="#337FB2"></HeaderStyle>
							<FooterStyle Font-Size="X-Small"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<HeaderTemplate>
										<FONT face="宋体">◎</FONT>
									</HeaderTemplate>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:CheckBox id="ClassID" Runat="server"></asp:CheckBox></FONT>
									</ItemTemplate>
									<EditItemTemplate>
										<FONT face="宋体"></FONT>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="项目名称" Target="_self" DataNavigateUrlField="ClassID" DataNavigateUrlFormatString="../Project.aspx?Subscription=1&amp;ClassID={0}"
									DataTextField="ClassName" HeaderText="项目名称">
									<HeaderStyle HorizontalAlign="Left" Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="FILECOUNT" HeaderText="已归档">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Status" HeaderText="状态">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Scale" HeaderText="所占比例">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StartDate" HeaderText="起始日期">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="EndDate" HeaderText="截止日期">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" Font-Size="X-Small" PrevPageText="上一页" HorizontalAlign="Right"
								ForeColor="White" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<br>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="Index.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Mail.MailList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Index</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../../images/maillistbutton2.gif';
		nonactive.src = '../../../images/maillistbutton1.gif';

		function onMouseOver(img)
		{
			document.images[img].src = ball2.src;
		}

		function onMouseOut(img)
		{
			document.images[img].src = ball1.src;
		}

		function onOverBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+active.src+")";
				
			}
		}

		function onOutBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+nonactive.src+")";
			}
		}
		
		function selectAll(){
			var len=document.MailList.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.MailList.elements[i].type=="checkbox"){
		        document.MailList.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.MailList.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.MailList.elements[i].type=="checkbox"){
	                  document.MailList.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="MailList" method="post" runat="server">
        <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20" height="30"
									align="right" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../Images/icon/284.GIF" width="16"></FONT></TD>
							  <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right">我的邮件</TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体">
										<asp:label id="lblMsg" runat="server" Width="88px" Font-Size="X-Small"></asp:label>&nbsp;
										<asp:button id="btnClear" runat="server" Visible="False" Text="清 空" CssClass="redButtonCss"></asp:button>
										&nbsp;
										<asp:button id="btnDelete" runat="server" Text="删 除" CssClass="redButtonCss"></asp:button>&nbsp;
										<INPUT class="redButtonCss" onClick="selectAll()" type="button" value="全 选">&nbsp;
										<INPUT class="redButtonCss" onClick="unSelectAll()" type="button" value="取 消">&nbsp;
										<asp:dropdownlist id="listFolderType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FolderListChange"></asp:dropdownlist></FONT></TD>
							</TR>
						</TABLE>
			<table width="98%" align="center" cellPadding="0" cellSpacing="0">
				<tr>
					<td vAlign="top" height="10">
					</td>
				</tr>
				<tr>
					<td vAlign="bottom" height="25">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="25">
								<td style="HEIGHT: 25px" width="1"></td>
								<td   id=bar1 align=center width=90 
          background='<% Response.Write(Session["FolderType"].ToString()=="1"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<A href="Index.aspx?FolderType=1" class="Newbutton">收件箱</A></td>
								<td   id=bar2 align=center width=90 
          background='<% Response.Write(Session["FolderType"].ToString()=="2"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>' 
          class=Newbutton>&nbsp;<A href="Index.aspx?FolderType=2" class="Newbutton">发件箱</A></td>
								<td   id=bar3 align=center width=90 
          background='<% Response.Write(Session["FolderType"].ToString()=="3"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<A href="Index.aspx?FolderType=3" class="Newbutton">废件箱</A></td>
								<td id="bar4" align="center" width="90" background="../../../images/maillistbutton1.gif">&nbsp;<A href="Compose.aspx?ClassID=0" class="Newbutton">撰写新邮件</A></td>
							<%--	 <td   id=bar5 align=center width=90 
          background='<% Response.Write(Session["FolderType"].ToString()=="4"?"../../../images/maillistbutton2.gif":"../../../images/maillistbutton1.gif"); %>' 
          >&nbsp;<A href="Index.aspx?FolderType=4" class="Newbutton">外部邮件</A></td>--%>
								<td style="HEIGHT: 25px" align="right"><FONT face="宋体">
										<asp:DropDownList id="listExtMail" runat="server" Visible="False"></asp:DropDownList>
										<asp:Button id="btnBeginReceive" runat="server" CssClass="redButtonCss" Text="开始接收" Visible="False"></asp:Button>
										&nbsp;
										<asp:Button id="btnExtPopSetup" runat="server" CssClass="redButtonCss" Text="外部邮箱设置" Visible="False"></asp:Button></FONT></td> 
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top">
						<asp:datagrid id="dgMailList" runat="server" Width="100%" OnItemDataBound="DataGrid_ItemDataBinding"
							OnSortCommand="DataGrid_Sort" AllowSorting="True" CellPadding="3" BackColor="White" BorderWidth="1px"
							BorderStyle="None" BorderColor="#93BEE2" AutoGenerateColumns="False" AllowPaging="True" PagerStyle-Mode="NumericPages"
							PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="DataGrid_PageChanged" DataKeyField="MailID"
							PageSize="15">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle"
								BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="10px" ForeColor="White" VerticalAlign="Top"
								BackColor="#337FB2"></HeaderStyle>
							<FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" ForeColor="Black" VerticalAlign="Bottom"
								BackColor="#93BEE2"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="选择">
									<HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="grpMailID" Checked="False" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="邮件主题">
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<a href='ReadMail.aspx?MailId=<%# DataBinder.Eval(Container.DataItem,"MailID") %>&CurrentPageIndex=<%=CurrentPageIndex%>&FolderType=<%=Session["FolderType"].ToString()%>'>
											<%# (DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Length>20)?DataBinder.Eval(Container.DataItem,"MailSubject").ToString().Substring(0,20)+"...":DataBinder.Eval(Container.DataItem,"MailSubject").ToString() %>
										</a>
										<%# DataBinder.Eval(Container.DataItem,"attnumber").ToString()=="0"?"":"<img src='../../../DataImages/attach.gif' border='0'>" %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="MailSender" SortExpression="MailSender" HeaderText="发送者">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemStyle Font-Size="X-Small"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="接收者">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetRealNameStr(DataBinder.Eval(Container, "DataItem.MailReceiver").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="所有接收者">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# GetRealNameStr(DataBinder.Eval(Container, "DataItem.MailReceiverStr").ToString()) %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="是否已读">
									<HeaderStyle Width="80px"></HeaderStyle>
									<ItemStyle Font-Size="X-Small"></ItemStyle>
									<ItemTemplate>
										<%# (string)DataBinder.Eval(Container.DataItem,"MailReadFlag")=="False"?"<img src='../../../Images/mailclose.gif'>":"<img src='../../../Images/mailopen.gif'>" %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ClassName" SortExpression="ClassName" HeaderText="所属项目">
									<ItemStyle Font-Size="X-Small"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="attsize" HeaderText="大小(Kb)">
									<ItemStyle Font-Size="X-Small"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# (DataBinder.Eval(Container, "DataItem.attsize")).ToString()!=""&&(DataBinder.Eval(Container, "DataItem.attsize")).ToString()!="0"?(DataBinder.Eval(Container, "DataItem.attsize")).ToString()+"":"1" %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="MailSendDate" HeaderText="日期">
									<ItemStyle Font-Size="X-Small"></ItemStyle>
									<ItemTemplate>
										<ItemStyle Font-Size="X-Small"></ItemStyle>
										<asp:Label runat="server" Text='<%# DateTime.Parse(DataBinder.Eval(Container, "DataItem.MailSendDate").ToString()).ToString("yyyy-MM-dd") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
								BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<TD vAlign="top">&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>

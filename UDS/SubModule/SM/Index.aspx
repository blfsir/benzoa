<%@ Page language="c#" Codebehind="Index.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.SM.Index" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>消息主页</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function selectAll(){
			var len=document.Index.elements.length;
			var i;
		    for (i=0;i<len;i++){
		    
			if (document.Index.elements[i].type=="checkbox"){
		        document.Index.elements[i].checked=true;								
						 }
					}
					
				}

		function unSelectAll(){
	          var len=document.Index.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Index.elements[i].type=="checkbox"){
	                  document.Index.elements[i].checked=false; 
	               }   
	              
	        	 } 
	        	 }
	     	function SendMsg(username,realname)
		{
			window.opener.parent.parent.MainFrame.location='../SM/MsgSend.aspx?SendTo='+username+'&SendToRealName='+realname;
			window.close();
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0">
		<form id="Index" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
				width="100%" height="1">
				<tr>
					<td width="20" height="30" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText"><font color="#003366" size="3"><img src="../../DataImages/message2.gif" width="16" height="16"></font></td>
					<td width="60" align="center" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText"><font color="#006699">短讯管理</font></td>
					<td background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">&nbsp;</td>
				</tr>
			</table>
			<FONT face="宋体">		    </FONT>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<FONT face="宋体">
			  <table width="98%" border="0" align="center" cellPadding="0" cellSpacing="0">
					<tr height="20" >
					
						<td     align="center" width="90"    background="<% Response.Write(Session["MsgDispType"].ToString()=="1"?"../../images/maillistbutton2.gif":"../../images/maillistbutton1.gif"); %>">&nbsp;<A href="Index.aspx?DispType=1" class="Newbutton">我的消息</A></td>
						<td     align=center width=90     background='<% Response.Write(Session["MsgDispType"].ToString()=="2"?"../../images/maillistbutton2.gif":"../../images/maillistbutton1.gif"); %>' 
    >&nbsp;<A href="Index.aspx?DispType=2" class="Newbutton">已发送消息</A></td>
						<td	align="center" width="90" background="../../images/maillistbutton1.gif">&nbsp;<A href="MsgSend.aspx" class="Newbutton">写新消息</A></td>
						<td style="HEIGHT: 25px" align="right"><FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT></td>
					</tr>
				</table>
				<table width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" class="GbText">
					<tr>
						<td vAlign="top" colSpan="3"><asp:datagrid id="dgMsgList" runat="server" PageSize="15" DataKeyField="ID" OnPageIndexChanged="DataGrid_PageChanged"
								PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" AllowSorting="True" Width="100%">
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
											<asp:CheckBox id="grpMsgID" Checked="False" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="发送者">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<a href='../SM/MsgSend.aspx?SendTo=<%# DataBinder.Eval(Container, "DataItem.Sender") %>&SendToRealName=<%# DataBinder.Eval(Container,"DataItem.SenderRealName") %>&Type=<%# DataBinder.Eval(Container,"DataItem.type") %>'>
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SenderRealName") %>'>
												</asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接收者">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<a href='../SM/MsgSend.aspx?SendTo=<%# DataBinder.Eval(Container, "DataItem.Receiver") %>&SendToRealName=<%# DataBinder.Eval(Container, "DataItem.ReceiverRealName") %>&Type=<%# DataBinder.Eval(Container,"DataItem.type") %>'>
												<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ReceiverRealName") %>'>
												</asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Content" HeaderText="内容">
										<HeaderStyle Width="40%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="短讯类型">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.typeDetail") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="是否已读">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<%# (string)DataBinder.Eval(Container.DataItem,"IsRead")=="False"?"<img src='../../Images/mailclose.gif'>":"<img src='../../Images/mailopen.gif'>" %>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Sendtime" HeaderText="发送时间">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><BR>
							<INPUT class="redButtonCss" onClick="selectAll()" type="button" value="全 选">&nbsp;
							<INPUT class="redButtonCss" onClick="unSelectAll()" type="button" value="取 消">&nbsp;
							<asp:button id="btnRead" runat="server" CssClass="redButtonCss" Text="已阅"></asp:button>&nbsp;
							<asp:button id="btnDelete" runat="server" CssClass="redButtonCss" Text="删除" Visible="False"></asp:button></td>
					</tr>
				</table>
			</FONT>
		</form>
	</body>
</HTML>

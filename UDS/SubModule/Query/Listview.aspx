<%@ Page language="c#" Codebehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Query.Listview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listview</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="1" topMargin="1" rightMargin="1" MS_POSITIONING="GridLayout">
		<form id="Listview" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td>
							<TABLE class="gbtext" id="tabDoc" cellSpacing="0" cellPadding="0" width="90" border="0"
								runat="server">
								<TR>
									<TD background ="../../images/maillistbutton2.gif" align="center"
										height="24" class="gbtext" >文 档</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:datagrid id="dgDocList" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
								AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" OnPageIndexChanged="DataGrid_PageChanged"
								DataKeyField="DocID" PageSize="15" BorderWidth="1px" CellPadding="3" BorderColor="#93BEE2"
								BorderStyle="None" BackColor="White">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle ForeColor="#003399" VerticalAlign="Middle" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="10px" ForeColor="White"
									VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" ForeColor="#003399"
									VerticalAlign="Bottom" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="选择">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="Checkbox1" Checked="False" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="文档主题">
										<HeaderStyle Width="35%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small"></ItemStyle>
										<ItemTemplate>
											<a href='../UnitiveDocument/Document/BrowseDocument.aspx?DocId=<%# DataBinder.Eval(Container.DataItem,"DocID") %>'>
												<%# DataBinder.Eval(Container.DataItem,"DocTitle") %>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="DocViewedTimes" HeaderText="浏览次数">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<FooterStyle Font-Size="XX-Small"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocApprover" HeaderText="审批人">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocAddedBy" HeaderText="上传人">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<FooterStyle Font-Size="X-Small"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DocLastViewer" HeaderText="最后浏览者">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="上传日期">
										<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# DateTime.Parse(DataBinder.Eval(Container, "DataItem.DocAddedDate").ToString()).ToString("yyyy-MM-dd") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
									BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;
							<TABLE class="gbtext" id="tabMail" cellSpacing="0" cellPadding="0" width="90" border="0"
								runat="server">
								<TR>
									<TD class="gbtext"  background="../../images/maillistbutton2.gif"
										align="center" height="24" >邮 件</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:datagrid id="dgMailList" runat="server" DataKeyField="MailID" PagerStyle-HorizontalAlign="Right"
								PagerStyle-Mode="NumericPages" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
								Width="100%" BackColor="White" BorderStyle="None" BorderColor="#93BEE2" CellPadding="3" BorderWidth="1px"
								PageSize="15">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center" ForeColor="#003399" VerticalAlign="Middle" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" Height="10px" ForeColor="White"
									VerticalAlign="Top" BackColor="#337FB2"></HeaderStyle>
								<FooterStyle Font-Size="XX-Small" HorizontalAlign="Center" Height="10px" ForeColor="#003399"
									VerticalAlign="Bottom" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="选择">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" Height="20px" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="grpMailID" Checked="False" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="邮件主题">
										<HeaderStyle HorizontalAlign="Left" Width="45%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<A href='../UnitiveDocument/Mail/ReadMail.aspx?MailId=<%# DataBinder.Eval(Container.DataItem,"MailID") %>'>
												<%# DataBinder.Eval(Container.DataItem,"MailSubject") %>
											</A>
											<%# DataBinder.Eval(Container.DataItem,"attnumber").ToString()=="0"?"":"<img src='../../DataImages/attach.gif' border='0'>" %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="发送者">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%#GetUserRealName(DataBinder.Eval(Container, "DataItem.MailSender").ToString()) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%#GetUserRealName(DataBinder.Eval(Container, "DataItem.MailSender").ToString()) %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="接收者">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%#GetUserRealName(DataBinder.Eval(Container, "DataItem.MailReceiverStr").ToString()) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%#GetUserRealName(DataBinder.Eval(Container, "DataItem.MailReceiverStr").ToString()) %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="是否已读">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<%# (string)DataBinder.Eval(Container.DataItem,"MailReadFlag")=="False"?"<img src='../../Images/mailclose.gif'>":"<img src='../../Images/mailopen.gif'>" %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="MailSendDate" SortExpression="MailSendDate" HeaderText="日期">
										<HeaderStyle Font-Underline="True" HorizontalAlign="Center" Width="20%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
										<FooterStyle Font-Size="XX-Small"></FooterStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="12px" BorderColor="#E0E0E0" BorderStyle="Dotted" HorizontalAlign="Right"
									BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

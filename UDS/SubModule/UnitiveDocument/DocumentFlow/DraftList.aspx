<%@ Page language="c#" Codebehind="DraftList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.DraftList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DraftList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<P><FONT face="宋体">
				<FORM id="WebForm1" method="post" runat="server">
					<FONT face="宋体">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" height="38">
									<TABLE id="Table3" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR height="30">
											<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
												bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
											<TD class="GbText" align="right" width="60" background="../../../Images/treetopbg.jpg"
												bgColor="#e8f4ff"><FONT color="#006699">文档流转</FONT></TD>
											<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="宋体"><asp:button id="cmdQuery" runat="server" Width="50px" Text="查询" CssClass="buttoncss"></asp:button><asp:button id="cmdNewDocument" runat="server" Width="54px" Text="撰稿" CssClass="buttoncss"></asp:button>&nbsp;&nbsp;&nbsp;</FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE class="gbtext" id="Table2" height="24" cellSpacing="0" cellPadding="0" width="100%"
										border="0">
										<TR>
											<TD align="center" width="90" background="../../../Images/maillistbutton1.gif"><asp:linkbutton id="lbMyRead" runat="server" CssClass="Newbutton">我的批阅</asp:linkbutton></TD>
											<TD align="center" width="90" background="../../../Images/maillistbutton1.gif"><asp:linkbutton id="lbMyRequisition" runat="server" CssClass="Newbutton">我的申请</asp:linkbutton></TD>
											<TD align="center" width="90" background="../../../Images/maillistbutton1.gif"><asp:linkbutton id="lbMyApproved" runat="server" CssClass="Newbutton">已经批阅</asp:linkbutton></TD>
											<TD align="center" width="90" background="../../../Images/maillistbutton2.gif"><asp:linkbutton id="lbDraftList" runat="server" CssClass="Newbutton">拟稿箱</asp:linkbutton></TD>
											<%if(bManageFlow==true){%>
											<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">&nbsp;
												<asp:linkbutton id="lbFlowManage" runat="server" CssClass="Newbutton">流程管理</asp:linkbutton></TD>
											<%}%>
											<%else {%>
											<TD align="center" width="90">&nbsp;
											</TD>
											<%}%>
											<TD align="center">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><asp:datagrid id="dgDraftList" runat="server" Width="100%" Font-Size="X-Small" PageSize="15" CellPadding="3"
										BorderWidth="1px" BorderStyle="None" BorderColor="#93BEE2" BackColor="White" OnPageIndexChanged="DataGrid_PageChanged"
										AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="ID">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="Flow_ID" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="文档标题">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' NavigateUrl='<%# GetDisplayDocumentUrl(DataBinder.Eval(Container, "DataItem.Doc_ID").ToString())%>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="DocBuilder" HeaderText="拟稿人">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:HyperLinkColumn DataNavigateUrlField="FLOW_ID" DataNavigateUrlFormatString="DisplayFlow.aspx?FlowID={0}"
												DataTextField="FlowName" HeaderText="流程说明">
												<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
												<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
											</asp:HyperLinkColumn>
											
									<asp:TemplateColumn HeaderText="流程图例">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center">										
										</ItemStyle> 
										<ItemTemplate>
										<a   href="###"   onclick="window.open('/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>',   '',   'scrollbars=no,resizable=yes,toolbar=no')">图例</a>
										<%--<a href ="/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>" target="_blank">图例</a>--%>
										</ItemTemplate>
									</asp:TemplateColumn>
									
											<asp:TemplateColumn HeaderText="当前步骤">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemTemplate>
													<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StepName") %>' NavigateUrl='<%#GetDisplayStepMemberUrl(DataBinder.Eval(Container, "DataItem.Doc_ID").ToString()) %>'>
													</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Short_Doc_Added_Date" HeaderText="拟稿时间">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Status" HeaderText="状态">
												<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="8%"></HeaderStyle>
												<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="" Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399"
											BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</FONT>
				</FORM>
			</FONT>
		</P>
	</body>
</HTML>

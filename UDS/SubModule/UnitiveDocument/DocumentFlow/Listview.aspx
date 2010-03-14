<%@ Page language="c#" Codebehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Flow.Listview" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listview</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function delete_confirm(e) {
				if (event.srcElement.outerText == "删除")
				event.returnValue =confirm("您确认要删除?");
			}
			document.onclick=delete_confirm;		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Listview" method="post" runat="server">
			<FONT face="宋体">
            <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="20" height="30"
										align="right" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
								  <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
										align="center">文档流转</TD>
									<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体"><asp:button id="cmdNewFlow" runat="server" CssClass="redbuttoncss" Height="21px" Text="新建流程"
												Width="66px"></asp:button>
<FONT face="宋体">
		<asp:button id="cmdDeleteFlow" runat="server" CssClass="redbuttoncss" Height="20px" Text="删除流程"
													Width="69px"></asp:button>
</FONT>
											<asp:button id="cmdManageStyle" runat="server" CssClass="redbuttoncss" Text="表单管理"></asp:button>&nbsp;</FONT></TD>
								</TR>
							</TABLE>
				<TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" id="Table1">
					<tr>
						<td vAlign="top" height="10"></td>
					</tr>
					<TR>
						<TD>
							<TABLE class="gbtext" id="Table3" height="24" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TR>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:linkbutton id="lbMyApprove" runat="server"  CssClass=Newbutton>我的批阅</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:linkbutton id="LinkButton1" runat="server"  CssClass=Newbutton>我的申请</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:linkbutton id="lbMyApproved" runat="server"  CssClass=Newbutton>已经批阅</asp:linkbutton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:linkbutton id="lbMyDraft" runat="server"  CssClass=Newbutton>拟稿箱</asp:linkbutton></TD>
									<%if(bManageFlow==true){%>
									<TD align="center" width="90" background="../../../Images/maillistbutton2.gif">
										<asp:linkbutton id="lbManageFlow" runat="server"  CssClass=Newbutton>流程管理</asp:linkbutton></TD>
									<%} else {%>
									<TD align="right">&nbsp;&nbsp;<FONT face="宋体">&nbsp;</FONT></TD>
									<%}%>
									<TD align="right">&nbsp;&nbsp;<FONT face="宋体">&nbsp;</FONT></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgFlowList" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
								AllowPaging="True" Font-Size="X-Small" OnPageIndexChanged="DataGrid_PageChanged" BorderColor="#93BEE2"
								BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" PageSize="15" DataKeyField="Flow_ID"
								OnDeleteCommand="MyDataGrid_Delete">
								<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle"
									BackColor="#337FB2"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ID">
										<HeaderStyle Width="2%"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="FlowID" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="Flow_ID" DataNavigateUrlFormatString="ManageFlow.aspx?FlowID={0}"
										DataTextField="Flow_Name" HeaderText="流程名">
										<HeaderStyle Font-Size="X-Small" Width="15%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small"></ItemStyle>
									</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="Flow_Class" HeaderText="流程类别">
										<HeaderStyle Width="11%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Remark" HeaderText="流程简介">
										<HeaderStyle Width="30%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="流程说明">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center">										
										</ItemStyle>
										<ItemTemplate>
										<a href ="DisplayFlow.aspx?FlowID=<%#DataBinder.Eval(Container,"DataItem.Flow_ID")%>">说明</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="流程图例">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center">										
										</ItemStyle> 
										<ItemTemplate>
										<a   href="###"   onclick="window.open('/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>',   '',   'scrollbars=no,resizable=yes,toolbar=no')">图例</a>
										<%--<a href ="/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>" target="_blank">图例</a>--%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="Style_ID" DataNavigateUrlFormatString="DisplayStyle.aspx?StyleID={0}"
										DataTextField="Style_Name" HeaderText="表格/附件">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:HyperLinkColumn>
									<asp:BoundColumn DataField="Build_Date" HeaderText="建立时间">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="编辑">
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<a href ='EditFlow.aspx?FlowID=<%# DataBinder.Eval(Container, "DataItem.Flow_ID") %>'>
												编辑</a>
										</ItemTemplate>
										<EditItemTemplate>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="删除" HeaderText="删除" CommandName="Delete">
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="" HorizontalAlign="Right" ForeColor="#003399" BackColor="#E8F4FF"
									Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" Codebehind="ManageFlow.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.ManageFlow" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageFlow</title>
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
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="ManageFlow" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="HEIGHT: 50px" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 30px" background="../../../Images/treetopbg.jpg"><FONT size="2">流程名：</FONT>
							<asp:Label id="labTitle" runat="server" Width="632px"></asp:Label>
						</TD>
						<td align="right" style="HEIGHT: 30px" background="../../../Images/treetopbg.jpg"><asp:Button id="cmdReturn" accessKey="r" runat="server" Width="60px" CssClass="buttoncss" Text="返回"></asp:Button></td>
					</TR>
					<TR>
						<TD vAlign="top" colspan="2"><asp:datagrid id="dgStepList" runat="server" BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px"
								BackColor="White" CellPadding="3" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" DataKeyField="Step_ID"
								OnPageIndexChanged="DataGrid_PageChanged" Width="100%" HorizontalAlign="Center" AllowSorting="True" OnDeleteCommand="MyDataGrid_Delete"
								OnEditCommand="MyDataGrid_Move">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="White"
									BackColor="#337FB2"></HeaderStyle>
								<FooterStyle HorizontalAlign="Center" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Step_ID" HeaderText="步骤">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="名称">
										<HeaderStyle HorizontalAlign="Left" Width="48%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<a href ='EditTache.aspx?FlowID=<%=FlowID%>&StepID=<%#DataBinder.Eval(Container.DataItem,"Step_ID")%>'>
												<%# DataBinder.Eval(Container, "DataItem.Step_Name") %>
											</a>
										</ItemTemplate>
										<EditItemTemplate>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="流转规则">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:Label runat="server">
												<%#GetTranslateFlowRule(DataBinder.Eval(Container.DataItem,"Flow_Rule").ToString())%>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server"></asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="人员">
										<HeaderStyle Width="8%"></HeaderStyle>
										<ItemTemplate>
											<a href ='BindStaff.aspx?FlowID=<%=FlowID%>&StepID=<%#DataBinder.Eval(Container.DataItem,"Step_ID")%>'>
												绑定</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="删除" HeaderText="操作" CommandName="Delete">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" HeaderText="位置" CancelText="" EditText="上移">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:EditCommandColumn>
									<asp:TemplateColumn HeaderText="分支(个)">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<a href ='EditJump.aspx?FlowID=<%=FlowID%>&StepID=<%#DataBinder.Eval(Container.DataItem,"Step_ID")%>'>
												分支</a>(<%#DataBinder.Eval(Container.DataItem,"Jump_Count")%>)
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

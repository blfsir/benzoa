<%@ Page language="c#" Codebehind="ListDocument.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.ListDocument" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListDocument</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			
//			parent.document.forms["MainFrame"].document.body.style.overflow = "auto";
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="ListDocument" method="post" runat="server">
			<FONT face="宋体">
            <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="GbText" align="right" width="20" background="../../../Images/treetopbg.jpg"
										bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
									<TD width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
										bgColor="#e8f4ff" class="GbText"><font color="#006699">文档流转</font></TD>
									<TD class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff"><FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT></TD>
								</TR>
			</TABLE>
	  <TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" id="Table1">
					<tr>
						<td vAlign="top" height="10"></td>
					</tr>
					<TR>
						<TD>
							<TABLE class="gbtext" id="Table3" style="WIDTH: 450px; HEIGHT: 24px" height="24" cellSpacing="0"
								cellPadding="0" width="449" border="0">
								<TR>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif' 
          ><asp:linkbutton id="lbMyApprove" runat="server" CssClass="Newbutton">我的批阅</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,2));%>.gif' 
          ><asp:linkbutton id="lbMyDocument" runat="server" CssClass="Newbutton">我的申请</asp:linkbutton></TD>
									<TD align=center width=90 
          background='../../../Images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,3));%>.gif' 
          ><asp:LinkButton ID="lbMyApproved" runat="server" CssClass="Newbutton">已经批阅</asp:LinkButton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif"><asp:linkbutton id="lbMyDraft" runat="server" CssClass="Newbutton" >拟稿箱</asp:linkbutton></TD>
									<%if(bManageFlow==true){%>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif"><asp:linkbutton id="lbManageFlow" runat="server" CssClass="Newbutton" >流程管理</asp:linkbutton></TD>
									<%}%>
									<%else {%>
									<TD class="Newbutton" align="center" width="90">&nbsp;
									</TD>
									<%}%>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE><table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><asp:datagrid id="dgDocumentList" runat="server" Font-Size="X-Small" PageSize="15" CellPadding="3"
					BorderWidth="1px" BorderStyle="None" BorderColor="#93BEE2" BackColor="White" OnPageIndexChanged="DataGrid_PageChanged"
					AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%">
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
							DataTextField="FlowName" HeaderText="流程名">
							<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
						</asp:HyperLinkColumn>
						 
						<asp:TemplateColumn HeaderText="当前环节">
							<ItemTemplate>
								<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StepName") %>' NavigateUrl='<%#GetDisplayTacheMemberUrl(DataBinder.Eval(Container, "DataItem.Doc_ID").ToString()) %>'>
								</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Short_Doc_Added_Date" HeaderText="拟稿时间">
							<HeaderStyle Width="13%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Status" HeaderText="状态">
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="8%"></HeaderStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle NextPageText="" Font-Size="X-Small" HorizontalAlign="Right" ForeColor="#003399"
						BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
  </tr>
</table>

				</FONT></form>
	</body>
</HTML>

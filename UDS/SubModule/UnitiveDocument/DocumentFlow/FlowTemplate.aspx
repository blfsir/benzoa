<%@ Page language="c#" Codebehind="FlowTemplate.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0" rightmargin="0">
		<form id="WebForm1" method="post" runat="server">
			<FONT face="����">
            <TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR >
									<TD width="20" height="30"
										align="right" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/DocFlow.gif" width="16"></FONT></TD>
								  <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
										align="center"><font color="#006699">�ĵ���ת</font></TD>
									<TD align="right" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" class="GbText"><FONT face="����">
									        <asp:Button runat="server" ID="btnSetDesktopFlow" Width="95px" 
                                            Text="��Ϊ�������" CssClass="buttoncss" onclick="btnSetDesktopFlow_Click" />
											<asp:Button id="cmdListDraft" runat="server" Width="55px" Text="�б�" CssClass="buttoncss"></asp:Button>&nbsp;</FONT></TD>
								</TR>
							</TABLE>
				<TABLE width="98%" border="0" align="center" cellPadding="0" cellSpacing="0" id="Table1">
					<tr>
						<td vAlign="top" height="10">
						</td>
					</tr>
					<TR>
						<TD>
							<TABLE width="100%" height="24"
								border="0" align="center" cellPadding="0" cellSpacing="0" class="gbtext" id="Table2">
								<TR>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:LinkButton id="lbMyApprove" runat="server" CssClass=Newbutton>�ҵ�����</asp:LinkButton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:LinkButton id="LinkButton1" runat="server" CssClass=Newbutton>�ҵ�����</asp:LinkButton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">
										<asp:LinkButton id="lbMyApproved" runat="server" CssClass=Newbutton>�Ѿ�����</asp:LinkButton></TD>
									<TD align="center" width="90" background="../../../Images/maillistbutton2.gif">
										<asp:LinkButton id="lbMyDraft" runat="server" CssClass=Newbutton>�����</asp:LinkButton></TD>
									<%if(bManageFlow==true){%>
									<TD align="center" width="90" background="../../../Images/maillistbutton1.gif">&nbsp;
										<asp:LinkButton id="lbManageFlow"  CssClass=Newbutton runat="server">���̹���</asp:LinkButton></TD>
									<%}%>
									<%else {%>
									<TD align="center">&nbsp;
									</TD>
									<%}%>
									<TD align="center">&nbsp;</TD>
								</TR>
					  </TABLE></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgFlowList" runat="server" CellPadding="3" BackColor="White" BorderWidth="1px"
								BorderStyle="None" BorderColor="#93BEE2" OnPageIndexChanged="DataGrid_PageChanged" Font-Size="X-Small"
								AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%" PageSize="15" DataKeyField="Flow_ID">
								<SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
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
									<asp:HyperLinkColumn DataNavigateUrlField="Flow_ID" DataNavigateUrlFormatString="NewDocument.aspx?FlowID={0}"
										DataTextField="Flow_Name" HeaderText="������">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Left" Width="33%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
									</asp:HyperLinkColumn>
									<asp:HyperLinkColumn DataTextField="Flow_Class" HeaderText="�������">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Left" Width="10%"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Left"></ItemStyle>
									</asp:HyperLinkColumn>
									<asp:TemplateColumn HeaderText="����˵��">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate >
										<a href ="DisplayFlow.aspx?FlowID=<%#DataBinder.Eval(Container,"DataItem.Flow_ID")%>">˵��</a>
										</ItemTemplate>
									</asp:TemplateColumn>

									<asp:TemplateColumn HeaderText="����ͼ��">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center">										
										</ItemStyle> 
										<ItemTemplate>
										<a   href="###"   onclick="window.open('/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>',   '',   'scrollbars=no,resizable=yes,toolbar=no')">ͼ��</a>
										<%--<a href ="/SubModule/UnitiveDocument/DocumentFlow/Attachment/<%#DataBinder.Eval(Container,"DataItem.flow_chat")%>" target="_blank">ͼ��</a>--%>
										</ItemTemplate>
									</asp:TemplateColumn>

									<asp:TemplateColumn HeaderText="������" ItemStyle-Height ="13%">
										<ItemTemplate>
											<a href ='DisplayTacheMember.aspx?StepID=<%#DataBinder.Eval(Container, "DataItem.Step_ID")%>&FlowID=<%#DataBinder.Eval(Container, "DataItem.Flow_ID")%>&ReturnPage=4'>
												<%# DataBinder.Eval(Container, "DataItem.StepName") %>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="Style_ID" DataNavigateUrlFormatString="DisplayStyle.aspx?StyleID={0}"
										DataTextField="Style_Name" HeaderText="���/����">
										<HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:HyperLinkColumn>
									<asp:BoundColumn DataField="LastUseDate" HeaderText="���ʹ������">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UsedTimes" HeaderText="ʹ�ô���">
										<HeaderStyle Width="8%"></HeaderStyle>
									</asp:BoundColumn>
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

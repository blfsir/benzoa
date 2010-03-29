<%@ Page language="c#" Codebehind="EditJump.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.DocumentFlow.EditJump" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditJump</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function delete_confirm(e) {
				if (event.srcElement.outerText == "ɾ��")
				event.returnValue =confirm("��ȷ��Ҫɾ��?");
			}
			document.onclick=delete_confirm;		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <TR>
					<TD height="30" colSpan="2" background="../../../Images/treetopbg.jpg"><FONT face="����">������ת��
							<asp:label id="labTitle" runat="server" Width="318px"></asp:label></FONT></TD>
			  </TR>
		  </table>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#93bee2">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<TABLE width="98%" border="1" align="center" cellPadding="3" cellSpacing="0" class="gbtext" id="Table2" bordercolor="#93bee2">
				<TR>
					<TD style="WIDTH: 61px"><FONT face="����">�����жϣ�</FONT></TD>
					<TD><FONT face="����"><asp:dropdownlist id="ddFieldName" runat="server" Width="150px" Height="20px"></asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddCompare" runat="server" Width="77px" Height="20px">
								<asp:ListItem Value="1">&gt;</asp:ListItem>
								<asp:ListItem Value="2">=</asp:ListItem>
								<asp:ListItem Value="3">&lt;</asp:ListItem>
								<asp:ListItem Value="4">&gt;=</asp:ListItem>
								<asp:ListItem Value="5">&lt;=</asp:ListItem>
								<asp:ListItem Value="6">&lt;&gt;</asp:ListItem>
							</asp:dropdownlist>&nbsp;<asp:textbox id="txtContant" runat="server" Width="58px" Height="20px" CssClass="inputcss">0</asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 61px">
						<P><FONT face="����">��֧��ת��</FONT></P>
					</TD>
					<TD><FONT face="����"><asp:dropdownlist id="ddStep" runat="server" Width="150px" Height="20px"></asp:dropdownlist>&nbsp;��ת����
							<asp:dropdownlist id="ddlFlowRule" runat="server" Width="84px">
								<asp:ListItem Value="0">����Ա</asp:ListItem>
								<asp:ListItem Value="1">��ְλ</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">����Ŀ</asp:ListItem>
							</asp:dropdownlist></FONT></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 61px"></TD>
					<TD><asp:button id="cmdInsert" accessKey="a" runat="server" Width="56px" Height="20px" CssClass="buttoncss"
							Text="����"></asp:button><asp:button id="cmdReturn" accessKey="r" runat="server" Width="60px" CssClass="buttoncss" Text="����"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><FONT face="����"><asp:datagrid id="dgJumpList" runat="server" Width="100%" BorderColor="#93BEE2" BorderStyle="None"
								BorderWidth="1px" BackColor="White" CellPadding="3" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="DataGrid_PageChanged"
								HorizontalAlign="Center" AllowSorting="True" DataKeyField="Priority" OnEditCommand="MyGrid_Move" OnDeleteCommand="MyGrid_Delete">
								<SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small"  HorizontalAlign="Center" ForeColor="White"
									BackColor="#337FB2"></HeaderStyle>
								<FooterStyle HorizontalAlign="Center" ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Priority" HeaderText="����">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="field_description" HeaderText="�ֶ�">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Compare" HeaderText="�Ƚ�">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="comparevalue" HeaderText="����">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="����">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetTranslateFlowRule(DataBinder.Eval(Container, "DataItem.Flow_Rule").ToString()) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="step_name" HeaderText="ת������">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="ɾ��" HeaderText="����" CommandName="Delete">
										<HeaderStyle Width="6%"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" HeaderText="λ��" CancelText="ȡ��" EditText="����">
										<HeaderStyle Width="6%"></HeaderStyle>
									</asp:EditCommandColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

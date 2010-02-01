<%@ Page language="c#" Codebehind="Listview.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Task.Task" %>
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
			var len=document.Task.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.Task.elements[i].type=="checkbox"){
		        document.Task.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.Task.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.Task.elements[i].type=="checkbox"){
	                  document.Task.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
		<LINK href="../../../Css/basiclayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Task" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="38"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
									align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/help_page.gif" width="16"></FONT></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right"><font color="#006699">�ҵ���Ŀ</font></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="����">
										<asp:panel id="PanFunction" runat="server">
											<INPUT class="redButtonCss" onclick="selectAll()" type="button" value="ȫ��ѡ��"></FONT>
									<INPUT class="redButtonCss" onclick="unSelectAll()" type="button" value="ȫ��ȡ��"></asp:panel></FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="gbtext" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="90" background="../../../images/maillistbutton2.gif" height="24"
									style="WIDTH: 90px" valign="middle"><FONT face="����">&nbsp;</FONT><a href="../Task/Listview.aspx" class="Newbutton">�ҵĲ���</a></TD>
								<TD align="center" width="90" background="../../../images/maillistbutton1.gif" height="24"
									style="WIDTH: 90px" valign="middle" class="Newbutton"><FONT face="����">&nbsp;</FONT><a href="../Subscription/Listview.aspx" class="Newbutton">�ҵĹ�ע</a></TD>
								<TD align="right"><FONT face="����">&nbsp;&nbsp; </FONT>
								</TD>
							</TR>
						</TABLE>
						<asp:datagrid id="dgMyTask" runat="server" CellPadding="3" BorderColor="#93BEE2" AllowCustomPaging="True"
							PageSize="15" OnPageIndexChanged="DataGrid_PageChanged" AutoGenerateColumns="False" AllowSorting="True"
							AllowPaging="True" Width="100%" HorizontalAlign="Justify" BorderWidth="1px">
							<SelectedItemStyle Font-Size="X-Small"></SelectedItemStyle>
							<EditItemStyle Font-Size="X-Small"></EditItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Height="22px" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" Height="22px" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Height="24px" ForeColor="White" VerticalAlign="Middle"
								BackColor="#337FB2"></HeaderStyle>
							<FooterStyle Font-Size="X-Small"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<HeaderTemplate>
										<FONT face="����">��</FONT>
									</HeaderTemplate>
									<ItemTemplate>
										<FONT face="����">
											<asp:CheckBox id="ClassID" Runat="server"></asp:CheckBox></FONT>
									</ItemTemplate>
									<EditItemTemplate>
										<FONT face="����"></FONT>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn Text="��������" Target="_self" DataNavigateUrlField="ClassID" DataNavigateUrlFormatString="../Project.aspx?ClassID={0}"
									DataTextField="ClassName" HeaderText="��Ŀ����">
									<HeaderStyle HorizontalAlign="Left" Width="25%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="FILECOUNT" HeaderText="�ѹ鵵">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Status" HeaderText="״̬">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Scale" HeaderText="��ռ����">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StartDate" HeaderText="��ʼ����">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="EndDate" HeaderText="��ֹ����">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" Font-Size="Smaller" PrevPageText="��һҳ" HorizontalAlign="Right"
								BackColor="#E8F4FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="ContactInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.ContactInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ContactInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../Css/meizzDate.js"></script>
		<script language="C#" runat="server">
		private string GetCurStatus(string curstatus)
		{
			switch(curstatus.Split(',')[0].ToString())
			{
				case "trace":
					return ("����");
					break;
				case "boot":
					return ("����");
					break;
				case "commend":
					return ("��Ʒ�Ƽ�");
					break;
				case "requirement":
					return ("������");
					break;
				case "submit":
					return ("�����ύ");
					break;
				case "negotiate":
					return ("����̸��");
					break;
				case "actualize":
					return ("��Ŀʵʩ");
					break;
				case "traceservice":
					return ("���ٷ���");
					break;
				case "last":
					return ("��β��");
					break;
			}
			return("");
		}
		private string GetAddMan(DataRow[] row)
		{
			if(row.Length!=0)
			{
				return(row[0]["Staff_Name"].ToString());
			}
			else
				return ("");
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ContactInfo" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 12px" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>��ѯ������
							<asp:DropDownList id="ddl_search" runat="server" AutoPostBack="True">
								<asp:ListItem Value="������Ա����">������Ա����</asp:ListItem>
								<asp:ListItem Value="�ͻ�����">�ͻ�����</asp:ListItem>
								<asp:ListItem Value="�ͻ����">�ͻ����</asp:ListItem>
								<asp:ListItem Value="���۽׶�">���۽׶�</asp:ListItem>
								<asp:ListItem Value="�ɽ�Ԥ��">�ɽ�Ԥ��</asp:ListItem>
								<asp:ListItem Value="�ѽ�Ǣ����">�ѽ�Ǣ����</asp:ListItem>
								<asp:ListItem Value="��Ǣ����ְ��">��Ǣ����ְ��</asp:ListItem>
								<asp:ListItem Value="�״ν�Ǣʱ��">�״ν�Ǣʱ��</asp:ListItem>
								<asp:ListItem Value="���һ�ν�Ǣʱ��">���һ�ν�Ǣʱ��</asp:ListItem>
								<asp:ListItem Value="�´�Լ��ʱ��">�´�Լ��ʱ��</asp:ListItem>
								<asp:ListItem Value="����������¼">����������¼</asp:ListItem>
								<asp:ListItem Value="����������¼">����������¼</asp:ListItem>
							</asp:DropDownList>
							<asp:TextBox id="tbx_searchvalue" runat="server"></asp:TextBox>
							<asp:RadioButtonList id="rbl_searchvalue" runat="server"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btn_addsearch" runat="server" Text="���"></asp:Button>&nbsp;
							<asp:Button id="btn_Del" runat="server" Text="ɾ��"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:ListBox id="lbx_search" runat="server" Width="523px"></asp:ListBox>
							<asp:Button id="btn_OK" runat="server" Text="��ѯ"></asp:Button></TD>
					</TR>
					<TR>
						<TD>���鵽
							<asp:Literal id="ltl_Client" runat="server"></asp:Literal>λ���������Ŀͻ�</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_ContactList" Width="100%" runat="server" AutoGenerateColumns="False" AllowPaging="True">
								<Columns>
									<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="���"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="NAME" HeaderText="�ͻ�����">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' NavigateUrl='<%# "Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Target="_blank" ID="Hyperlink1">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ContactTimes" SortExpression="ContactTimes" HeaderText="�Ӵ�����"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�ɽ�Ԥ��">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BargainPrognosis") %>' NavigateUrl='<%# "ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Target="_blank" ID="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="UpdateTime" SortExpression="UpdateTime" HeaderText="����ʱ��"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�Ӵ�״̬">
										<ItemTemplate>
											<asp:HyperLink runat="server" Text='<%# GetCurStatus(DataBinder.Eval(Container,"DataItem.Curstatus").ToString()) %>' NavigateUrl='<%# "ClientContact.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' ID="Hyperlink3" NAME="Hyperlink2">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�����">
										<ItemTemplate>
											<asp:Label runat="server" Text='<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientAddMan_Staff")) %>' ID="Label1">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

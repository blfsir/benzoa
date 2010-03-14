<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="ContactedClient.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.ContactedClient" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ContactedClient</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private string GetLinkMan(DataRow[] row)
		{
			if(row.Length!=0)
			{
				return(row[0]["Name"].ToString());
			}
			else
				return ("");
		}
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
				return(row[0]["realname"].ToString());
			}
			else
				return ("");
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftMargin="0" topmargin="0">
		<form id="ContactedClient" method="post" runat="server">
			<FONT face="����">
				<TABLE width="98%" border="1" align="center" cellPadding="1" cellSpacing="1" id="Table1">
					<TR>
						<TD>���Ӵ�
							<asp:Literal id="ltl_Client" runat="server"></asp:Literal>λ�ͻ�</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_Client" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
								CellPadding="3" BorderWidth="1px" BorderColor="#93BEE2">
								<AlternatingItemStyle BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small"></ItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ID" HeaderText="���"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�ͻ�����">
										<ItemTemplate>
											<asp:HyperLink id=HyperLink1 runat="server" Target="_blank" NavigateUrl='<%# "../Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
											</asp:HyperLink>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ContactTimes" HeaderText="�Ӵ�����"></asp:BoundColumn>
									<asp:BoundColumn DataField="BargainPrognosis" HeaderText="�ɽ�Ԥ��"></asp:BoundColumn>
									<asp:BoundColumn DataField="UpdateTime" HeaderText="����ʱ��"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�Ӵ�״̬">
										<ItemTemplate>
											<%# GetCurStatus(DataBinder.Eval(Container.DataItem,"CurStatus").ToString()) %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="�����">
										<ItemTemplate>
											<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("StaffID_Staff")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

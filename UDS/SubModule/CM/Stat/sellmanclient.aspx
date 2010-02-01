<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="sellmanclient.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.sellmanclient" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>sellmanclient</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="C#" runat="server">
		private string GetCurStatus(string curstatus)
		{
			switch(curstatus)
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
	<body MS_POSITIONING="GridLayout">
		<form id="sellmanclient" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>
							<asp:Literal id="ltl_begintime" runat="server"></asp:Literal>
							<asp:Literal id="ltl_endtime" runat="server"></asp:Literal>
							<asp:Literal id="ltl_clientno" runat="server"></asp:Literal>
							<asp:Literal id="ltl_contactno" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgrd_sellmanclient" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
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

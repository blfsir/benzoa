<%@ Page language="c#" Codebehind="ClientInfo.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.Stat.ClientInfo" %>
<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="UDS.Components"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ѯ</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../Css/meizzDate.js"></script>
		<script runat="server">
		private string GetUpdateTime(DataRow[] row)
		{
			if(row.Length!=0)
			{
				return(row[0]["UpdateTime"].ToString());
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
	<body leftmargin="0" topmargin="0">
		<form id="ClientInfo" method="post" runat="server">
			<FONT face="����">
				<TABLE borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="20" height="30"
							align="right" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6" class="GbText"><FONT color="#003366" size="3"><IMG height="16" src="../../../DataImages/myLinkman.gif" width="16"></FONT></TD>
					  <TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
							align="center">�ͻ�����</TD>
						<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="left">-��ѯ&nbsp;</TD>
					</TR>
				</TABLE>
			</FONT>
		  <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table>
			<FONT face="����">
				<TABLE width="98%" border="1" align="center" cellPadding="3" cellSpacing="0" borderColor="#93bee2" class="GbText" id="Table1"
					style="BORDER-COLLAPSE: collapse">
					<TR>
						<TD width="50%" height="30" bgcolor="#E8F4FF">��ѯ������&nbsp;&nbsp;
							<asp:dropdownlist id="ddl_search" runat="server" AutoPostBack="True" Width="130px">
								<asp:ListItem Value="�ͻ�����">�ͻ�����</asp:ListItem>
								<asp:ListItem Value="�ͻ�����">�ͻ�����</asp:ListItem>
								<asp:ListItem Value="�ͻ����">�ͻ����</asp:ListItem>
								<asp:ListItem Value="��ϵ��">��ϵ��</asp:ListItem>
								<asp:ListItem Value="�绰">�绰</asp:ListItem>
								<asp:ListItem Value="������ҵ">������ҵ</asp:ListItem>
								<asp:ListItem Value="��ҵ����">��ҵ����</asp:ListItem>
								<asp:ListItem Value="�ͻ���Դ">�ͻ���Դ</asp:ListItem>
								<asp:ListItem Value="������Ա">������Ա</asp:ListItem>
								<asp:ListItem Value="�������">�������</asp:ListItem>
								<asp:ListItem Value="���������ͻ�">���������ͻ�</asp:ListItem>
								<asp:ListItem Value="���������ͻ�">���������ͻ�</asp:ListItem>
							</asp:dropdownlist><asp:textbox id="tbx_searchvalue" runat="server" CssClass="inputcss"></asp:textbox>&nbsp;</TD>
						<TD bgcolor="#E8F4FF">��ѯ��Χ
							<asp:dropdownlist id="ddl_SearchBound" runat="server">
								<asp:ListItem Value="1">����������</asp:ListItem>
								<asp:ListItem Value="2">������</asp:ListItem>
								<asp:ListItem Value="3">������</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:radiobuttonlist id="rbl_searchvalue" runat="server" Visible="False"></asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD height="30" colSpan="2"><asp:button id="btn_addsearch" runat="server" Text="�������" CssClass="redbuttoncss"></asp:button>&nbsp;
							<asp:button id="btn_Del" runat="server" Text="ɾ������" CssClass="redbuttoncss"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:listbox id="lbx_search" runat="server" Height="95px" Width="496px"></asp:listbox><BR>
							<asp:button id="btn_OK" runat="server" Text="��ѯ" CssClass="redbuttoncss"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="2" height="30">��ѯ��������鵽
							<asp:Literal id="ltl_Client" runat="server"></asp:Literal>λ���������Ŀͻ�</TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="dgrd_clientlist" runat="server" Width="98%" AllowSorting="True" AllowPaging="True"
					AutoGenerateColumns="False">
		      <HeaderStyle ForeColor="White" BackColor="#337FB2"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn></asp:TemplateColumn>
						<asp:BoundColumn DataField="ID" SortExpression="ID" HeaderText="���"></asp:BoundColumn>
						<asp:TemplateColumn SortExpression="Name" HeaderText="�ͻ�����">
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' NAME="Hyperlink1" Target="_blank" NavigateUrl='<%# "../Client.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>'>
								</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Linkman" SortExpression="Linkman" HeaderText="��ϵ��"></asp:BoundColumn>
						<asp:BoundColumn DataField="Linkman_Telephone" SortExpression="Linkman_Telephone" HeaderText="�绰"></asp:BoundColumn>
						<asp:TemplateColumn SortExpression="UpdateTime" HeaderText="����ʱ��">
							<ItemTemplate>
								<asp:Label ID="lbl_UpdateTime" Runat="server">
									<%# DataBinder.Eval(Container,"DataItem.UpdateTime")%>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Ŀǰ״̬">
							<HeaderStyle Font-Size="X-Small"></HeaderStyle>
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink2 runat="server" Text='<%# GetCurStatus(DataBinder.Eval(Container,"DataItem.Curstatus").ToString()) %>' NavigateUrl='<%# "../../../SubModule/CM/ClientContact_thisWeek.aspx?ClientID="+DataBinder.Eval(Container,"DataItem.ID")%>' NAME="Hyperlink2" Target="_blank">
								</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn SortExpression="AddMan" HeaderText="�����">
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# GetAddMan(((DataRowView)Container.DataItem).Row.GetChildRows("ClientAddMan_Staff")) %>' ID="Label1">
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</FONT>
		</form>
	</body>
</HTML>

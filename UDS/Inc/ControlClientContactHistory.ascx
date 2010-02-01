<%@ Import namespace="UDS.Components"  %>
<%@ Import namespace="System.Data.SqlClient"  %>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ControlClientContactHistory.ascx.cs" Inherits="UDS.Inc.ControlClientContactHistory" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="C#" runat="server">
private string GetContactType(string str)
{
	string tmp = "";
	for(int i=0;i<str.Split(',').Length;i++)
	{
		
		switch(str.Split(',')[i])
		{
		case "telephone":
			tmp += "�绰 ";break;
		case "fax":
			tmp += "���� ";break;
		case "email":
			tmp += "�ʼ� ";break;
		case "mail":
			tmp += "�ź� ";break;
		case "sms":
			tmp += "����Ϣ ";break;
		case "callin":
			tmp += "���� ";break;
		case "interview":
			tmp += "�߷� ";break;
		case "meeting":
			tmp += "���� ";break;
	
		}
	}
	return(tmp);

}
private string GetContactStatus(string str)
{
	string tmp = "";
	for(int i=0;i<str.Split(',').Length;i++)
	{
		
		switch(str.Split(',')[i])
		{
		case "trace":
			tmp += "���� ";break;
		case "boot":
			tmp += "���� ";break;
		case "commend":
			tmp += "��Ʒ�Ƽ� ";break;
		case "requirement":
			tmp += "������ ";break;
		case "submit":
			tmp += "�����ύ ";break;
		case "negotiate":
			tmp += "����̸�� ";break;
		case "actualize":
			tmp += "��Ŀʵʩ ";break;
		case "traceservice":
			tmp += "���ٷ��� ";break;
		case "last":
			tmp += "��β�� ";break;
	
		}
	}
	return(tmp);
	
}

private string GetFeeUsed(string str)
{
	string tmp = "";
	for(int i=0;i<str.Split(',').Length;i++)
	{
		
		switch(str.Split(',')[i])
		{
		case "travel":
			tmp += "���� ";break;
		case "food":
			tmp += "���� ";break;
		case "gift":
			tmp += "��Ʒ ";break;
		case "outer":
			tmp += "���� ";break;
		
		}
	}
	return(tmp);

}


</script>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" style="FONT-SIZE: x-small">
	<TR>
		<TD width="100%">
			<table width="100%" border="1" style="FONT-SIZE: x-small">
				<asp:Repeater id="rpt_data" runat="server">
					<ItemTemplate>
						<tr bordercolor="#93BEE2">
							<td width="20%">
								���ʱ��:<%# DateTime.Parse(DataBinder.Eval(Container.DataItem,"UpdateTime").ToString()).ToShortDateString()%>
								<br>
								�Ӵ�ʱ��:<%# DateTime.Parse(DataBinder.Eval(Container.DataItem,"ContactTime").ToString()).ToShortDateString()%>
								<br>
								<asp:Repeater ID="rpt_Cooperater"  DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Cooperater") %>' Runat=server>
									<ItemTemplate>
										Эͬ��Ա:<%# DataBinder.Eval(Container.DataItem,"[\"realname\"]")%>
									</ItemTemplate>
								</asp:Repeater>
								<br>
								����:<%# DataBinder.Eval(Container.DataItem,"Fee")%>
								<br>
								�ɽ�Ԥ��:<%# DataBinder.Eval(Container.DataItem,"BargainPrognosis")%>
							</td>
							<td>
								�Ӵ�����
								<asp:Repeater ID="rpt_Linkman" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Linkman") %>' Runat=server>
									<ItemTemplate>
								
										<a href='<%# "Linkman.aspx?LinkmanID="+DataBinder.Eval(Container.DataItem,"[\"ID\"]") %>' target=_blank>
										
											<%#  DataBinder.Eval(Container.DataItem,"[\"Name\"]")%>
										
										</a>
									</ItemTemplate>
								</asp:Repeater>
								�Ӵ�Ŀ�ģ�<%#  DataBinder.Eval(Container.DataItem,"ContactAim")%>; �Ӵ���ʽ��<%#  GetContactType(DataBinder.Eval(Container.DataItem,"ContactType").ToString())%>; 
								���۽׶Σ�<%#  GetContactStatus(DataBinder.Eval(Container.DataItem,"CurStatus").ToString())%>; 
								������;��<%#  GetFeeUsed(DataBinder.Eval(Container.DataItem,"FeeUsed").ToString())%>; 
								�´νӴ�Ŀ�ģ�<%#  DataBinder.Eval(Container.DataItem,"NextContactAim")%>; �´νӴ�ʱ�䣺<%#  DateTime.Parse(DataBinder.Eval(Container.DataItem,"NextContactTime").ToString())%>; 
								���ڱ�ģ�<%#  DataBinder.Eval(Container.DataItem,"sellmoney")%>;<br>
								������
								<asp:Repeater DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Attachment") %>' Runat=server ID="Repeater1">
									<ItemTemplate>
										<a href='<%# Request.Path.Substring(0,Request.Path.LastIndexOf("/"))+"\\Attachment\\"+DataBinder.Eval(Container.DataItem,"[\"ID\"]")+DataBinder.Eval(Container.DataItem,"[\"Extension\"]") %>' target=_blank>
											<%# DataBinder.Eval(Container.DataItem,"[\"Path\"]")+"," %>
										</a>
									</ItemTemplate>
								</asp:Repeater><br>
								�Ӵ�����;<%#  DataBinder.Eval(Container.DataItem,"ContactContent")%>;
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</table>
		</TD>
	</TR>
</TABLE>
<FONT face="����"></FONT>

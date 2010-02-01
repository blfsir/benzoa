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
			tmp += "电话 ";break;
		case "fax":
			tmp += "传真 ";break;
		case "email":
			tmp += "邮件 ";break;
		case "mail":
			tmp += "信函 ";break;
		case "sms":
			tmp += "短消息 ";break;
		case "callin":
			tmp += "来访 ";break;
		case "interview":
			tmp += "走访 ";break;
		case "meeting":
			tmp += "会议 ";break;
	
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
			tmp += "跟踪 ";break;
		case "boot":
			tmp += "启动 ";break;
		case "commend":
			tmp += "产品推荐 ";break;
		case "requirement":
			tmp += "需求定义 ";break;
		case "submit":
			tmp += "方案提交 ";break;
		case "negotiate":
			tmp += "商务谈判 ";break;
		case "actualize":
			tmp += "项目实施 ";break;
		case "traceservice":
			tmp += "跟踪服务 ";break;
		case "last":
			tmp += "收尾款 ";break;
	
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
			tmp += "差旅 ";break;
		case "food":
			tmp += "餐饮 ";break;
		case "gift":
			tmp += "礼品 ";break;
		case "outer":
			tmp += "公关 ";break;
		
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
								添加时间:<%# DateTime.Parse(DataBinder.Eval(Container.DataItem,"UpdateTime").ToString()).ToShortDateString()%>
								<br>
								接触时间:<%# DateTime.Parse(DataBinder.Eval(Container.DataItem,"ContactTime").ToString()).ToShortDateString()%>
								<br>
								<asp:Repeater ID="rpt_Cooperater"  DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Cooperater") %>' Runat=server>
									<ItemTemplate>
										协同人员:<%# DataBinder.Eval(Container.DataItem,"[\"realname\"]")%>
									</ItemTemplate>
								</asp:Repeater>
								<br>
								费用:<%# DataBinder.Eval(Container.DataItem,"Fee")%>
								<br>
								成交预估:<%# DataBinder.Eval(Container.DataItem,"BargainPrognosis")%>
							</td>
							<td>
								接触对象：
								<asp:Repeater ID="rpt_Linkman" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Linkman") %>' Runat=server>
									<ItemTemplate>
								
										<a href='<%# "Linkman.aspx?LinkmanID="+DataBinder.Eval(Container.DataItem,"[\"ID\"]") %>' target=_blank>
										
											<%#  DataBinder.Eval(Container.DataItem,"[\"Name\"]")%>
										
										</a>
									</ItemTemplate>
								</asp:Repeater>
								接触目的：<%#  DataBinder.Eval(Container.DataItem,"ContactAim")%>; 接触方式：<%#  GetContactType(DataBinder.Eval(Container.DataItem,"ContactType").ToString())%>; 
								销售阶段：<%#  GetContactStatus(DataBinder.Eval(Container.DataItem,"CurStatus").ToString())%>; 
								费用用途：<%#  GetFeeUsed(DataBinder.Eval(Container.DataItem,"FeeUsed").ToString())%>; 
								下次接触目的：<%#  DataBinder.Eval(Container.DataItem,"NextContactAim")%>; 下次接触时间：<%#  DateTime.Parse(DataBinder.Eval(Container.DataItem,"NextContactTime").ToString())%>; 
								近期标的：<%#  DataBinder.Eval(Container.DataItem,"sellmoney")%>;<br>
								附件：
								<asp:Repeater DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("Contact_Attachment") %>' Runat=server ID="Repeater1">
									<ItemTemplate>
										<a href='<%# Request.Path.Substring(0,Request.Path.LastIndexOf("/"))+"\\Attachment\\"+DataBinder.Eval(Container.DataItem,"[\"ID\"]")+DataBinder.Eval(Container.DataItem,"[\"Extension\"]") %>' target=_blank>
											<%# DataBinder.Eval(Container.DataItem,"[\"Path\"]")+"," %>
										</a>
									</ItemTemplate>
								</asp:Repeater><br>
								接触内容;<%#  DataBinder.Eval(Container.DataItem,"ContactContent")%>;
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</table>
		</TD>
	</TR>
</TABLE>
<FONT face="宋体"></FONT>

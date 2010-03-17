<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Data"  %>
<%@ Import namespace="System"%>
<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script>
		//获取时间
function Timer(span)
{
	var tmp = new Date();
	var milsecs=Date.parse(tmp.getMonth()+"-"+tmp.getDay()+"-"+tmp.getFullYear()+" "+document.getElementById('lbl_Hour').innerText+":"+document.getElementById('lbl_Minute').innerText+":"+document.getElementById('lbl_Second').innerText);
	var timer = new Date(milsecs+span);
	var seconds,minutes,hours;
	if(timer.getSeconds()<10)
		seconds = "0"+timer.getSeconds();
	else
		seconds = timer.getSeconds();
	if(timer.getMinutes()<10)
		minutes = "0"+timer.getMinutes();
	else
		minutes = timer.getMinutes();
	if(timer.getHours()<10)
		hours = "0"+timer.getHours();
	else
		hours = timer.getHours();	
	document.getElementById('lbl_Second').innerText = seconds;
	document.getElementById('lbl_Minute').innerText = minutes;
	document.getElementById('lbl_Hour').innerText = hours;
}
//得到服务器时间每隔updatespan分钟校验一次，每秒更新一次本地时钟
function GetServerTime(updatespan)
{	
	var clientspan = 1*1000;
	//更新本地时钟
	setInterval("Timer("+clientspan+")",clientspan);
	//同步服务器时钟
	setInterval("window.location.href='Default.aspx'",updatespan);
	
}
//-->
		</script>
		<script language="C#" runat="server">
		string GetMemo(object id)
		{
			if(id.ToString()=="") return "";
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams =  {
										db.MakeInParam("@id",SqlDbType.BigInt,8,Int64.Parse(id.ToString())),
										db.MakeOutParam("@result",SqlDbType.VarChar,300)
									};
			db.RunProc("sp_WA_GetMemo",prams);
			return(prams[1].Value.ToString());
		
		}
		
		string GetTime(object day)
		{
			if(day.ToString()=="")
				return "";
			else
			{
				return(DateTime.Parse(day.ToString()).ToShortTimeString());			
			}
		
		}
		</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" onLoad="GetServerTime(15*60*1000)">
		<form method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" height="1">
				<tr>
					<td width="20" height="30" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText"><font color="#006699" size="3"><img src="../..//DataImages/page2.gif" width="16" height="16"></font></td>
					<td width="60" align="center" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">我的考勤</td>
					<td align="center" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">&nbsp;</td>
				</tr>
			</table>
			<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
			  <tr>
			    <td height="10"></td>
		      </tr>
		  </table> 
			<TABLE width="98%" border="1" align="center" cellPadding="3" cellSpacing="0"
				class="gbtext" id="Table1" bordercolor="#93bee2">
			  <TR>
					<TD height="30" align="center" bgcolor="#e8f4ff">
						<asp:Label id="lblDutyMessage" runat="server">考勤信息</asp:Label>
						<asp:label id="lbl_Time" runat="server" Font-Size="X-Small"></asp:label>
						<asp:label id="lbl_Hour" runat="server" Font-Size="X-Small">Label</asp:label>:<asp:label id="lbl_Minute" runat="server" Font-Size="X-Small">Label</asp:label>:<asp:label id="lbl_Second" runat="server" Font-Size="X-Small">Label</asp:label>
		  <TR>
					<TD align="center">
						<asp:TextBox id="txtAttendanceMemo" runat="server" TextMode="MultiLine" Height="150px" Width="500px"
							Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD height="30" align="center" bgcolor="#e8f4ff">
						<asp:Button id="btnCheckAttendance" CommandArgument="" runat="server" CssClass="buttoncss" Width="80px"></asp:Button></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">
							<asp:DataGrid id="grdWeekAttendanceData" runat="server" Width="100%" AutoGenerateColumns="False"
								CellPadding="3" BorderWidth="1px" CssClass="gbtext" BorderColor="#93BEE2" PageSize="5" AllowPaging="True">
								<HeaderStyle ForeColor="Black" BackColor="#E8F4FF"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="日期">
										<ItemTemplate>
											<%# DateTime.Parse(((DataRowView)Container.DataItem)["WorkDate"].ToString()).ToShortDateString()%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="登录上班时间">
										<ItemTemplate>
											<%# GetTime(((DataRowView)Container.DataItem)["OnDuty"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="登录上班备注">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["OnDuty_MemoID"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="登录下班时间">
										<ItemTemplate>
											<%#	GetTime(((DataRowView)Container.DataItem)["OffDuty"])%>
											<asp:Literal id="Literal2" Runat="server"></asp:Literal>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="登录下班备注">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["OffDuty_MemoID"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									
									<asp:TemplateColumn HeaderText="打卡上班时间">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["fingerprintOnDuty"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:TemplateColumn HeaderText="打卡下班时间">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["fingerprintOffDuty"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									
								</Columns>
								<PagerStyle NextPageText="下周考勤记录" PrevPageText="上周考勤记录" HorizontalAlign="Center"></PagerStyle>
							</asp:DataGrid></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System"%>
<%@ Import namespace="System.Data"  %>
<%@ Page language="c#" Codebehind="StaffData.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance.StaffData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StaffData</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
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
	<body onload="window." leftmargin="0" topmargin="0">
		<form id="StaffData" method="post" runat="server">
			<FONT face="宋体">
				<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
					width="100%" height="1">
					<tr height="30">
						<td width="3%" bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg"><font color="#006699" size="3"></font></td>
						<td bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg"><b>考勤信息</b></td>
					</tr>
				</table>
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" class="gbtext">
					<TR>
						<TD style="WIDTH: 155px" height="40">&nbsp; 姓名：
							<asp:Literal id="ltlname" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 235px" height="40">查询开始时间：
							<asp:Literal id="ltlbegintime" runat="server"></asp:Literal></TD>
						<TD style="WIDTH: 223px" height="40">查询结束时间：
							<asp:Literal id="ltlendtime" runat="server"></asp:Literal></TD>
						<TD height="40">状态：
							<asp:Literal id="lbltype" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:DataGrid id="grdStaff" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#93BEE2"
								BorderWidth="1px" CellPadding="3" CssClass="gbtext">
								<HeaderStyle BackColor="#E8F4FF"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="日期">
										<ItemTemplate>
											<%# DateTime.Parse(((DataRowView)Container.DataItem)["WorkDate"].ToString()).ToString("yyyy-MM-dd") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="上班时间">
										<ItemTemplate>
											<%# GetTime(((DataRowView)Container.DataItem)["OnDuty"]) %>
											<asp:Literal id="Literal1" Runat="server"></asp:Literal>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="上班备注">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["OnDuty_MemoID"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="下班时间">
										<ItemTemplate>
											<%#	GetTime(((DataRowView)Container.DataItem)["OffDuty"])%>
											<asp:Literal id="Literal2" Runat="server"></asp:Literal>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="下班备注">
										<ItemTemplate>
											<%# GetMemo(((DataRowView)Container.DataItem)["OffDuty_MemoID"])%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

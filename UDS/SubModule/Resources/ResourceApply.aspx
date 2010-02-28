<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceApply.aspx.cs" Inherits="UDS.SubModule.Resources.ResourceApply" %>


<HTML>
	<HEAD>
		<title>ResourcesApply</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		 
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="ManageStaff" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
							<td vAlign="top" ><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TBODY>
										<TR height="30">
											<TD class="GbText" width="80" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6" align="right"> <IMG height="16" src="../../DataImages/staff.gif" width="16"/><font color="#006699">资源预定</font></TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
												align="right">&nbsp;</TD>
											<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right" width=85%></TD>
			</TD></TR></TBODY></TABLE></TD></TR>
						<tr><TD>
							<TABLE class="gbtext" id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="1">
								 
								<TR>
									<TD align="center" width="90"    height="24">
			                            <FONT face="宋体">
										<input type="button" class="redButtonCss" value="会议室申请" onclick="javacript:location.href='../Meeting/ApplyMeeting.aspx'" />
			</FONT>
		                                 </TD><TD align="center" width="90"    height="24">
			<FONT face="宋体"><input type="button" class="redButtonCss" value="车辆申请" onclick="javacript:location.href='../Vehicle/ApplyVehicle.aspx'" />
			</FONT>
		                                 </TD>
									
								 
								</TR>
								
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					
					<tr>
								<td colspan="3">
							        
								</td>
								</tr>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="Setup.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Setup.Setup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Setup</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="../../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	<body leftmargin="0" topmargin="0" MS_POSITIONING="GridLayout">
		<form id="Setup" method="post" runat="server">
			</TD></TD>
			<TD width="96%" height="1">
				<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" id="AutoNumber4" height="1">
					<tr height="30">
						<td width="3%" bgcolor="#c0d9e6" class="GbText" background="../../../Images/treetopbg.jpg"><font color="#003366" size="3"><img src="../../../Images/icon/057.GIF" width="16" height="16"></font></td>
						<td bgcolor="#c0d9e6" class="GbText" background="../../../Images/treetopbg.jpg"><b>系统设置</b></td>
					</tr>
				</table>
			</TD>
			</TR>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD height="60"><FONT face="宋体">&nbsp; <IMG alt="" src="../../../Images/admin_logo.gif">
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="60"><FONT face="宋体"> </FONT>
						<TABLE id="Table2" height="50" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD style="BACKGROUND-POSITION: left 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat" vAlign="bottom" background="../../../Images/admin_1bg.gif"><BR>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="16" src="../../../Images/admin_ico1.gif" width="16" border="0"><SPAN id="position_set" runat="server" style="RIGHT: 1in; WIDTH: 458px; BOTTOM: 1in; HEIGHT: 20px" class="gbtext">&nbsp;&nbsp;
										<A href="../../position/index.htm" target="main">职位设置</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;添加,删除,修改职位,对职位人员的新增,修改,调职等
									</SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="60"><FONT face="宋体">
							<TABLE id="Table4" height="50" cellSpacing="0" cellPadding="0" width="550" border="0">
								<TR>
									<TD style="BACKGROUND-POSITION: left 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat" vAlign="bottom" background="../../../Images/admin_2bg.gif"><BR>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="16" src="../../../Images/admin_ico2.gif" width="16" border="0"><span id="role_set" runat="server" class="gbtext" style="RIGHT: 1in; WIDTH: 428px; BOTTOM: 1in; HEIGHT: 19px">&nbsp;&nbsp;
											<A href="../../role/Index.aspx?ClassID=<%=ClassID%>" 
            target=main>角色设置</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;添加,删除,修改角色,把人员归入角色,设置角色权限等 </span>
									</TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="60"><FONT face="宋体">
							<TABLE id="Table6" height="50" cellSpacing="0" cellPadding="0" width="550" border="0">
								<TR>
									<TD style="BACKGROUND-POSITION: left 50%; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-REPEAT: no-repeat" vAlign="bottom" background="../../../Images/admin_3bg.gif"><BR>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG height="16" src="../../../Images/admin_ico3.gif" width="16" border="0"><SPAN id="Span2" style="RIGHT: 1in; WIDTH: 419px; BOTTOM: 1in; HEIGHT: 20px" runat="server" class="gbtext">&nbsp;&nbsp;
											<A href="../../WorkAttendance/SearchData.aspx">考勤查询</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;查询所有员工的考勤情况
										</SPAN>
									</TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="middle" height="50"><FONT face="宋体">
							<TABLE id="Table5" height="50" cellSpacing="0" cellPadding="0" width="550" border="0">
								<TR>
									<TD background="../../../Images/admin_4bg.gif" vAlign="bottom" style="BACKGROUND-POSITION:left 50%; BACKGROUND-ATTACHMENT:fixed; BACKGROUND-REPEAT:no-repeat"><BR>
										&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<IMG height="16" src="../../../Images/admin_ico4.gif" width="16" border="0"><SPAN class="gbtext" id="Span1" style="RIGHT: 1in; WIDTH: 417px; BOTTOM: 1in; HEIGHT: 18px" runat="server">&nbsp;&nbsp;
											<A href="../../Staff/ManageStaff.aspx?DisplayType=0">员工列表</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;显示所有的员工
										</SPAN>
									</TD>
								</TR>
							</TABLE>
						</FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

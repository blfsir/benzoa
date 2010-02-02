<%@ Page language="c#" Codebehind="ODepartment.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Department.ODepartment" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ODepartment</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<form id="ODepartment" method="post" runat="server">
			<TABLE id="tabMain" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<TABLE class="gbtext" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="middle" width="90" background="../../images/maillistbutton2.gif" height="24"><FONT face="宋体">职位操作</FONT></TD>
								<TD align="right">
									<asp:LinkButton id="lbAddDepartment" runat="server">创建下级职位</asp:LinkButton>
									<asp:LinkButton id="lbDeleteDepartment" runat="server">删除当前职位</asp:LinkButton>
									<asp:LinkButton id="lbModifyDepartment" runat="server">修改职位</asp:LinkButton>
									<asp:LinkButton id="lbMoveDepartment" runat="server">职位的移动</asp:LinkButton>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD valign="top"><FONT face="宋体">
							<TABLE id="tabAdd" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" height="24" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;上级职位：</FONT></TD>
									<TD id="TD1" runat="server"><FONT face="宋体">&nbsp;
											<asp:Label id="addDepartmentName" runat="server"></asp:Label></FONT></TD>
								</TR>
								<TR>
									<TD height="24" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;职位名称：</FONT></TD>
									<TD><FONT face="宋体">&nbsp;
											<asp:TextBox id="txtADepartmentName" runat="server" CssClass="inputcss" Columns="86"></asp:TextBox>
											<asp:Literal id="litAMessage" runat="server"></asp:Literal></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" valign="top" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;职位简介：</FONT></TD>
									<TD><FONT id="FONT2" face="宋体" runat="server">&nbsp;
											<asp:TextBox id="txtADepartmentRemark" runat="server" CssClass="inputsta" Columns="87" Rows="5" TextMode="MultiLine"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;考勤时间：</FONT></TD>
									<TD>&nbsp;
										<asp:TextBox id="txtOnDutyTime" runat="server" CssClass="inputcss" Columns="10" Rows="5" Width="150px"></asp:TextBox>
										<asp:RegularExpressionValidator id="rev_OnDutyTime" runat="server" ErrorMessage="输入错误" ControlToValidate="txtOnDutyTime" Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator><FONT face="宋体">-</FONT>
										<asp:TextBox id="txtOffDutyTime" runat="server" CssClass="inputcss" Columns="10" Rows="5" Width="150px"></asp:TextBox>
										<asp:RegularExpressionValidator id="rev_OffDutyTime" runat="server" ErrorMessage="输入错误" ControlToValidate="txtOffDutyTime" Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>(hh:mm)</TD>
								</TR>
								<TR>
									<TD colspan="2" align="middle" height="36"><FONT id="FONT1" face="宋体" runat="server"> <INPUT class="ButtonCss " id="cmdAdd" accessKey="o" type="submit" value=" 确 定 " runat="server" size="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdAddReturn" runat="server" CssClass="ButtonCss" Text=" 返 回 "></asp:Button></FONT></TD>
								</TR>
							</TABLE>
							<TABLE id="tabDelete" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" height="24"><FONT face="宋体">&nbsp;删除职位：</FONT></TD>
									<TD>&nbsp;
										<asp:Label id="delDepartmentName" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD colspan="2" align="middle" height="36"><FONT face="宋体"> <INPUT class="ButtonCss" id="cmdDelete" type="submit" value=" 删 除 " runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdDeleteReturn" runat="server" CssClass="ButtonCss" Text=" 返 回 "></asp:Button></FONT></TD>
								</TR>
							</TABLE>
							<TABLE id="tabModify" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff" height="24"><FONT face="宋体">&nbsp;职位名称：</FONT></TD>
									<TD>&nbsp;
										<asp:TextBox id="txtDepartmentName" runat="server" CssClass="inputcss" Columns="90"></asp:TextBox>
										<asp:Literal id="litMMessage" runat="server"></asp:Literal></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" valign="top" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;职位简介：</FONT></TD>
									<TD><FONT face="宋体">&nbsp;
											<asp:TextBox id="txtMDepartmentRemark" runat="server" CssClass="Inputcss" Columns="90" Rows="5" TextMode="MultiLine"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 90px" bgcolor="#e8f4ff"><FONT face="宋体">&nbsp;考勤时间：</FONT></TD>
									<TD><FONT face="宋体">&nbsp;
											<asp:TextBox id="txtuOnDutyTime" runat="server" CssClass="inputsta" Columns="10" Rows="5">9:00</asp:TextBox>
											<asp:RegularExpressionValidator id="rev_uOnDutyTime" runat="server" ErrorMessage="输入错误" ControlToValidate="txtuOnDutyTime" Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>-
											<asp:TextBox id="txtuOffDutyTime" runat="server" CssClass="inputsta" Columns="10" Rows="5">17:00</asp:TextBox>
											<asp:RegularExpressionValidator id="rev_uOffDutyTime" runat="server" ErrorMessage="输入错误" ControlToValidate="txtuOffDutyTime" Display="Dynamic" ValidationExpression="([0-9]|(([0-1][0-9])|([2][[0-3]))):([0-5][0-9])"></asp:RegularExpressionValidator>(hh:mm)</FONT></TD>
								</TR>
								<TR>
									<TD colspan="2" align="middle" height="36">
										<INPUT class="ButtonCss" id="cmdModify" type="submit" value=" 修 改 " runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="cmdModifyReturn" runat="server" CssClass="ButtonCss" Text=" 返 回 "></asp:Button></TD>
								</TR>
							</TABLE>
						</FONT>
						<P><FONT face="宋体">
								<TABLE id="tabMove" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
									<TR>
										<TD style="WIDTH: 90px; HEIGHT: 28px" bgcolor="#e8f4ff">&nbsp;职位名称:</TD>
										<TD style="HEIGHT: 28px">&nbsp;
											<asp:Label id="lblDepartment" runat="server" Width="213px"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 106px" valign="top" bgcolor="#e8f4ff">&nbsp;移动到：</TD>
										<TD>&nbsp;
											<asp:ListBox id="lstDeparment" runat="server" Width="427px" Height="104px"></asp:ListBox></TD>
									</TR>
									<TR>
										<TD colspan="2" align="middle" height="36">
											<asp:Button id="cmdMove" runat="server" CssClass="ButtonCss" Text=" 确 定 "></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="cmdMoveReturn" runat="server" CssClass="ButtonCss" Text=" 返 回 "></asp:Button></TD>
									</TR>
								</TABLE>
							</FONT>
						</P>
					</TD>
				</TR>
			</TABLE>
			-&nbsp;</INPUT>&nbsp;
			<P><FONT face="宋体"></FONT>
			</P>
		</form>
	</BODY>
</HTML>

<%@ Page language="c#" Codebehind="ProjectDetail.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.ProjectDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProjectDetail</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function MoveToTeam(a)
{
	var ret;
	ret = window.showModalDialog("MoveTeam/TreeView.aspx?FromID=<%=classID%>",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");

	
	if(ret>0)
//	frmAddRight.ObjID.value = ret;
	return false;
}
		</script>
		<script language="JavaScript" src="../../Css/tr.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ProjectDetail" method="post" runat="server">
			<table height="345" cellSpacing="0" cellPadding="1" width="100%" align="right" border="0">
				<TBODY>
					<tr>
						<td class="text" vAlign="top" width="100%" height="57">
							<div align="center">
								<table class="GbText" id="AutoNumber7" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="192" cellSpacing="0" cellPadding="0" width="100%" align="center" border="1">
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" width="10%" height="21">项目名称：</td>
										<td colSpan="3" height="21">&nbsp;
											<asp:label id="lblClassName" runat="server" BorderColor="Transparent" Font-Size="XX-Small" Font-Names="Arial"></asp:label></td>
										
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" height="21">开始时间：</td>
										<td width="30%" height="21">&nbsp;
											<asp:label id="lblBuildDate" runat="server"></asp:label></td>
										<td width="14%" height="21">&nbsp; 结束时间：</td>
										<td height="21">&nbsp;
											<asp:label id="lblEndDate" runat="server"></asp:label></td>
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" height="21">完成进度：</td>
										<td colSpan="3" height="21">&nbsp;
											<asp:label id="lblFinishedScale" runat="server"></asp:label></td>
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" height="21">后续任务：</td>
										<td colSpan="3" height="21">&nbsp;
											<asp:label id="lblSubClass" runat="server"></asp:label></td>
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" height="21">上级项目：</td>
										<td height="21">&nbsp;
											<asp:label id="lblParentClassName" runat="server"></asp:label></td>
										<td height="21">&nbsp; 上级负责人：</td>
										<td height="21">&nbsp;
											<asp:label id="lblParentLeader" runat="server"></asp:label></td>
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td align="middle" height="21">项目成员：</td>
										<td height="21">&nbsp;
											<asp:label id="lblMember" runat="server"></asp:label></td>
										<td height="21">&nbsp; 项目负责人：</td>
										<td height="21">&nbsp;
											<asp:label id="lblLeader" runat="server"></asp:label></td>
									</tr>
									<tr onmouseover="high( this );" onmouseout="low( this );">
										<td vAlign="center" align="middle" height="21">项目介绍：</td>
										<td vAlign="center" align="left" colSpan="3" height="21">&nbsp;
											<asp:label id="lblDescription" runat="server"></asp:label></td>
									</tr>
								</table>
							</div>
						</td>
					</tr>
					<tr>
						<td class="text" vAlign="top" width="100%" height="120">
							<P><br>
								<BR>
								&nbsp;<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</FONT><INPUT class="buttonCss" style="WIDTH: 173px; HEIGHT: 20px" type="button" value="返回" onclick="self.location='Project.aspx?ClassID=<%=classID%>';"></P>
							</FONT></td>
					</tr>
					<tr>
						<td class="text" vAlign="top" width="100%" height="120"><FONT face="宋体"></FONT><br>
							<BR>
							<P></P>
							<table id="tblMailList" style="BORDER-COLLAPSE: collapse" borderColor="#cccccc" height="36" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							</table>
						</td>
					</tr>
					<tr>
						<td class="text" vAlign="top" width="100%" height="149"><FONT face="宋体"></FONT><br>
							&nbsp; <A href="#"></A>
							<BR>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>

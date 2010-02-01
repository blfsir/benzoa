<%@ Page language="c#" Codebehind="TreeView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.AssginRule.frmAddRight" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TreeView</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function test()
		{	
			var ret;
			ret = window.showModalDialog("ClassTree.aspx?ClassID=1",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:yes;Status:Yes;Scroll:auto;Status:no;");
	
		}
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="frmAddRight" method="post" runat="server">
			<table id="AutoNumber1" style="BORDER-COLLAPSE: collapse" borderColor="#111111" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td colspan="2">
						<TABLE id="Table1" borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#003366" size="3"><IMG height="16" src="../../DataImages/scales.gif" width="16"></FONT></TD>
								<TD class="GbText" background="../../Images/treetopbg.jpg" bgColor="#c0d9e6"><FONT color="#006699">新增权限</FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<TD vAlign="top" align="middle" width="30%" height="100%" style="WIDTH: 268px"><IFRAME id="ClassList" src="ClassTree.aspx?SrcID=<%Response.Write(SrcID);%>&DisplayType=<%Response.Write(DisplayType);%>" scrolling="no" width="100%" height="100%" style="WIDTH: 106.3%; HEIGHT: 100%">
						</IFRAME>
					</TD>
					<td vAlign="top" align="middle" width="70%" height="100%"><iframe src="RightList.aspx?SrcID=<%Response.Write(SrcID);%>&DisplayType=<%Response.Write(DisplayType);%>" id="RightList" scrolling="no" width="100%" height="100%" name="RightList" frameborder="0" border="0" framespacing="0">
						</iframe>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

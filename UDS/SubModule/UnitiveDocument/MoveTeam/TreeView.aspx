<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" Codebehind="TreeView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.MoveTeam.TreeView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��Ŀ�ƶ�</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function confirmRemove()
	{
	    var parwin = window.dialogArguments;	
	    tdText = TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("Text")
		if(confirm("��ȷ��Ҫ�ƶ�ԭ��Ŀ�� <<"+tdText+">> ?"))
		{
			parwin.location="TreeView.aspx?Action=1&FromID=<%=FromID%>&ToID="+TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("ID");
			window.close();
			parwin.alert('�ƶ��ɹ�!');
			parwin.parent.location.reload();
		}
	}

		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table width="33%" border="0">
			<tr>
				<td>&nbsp;<iewc:treeview id="TreeView1" ondblclick="javascript:confirmRemove()" runat="server"></iewc:treeview></td>
			</tr>
			<tr>
				<td>&nbsp;<FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</FONT><INPUT class="ButtonCss" type="button" value="ȷ��" onclick="confirmRemove()"></td>
			</tr>
		</table>
		<form id="TreeView" method="post" runat="server">
		</form>
	</body>
</HTML>

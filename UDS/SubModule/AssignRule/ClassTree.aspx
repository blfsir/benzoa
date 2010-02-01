<%@ Register TagPrefix="uc1" TagName="ControlProjectTreeView" Src="../../Inc/ControlProjectTreeView.ascx" %>
<%@ Page language="c#" Codebehind="ClassTree.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.AssginRule.ClassTree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClassTree</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function GetValue()
		{
			var pwindow = window.dialogArguments;
			//alert( CustomTreeView.getTreeNode(CustomTreeView.selectedNodeIndex).getAttribute("ID"));
			pwindow.document.all.ObjID.value = TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("ID");
			pwindow.document.all.ObjectName.value = TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("Text");
			close();
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="ClassTree" method="post" runat="server">
			<iewc:treeview id="TreeView1" runat="server"></iewc:treeview>
			<P><FONT face="ËÎÌו"></FONT></P>
			</FONT></form>
	</body>
</HTML>

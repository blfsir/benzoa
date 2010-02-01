<%@ Page language="c#" Codebehind="TreeView.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Mail.TreeView" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TreeView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript">
		window.onerror = function(){return true;}
		function confirmSelect()
	{
	    var parwin = window.dialogArguments;	
	    tdText = TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("Text");
	    tdID   = TreeView1.getTreeNode(TreeView1.selectedNodeIndex).getAttribute("ID");
		if(parwin.ReadMail!=null)
		{
			if(confirm("您确认要选择 <<"+tdText+">> ?"))
			{	
				parwin.location='ReadMail.aspx?Action=3&ClassID='+tdID+'&MailID='+parwin.ReadMail.hdnMailID.value;
				window.close();
			}
			
		}
		if(confirm("您确认要选择 <<"+tdText+">> ?"))
		{
			parwin.document.all.txtProjectName.value=tdText;
			parwin.document.all.hdnProjectID.value=tdID;
			window.close();
		
		}
	}

		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table width="33%" border="0">
			<tr>
				<td>&nbsp;
					<iewc:TreeView id="TreeView1" runat="server" ondblclick="javascript:confirmSelect()"></iewc:TreeView></td>
			</tr>
			<tr>
				<td>&nbsp;<FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</FONT><INPUT class="ButtonCss" type="button" value="确定" onclick="confirmSelect()"></td>
			</tr>
		</table>
		<form id="TreeView" method="post" runat="server">
		</form>
	</body>
</HTML>

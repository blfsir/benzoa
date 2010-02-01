<%@ Page language="c#" Codebehind="StaffList.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.CM.StaffList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StaffList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language=javascript>
		function Execute()
		{
			alert(opener.document.ClientContact.lbx_Cooperater.options.length);
			//opener.document.ClientContact.lbx_Cooperater.options.add(new Option("2", "2"));
			/*
			for(var i=0;i<document.StaffList.lbx_Staff.options.length;i++)
			{
				if(document.StaffList.lbx_Staff.options[i].selected)
				{
					var oOption = document.createElement("OPTION");
					oOption.innerText = document.StaffList.lbx_Staff.options[i].text;
					oOption.Value = document.StaffList.lbx_Staff.options[i].value;
					//opener.document.ClientContact.lbx_Cooperater.options.add(oOption);
					

				}
			}	
		*/
		}
		</script>
	</HEAD>
	<body>
		<form id="StaffList" method="post" runat="server">
			<FONT face="ËÎÌו">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
					<TR>
						<TD>
							<asp:ListBox id="lbx_Staff" runat="server" Width="203px" Height="208px" SelectionMode="Multiple"></asp:ListBox></TD>
					</TR>
					<TR>
						<TD>
							<INPUT type="button" value="Button" onclick="Execute();"></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

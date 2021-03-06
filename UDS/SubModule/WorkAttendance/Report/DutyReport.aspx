<%@ Page language="c#" Codebehind="DutyReport.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance.Report.DutyReport" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>打印报表</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		function displayoptionlabel()
		{
			var obj = document.getElementById('div_opt');
			if(obj != null)
				if(document.getElementById('div_opt').style.display != "none")
				{
					
					var left = parseInt(obj.style.left.substring(0,obj.style.left.length-2));
					var top = parseInt(obj.style.top.substring(0,obj.style.top.length-2));
					var width = parseInt(obj.style.width.substring(0,obj.style.width.length-2));
					var height = parseInt(obj.style.height.substring(0,obj.style.height.length-2));
					if( (event.x>(left+width)) || (event.y<top-80) || (event.y>top+height+20))
					{
						//alert('1');
						document.getElementById('div_opt').style.display = "none";
					}
				
				}
				else
				{
					if(event.x<10)
					{
						document.getElementById('div_opt').style.display = "";
						document.getElementById('div_opt').style.left= event.x;
						document.getElementById('div_opt').style.top= event.y;
					}
					else
					{
						document.getElementById('div_opt').style.display = "none";
					}
				}
				
				//obv.innerText = "event.x="+event.x+" event.y="+event.y+" left:"+left+" width:"+width+" left+width:"+(left+width)+" top:"+top+" top+height:"+(top+height);
			
		}
		</script>
	</HEAD>
	<body  MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<cr:crystalreportviewer id="cv_Duty" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
					Height="50px" Width="350px" DisplayGroupTree="False"></cr:crystalreportviewer>
				<DIV id="div_opt" style="DISPLAY: none; Z-INDEX: 102; LEFT: 320px; WIDTH: 400px; POSITION: absolute; TOP: 288px; HEIGHT: 40px"
					ms_positioning="FlowLayout">&nbsp;
					<asp:LinkButton id="lbtn_IEPrint" runat="server">IE打印预览</asp:LinkButton>&nbsp;格式转换
					<asp:DropDownList id="ddl_FileFormat" runat="server">
						<asp:ListItem Value="pdf">Pdf</asp:ListItem>
						<asp:ListItem Value="doc">Word</asp:ListItem>
					</asp:DropDownList>
					<asp:Button id="btn_Change" runat="server" Text="转换"></asp:Button>
				</DIV>
			</FONT>
		</form>
	</body>
</HTML>

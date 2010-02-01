<%@ Page language="c#" Codebehind="ShowDay.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.WorkAttendance.ShowDay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>考勤日期设置</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="jscript">
		function Click_Cell(object)
		{
			
			if(object.style.backgroundColor.toUpperCase()=='<%=indaycolor%>'.toUpperCase()) 
				object.style.backgroundColor = '<%=outdaycolor%>';
			else 
				object.style.backgroundColor = '<%=indaycolor%>';
			
			//alert(object.style.backgroundColor);
			//数据格式采用ID:n,{ID:n....}（n双数上班，单数休息）
			var innerstring;
			innerstring = document.ShowDay.hcellstatus.value;
			//遍历ID找到是否存在该ID,如果有就修改VALUE，没有就添加VALUE=0
			var arr = innerstring.split(",");
			var arrtmp;
			var re = /\d+/;//匹配id
			var re1 = /:\w+/;//匹配n
			var n,tmpstr;
			var havefound = false;//找到了匹配项
			for(var i=0;i<arr.length;i++)
			{
				arrtmp = arr[i].match(re);
			//	if(arrtmp!=null)
			//		alert("|"+arrtmp[0]+"|"+object.id+"|");
				if((arrtmp != null)&&(arrtmp[0]==object.id))//找到匹配项
				{
					//alert("找到匹配项"+"|"+arrtmp[0]+"|"+object.id);
					n = arr[i].match(re1);
					n = n[0].substr(1);
					n = ":"+String(parseInt(n)+1);
					tmpstr = arr[i].replace(re1,n);
					document.ShowDay.hcellstatus.value=innerstring.replace(arr[i],tmpstr);
					havefound = true;
					break;
				}	
				
			}
			if(!havefound)//没有找到匹配项，添加字符串
			{
				//alert(object.style.backgroundColor);
				if(object.style.backgroundColor.toUpperCase()=='<%=indaycolor%>'.toUpperCase())
					innerstring = object.id + ":0,";
				else
					innerstring = object.id + ":1,";
				document.ShowDay.hcellstatus.value += innerstring;	
				//alert(document.ShowDay.hcellstatus.value);
			}
			
			//alert(object.style.backgroundColor);
		
		}
		
		function Top_Click(cellnumber)
		{
			for(var i=0;i<daytable.rows.length;i++)
			{
				daytable.rows[i].cells[cellnumber].click();
			
			}
		}
		</script>
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form id="ShowDay" method="post" runat="server">
			<FONT face="宋体">
				<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111"
					width="100%" height="1">
					<tr height="30">
						<td width="3%" bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg"><font color="#006699" size="3"><img src="../..//DataImages/page.gif" width="16" height="16"></font></td>
						<td bgcolor="#c0d9e6" class="GbText" background="../../Images/treetopbg.jpg"><b>考勤设置</b></td>
					</tr>
				</table>
				<TABLE id="daytable" cellSpacing="0" cellPadding="0" width="100%" align="center" border="1"
					runat="server" class="gbtext" style="BORDER-COLLAPSE: collapse" bordercolor="#93bee2">
					<TR height="30">
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(0)" onmouseover="this.title='点击改变整列'"
							title="点击修改整列" bgcolor="#e8f4ff">星期一</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(1)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期二</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(2)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期三</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(3)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期四</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(4)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期五</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(5)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期六</TD>
						<TD align="center" style="CURSOR: hand" onclick="Top_Click(6)" onmouseover="this.title='点击改变整列'"
							bgcolor="#e8f4ff">星期日</TD>
					</TR>
				</TABLE>
			</FONT>
			<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" width="100%">
				<tr height="30">
					<td class="GbText">
						<TABLE id="Table1" height="24" cellSpacing="0" cellPadding="0" width="200" class="gbtext"
							style="BORDER-COLLAPSE: collapse" border="1" bordercolor="#e8e8e8">
							<TR>
								<TD bgColor="#ebffe5" width="100" align="center"><FONT face="宋体">工作日</FONT></TD>
								<TD bgColor="#ffffef" width="100" align="center"><FONT face="宋体">休息日</FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr height="30">
					<td class="GbText" align="center">
						<asp:button id="btnsubmit" runat="server" Text=" 确 认 " CssClass="buttoncss"></asp:button>
						<INPUT id="hcellstatus" type="hidden" runat="server">
						<asp:button id="lblMessage" runat="server" CssClass="buttoncss" Text="修改成功" Visible="False"
							BorderWidth="0px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

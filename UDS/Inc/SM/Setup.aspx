<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>短消息设置</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function SetCookie(sName, sValue)
		{
			var parwin = window.dialogArguments;
			parwin.document.cookie = sName + "=" + escape(sValue) + "; ";
		}
	
		function GetCookie(sName)
		{
			var parwin = window.dialogArguments;
			var aCookie = parwin.document.cookie.split("; ");
			for (var i=0; i < aCookie.length; i++)
			{
				
				var aCrumb = aCookie[i].split("=");
				if (sName == aCrumb[0]) 
				return unescape(aCrumb[1]);
			}
			
		}
			
		function SetInit()
		{	
			this.document.all.Setup.yes.focus();
			if(GetCookie("UDS_RefreshTime")==null)
			{
				this.document.all.Setup.radiobutton[0].checked=true;
			}
			else
			{
				for(i=0;i<this.document.all.Setup.radiobutton.length;i++)
				{
					if(GetCookie("UDS_RefreshTime")==this.document.all.Setup.radiobutton[i].value*60000)
					{
						this.document.all.Setup.radiobutton[i].checked=true;
					}
				}
			}
			
			
			if(GetCookie("UDS_RemindType")==null)
			{
				this.document.all.Setup.radiobutton1[0].checked=true;
			}
			else
			{
				for(i=0;i<this.document.all.Setup.radiobutton1.length;i++)
				{
					if(GetCookie("UDS_RemindType")==this.document.all.Setup.radiobutton1[i].value)
					{
						this.document.all.Setup.radiobutton1[i].checked=true;
					}
				}
			}
				
		}
		
		function FinishSetup()
		{
			for(i=0;i<this.document.all.Setup.radiobutton.length;i++)
				{
					if(this.document.all.Setup.radiobutton[i].checked==true)
					{
						SetCookie("UDS_RefreshTime",this.document.all.Setup.radiobutton[i].value*60000);
						
					}
				}
				
			for(i=0;i<this.document.all.Setup.radiobutton1.length;i++)
				{
					if(this.document.all.Setup.radiobutton1[i].checked==true)
					{
						SetCookie("UDS_RemindType",this.document.all.Setup.radiobutton1[i].value);
						
					}
				}
			window.dialogArguments.location.reload();	
			window.close();
		}
		</script>
	</HEAD>
	<body onload="SetInit()" MS_POSITIONING="GridLayout">
		<form id="Setup" method="post">
			<table class="GbText" width="90%" border="0">
				<tr>
					<td width="20%"><font color="#ff9966">&nbsp; 短消息设置</font></td>
					<td></td>
				</tr>
				<tr>
					<td width="20%">&nbsp;&nbsp;设置提醒时间</td>
					<td><input type="radio" value="0.5" name="radiobutton">0.5分钟 <input type="radio" value="1" name="radiobutton">1分钟
						<input type="radio" value="2" name="radiobutton">2分钟 <input type="radio" value="3" name="radiobutton">3分钟
						<input type="radio" value="4" name="radiobutton">4分钟 <input type="radio" value="5" name="radiobutton">5分钟
					</td>
				</tr>
				<tr>
					<td width="20%">&nbsp;&nbsp;设置提醒方式</td>
					<td><input type="radio" value="1" name="radiobutton1"> 弹出窗口 <input type="radio" value="2" name="radiobutton1">
						闪烁图标
					</td>
				</tr>
				<tr>
					<td width="20%"></td>
					<td><br>
						<input class="redButtonCss" style="WIDTH: 112px; HEIGHT: 20px" onclick="FinishSetup()"
							type="button" value="确               定" name="yes">&nbsp;&nbsp;&nbsp;&nbsp;<input class="redButtonCss" style="WIDTH: 112px; HEIGHT: 20px" onclick="window.close()"
							type="button" value="取               消" name="no">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

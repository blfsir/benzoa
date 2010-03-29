<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetMove.aspx.cs" Inherits="UDS.SubModule.Asset.AssetMove" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeDepartment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="../../Css/BasicLayout.css" type="text/css">
	</HEAD>
	
 <script language="javascript">
			function dialwinprocess(txtName)
			{
				var newdialoguewin = window.showModalDialog("../Position/SelectStaff.aspx?txtName="+txtName,window,"dialogWidth:600px;DialogHeight=490px;status:no");
				if(newdialoguewin!=null){
					if(newdialoguewin.length>5)
					{
						ReceiverTypeArray = newdialoguewin.split("|");
						SendToArray = ReceiverTypeArray[0].split("-");
						MobileSendToArray = ReceiverTypeArray[1].split("-");
						try{
							this.document.MsgSend.txtSendTo.value = SendToArray[0];
							//this.document.MsgSend.txtMobileSendTo.value = MobileSendToArray[0];
						}
						catch(e){}
						
						
					}
				}
			}
			
			function SendMsg()
			{
				if(event.keyCode==10)
				{
					document.MsgSend.btnSend.click();
				}
			}
		</script>
			
	<%--<body>
		<form id="ChangeDepartment" method="post" runat="server">
			<span class="BlueTextBX"><font face="楷体_GB2312" color="#0000ff" size="5">
					<CENTER><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<br>
						<STRONG><U>设备转移到</U></STRONG>
				</font></span><font face="楷体_GB2312" color="#0000ff"><STRONG><U></U></STRONG></font>
			<br>
			<br>
			<asp:Label id="Label1" runat="server" Width="140px" Height="18px" Font-Size="X-Small">请选择要转移到的人员:</asp:Label>
			<asp:DropDownList ID="ddlBuyUser" runat="server">
                    </asp:DropDownList>
                    <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="" name="txtSendTo"><A onclick="dialwinprocess('txtSendTo')" href="#"><img src="../../DataImages/staff.gif" border="0"><FONT face="宋体">选择人员</FONT></A>
			<select id="cboPosition" style="WIDTH:408px; HEIGHT:261px" size="1" runat="server" EnableViewState="true">
			</select></CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>
				<input type="submit" value="确 定" id="cmdSubmit" OnClick="SubmitMe()" class="redButtonCss"
					runat="server">&nbsp;&nbsp; <input type="button" value="返 回" name="cmdReturn" OnClick="history.back()" class="redButtonCss">
			</CENTER>
			<CENTER>
				<CENTER>
					<asp:CheckBox id="cbRemind" runat="server" Font-Size="X-Small" Height="16px" Width="240px" Text="站内短消息提醒(提醒公司全体员工)"></asp:CheckBox></CENTER>
				<br>
			</CENTER>
		</form>
	</body>--%>
	
	<body leftmargin="0" topmargin="0">
    <form id="AssetMove" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                设备转移
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                   &nbsp;</font>
            </td>
        </tr>
    </table>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1">
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="10" colspan="3" align="center">
                        </td>
                    </tr>
                     
                </table>
            </td>
        </tr>
        <tr>
            <td style="line-height: 20px;">
                <span class="BlueTextBX"><font face="楷体_GB2312" color="#0000ff" size="5">
					<CENTER><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<br>
						<STRONG><U>设备转移到</U></STRONG>
				</font></span><font face="楷体_GB2312" color="#0000ff"><STRONG><U></U></STRONG></font>
			<br>
			<br>
			<asp:Label id="Label1" runat="server" Width="140px" Height="18px" Font-Size="X-Small">请选择要转移到的人员:</asp:Label>
			<asp:DropDownList ID="ddlMoveTo" runat="server">
                    </asp:DropDownList>
                    <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="" name="txtMoveAsset"><A onclick="dialwinprocess('txtMoveAsset')" href="#"> <FONT face="宋体">选择人员</FONT></A> </CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER>&nbsp;</CENTER>
			<CENTER><asp:Button ID="btnSubmit" runat="server" class="redButtonCss" Text="确定" 
                    onclick="btnSubmit_Click" />
				&nbsp;&nbsp; <input type="button" value="返 回" name="cmdReturn" OnClick="history.back()" class="redButtonCss">
			</CENTER>
			<CENTER>
				<CENTER>
					</CENTER>
				<br>
			</CENTER>
            </td>
        </tr>
        </td></tr></table>
    </form>
</body>
</HTML>

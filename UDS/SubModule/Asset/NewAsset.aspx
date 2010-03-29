<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAsset.aspx.cs" Inherits="UDS.SubModule.Asset.NewAsset" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewAsset</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

    <script language="JavaScript" src="../../Css/meizzDate.js"></script>

    <style>
        .td
        {
            font-size: 14px;
            color: #0000ff;
        }
    </style>
    
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

  

</head>
<body leftmargin="0" topmargin="0">
    <form id="MsgSend"  method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" style="table-layout:fixed"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/t5.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">新增IT设备</font>
            </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    资产名称:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入名称" ControlToValidate="txtName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal><asp:TextBox ID="lblAssetID" runat="server" Width="0px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    规格及型号:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    数量:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtNumber" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    原使用人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlOriginalUser" runat="server">
                    </asp:DropDownList>
                      <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="" name="txtOriginalUser"><A onclick="dialwinprocess('txtOriginalUser')" href="#"> <FONT face="宋体">选择人员</FONT></A>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    原使用人部门:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlOriginalDept" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    现使用人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlCurrentUser" runat="server">
                    </asp:DropDownList>
                      <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="" name="txtCurrentUser"><A onclick="dialwinprocess('txtCurrentUser')" href="#"> <FONT face="宋体">选择人员</FONT></A>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    现使用人部门:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlCurrentDept" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    现存放地点:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlLocation" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    现使用状况:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlUseState" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    采购申请人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:DropDownList ID="ddlBuyUser" runat="server">
                    </asp:DropDownList>
                    <INPUT class=InputCss readOnly style="display:none;" type=text size=50 value="<%=SendToRealName%>" name="txtSendTo"><A onclick="dialwinprocess('txtSendTo')" href="#"> <FONT face="宋体">选择人员</FONT></A>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    采购日期:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtBuyDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="382" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    变动日期:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtMoveDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="382" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    保修期限:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtWarrantyPeriod" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <%--<tr >
                <td style="height: 34px" align="right" width="20%" height="34">
                    附件:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox13" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                            runat="server" ErrorMessage="请输入附件" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal13" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>--%>
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="宋体">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" 
                        Width="60px" Text="确定"
                            Height="20px" onclick="cmdSubmit_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="redButtonCss" style="width: 60px; height: 20px"  
                            type="button" value="返 回" name="cmdReturn" onclick="javascript:location.href='AssetMange.aspx'">
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

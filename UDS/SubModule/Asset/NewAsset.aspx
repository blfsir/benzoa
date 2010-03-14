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
		function ReturnBack(ReturnType)
		{			
			if(ReturnType==0)
				location.href ="ListView.aspx?Position_ID=<%=PositionID%>";	
			else
				location.href ="../Staff/ManageStaff.aspx";			
		}
		
		



原使用人部门
现使用人
现使用人部门
现存放地点
现使用状况
采购申请人
采购日期
变动日期
保修期限
附件


    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewStaff" method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font>
                </td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <b><b><b><font face="宋体">新增IT设备</font></b></b></b>
                </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    资产名称:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtStaffName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
             
             
             <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    规格及型号:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox1" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="请输入规格及型号" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    数量:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox2" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ErrorMessage="请输入数量" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    原使用人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox3" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ErrorMessage="请输入原使用人" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal3" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    原使用人部门:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox4" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ErrorMessage="请输入原使用人部门" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal4" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    现使用人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox5" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                            runat="server" ErrorMessage="请输入现使用人" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal5" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    现使用人部门:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox6" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                            runat="server" ErrorMessage="请输入现使用人部门" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal6" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    现存放地点:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox7" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                            runat="server" ErrorMessage="请输入现存放地点" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal7" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    现使用状况:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox8" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                            runat="server" ErrorMessage="请输入现使用状况" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal8" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    采购申请人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox9" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                            runat="server" ErrorMessage="请输入姓名采购申请人" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal9" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    采购日期:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox10" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                            runat="server" ErrorMessage="请输入采购日期" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal10" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    变动日期:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox11" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                            runat="server" ErrorMessage="请输入变动日期" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal11" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
             
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    保修期限:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox12" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                            runat="server" ErrorMessage="请输入保修期限" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal12" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            
             
            <tr bgcolor="#e8f4ff"><td style="height: 34px" align="right" width="20%" height="34">
                    附件:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="TextBox13" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                            runat="server" ErrorMessage="请输入附件" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="Literal13" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
             
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="宋体">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" Width="60px" Text="确定"
                            Height="20px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="redButtonCss" style="width: 60px; height: 20px" onclick="ReturnBack(<%=ReturnPage%>)"
                            type="button" value="返 回" name="cmdReturn">
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

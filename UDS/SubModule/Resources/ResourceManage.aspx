<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceManage.aspx.cs"
    Inherits="UDS.SubModule.Resources.ResourceManage" %>

<html>
<head>
    <title>ManageResources</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<%--<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="ManageStaff" method="post" runat="server">
    <font face="宋体">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tbody>
                            <tr height="30">
                                <td class="GbText" width="80" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                                    align="right">
                                    <img height="16" src="../../DataImages/staff.gif" width="16" /><font color="#006699">资源管理</font>
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                    align="right">
                                    &nbsp;
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right"
                                    width="85%">
                                </td>
                </td>
            </tr>
        </table>
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr>
                        <td align="left" width="90" height="24">
                            <font face="宋体">
                                <input type="button" class="redButtonCss" value="会议查询" onclick="javacript:location.href='../Meeting/MeetingManage.aspx'" />
                            </font>
                        </td>
                        <td align="left" width="90" height="24">
                            <font face="宋体">
                                <input type="button" class="redButtonCss" value="车辆查询" onclick="javacript:location.href='../Vehicle/VehicleManage.aspx'" /></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="90" height="24">
                            <font face="宋体">
                                <input type="button" class="redButtonCss" value="会议类型设置" onclick="javacript:location.href='../Meeting/MeetingTypeManage.aspx'" /></font>
                        </td>
                        <td align="left" width="90" height="24">
                            <font face="宋体">
                                <input type="button" class="redButtonCss" value="车辆管理" onclick="javacript:location.href='../Vehicle/CarManage.aspx'" />
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="90" height="24">
                            <font face="宋体">
                                <input type="button" class="redButtonCss" value="会议室设置" onclick="javacript:location.href='../Meeting/MeetingRoomManage.aspx'" /></font>
                        </td>
                        <td align="left" width="90" height="24">
                            <font face="宋体">&nbsp;</font>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
        </TABLE> </font>
    </form>
</body>--%>

<body leftmargin="0" topmargin="0">
    <form id="Listview" method="post" runat="server">
    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0" style="table-layout:fixed"
        bordercolor="#111111">
        <tr height="30">
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                align="center">
                <font color="#006699">资源管理</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                  <input type="button" class="redButtonCss" value="会议查询" onclick="javacript:location.href='../Meeting/MeetingManage.aspx'" />
                    <input type="button" class="redButtonCss" value="会议类型设置" onclick="javacript:location.href='../Meeting/MeetingTypeManage.aspx'" />
                    <input type="button" class="redButtonCss" value="会议类型设置" onclick="javacript:location.href='../Meeting/MeetingTypeManage.aspx'" />
                    <input type="button" class="redButtonCss" value="会议室设置" onclick="javacript:location.href='../Meeting/MeetingRoomManage.aspx'" />
                   <input type="button" class="redButtonCss" value="车辆查询" onclick="javacript:location.href='../Vehicle/VehicleManage.aspx'" /> 
                    <input type="button" class="redButtonCss" value="车辆管理" onclick="javacript:location.href='../Vehicle/CarManage.aspx'" />&nbsp;
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
                
            </td>
        </tr>
       </table>
    </form>
</body>
</html>

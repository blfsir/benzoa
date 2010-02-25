<%@ Page Language="c#" CodeBehind="ApplyMeeting.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Meeting.ApplyMeeting" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ApplyMeeting</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	<script language="JavaScript" src="../../Css/meizzDate1.js"></script>
    
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
			//location.href ="NoteManage.aspx";			
		}
		
		function onChangDate()
		{
		    var strdate=document.getElementById("txtBeginTime").value;
		    document.getElementById("spanRq").innerHTML=strdate;
		    var obj=UDS.SubModule.Meeting.ApplyMeeting.GetMeetingInfo(strdate);
		    document.getElementById("divZhanyong").innerHTML=obj.value;
		}
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="ApplyMeeting" method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font>
                </td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <b><b><b><font face="宋体">会议申请</font></b></b></b>
                </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr bgcolor="#e8f4ff">
                <td style="height:20px" colspan=4>
                <table style="font-size:9pt;"><tr><td >会议室占用情况[<span id="spanRq" runat=server>2010-2-4</span>]&nbsp;</td><td><div style="width:15px;background-color:Red;"></div></td><td>&nbsp;占用</td></tr></table></td>
            </tr>
            <tr>
            <td colspan=4>
            <div style="width:100%;height:120px;overflow-y:scroll;" id="divZhanyong" runat=server>
            </div>
            </td>
            </tr>
            
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px;" align="right" width="15%" height="34">
                    会议类型:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<%--<asp:TextBox ID="txtMeetingType" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>--%>
                    <asp:DropDownList ID="ddlMeetingType" runat="server" Width="230">
                    </asp:DropDownList>
                </td>
                <td style="height: 34px" align="right" width="15%" height="34">
                    会议主题:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtMeetingSubject" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 34px" align="right"  height="34">
                    主办部门:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtDepartment" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td style="height: 34px" align="right"  height="34">
                    会 议 室:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<%--<asp:TextBox ID="txtMeetingRoom" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlMeetingRoom" runat="server" Width="230">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right"  height="34">
                    开始时间:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtBeginTime" onfocus="setday(this);" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ReadOnly="True" onchange="onChangDate();"></asp:TextBox>
                    <asp:DropDownList ID="ddlHour1" runat="server" CssClass="InputCss">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                    </asp:DropDownList>时
                    <asp:DropDownList ID="ddlMinute1" runat="server" CssClass="InputCss">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>分
                </td>
                <td style="height: 34px" align="right"  height="34">
                    结束时间:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtEndTime" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ReadOnly="True"></asp:TextBox>
                     <asp:DropDownList ID="ddlHour2" runat="server" CssClass="InputCss">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                    </asp:DropDownList>时
                    <asp:DropDownList ID="ddlMinute2" runat="server" CssClass="InputCss">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                    </asp:DropDownList>分
                </td>
            </tr>
            <tr>
                <td style="height: 34px" align="right"  height="34">
                    主 持 人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtHost" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td style="height: 34px" align="right"  height="34">
                    纪 要 员:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtRecorder" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right"  height="34">
                    参 会 人:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtEnterPeople" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="height: 34px" align="right"  height="34">
                    其他资源:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtOtherResources" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right"  height="30">
                    会议内容:
                </td>
                <td height="30" colspan=3>
                    &nbsp;<asp:TextBox ID="txtMeetingContents" CssClass="InputCss" runat="server" Columns="70"
                        Width="772px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="4" height="35">
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

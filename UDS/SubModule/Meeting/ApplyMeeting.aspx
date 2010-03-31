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
		
		/*
去处空格
*/
String.prototype.Trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

		//提交时验证
    function DoValidate()
    {
        //会议主题
        var MeetingSubject = document.getElementById("txtMeetingSubject").value.Trim();
        if(MeetingSubject=="" || MeetingSubject ==null)
        {
             alert('会议主题不可为空！');
             return false;
        }
        
        //主办部门
        var Department = document.getElementById("txtDepartment").value.Trim();
        if(Department=="" || Department ==null)
        {
             alert('主办部门不可为空！');
             return false;
        }
        
        //开始时间
        var BeginTime = document.getElementById("txtBeginTime").value.Trim();
        if(BeginTime=="" || BeginTime ==null)
        {
             alert('开始时间不可为空！');
             return false;
        } 
        
        //结束时间
        var EndTime = document.getElementById("txtEndTime").value.Trim();
        if(EndTime=="" || EndTime ==null)
        {
             alert('结束时间不可为空！');
             return false;
        }
        
        //主持人
        var Host = document.getElementById("txtHost").value.Trim();
        if(Host=="" || Host ==null)
        {
             alert('主持人不可为空！');
             return false;
        }
        //
        //纪 要 员
        var Recorder = document.getElementById("txtRecorder").value.Trim();
        if(Recorder=="" || Recorder ==null)
        {
             alert('纪要员不可为空！');
             return false;
        }
        //参 会 人
        var EnterPeople = document.getElementById("txtEnterPeople").value.Trim();
        if(EnterPeople=="" || EnterPeople ==null)
        {
             alert('参会人不可为空！');
             return false;
        }
        //会议内容
        var MeetingContents = document.getElementById("txtMeetingContents").value.Trim();
        if(MeetingContents=="" || MeetingContents ==null)
        {
             alert('会议内容不可为空！');
             return false;
        }
        return true;
    }
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="ApplyMeeting" method="post" runat="server">
    <center>
         <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                <font color="#006699">会议申请</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                  &nbsp;</font>
            </td>
        </tr>
    </table>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="10"></td>
          </tr>
        </table>
        <table width="98%" border="1" align="center" cellpadding="0"
            cellspacing="0" bordercolor="#93bee2" class="gbtext" id="AutoNumber1" style="border-collapse: collapse" runat="server">
<tr bgcolor="#e8f4ff">
                <td height="30" colspan=4>
                <table style="font-size:9pt;"><tr><td >会议室占用情况[<span id="spanRq" runat=server>2010-2-4</span>]&nbsp;</td><td><div style="width:15px;background-color:Red;"></div></td><td>&nbsp;占用</td></tr></table></td>
        </tr>
            <tr>
            <td colspan=4>
            <div style="width:100%;height:120px;overflow-y:scroll;" id="divZhanyong" runat=server>
            </div>
            </td>
            </tr>
            
            <tr bgcolor="#e8f4ff">
                <td align="center" width="120" height="34">
                    会议类型:
                </td>
                <td height="34" bgcolor="#e8f4ff">
                    &nbsp;<%--<asp:TextBox ID="txtMeetingType" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>--%>
                    <asp:DropDownList ID="ddlMeetingType" runat="server" Width="230">
                  </asp:DropDownList>
              </td>
                <td align="center" width="120" height="34">
                    会议主题:
              </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtMeetingSubject" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120"  height="34" align="center">
                    主办部门:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtDepartment" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    会 议 室:
                </td>
                <td height="34">
                    &nbsp;<%--<asp:TextBox ID="txtMeetingRoom" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlMeetingRoom" runat="server" Width="230">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td width="120"  height="34" align="center">
                    开始时间:
                </td>
                <td height="34">
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
                <td width="120"  height="34" align="center">
                    结束时间:
                </td>
                <td height="34">
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
                <td width="120"  height="34" align="center" >
                    主 持 人:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtHost" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    纪 要 员:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtRecorder" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td width="120"  height="34" align="center" >
                    参 会 人:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtEnterPeople" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    其他资源:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtOtherResources" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120"  height="30" align="center">
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
                            Height="20px" OnClientClick="return DoValidate();"></asp:Button>
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

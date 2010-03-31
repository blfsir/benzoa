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
ȥ���ո�
*/
String.prototype.Trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

		//�ύʱ��֤
    function DoValidate()
    {
        //��������
        var MeetingSubject = document.getElementById("txtMeetingSubject").value.Trim();
        if(MeetingSubject=="" || MeetingSubject ==null)
        {
             alert('�������ⲻ��Ϊ�գ�');
             return false;
        }
        
        //���첿��
        var Department = document.getElementById("txtDepartment").value.Trim();
        if(Department=="" || Department ==null)
        {
             alert('���첿�Ų���Ϊ�գ�');
             return false;
        }
        
        //��ʼʱ��
        var BeginTime = document.getElementById("txtBeginTime").value.Trim();
        if(BeginTime=="" || BeginTime ==null)
        {
             alert('��ʼʱ�䲻��Ϊ�գ�');
             return false;
        } 
        
        //����ʱ��
        var EndTime = document.getElementById("txtEndTime").value.Trim();
        if(EndTime=="" || EndTime ==null)
        {
             alert('����ʱ�䲻��Ϊ�գ�');
             return false;
        }
        
        //������
        var Host = document.getElementById("txtHost").value.Trim();
        if(Host=="" || Host ==null)
        {
             alert('�����˲���Ϊ�գ�');
             return false;
        }
        //
        //�� Ҫ Ա
        var Recorder = document.getElementById("txtRecorder").value.Trim();
        if(Recorder=="" || Recorder ==null)
        {
             alert('��ҪԱ����Ϊ�գ�');
             return false;
        }
        //�� �� ��
        var EnterPeople = document.getElementById("txtEnterPeople").value.Trim();
        if(EnterPeople=="" || EnterPeople ==null)
        {
             alert('�λ��˲���Ϊ�գ�');
             return false;
        }
        //��������
        var MeetingContents = document.getElementById("txtMeetingContents").value.Trim();
        if(MeetingContents=="" || MeetingContents ==null)
        {
             alert('�������ݲ���Ϊ�գ�');
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
                <font color="#006699">��������</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="����">
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
                <table style="font-size:9pt;"><tr><td >������ռ�����[<span id="spanRq" runat=server>2010-2-4</span>]&nbsp;</td><td><div style="width:15px;background-color:Red;"></div></td><td>&nbsp;ռ��</td></tr></table></td>
        </tr>
            <tr>
            <td colspan=4>
            <div style="width:100%;height:120px;overflow-y:scroll;" id="divZhanyong" runat=server>
            </div>
            </td>
            </tr>
            
            <tr bgcolor="#e8f4ff">
                <td align="center" width="120" height="34">
                    ��������:
                </td>
                <td height="34" bgcolor="#e8f4ff">
                    &nbsp;<%--<asp:TextBox ID="txtMeetingType" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="����������" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>--%>
                    <asp:DropDownList ID="ddlMeetingType" runat="server" Width="230">
                  </asp:DropDownList>
              </td>
                <td align="center" width="120" height="34">
                    ��������:
              </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtMeetingSubject" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120"  height="34" align="center">
                    ���첿��:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtDepartment" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    �� �� ��:
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
                    ��ʼʱ��:
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
                    </asp:DropDownList>ʱ
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
                    </asp:DropDownList>��
                </td>
                <td width="120"  height="34" align="center">
                    ����ʱ��:
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
                    </asp:DropDownList>ʱ
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
                    </asp:DropDownList>��
                </td>
            </tr>
            <tr>
                <td width="120"  height="34" align="center" >
                    �� �� ��:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtHost" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    �� Ҫ Ա:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtRecorder" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td width="120"  height="34" align="center" >
                    �� �� ��:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtEnterPeople" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td width="120"  height="34" align="center">
                    ������Դ:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtOtherResources" CssClass="InputCss" runat="server" Columns="70"
                        Width="230" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120"  height="30" align="center">
                    ��������:
                </td>
                <td height="30" colspan=3>
                    &nbsp;<asp:TextBox ID="txtMeetingContents" CssClass="InputCss" runat="server" Columns="70"
                        Width="772px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="4" height="35">
                    <font face="����">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" Width="60px" Text="ȷ��"
                            Height="20px" OnClientClick="return DoValidate();"></asp:Button>
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>

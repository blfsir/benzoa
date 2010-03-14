<%@ Page Language="c#" CodeBehind="ApplyVehicle.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Vehicle.ApplyVehicle" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ApplyVehicle</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
	<script language="JavaScript" src="../../Css/meizzDate2.js"></script>
    
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
		    var strdate=document.getElementById("txtUseTime").value;
		    document.getElementById("spanRq").innerHTML=strdate;
		    var obj=UDS.SubModule.Vehicle.ApplyVehicle.GetCarInfo(strdate);
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
        //�ó�����
        var Department = document.getElementById("txtDepartment").value.Trim();
        if(Department=="" || Department ==null)
        {
             alert('�ó����Ų���Ϊ�գ�');
             return false;
        }
        
        //�ó���
        var UsePeople = document.getElementById("txtUsePeople").value.Trim();
        if(UsePeople=="" || UsePeople ==null)
        {
             alert('�ó��˲���Ϊ�գ�');
             return false;
        }
        
        //��������
        var Task = document.getElementById("txtTask").value.Trim();
        if(Task=="" || Task ==null)
        {
             alert('�������񲻿�Ϊ�գ�');
             return false;
        } 
        
        //�ó�ʱ��
        var UseTime = document.getElementById("txtUseTime").value.Trim();
        if(UseTime=="" || UseTime ==null)
        {
             alert('�ó�ʱ�䲻��Ϊ�գ�');
             return false;
        }
        
        //ʹ��ʱ��
        var Times = document.getElementById("txtTimes").value.Trim();
        if(Times=="" || Times ==null)
        {
             alert('������ʹ��ʱ�䣡');
             return false;
        }
        else
        {
            var re = /^\d+(?=\.{0,1}\d+$|$)/   
            if(!re.test(Times))
            {
                alert('ʹ��ʱ��ӦΪ���֣�');
                return false;
            }
        }
        
         
        //�ó�����
        var PeopleNum = document.getElementById("txtPeopleNum").value.Trim();
        if(PeopleNum=="" || PeopleNum ==null)
        {
             alert('�������ó�������');
             return false;
        }
        else
        {
            if(isNaN(PeopleNum))
            {
                 alert('�ó�����ӦΪ���֣�');
                 return false;
            }
        }
        
        return true;
    }
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="ApplyVehicle" method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr>
                <td width="20" height="30" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font>
                </td>
                <td width="60" align="center" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">
              <font face="����">��������</font></td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
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
                <td style="height:20px" colspan=6>
                <table style="font-size:9pt;"><tr><td >����ռ�����[<span id="spanRq" runat=server>2010-2-4</span>]&nbsp;</td><td><div style="width:15px;background-color:Red;"></div></td><td>&nbsp;ռ��</td></tr></table></td>
            </tr>
            <tr>
            <td colspan=6>
            <div style="width:100%;height:120px;overflow-y:scroll;" id="divZhanyong" runat=server>
            </div>
            </td>
            </tr>
            
            <tr bgcolor="#e8f4ff">
                <td  align="center" width="120">
                    �ó�����:
                </td>
                <td >
                    &nbsp;<asp:TextBox ID="txtDepartment" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                    <%--<asp:DropDownList ID="ddlMeetingType" runat="server" Width="230">
                    </asp:DropDownList>--%>
                </td>
                <td align="center" width="120">
                    �ó���:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtUsePeople" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>
                 <td align="center"  width="120">
                    ��ϵ�绰:
                </td>
                <td height="34">
                    &nbsp;<asp:TextBox ID="txtTelephone" CssClass="InputCss" runat="server" Columns="70"
                        Width="230"></asp:TextBox>
                </td>    
            </tr>
            <tr>
               
                <td width="120"  height="34" align="center">
                    ��������:
                </td>
                <td height="34" colspan=5>
                    &nbsp;<asp:TextBox ID="txtTask" CssClass="InputCss" runat="server" Columns="70"
                        Width="99%" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td width="120"  height="34" align="center">
                    �ó�ʱ��:
                </td>
                <td height="34" colspan=2>
                    &nbsp;<asp:TextBox ID="txtUseTime" onfocus="setday(this);" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ReadOnly="True" onchange="onChangDate();"></asp:TextBox>
                    <asp:DropDownList ID="ddlHour" runat="server" CssClass="InputCss">
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
                    <asp:DropDownList ID="ddlMinute" runat="server" CssClass="InputCss">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                    </asp:DropDownList>��
                </td>
                <td align="right"  height="34">
                    ��ʱ:
                </td>
                <td height="34" colspan=2>
                    &nbsp;<asp:TextBox ID="txtTimes" CssClass="InputCss" runat="server"
                        Columns="70" Width="120" ></asp:TextBox> &nbsp;Сʱ
                </td>
            </tr>
            <tr>
                <td width="120"  height="34" align="center">
                    �ó�����:
                </td>
                <td height="34" colspan=2>
                    &nbsp;<asp:TextBox ID="txtPeopleNum" CssClass="InputCss" runat="server" Columns="70"
                        Width="130"></asp:TextBox> &nbsp;0 ��ʾ������ȷ��
                </td>
                <td align="right"  height="34">
                    �ó�����:
                </td>
                <td colspan=2>
                    <asp:RadioButtonList ID="rbtnlNature" runat="server" CssClass="InputCss"
                        RepeatDirection="Horizontal" Width="93px" BorderStyle="None">
                        <asp:ListItem Selected="True">��</asp:ListItem>
                        <asp:ListItem>˽</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td width="120"  height="34" align="center">
                    ���복��:
                </td>
                <td height="34" colspan=5>
                    &nbsp;<%--<asp:TextBox ID="txtApplyCar" CssClass="InputCss" runat="server" Columns="70"
                        Width="530"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlApplyCar" runat="server" Width="230">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="6" height="35">
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

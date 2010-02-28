<%@ Page Language="c#" CodeBehind="NewCar.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Vehicle.NewCar" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewCar</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">

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
			location.href ="CarManage.aspx";			
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
        //����
        var CarType = document.getElementById("txtCarType").value.Trim();
        if(CarType=="" || CarType ==null)
        {
             alert('���Ͳ���Ϊ�գ�');
             return false;
        }
        
        //�ó���
        var CarNum = document.getElementById("txtCarNum").value.Trim();
        if(CarNum=="" || CarNum ==null)
        {
             alert('���Ų���Ϊ�գ�');
             return false;
        }
        
        return true;
    }
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewCar" method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="3%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font>
                </td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                    <b><b><b><font face="����">��������</font></b></b></b>
                </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    ����:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtCarType" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="right" width="20%" height="30">
                    ����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtCarNum" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    ��ע:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtMemo" CssClass="InputCss" runat="server" Columns="70"
                        Width="791px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="����">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" Width="60px" Text="ȷ��"
                            Height="20px" OnClientClick="return DoValidate();"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <input class="redButtonCss" style="width: 60px; height: 20px" onclick="ReturnBack(<%=ReturnPage%>)"
                            type="button" value="�� ��" name="cmdReturn">
                    </font>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
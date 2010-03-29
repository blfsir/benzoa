<%@ Page Language="c#" CodeBehind="NewStaff.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Position.NewStaff" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>NewStaff</title>
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
        .style1
        {
            font-size: 12px;
            width: 32px;
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
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewStaff" method="post" runat="server">
    <center>
     <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/ClientManage.gif" width="16">
            </td>
            <td width="60" height="30" align="left" background="../../../Images/treetopbg.jpg"
                bgcolor="#e8f4ff" class="GbText">
                &nbsp;<font color="#006699">Ա��ע��</font>
            </td>
            <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">&nbsp;
                </td>
        </tr>
    </table>
 
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    �û�����:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtStaffName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="����������" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��ʵ����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRealName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="��������ʵ����" ControlToValidate="txtRealName" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    �Ա�:
                </td>
                <td height="30">
                    &nbsp;<asp:RadioButton ID="rb_male" runat="server" GroupName="rSex" Checked="True"
                        Text="��"></asp:RadioButton><asp:RadioButton ID="rb_female" runat="server" GroupName="rSex"
                            Checked="False" Text="Ů"></asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��������:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtBirthday" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="383" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    ����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtPassword" runat="server" CssClass="InputCss" Width="383px"
                        TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ErrorMessage="���벻��Ϊ��" ControlToValidate="txtPassword" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �ظ�����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRePassword" runat="server" CssClass="InputCss" Width="382px"
                        TextMode="Password"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server"
                            ErrorMessage="����ȷ�ϴ���" ControlToValidate="txtRePassword" Font-Size="X-Small" ControlToCompare="txtPassword"></asp:CompareValidator>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    �����ʼ�:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEmail" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ErrorMessage="����д�����ʼ���ַ" ControlToValidate="txtEmail" Font-Size="X-Small"
                            Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="checkmail"
                                runat="server" ErrorMessage="�����EMAIL��ʽ" ControlToValidate="txtEmail" Display="Dynamic"
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��˾�绰:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtPhone" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    �ƶ��绰:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMobile" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RegularExpressionValidator ID="checkmobile" runat="server"
                            ErrorMessage="�ֻ��Ŵ���" ControlToValidate="txtMobile" Font-Size="X-Small" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    <font face="����">ְλ����:</font>
                </td>
                <td height="30">
                    <font face="����">&nbsp;<asp:TextBox ID="txtCaste" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ErrorMessage="����Ϊ��" ControlToValidate="txtCaste"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="����Ϊ����" ControlToValidate="txtCaste"
                                ValidationExpression="\d*"></asp:RegularExpressionValidator></font>
                </td>
            </tr>
            <tr id="Tr1" runat="server">
                <td align="right" width="20%" height="30">
                    ��������:
                </td>
                <td height="30">
                    <font face="����">&nbsp;<asp:DropDownList ID="dplDept" runat="server" Width="383px">
                    </asp:DropDownList>
                    </font>
                </td>
            </tr>
            <tr id="myposition" runat="server">
                <td align="right" width="20%" height="30">
                    ����ְλ:
                </td>
                <td height="30">
                    <font face="����">&nbsp;<asp:DropDownList ID="cboPosition" runat="server" Width="383px">
                    </asp:DropDownList>
                    </font>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��ͬ��ǩ����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtContractDate" onfocus="setday(this)" CssClass="InputCss"
                        runat="server" Columns="70" Width="383" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ����״��:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceStatus" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ������״��:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationStatus" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ���֤����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtIDNumber" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ����״��:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMarriage" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��סַ:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAddress" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �������ڵ�:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtBirthPlace" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ѧ��:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEducation" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �س�:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtFeatures" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ��ע:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRemark" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �籣����:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceBase" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtInsuranceBase" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ���ϱ��չ�˾(20%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEndowmentCompany" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtEndowmentCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ���ϱ��ո���(8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEndowmentPersonal" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtEndowmentPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ʧҵ���չ�˾(1%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtUnemploymentCompany" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtUnemploymentCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ʧҵ���ո���(0.2%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtUnemploymentPersonal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtUnemploymentPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ���˱��չ�˾(0.8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInjury" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                        ErrorMessage="�������֣�����λС��" ControlToValidate="txtInjury" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �������չ�˾(0.8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMaternity" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtMaternity" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ҽ�Ʊ��չ�˾(10%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMedicalCompany" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtMedicalCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ҽ�Ʊ��ո���(2%+3):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMedicalPersonal" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtMedicalPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �籣��˾�ϼ�:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceCompanyTotal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtInsuranceCompanyTotal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    �籣���˺ϼ�:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsurancePersonalTotal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtInsurancePersonalTotal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ������ɷѻ���:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationBase" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtAccumulationBase" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ������˾(12%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationCompany" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtAccumulationCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    ���������(12%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationPersonal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="�������֣�����λС��"
                        ControlToValidate="txtAccumulationPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                </td>
                <td height="30">
                    <asp:CheckBox ID="cbRemind" runat="server" Width="240px" Font-Size="X-Small" Text="վ�ڶ���Ϣ����(���ѹ�˾ȫ��Ա��)"
                        Height="16px"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="����">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss" Width="60px" Text="ȷ��"
                            Height="20px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
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

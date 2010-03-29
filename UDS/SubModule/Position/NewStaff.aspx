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
                &nbsp;<font color="#006699">员工注册</font>
            </td>
            <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">&nbsp;
                </td>
        </tr>
    </table>
 
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
            <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    用户姓名:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtStaffName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    真实姓名:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRealName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="请输入真实姓名" ControlToValidate="txtRealName" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    性别:
                </td>
                <td height="30">
                    &nbsp;<asp:RadioButton ID="rb_male" runat="server" GroupName="rSex" Checked="True"
                        Text="男"></asp:RadioButton><asp:RadioButton ID="rb_female" runat="server" GroupName="rSex"
                            Checked="False" Text="女"></asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    出生日期:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtBirthday" onfocus="setday(this)" CssClass="InputCss" runat="server"
                        Columns="70" Width="383" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    密码:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtPassword" runat="server" CssClass="InputCss" Width="383px"
                        TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ErrorMessage="密码不能为空" ControlToValidate="txtPassword" Font-Size="X-Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    重复密码:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRePassword" runat="server" CssClass="InputCss" Width="382px"
                        TextMode="Password"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server"
                            ErrorMessage="密码确认错误" ControlToValidate="txtRePassword" Font-Size="X-Small" ControlToCompare="txtPassword"></asp:CompareValidator>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    电子邮件:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEmail" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ErrorMessage="请填写电子邮件地址" ControlToValidate="txtEmail" Font-Size="X-Small"
                            Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="checkmail"
                                runat="server" ErrorMessage="错误的EMAIL格式" ControlToValidate="txtEmail" Display="Dynamic"
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    公司电话:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtPhone" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8f4ff">
                <td align="right" width="20%" height="30">
                    移动电话:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMobile" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RegularExpressionValidator ID="checkmobile" runat="server"
                            ErrorMessage="手机号错误" ControlToValidate="txtMobile" Font-Size="X-Small" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    <font face="宋体">职位级别:</font>
                </td>
                <td height="30">
                    <font face="宋体">&nbsp;<asp:TextBox ID="txtCaste" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ErrorMessage="不能为空" ControlToValidate="txtCaste"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="必须为数字" ControlToValidate="txtCaste"
                                ValidationExpression="\d*"></asp:RegularExpressionValidator></font>
                </td>
            </tr>
            <tr id="Tr1" runat="server">
                <td align="right" width="20%" height="30">
                    所属部门:
                </td>
                <td height="30">
                    <font face="宋体">&nbsp;<asp:DropDownList ID="dplDept" runat="server" Width="383px">
                    </asp:DropDownList>
                    </font>
                </td>
            </tr>
            <tr id="myposition" runat="server">
                <td align="right" width="20%" height="30">
                    所属职位:
                </td>
                <td height="30">
                    <font face="宋体">&nbsp;<asp:DropDownList ID="cboPosition" runat="server" Width="383px">
                    </asp:DropDownList>
                    </font>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    合同首签日期:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtContractDate" onfocus="setday(this)" CssClass="InputCss"
                        runat="server" Columns="70" Width="383" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    保险状况:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceStatus" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    公积金状况:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationStatus" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    身份证号码:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtIDNumber" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    婚姻状况:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMarriage" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    现住址:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAddress" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    户口所在地:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtBirthPlace" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    学历:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEducation" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    特长:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtFeatures" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    备注:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtRemark" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    社保基数:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceBase" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtInsuranceBase" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    养老保险公司(20%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEndowmentCompany" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtEndowmentCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    养老保险个人(8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtEndowmentPersonal" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtEndowmentPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    失业保险公司(1%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtUnemploymentCompany" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtUnemploymentCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    失业保险个人(0.2%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtUnemploymentPersonal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtUnemploymentPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    工伤保险公司(0.8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInjury" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                        ErrorMessage="输入数字，限两位小数" ControlToValidate="txtInjury" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    生育保险公司(0.8%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMaternity" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtMaternity" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    医疗保险公司(10%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMedicalCompany" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtMedicalCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    医疗保险个人(2%+3):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtMedicalPersonal" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtMedicalPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    社保公司合计:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsuranceCompanyTotal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtInsuranceCompanyTotal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    社保个人合计:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtInsurancePersonalTotal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtInsurancePersonalTotal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    公积金缴费基数:
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationBase" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtAccumulationBase" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    公积金公司(12%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationCompany" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtAccumulationCompany" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                    公积金个人(12%):
                </td>
                <td height="30">
                    &nbsp;<asp:TextBox ID="txtAccumulationPersonal" CssClass="InputCss" runat="server"
                        Columns="70" Width="382"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="输入数字，限两位小数"
                        ControlToValidate="txtAccumulationPersonal" ValidationExpression="^\d{1,10}(\.\d{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" height="30">
                </td>
                <td height="30">
                    <asp:CheckBox ID="cbRemind" runat="server" Width="240px" Font-Size="X-Small" Text="站内短消息提醒(提醒公司全体员工)"
                        Height="16px"></asp:CheckBox>
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

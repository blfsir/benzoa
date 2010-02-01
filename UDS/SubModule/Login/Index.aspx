<%@ Page Language="c#" CodeBehind="Index.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.Login.index" %>

<html>
<head>
    <title>BMC OA办公化自动系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        .Mybuttona { background-image:url(../../Images/b1.jpg); CURSOR: hand;}
        .Mybuttonb { background-image:url(../../Images/b2.jpg); CURSOR: hand;border: 0px solid; }
        body
        {
            margin: 0px;
            background-color: #f0f0f0;
        }
        .bg
        {
            background-image: url(../../Images/bg.jpg);
        }
        input
        {
            background-image: url(../../Images/bg2.jpg);
            width: 156px;
            height: 30px;
            border: none;
            line-height: 30px;
            text-indent: 10px;
            color: #FFF;
            font-size: 14px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function reset()
        {
            //alert("reset");
            document.getElementById("txtUsername").value = "";
            document.getElementById("txtPassword").value = "";
            
        }
    </script>
</head>
<body bgcolor="#353467" bgcolor="leftMargin="0" topmargin="0" onload='javascript: if(this.document.all.txtUsername.value=="") this.document.all.txtUsername.focus();else this.document.all.txtPassword.focus();'>
    <span id="obj"></span>
    <!--
		<OBJECT id="ePass" style="LEFT: 0px; TOP: 0px" height="0" width="0" classid="clsid:E740C5DF-3454-46A7-80EC-364D1ADB6CF0" name="ePass" VIEWASTEXT>
		</OBJECT>
		-->
    <!--判断用户是否选择使用USBKey-->

    <script language="VBScript">

Dim FirstDigest
Dim Digest 
Digest= "01234567890123456"
dim bErr

'sub needUsbKey()
'	if  index.cb_isNeedUsbKey.checked =true Then
'		obj.innerHTML="<OBJECT id='ePass' style='LEFT: 0px; TOP: 0px' height='0' width='0' classid='clsid:E740C5DF-3454-46A7-80EC-364D1ADB6CF0' name='ePass' VIEWASTEXT></OBJECT>"
'	end if
'End sub

sub ShowErr(Msg)
	bErr = true
	ErrMsg.innerHTML = "<input type='hidden' name='ErrMsg' Value='" & Msg & "'>"
'	MsgBox Msg,0,"提示"
'	Document.Writeln "<FONT COLOR='#FF0000'>"
'	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P><P ALIGN='CENTER'><B>ERROR:</B>"
'	Document.Writeln "<P>&nbsp;</P><P ALIGN='CENTER'>"
'	Document.Writeln Msg
'	Document.Writeln " failed, and returns 0x" & hex(Err.number) & ".<br>"
'	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P>"
'	Document.Writeln "</FONT>"
End Sub

function Validate()
	Digest = "01234567890123456"
	On Error Resume Next
	'Dim TheForm
	'Set TheForm = Document.forms("ValidForm")
	'If Len(TheForm.UserPIN.Value) < 4  Then
	'	MsgBox "PIN empty or user pin length less than 4 or so pin length less than 6!!"	 
	'	Validate = FALSE
	'	Exit Function
	'End If

	bErr = false

	'Let detecte whether the ePass 1000 Safe Active Control loaded.
	'If we call any method and the Err.number be set to &H1B6, it 
	'means the ePass 1000 Safe Active Control had not be loaded.
	ePass.GetLibVersion
	
	If Err.number = &H1B6 Then

		ShowErr "Load ePass 1000 Safe Active Control"
		Validate = false
		Exit function
	Else
		
		ePass.OpenDevice 1, ""
		
		If Err then
			ShowErr "请勾选使用框,并插入USB_Key!"
			Validate = false
			ePass.CloseDevice
			Exit function
		End if
	
		'ePass.ResetSecurityState 0
		dim results
		results = "01234567890123456"
		results = ePass.GetStrProperty(7, 0, 0)
		'MsgBox results

		'ePass.VerifyUserPIN TheForm.Identity.Value, TheForm.UserPIN.Value
		'ePass.VerifyPIN 0, TheForm.UserPIN.Value

		If Err Then
			ShowErr "Verify User PIN Failure!!!"
			Validate = false
			ePass.CloseDevice
			Exit function
		End If
		

		If Not bErr Then
			ePass.ChangeDir &H300, 0, "ASP_DEMO"
			If Err then 
				ShowErr "Change to demo directory"
				Validate = false
				ePass.CloseDevice
				Exit function
			End If
		End If


		'Open the first key file.
		If Not bErr Then
			ePass.OpenFile 0, 1
			If Err Then
				ShowErr "Open first KEY-file"
				Validate = false
				ePass.CloseDevice
				Exit function
			End If
		
		End If

		'Do HASH-MD5-HMAC compute.
		If Not bErr Then
			Digest = ePass.HashToken (1, 2,"<%=RandData%>")
			If Err Then 
				ShowErr "HashToken compute"
				Validate = false
				ePass.CloseDevice
				Exit function
			End If
			DigestID.innerHTML = "<input type='hidden' name='Digest' Value='" & Digest & "'>"
			snID.innerHTML = "<input type='hidden' name='SN_SERAL' Value='" & results & "'>"
		End If		
	End If

	ePass.CloseDevice
	
End function
    </script>

    <form id="index" method="post" runat="server" onsubmit="Validate()">
    <span id="DigestID"></span><span id="snID"></span><span id="ErrMsg"></span>
     

     <table width="1003" height="591" border="0" align="center" cellpadding="0" cellspacing="0" id="__01">
  <tr>
    <td colspan="3"><img src="../../Images/oa_01.jpg" width="1003" height="138" alt="" /></td>
  </tr>
  <tr>
    <td width="223"><img src="../../Images/oa_02.jpg" width="223" height="238" alt="" /></td>
    <td width="550" valign="top" background="../../Images/oa_03.jpg"><table width="200" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="100">&nbsp;</td>
      </tr>
    </table>
      <table width="500" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="150" align="right" class="oa_01"><font color="white">用户名</font></td>
        <td width="200" height="35" align="center"> <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        <td rowspan="2">  <img src="../../Images/oa_06.jpg" width="73" height="62" onclick="javascript:__doPostBack('btnSubmit','')" /> </td>
      </tr>
      <tr align="center">
        <td align="right" class="oa_01"><font color="white">密　码</font></td> 
        <td height="35"><asp:TextBox ID="txtPassword" runat="server"   TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator></td>
      </tr>
      <tr><td colspan="3" align="center"><asp:Label ID="lblErrorMessage" runat="server"  Visible="False" ForeColor="Red" Width="158px">错误的用户名和口令</asp:Label><asp:Button ID="btnSubmit"   BorderWidth="0" BorderStyle="None" Width="0" Height="0" runat="server"   Text=""></asp:Button></td></tr>
    </table></td>
    <td width="230"><img src="../../Images/oa_04.jpg" width="230" height="238" alt="" /></td>
  </tr>
  <tr>
    <td colspan="3"><img src="../../Images/oa_05.jpg" width="1003" height="215" alt="" /></td>
  </tr>
</table>
    </form>
</body>
</html>

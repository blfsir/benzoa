<%

	Const Err_UserNotExist = -1
	Const Err_PasswordIsWrong = -2
	Const Err_OverfullRecord = -3
	Const Err_Success = 0
	Const Err_Errors = -4

	'On Error Resume Next

	'//�������
	Dim myLoginObj
	
	
	Dim myDocument
	Dim myResult
	Dim CON
	Dim SQL
	
	Dim bReadOK	
	
	Dim myPurview
	dim CS	
	Set CS = Server.CreateObject("uds.ConDB")	
	con = CS.GetConnectString(server.MapPath("..") & "\cno.ini")
	Set CS = Nothing
		
	Set myDocument = Server.CreateObject("uds.Document")
		
	'//��ȡ����
	Username = Request("Username")
	Password = Request("Password")


	'//������
	Set myLoginObj = Server.CreateObject( "Uds.Login" )

	'//�����û��Ƿ�Ϸ�
	IF myLoginObj.CheckUser("Uds_Staff","Staff_Name","Password",CStr(UserName),CStr(Password),myResult,False,CStr(Con)) = True Then
	
		'//�õ��û�ID		
		IF myLoginObj.GetUserInfo("Uds_Staff","Staff_ID","Staff_Name",CStr(UserName),myResult,False,CStr(con)) = True Then

			'//�����û�Ȩ�޶���
			
				'//дȨ��COOKIE,����ת
				Response.Cookies("UDSUserName") = Username & ""	
				Response.Cookies("UDSState") = 1
				Response.ReDirect "../../SubModule/Index.Asp"							
				
			
		End IF		
	Else		
		Response.ReDirect "../../SubModule/Login/Index.Asp?ErrMsg=" & CLng(myResult)
	End IF
	

%>
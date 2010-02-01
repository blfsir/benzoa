<%
	
	Response.Cookies("UDSUserName") = ""	
	Response.Cookies("UDSState") = 0

	' 如果退出成功

	Response.Redirect "../../index.asp"
	Response.End

%>
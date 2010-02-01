<%@ Page language="c#" Codebehind="Compose.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Mail.Compose" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>写新邮件</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../css/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function dialwinprocess(type)
			{
				var newdialoguewin = window.showModalDialog("SelectReceiver.aspx?ClassID=<% Response.Write(ClassID); %>&type="+type,window,"dialogWidth:600px;DialogHeight=490px;status:no");
				if(newdialoguewin!=null){
					if(newdialoguewin.length>5)
					{
						ReceiverTypeArray = newdialoguewin.split("|");
						SendToArray = ReceiverTypeArray[0].split("-");
						CcToArray = ReceiverTypeArray[1].split("-");
						BccToArray = ReceiverTypeArray[2].split("-");
						try{
							this.document.Compose.txtSendTo.value = SendToArray[0];
							this.document.Compose.txtCcTo.value = CcToArray[0];
							this.document.Compose.txtBccTo.value = BccToArray[0]; 
						}
						catch(e){}
						
						
					}
				}
			}
			
			
		function ProjectSelect()
{
	
	var ret;
	ret = window.showModalDialog("TreeView.aspx",window,"dialogHeight:400px;dialogWidth:300px;center:Yes;Help:No;Resizable:No;Status:Yes;Scroll:auto;Status:no;");
	if(ret>0)
	return false;
}
		
		</script>
		<script language="javascript">
			
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../../images/maillistbutton2.gif';
		nonactive.src = '../../../images/maillistbutton1.gif';

		function onMouseOver(img)
		{
			document.images[img].src = ball2.src;
		}

		function onMouseOut(img)
		{
			document.images[img].src = ball1.src;
		}

		function onOverBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+active.src+")";
				
			}
		}

		function onOutBar(bar)
		{
			if (bar != null) {
				bar.style.backgroundImage = "url("+nonactive.src+")";
			}
		}
		
		function selectAll(){
			var len=document.MailList.elements.length;
			var i;
		    for (i=0;i<len;i++){
			if (document.MailList.elements[i].type=="checkbox"){
		        document.MailList.elements[i].checked=true;								
						 }
					}
				}

		function unSelectAll(){
	          var len=document.MailList.elements.length;
	          var i;
	          for (i=0;i<len;i++){
	               if (document.MailList.elements[i].type=="checkbox"){
	                  document.MailList.elements[i].checked=false; 
	               }   
	        	 } 
		    }		

		</script>
	</HEAD>
	<body leftMargin="0" MS_POSITIONING="GridLayout" topmargin="0">
		<form id="Compose" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="38"><TABLE borderColor="#111111" height="1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="30">
								<TD class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgColor="#c0d9e6"
									align="right"><FONT color="#003366" size="3"><IMG height="16" src="../../../Images/icon/284.GIF" width="16"></FONT></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" width="60"
									align="right"><font color="#006699">我的邮件</font></TD>
								<TD class="GbText" background="../../../Images/treetopbg.jpg" bgColor="#e8f4ff" align="right"><FONT face="宋体">&nbsp;&nbsp;&nbsp;</FONT></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td vAlign="bottom" height="25">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr height="25">
								<td style="HEIGHT: 25px" width="1"></td>
								<td id="bar1" style="HEIGHT: 25px" align="center" width="90" background="../../../images/maillistbutton1.gif">&nbsp;<A href="Index.aspx?FolderType=1" class="Newbutton">收件箱</A></td>
								<td id="bar2" style="HEIGHT: 25px" align="center" width="90" background="../../../images/maillistbutton1.gif">&nbsp;<A href="Index.aspx?FolderType=2" class="Newbutton">发件箱</A></td>
								<td id="bar3" style="HEIGHT: 25px" align="center" width="90" background="../../../images/maillistbutton1.gif">&nbsp;<A href="Index.aspx?FolderType=3" class="Newbutton">废件箱</A></td>
								<td id="bar4" style="HEIGHT: 25px" align="center" width="90" background="../../../images/maillistbutton2.gif">&nbsp;<A href="Compose.aspx?ClassID=0" class="Newbutton">撰写新邮件</A></td>
								<%--<td id="bar5" style="HEIGHT: 25px" align="center" width="90" background="../../../images/maillistbutton1.gif">&nbsp;<A href="Index.aspx?FolderType=4" class="Newbutton">外部邮件</A></td>--%>
								<td style="HEIGHT: 25px" align="right"><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td bgColor="#93bee2" colSpan="5" height="5"><FONT style="BACKGROUND-COLOR: #ffffff" face="宋体"></FONT></td>
				</tr>
				<tr>
					<td>&nbsp;
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="right" width="100"><asp:label id="lblSendTo" runat="server" CssClass="Text" Font-Size="X-Small">收件人:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td><input class=InputCss 
            style="WIDTH: 404px; HEIGHT: 19px" readOnly type=text size=62 
            value="<%=SendToRealName%>" name=txtSendTo 
            >&nbsp;<A style="CURSOR: hand" onclick="dialwinprocess(1)" href="#"><FONT face="宋体">选择收件人</FONT></A></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCcTo" runat="server" CssClass="Text" Font-Size="X-Small">抄送人:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td><input class=InputCss 
            style="WIDTH: 405px; HEIGHT: 19px" readOnly type=text size=62 
            value="<%=CcToRealName%>" name=txtCcTo>&nbsp;<A style="CURSOR: hand" onclick="dialwinprocess(2)" href="#"><FONT face="宋体">选择抄送人</FONT></A></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblBccTo" runat="server" CssClass="Text" Font-Size="X-Small">秘抄人:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td><input class=InputCss 
            style="WIDTH: 406px; HEIGHT: 19px" readOnly type=text size=62 
            value="<%=BccToRealName%>" name=txtBccTo 
            >&nbsp;<A style="CURSOR: hand" onclick="dialwinprocess(2)" href="#"><FONT face="宋体">选择密送人</FONT></A></td>
							</tr>
							<tr>
								<td style="HEIGHT: 21px" align="right"><asp:label id="lblSubject" runat="server" CssClass="Text" Font-Size="X-Small" Width="40px">主&nbsp;&nbsp;题:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td style="HEIGHT: 21px"><asp:textbox id="txtSubject" runat="server" CssClass="InputCss" Width="484px"></asp:textbox></td>
							</tr>
							<tr height="30">
								<td align="right"><asp:label id="lblImportance" runat="server" CssClass="Text" Font-Size="X-Small">重要性:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td><asp:dropdownlist id="listImportance" runat="server" Width="150px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;<input 
            class=InputCss name=hdnProjectID style="WIDTH: 150px; HEIGHT: 20px" 
            type=hidden size=11 value="<%=ClassID %>" 
            width="20"><input class=InputCss name=txtProjectName 
            style="WIDTH: 150px; HEIGHT: 20px" readOnly type=text size=11 
            value="<%=GetClassName() %>" width="20"><input class="redButtonCss" onclick="ProjectSelect()" type="button" value="▼">
									<asp:CheckBox id="cbRemind" runat="server" Font-Size="X-Small" Text="站内短消息提醒"></asp:CheckBox></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblBody" runat="server" CssClass="Text" Font-Size="X-Small">内&nbsp;&nbsp;容:</asp:label><FONT face="宋体">&nbsp;</FONT></td>
								<td><asp:textbox id="txtBody" runat="server" CssClass="inputsta" Width="486px" Height="188px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr class="InputCss">
								<td>&nbsp;</td>
								<td>
									<table id="tblAttachFiles" width="486" border="0" cellpadding="0" cellspacing="0">
										<TR>
											<TD align="center">
												<table cellspacing="0" cellPadding="0" width="485" border="0">
													<tr>
														<td class="InputCss" style="WIDTH: 45px" rowSpan="2">
															<table style="WIDTH: 44px; HEIGHT: 76px" width="44" align="center" border="0">
																<TBODY class="InputCss">
																	<tr>
																		<td>&nbsp;<FONT face="宋体">附件1</FONT></td>
																	</tr>
																	<tr>
																		<td>&nbsp;<FONT face="宋体">附件2</FONT></td>
																	</tr>
																	<tr>
																		<td>&nbsp;<FONT face="宋体">附件3</FONT></td>
																	</tr>
																	<tr>
																		<td>&nbsp;<FONT face="宋体">附件4</FONT></td>
																	</tr>
																</TBODY>
															</table>
														</td>
														<td style="WIDTH: 150px" rowSpan="2"><INPUT class="InputCss" id="filecontrol1" style="WIDTH: 146px; HEIGHT: 19px" type="file"
																size="5" name="filecontrol1" runat="server"><br>
															<INPUT class="InputCss" id="filecontrol2" style="WIDTH: 146px; HEIGHT: 19px" type="file"
																size="6" name="filecontrol2" runat="server"><br>
															<INPUT class="InputCss" id="File1" style="WIDTH: 146px; HEIGHT: 19px" type="file" size="6"
																name="filecontrol3" runat="server"><br>
															<INPUT class="InputCss" id="File2" style="WIDTH: 146px; HEIGHT: 19px" type="file" size="6"
																name="filecontrol4" runat="server">
														</td>
														<td>&nbsp;<FONT face="宋体"> </FONT>
															<asp:button id="btnUpload" runat="server" CssClass="redButtonCss" Text="添加附件"></asp:button></td>
														<td rowSpan="2">&nbsp;<FONT face="宋体">&nbsp;&nbsp; </FONT>
															<asp:listbox id="listUp" runat="server" Width="153px" Height="81px" SelectionMode="Multiple"></asp:listbox></td>
													</tr>
													<tr>
														<td>&nbsp;<FONT face="宋体">
																<asp:button id="btnRemove" runat="server" CssClass="redButtonCss" Text="删除附件"></asp:button></FONT></td>
													</tr>
												</table>
												<P>
													&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkboxlist id="cblistAttribute" runat="server" Font-Size="X-Small" RepeatDirection="Horizontal"></asp:checkboxlist></P>
												<P><asp:button id="btnSendMail" runat="server" CssClass="ButtonCss" Text=" 发  送 "></asp:button>&nbsp;&nbsp;&nbsp;
													 <INPUT class=ButtonCss style="WIDTH: 58px; HEIGHT: 20px" onclick="javascript:try {if(parent.frames.length==0) window.close();else self.location='<% Response.Write(Request.UrlReferrer); %>';} catch(e){}" type=button value=" 返  回 "/> 
													<%--<INPUT class=ButtonCss style="WIDTH: 58px; HEIGHT: 20px" onclick="javascript:  window.location='<% Response.Write(Request.UrlReferrer); %>';" type=button value=" 返  回 "/>--%></P>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="47%"><IMG height="25" src="../../../Images/temp.gif" width="250">
								</td>
								<td width="53%">
									<div align="right"><IMG height="25" src="../../../Images/endbott.gif" width="279"></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <INPUT style="Z-INDEX: 109; LEFT: 137px; POSITION: absolute; TOP: 338px" type="hidden"
				name="hdnSendToStr">&nbsp; <input type=hidden 
value="<%=SendTo%>" name=hdnTxtSendTo><input type=hidden 
value="<%=CcTo%>" name=hdnTxtCcTo><input type=hidden 
value="<%=BccTo%>" name=hdnTxtBccTo></form>
	</body>
</HTML>

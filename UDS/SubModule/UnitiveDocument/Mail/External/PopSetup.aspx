<%@ Page language="c#" Codebehind="PopSetup.aspx.cs" AutoEventWireup="false" Inherits="UDS.SubModule.UnitiveDocument.Mail.External.PopSetup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopSetup</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 15px" vAlign="bottom" noWrap></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 1px" noWrap></TD>
					</TR>
					<TR>
						<TD class="curstep" style="HEIGHT: 20px" noWrap align="right" bgColor="#93bee2" colSpan="1"
							rowSpan="1"><FONT face="宋体">POP 邮件设置</FONT> &nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" noWrap align="center">
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="95%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" noWrap>
											<TABLE height="100%" cellSpacing="1" cellPadding="10" width="100%" border="0">
												<TBODY>
													<TR>
														<TD class="td" vAlign="top" width="612">
															<TABLE class="td" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD height="10"><FONT face="宋体"></FONT></TD>
																</TR>
																<TR>
																	<TD align="right" height="10">&nbsp;</TD>
																</TR>
																<TR>
																	<TD align="right" height="15"><asp:button id="btnOK" runat="server" Text="确定"></asp:button><asp:button id="btnCancel" runat="server" Text="返回"></asp:button></TD>
																</TR>
																<TR>
																	<TD class="curstep" style="HEIGHT: 24px" bgColor="#dbeaf5">&nbsp;设置 第一个 POP 帐户(默认)：
																	</TD>
																</TR>
																<TR>
																	<TD height="1">
																		<TABLE class="td" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD style="WIDTH: 223px" height="5"></TD>
																				<TD height="5"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">显示名称：
																				</TD>
																				<TD><asp:textbox id="txtTitle1" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">电子邮件地址：
																				</TD>
																				<TD><asp:textbox id="txtEmail1" runat="server" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
																						ControlToValidate="txtEMail1" ErrorMessage="邮件格式错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">接收邮件服务器(POP3)：</FONT>&nbsp;
																				</TD>
																				<TD><asp:textbox id="txtPopSvrName1" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">POP 用户名：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPopUserName1" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><span id="lblPwdTxt1">POP 用户密码：</span></TD>
																				<TD><INPUT id="lblPwd1" type="hidden" name="lblPwd1" runat="server"><asp:label id="lblPwdShow1" runat="server" Visible="False">******</asp:label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:textbox id="txtPopPwd1" runat="server" Width="200px" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">服务器超时（以秒为单位）：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtTimeOut1" runat="server" Width="60px">90</asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" ValidationExpression="\d{2,3}" ControlToValidate="txtTimeOut1"
																						ErrorMessage="[服务器超时]输入错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">端口号：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPort1" runat="server" Width="60px">110</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator9" runat="server" ValidationExpression="\d{2,5}" ControlToValidate="txtPort1"
																						ErrorMessage="[端口号]输入错误！">#</asp:regularexpressionvalidator>（注意：标准端口号为 110）
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkDelSvrMsg1"><asp:checkbox id="chkDelSvrMsg1" runat="server" Text="将邮件保留在 POP 服务器上"></asp:checkbox></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkDownNew1"><asp:checkbox id="chkDownNew1" runat="server" Text="只下载新邮件"></asp:checkbox></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkSvrAuth1"><FONT face="宋体"></FONT></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:button id="btnTest1" runat="server" Text="测试邮件设置"></asp:button><asp:label id="lblResultRep1" runat="server" Visible="False" BorderColor="Red" Font-Size="X-Small"
																						ForeColor="Red"></asp:label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD height="20"></TD>
																</TR>
																<TR>
																	<TD class="curstep" bgColor="#dbeaf5" height="24">设置 第二个 POP 帐户：
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="td" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD style="WIDTH: 223px" height="5"></TD>
																				<TD height="5"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">显示名称：
																				</TD>
																				<TD><asp:textbox id="txtTitle2" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px; HEIGHT: 16px">电子邮件地址：
																				</TD>
																				<TD style="HEIGHT: 16px"><asp:textbox id="txtEmail2" runat="server" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
																						ControlToValidate="txtEMail2" ErrorMessage="邮件格式错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">接收邮件服务器(POP3)：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPopSvrName2" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">POP 用户名：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPopUserName2" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><span id="lblPwdTxt2">POP 用户密码：</span></TD>
																				<TD><INPUT id="lblPwd2" type="hidden" name="lblPwd2" runat="server"><asp:label id="lblPwdShow2" runat="server" Visible="False">******</asp:label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf"></FONT></TD>
																				<TD><asp:textbox id="txtPopPwd2" runat="server" Width="200px" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">服务器超时（以秒为单位）：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtTimeOut2" runat="server" Width="60px">90</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ValidationExpression="\d{2,3}" ControlToValidate="txtTimeOut2"
																						ErrorMessage="[服务器超时]输入错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">端口号：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPort2" runat="server" Width="60px">110</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" ValidationExpression="\d{2,5}" ControlToValidate="txtPort2"
																						ErrorMessage="[端口号]输入错误！">#</asp:regularexpressionvalidator>（注意：标准端口号为 110）
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkDelSvrMsg2"><asp:checkbox id="chkDelSvrMsg2" runat="server" Text="将邮件保留在 POP 服务器上"></asp:checkbox></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:checkbox id="chkDownNew2" runat="server" Text="只下载新邮件"></asp:checkbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkSvrAuth2"><FONT face="宋体"></FONT></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:button id="btnTest2" runat="server" Text="测试邮件设置"></asp:button><asp:label id="lblResultRep2" runat="server" Visible="False" BorderColor="Red" Font-Size="X-Small"
																						ForeColor="Red"></asp:label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD height="20"></TD>
																</TR>
																<TR>
																	<TD class="curstep" bgColor="#dbeaf5" height="24">设置 第三个 POP 帐户：
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="td" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD style="WIDTH: 223px" height="5"></TD>
																				<TD height="5"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">显示名称：
																				</TD>
																				<TD><asp:textbox id="txtTitle3" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">电子邮件地址：
																				</TD>
																				<TD><asp:textbox id="txtEmail3" runat="server" Width="200px"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
																						ControlToValidate="txtEMail3" ErrorMessage="邮件格式错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf"><FONT class="Wf">接收邮件服务器(POP3)：</FONT></FONT>
																				</TD>
																				<TD><asp:textbox id="txtPopSvrName3" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">POP 用户名：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPopUserName3" runat="server" Width="200px"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><span id="lblPwdTxt3">POP 用户密码：</span></TD>
																				<TD><INPUT id="lblPwd3" type="hidden" name="lblPwd3" runat="server"><asp:label id="lblPwdShow3" runat="server" Visible="False">******</asp:label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px">&nbsp;</TD>
																				<TD><asp:textbox id="txtPopPwd3" runat="server" Width="200px" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">服务器超时（以秒为单位）：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtTimeOut3" runat="server" Width="60px">90</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ValidationExpression="\d{2,3}" ControlToValidate="txtTimeOut3"
																						ErrorMessage="[服务器超时]输入错误！">#</asp:regularexpressionvalidator></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"><FONT class="Wf">端口号：</FONT>
																				</TD>
																				<TD><asp:textbox id="txtPort3" runat="server" Width="60px">110</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ValidationExpression="\d{2,5}" ControlToValidate="txtPort3"
																						ErrorMessage="[端口号]输入错误！">#</asp:regularexpressionvalidator>（注意：标准端口号为 110）
																				</TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:checkbox id="chkDelSvrMsg3" runat="server" Text="将邮件保留在 POP 服务器上"></asp:checkbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><asp:checkbox id="chkDownNew3" runat="server" Text="只下载新邮件"></asp:checkbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD><label for="chkSvrAuth3"><FONT face="宋体"></FONT></label></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 223px"></TD>
																				<TD>
																					<asp:Button id="btnTest3" runat="server" Text="测试邮件设置"></asp:Button>
																					<asp:Label id="lblResultRep3" runat="server" Visible="False" BorderColor="Red" Font-Size="X-Small"
																						ForeColor="Red"></asp:Label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD height="21" style="HEIGHT: 21px"></TD>
																</TR>
																<TR>
																	<TD align="right"><input type="button" value="确定" onclick="document.all.Form1.btnOK.click()"><input type="button" value="返回" onclick="document.all.Form1.btnCancel.click()"></TD>
																</TR>
															</TABLE>
		</form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
	</body>
</HTML>

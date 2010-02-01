<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBoard.aspx.cs" Inherits="UDS.SubModule.UnitiveDocument.Board.ViewBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>公告浏览</title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
        <table class="gbtext" id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" height="38">
                    <table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr height="30">
                            <td class="GbText" style="width: 23px" align="right" width="23" background="../../../Images/treetopbg.jpg"
                                bgcolor="#c0d9e6">
                                <font color="#003366" size="3">
                                    <img height="16" src="../../../DataImages/DocFlow.gif" width="16"></font>
                            </td>
                            <td class="GbText" align="right" width="80" background="../../../Images/treetopbg.jpg"
                                bgcolor="#e8f4ff">
                                <font color="#006699">
                                    <asp:Label ID="lblTitle" runat="server" ForeColor="#006699" Font-Names="宋体"  
                                        Width="53px">  公司公告</asp:Label></font>
                            </td>
                            <td class="GbText" align="right" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff">
                                <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </font>&nbsp;</font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="1" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#cccccc"
							width="100%" id="AutoNumber2" height="1" class="GbText" align="left">
                        <tr>
                            <font face="宋体"></font>
                            <td align="left" width="10%">
                                <asp:Label ID="lblStyleName" runat="server">公告标题：</asp:Label>
                            </td>
                            <td height="22"><asp:Label ID="txtBoardName" runat="server"></asp:Label> 
                            </td>
                        </tr>
                     <%--    <tr>
                            <td width="10%">
                                发 布 者： </td>
                            <td>
                                <asp:Label ID="LBUserName" runat="server"></asp:Label>
                                &nbsp;（发布时间：&nbsp;<asp:Label ID="LabPostTime" runat="server"></asp:Label>）
                            </td>
                        </tr> 
                          <tr>
                            <td colspan="2">
                                公告内容： 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">--%>
                                <div id="board_content" style="width: 100%; height:100%; word-break: break-all;  word-wrap: break-word; margin:10px;" runat="server">
                                </div>
                           <%-- </td>
                        </tr>
                          <tr>
                            <td colspan="2">
                                <input type="button" value=" 关  闭 " onclick="javascript:try {if(parent.frames.length==0) window.close();else history.go(-1);} catch(e){}"
										class="buttoncss">
                            </td>
                        </tr>
                    
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>--%>
    </form>
</body>
</html>

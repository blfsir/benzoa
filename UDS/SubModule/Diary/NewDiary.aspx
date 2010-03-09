<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDiary.aspx.cs" Inherits="UDS.SubModule.Diary.NewDiary" %>


 
 <%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html>
<head>
    <title>NewStaff</title>
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

    <script type="text/javascript" language="javascript">
		 var editor;
		 
		function ReturnBack(ReturnType)
		{			
			location.href ="DiaryManage.aspx";			
		}
		
		
    function check(){
     
        var content = editor.GetXHTML(true); //content就是编辑器的内容的html源码了
     
        if( content==""){
            alert("请输入内容!");
            return false;
        }
    }
    function FCKeditor_OnComplete( editorInstance ){ 
        editor = editorInstance;
//        var oEditor = FCKeditorAPI.GetInstance('FCKeditor2') ;

//        alert(oEditor.Name);
    }
		/*设置FCKEDITOR为只读 */
        function setFCKeditorReadOnly(){
        try{
            editor.EditorDocument.body.contentEditable = false;
            editor.EditMode=FCK_EDITMODE_SOURCE;
            editor.ToolbarSet.RefreshModeState();
            editor.EditMode=FCK_EDITMODE_WYSIWYG;
            editor.ToolbarSet.RefreshModeState();
            editor.EditorWindow.parent.document.getElementById('xExpanded').style.display = 'none';
            editor.EditorWindow.parent.document.getElementById('xCollapsed').style.display = 'none';
            editor.EditorWindow.blur();
        }
        catch(e){
        }
        } 
//		function FCKeditor_OnComplete(editorInstance)
//        {
//            editorInstance.EditorDocument.body.disabled = true;
//            editorInstance.EditorWindow.parent.document.getElementById('xExpanded').style.display = 'none';
//            editorInstance.EditorWindow.parent.document.getElementById('xCollapsed').style.display = 'none';
//            editorInstance.EditorWindow.blur();
//        }
    </script>

</head>
<body leftmargin="0" topmargin="0">
    <form id="NewNote" method="post" runat="server">
    <center>
        <table id="Table2" bordercolor="#111111" height="1" cellspacing="0" cellpadding="0"
            width="100%" border="0">
            <tr height="30">
                <td class="GbText" width="50%" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" align="left">
                    <font color="#003366" size="3">
                        <img alt="" src="../../DataImages/ClientManage.gif"></font> <b><font face="宋体">新增日记</font></b></td>
                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
                <td class="GbText" align="right" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6">
                </td>
            </tr>
        </table>
        <table class="gbtext" id="AutoNumber1" style="border-collapse: collapse" bordercolor="#93bee2"
            cellspacing="0" cellpadding="0" width="100%" border="1" runat="server">
           <%-- <tr bgcolor="#e8f4ff">
                <td style="height: 34px" align="right" width="20%" height="34">
                    用户姓名:
                </td>
                <td style="height: 34px" height="34">
                    &nbsp;<asp:TextBox ID="txtStaffName" CssClass="InputCss" runat="server" Columns="70"
                        Width="382"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="请输入姓名" ControlToValidate="txtStaffName" Font-Size="X-Small"></asp:RequiredFieldValidator><asp:Literal
                                ID="message" runat="server" EnableViewState="False"></asp:Literal>
                </td>--%>
            </tr>
            
            <tr>
                <td align="right" width="20%" height="30" colspan="2">
                        
                      <fckeditorv2:fckeditor id="FCKeditor2" runat="server" width="100%" height="200px">
                                                        </fckeditorv2:fckeditor> 
                </td>
                
            </tr>
            
            <tr>
                <td align="center" colspan="2" height="35">
                    <font face="宋体">
                        <asp:Button ID="cmdSubmit" runat="server" CssClass="redButtonCss"  OnClientClick="return check();"
                        Width="60px" Text="确定"
                            Height="20px" onclick="cmdSubmit_Click1"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
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

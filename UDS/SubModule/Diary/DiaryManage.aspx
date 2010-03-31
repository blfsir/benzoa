<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiaryManage.aspx.cs" Inherits="UDS.SubModule.Diary.DiaryManage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>DiaryManage</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="JavaScript" src="../../Css/meizzDate.js"></script>

    <script language="javascript">
			
	     window.onerror=function(){return true;}
	     
		var ball1 = new Image();
		var ball2 = new Image();
		ball1.src = 'images/ball1.gif';
		ball2.src = 'images/ball2.gif';

		var active = new Image();
		var nonactive = new Image();
		active.src = '../../images/maillistbutton2.gif';
		nonactive.src = '../../images/maillistbutton1.gif';

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

function ock_Search(){  
alert("ssss");
	var strAlert="";
	strBeginTime = document.all.txtBeginDate.value;
	strEndTime = document.all.txtEndDate.value;
	if (strBeginTime!="" & strEndTime!=""){		
		if (!CompareDate(strBeginTime,strEndTime)){
			strAlert = strAlert + "终止日期应大于等于起始日期。\n"
		}		
	}
    if (strAlert!=""){
		alert(strAlert);
		return false;
    }
}

function isValiateTime()
{

var bvalue=document.getElementById('txtBeginDate').value;
var evalue=document.getElementById('txtEndDate').value;
 
if(bvalue == "" || evalue =="")
{
    alert("请选择日期。\n");
    return false;

}
if(bvalue.valueOf()>evalue.valueOf())
{
    alert("终止日期应大于等于起始日期。\n");
    return false;
}
return true;

//alert(bvalue);
//alert(evalue);

//      if(bvalue.length>9 && evalue.length>9){
//        var d1 = new Date(bvalue);
//        alert('d1');
//        alert(d1);
//        
//        var d2 = new Date(evalue);
//        alert('d1-2');
//        alert(bvalue.valueOf()<=evalue.valueOf())
//        alert(Date.parse(d1) - Date.parse(d2));
//        if(Date.parse(d1) - Date.parse(d2)>=0){
//            alert("please select end_time later than begin_time !");
//            return false;
//        }
//    } 
//    
}
    </script>

    <link href="../../Css/BasicLayout.css" type="text/css" rel="stylesheet">
</head>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0">
    <form id="ManageStaff" method="post" runat="server">
    <font face="宋体">
    <%--<table bordercolor="#111111" height="1" cellspacing="0" cellpadding="0" width="100%" style="table-layout:fixed"
                        border="0">
                        
                            <tr>
                                <td width="20" height="30" background="../../Images/treetopbg.jpg" bgcolor="#c0d9e6" class="GbText">
                                    <font color="#003366" size="3">
                                        <img height="16" src="../../DataImages/staff.gif" width="16"></font>
                                </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" width="60"
                                    align="left" id="td_title" runat="server">我的日记
                          </td>
                                <td class="GbText" background="../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                                </td>
                            </tr>
                         
                    </table>--%>
                    <table width="100%" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
        bordercolor="#111111">
        <tr>
            <td class="GbText" width="20" background="../../../Images/treetopbg.jpg" bgcolor="#c0d9e6"
                align="right">
                <img height="16" src="../../../DataImages/myDoc2.gif" width="16">
            </td>
            <td width="60" height="30" align="center" background="../../../Images/treetopbg.jpg"  id="td_title" runat="server"
                bgcolor="#e8f4ff" class="GbText">
                <font color="#006699">新增日记</font>
            </td>
            <td class="GbText" background="../../../Images/treetopbg.jpg" bgcolor="#e8f4ff" align="right">
                <font face="宋体">
                  &nbsp;</font>
            </td>
        </tr>
    </table>
    
      </font>
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="10"></td>
      </tr>
    </table>
    <font face="宋体">
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table1" bordercolor="#93bee2">
        <tr>
            <td>
                <table class="gbtext" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,0));%>.gif'
                                height="24">
                            <asp:LinkButton ID="lbMyNote" runat="server" CssClass="Newbutton" OnClick="lbMyNote_Click">我的日记</asp:LinkButton>
                        </td>
                        <td align="center" width="90" background='../../images/maillistbutton<%Response.Write(GetSelectImage("1","2",DisplayType,1));%>.gif'
                                height="24">
                            <asp:LinkButton ID="lbNoteCollect" runat="server" CssClass="Newbutton" OnClick="lbNoteCollect_Click">日记查询</asp:LinkButton>
                        </td>
                        <td align="right">
                            <input class="redbuttoncss" style="width: 80px" onClick="location.href='NewDiary.aspx?ReturnPage=1';"
                                    type="button" value="新增日记">
                                    <asp:Button id="btnDelete"  style="width: 80px" runat="server" CssClass="redbuttoncss" Text="删除"></asp:Button>&nbsp;
                            <%--<asp:button id="btnAdd" runat="server" Text="新增日记" CssClass="redbuttoncss" 
                                            onclick="btnAdd_Click1"></asp:button>
										
										<asp:button id="btnShoucang" runat="server" Text="加入收藏" CssClass="redbuttoncss"></asp:button>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_Tj" runat="server" bgcolor="#e8f4ff">
            <td align="left">
                <table class="gbtext" id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right">
                            起始日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtBeginDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                    Columns="70" Width="120" ReadOnly="True"></asp:TextBox> 
                        </td>
                        <td align="right">
                            终止日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" onfocus="setday(this)" CssClass="InputCss" runat="server"
                                    Columns="70" Width="120" ReadOnly="True"></asp:TextBox>  
                            
                           
                        </td>
                        <td align="right">
                            内容：
                        </td>
                        <td height="30">
                            <asp:TextBox ID="txtContents" CssClass="InputCss" runat="server" Columns="70" Width="200"></asp:TextBox>
                        </td>
                        <td align="right">
                            人员：
                        </td>
                        <td height="30">
                            <asp:DropDownList ID="ddlStaff" runat="server"   style="height: 18px"  >
                            </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="redbuttoncss" Text="查询" OnClientClick="return isValiateTime();"
                                        OnClick="btnSearch_Click"></asp:Button>
                                <asp:TextBox ID="txtIsSearch" CssClass="InputCss" runat="server" Columns="70" Width="20"
                                        Text="0" Style="display: none;"></asp:TextBox>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="dbDiaryList" runat="server" OnPageIndexChanged="DataGrid_PageChanged"
                        BorderColor="#93BEE2" BorderStyle="None" BorderWidth="1px" BackColor="White"
                        CellPadding="3" PageSize="15" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyField="ID" Width="100%">
                    <SelectedItemStyle  ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" BackColor="#E8F4FF"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small"  ForeColor="White" BackColor="#337FB2">
                    </HeaderStyle>
                    <FooterStyle Font-Size="X-Small" HorizontalAlign="Right" BackColor="#E8F4FF"></FooterStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="ID">
                            <HeaderStyle Width="20px"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkNote_ID" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Contents" HeaderText="内容" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="72%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="UserName" HeaderText="用户名" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle Width="8%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SubmitDate" HeaderText="提交日期" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <%--<asp:TemplateColumn HeaderText="编辑">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<a href='NewNote.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>' target="_self">编辑</a>
										</ItemTemplate>
										<HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>--%>
                    </Columns>
                    <PagerStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF" Mode="NumericPages">
                    </PagerStyle>
                </asp:DataGrid>
                <asp:Label runat="server" ID="LabelPageInfo" Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
      </table>
    </font>
    </form>
</body>
</html>

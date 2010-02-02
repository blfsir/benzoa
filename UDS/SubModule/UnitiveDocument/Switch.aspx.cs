using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;
namespace UDS.SubModule.UnitiveDocument
{
	public class Switch : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				JumpPage();
			}
		}

		public void JumpPage()
		{
			Class newClass		= new Class ();
			string action		= Request.QueryString["Action"].ToString();
			string classID		= Request.QueryString["classID"].ToString();
			string classtype    = newClass.GetClassType(Int32.Parse(classID));
			string url;
			Response.Cookies["ActiveNodeID"].Value = classID.ToString();
			//Response.Write(action+","+classID+","+classtype);
			switch (action)
			{
				case "0":
					Response.Redirect("Document/DeliverDocument.aspx?ClassID="+classID);
					break;
				case "1":
					switch (classtype)
					{
						case "0":
							Response.Redirect("Project.aspx?classID="+classID);
							break;
						case "1":
							Response.Redirect("Document/ListView.aspx?classID="+classID);
							break;
						case "2":
						
							break;
						case "3":
							Response.Redirect("BBS/Catalog.aspx?classID="+classID);
							break;
						case "4":
							Response.Redirect("../Staff/ManageStaff.aspx?DisplayType=0");							
							break;
						case "5":
							Response.Redirect("Task/Listview.aspx");
							break;
						case "6":
							Response.Redirect("../Schedule/TaskList.aspx");
							break;
						case "7":
							Response.Redirect("Mail/Index.aspx?classID="+classID);														
							break;
						case "8":
							Response.Redirect("NewDoc/Listview.aspx");
							break;							
						case "9":
							Response.Redirect("DocumentFlow/ListDocument.aspx");
							break;	
						case "10":
							Response.Redirect("../CM/ClientListview.aspx");
							break;
						case "11":
							Response.Redirect("../LinkMan/Listview.aspx");
							break;
						case "12":							
							url="../position/index.htm";
							Response.Write("<script laguage='javascript'>parent.location='" + url + "';</script>");
							break;
						case "13":							
							url="../role/Index.aspx";
							Response.Write("<script laguage='javascript'>parent.location='" + url + "';</script>");
							break;
						case "14":							
							Response.Redirect("../WorkAttendance/SearchData.aspx");
							break;
						case "15":							
							Response.Redirect("../WorkAttendance/Set.aspx");
							break;
						case "16":							
							Response.Redirect("../SM/Index.aspx");
							break;
						case "17":							
							Response.Redirect("../USBKey/USBKey_setup.aspx");
							break;
						case "100":
							Response.Redirect("ManageQuery/ManageQuery.aspx");	
							break;
                        case "50":
                            Response.Redirect("Board/BoardManagement.aspx");
                            break;
                        case "52":
                            Response.Redirect("News/NewsManagement.aspx");
                            break;
                        case "55": //文档管理
                            Response.Redirect("Document/ListView.aspx?classID=" + classID);
                            break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

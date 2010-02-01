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
using System.Data.SqlClient;
using UDS.Components ;


namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// ProjectDetail 的摘要说明。
	/// </summary>
	public class ProjectDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblClassName;
		protected System.Web.UI.WebControls.Label lblBuildDate;
		protected System.Web.UI.WebControls.Label lblEndDate;
		protected System.Web.UI.WebControls.Label lblParentClassName;
		protected System.Web.UI.WebControls.Label lblDescription;
		protected System.Web.UI.WebControls.Label lblFinishedScale;
		protected System.Web.UI.WebControls.Label lblSubClass;
		protected System.Web.UI.WebControls.Label lblMember;
		protected System.Web.UI.WebControls.Label lblParentLeader;
		protected System.Web.UI.WebControls.Label lblLeader;
		public int classID = 0;
		protected HttpCookie UserCookie;
		protected System.Web.UI.WebControls.Label lblManageProject;
		protected System.Web.UI.WebControls.Label lblManageDirectory;
		protected System.Web.UI.WebControls.Label lblComposeMail;
		protected System.Web.UI.WebControls.Label lblDeliveryDoc;
		protected System.Web.UI.WebControls.Label lblShowMember;
		protected System.Web.UI.WebControls.Label lblManagePermission;
		protected System.Web.UI.HtmlControls.HtmlTable tblMailList;
		protected System.Web.UI.WebControls.Label lblSubscribe;
		protected System.Web.UI.WebControls.Label lblRemove;
		public static string Username;
		public static string Action="";
		protected System.Web.UI.WebControls.Image imgSubscribe;
		protected System.Web.UI.WebControls.Image imgComposeMail;
		protected System.Web.UI.WebControls.Image imgDeliveryDoc;
	    protected System.Web.UI.WebControls.Image imgManageDirectory;
		protected System.Web.UI.WebControls.Image imgShowMember;
		protected System.Web.UI.WebControls.Image imgManagePermission;
		protected System.Web.UI.WebControls.Image imgManageProject;
		protected System.Web.UI.WebControls.Image imgRemove;
		public static bool bSubscription;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(Request.QueryString["classID"]!=null)
			{
				classID = Int32.Parse(Request.QueryString["classID"]);
			}
			Action	 = (Request.QueryString["Action"]!=null)?Request.QueryString["Action"].ToString():"";
			if(Action=="5") SubscribeProject();
			UserCookie = Request.Cookies["Username"];
            Username = Server.UrlDecode(Request.Cookies["UserName"].Value); 
			if(Request.QueryString["Subscription"]==null)
			{
				bSubscription= false;
			}
			else
			{
				bSubscription =	Int32.Parse(Request.QueryString["Subscription"])>0?true:false;
			}

			if(!Page.IsPostBack)
			{
				PopulateData();
			}
		}

		#region 显示数据
		/// <summary>
		/// 显示数据
		/// </summary>
		private void PopulateData()
		{
		
			#region 初始化数据
			DataTable dataTable      = new DataTable();
			SqlDataReader dataReader = null;
			ProjectClass pjt		 = new ProjectClass ();
			MailClass mail			 = new MailClass();
			DocumentClass doc		 = new DocumentClass();
			#endregion
                #region 获取项目信息
                dataReader = pjt.GetClassInfo(classID);
                try
                {
                    if (dataReader.Read())
                    {
                        this.lblClassName.Text = dataReader[0].ToString();
                        this.lblParentClassName.Text = dataReader[2].ToString();
                        this.lblBuildDate.Text = dataReader[3].ToString();
                        this.lblEndDate.Text = dataReader[4].ToString();
                        this.lblFinishedScale.Text = dataReader[8].ToString();
                        this.lblDescription.Text = dataReader[7].ToString();

                    }
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region 获取子项目信息
                dataReader = pjt.GetSubClassInfo(classID);
                try
                {
                    while (dataReader.Read())
                    {
                        this.lblSubClass.Text += "<a href='Switch.aspx?Action=1&ClassID=" + dataReader[0].ToString() + "'>" + dataReader[1].ToString() + "</a>&nbsp;&nbsp;";
                    }
                    if (this.lblSubClass.Text == "") this.lblSubClass.Text = "无";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region 获取项目成员信息
                dataReader = pjt.GetMemberInClass(classID);
                try
                {
                    while (dataReader.Read())
                    {
                        this.lblMember.Text += "<a href='Mail/Compose.aspx?Action=3"
                        + "&ClassID=" + classID.ToString()
                        + "&Username=" + dataReader["Staff_Name"].ToString()
                        + "&Name=" + Server.UrlEncode(dataReader["RealName"].ToString())
                        + "'>"
                        + dataReader["RealName"].ToString()
                        + "</a> &nbsp;&nbsp;";
                    }
                    if (this.lblMember.Text == "") this.lblMember.Text = "无";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region 获取项目上级负责人信息
                dataReader = pjt.GetParentLeader(classID);
                try
                {
                    if (dataReader.Read())
                    {
                        this.lblParentLeader.Text += "<a href='Mail/Compose.aspx?Action=3"
                            + "&ClassID=" + classID.ToString()
                            + "&Username=" + dataReader["Staff_Name"].ToString()
                            + "&Name=" + Server.UrlEncode(dataReader["RealName"].ToString())
                            + "'>"
                            + dataReader["RealName"].ToString()
                            + "</a> &nbsp;&nbsp;";
                    }
                    if (this.lblParentLeader.Text == "") this.lblParentLeader.Text = "无";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region 获取项目负责人信息
                dataReader = pjt.GetLeader(classID);
                try
                {
                    while (dataReader.Read())
                    {
                        this.lblLeader.Text += "<a href='Mail/Compose.aspx?Action=3"
                            + "&ClassID=" + classID.ToString()
                            + "&Username=" + dataReader["Staff_Name"].ToString()
                            + "&Name=" + Server.UrlEncode(dataReader["RealName"].ToString())
                            + "'>"
                            + dataReader["RealName"].ToString()
                            + "</a> &nbsp;&nbsp;";
                    }
                    if (this.lblLeader.Text == "") this.lblLeader.Text = "无";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                //dataReader = null;
            
            finally
            {
                dataReader.Close();
            }
                #endregion

                #region 注释
                /*			
			#region 根据权限显示相关功能标题
			// 设置缺省值
			int cstRightToApproveDocument 	= 2;
			int cstRightToViewDocument		= 10;
			int cstRightToBuildNode		 	= 5;
			int cstDisplayMember			= 6;
			int cstTeamRight				= 7;
			int cstComposeMail				= 11;
			int cstDeliveryDoc				= 11;
			int cstProjectMove				= 5;
			this.lblManageProject.Visible   = pjt.GetAccessPermission(classID,Username,cstRightToBuildNode);
			this.imgManageProject .Visible  = this.lblManageProject .Visible ;
			this.lblManageDirectory.Visible = pjt.GetAccessPermission(classID,Username,cstRightToBuildNode);
			this.imgManageDirectory .Visible= this.lblManageDirectory .Visible ;
			this.lblComposeMail.Visible     = pjt.GetAccessPermission(classID,Username,cstComposeMail);
			this.imgComposeMail .Visible    = this.lblComposeMail .Visible ;
			this.lblDeliveryDoc.Visible     = pjt.GetAccessPermission(classID,Username,cstDeliveryDoc);
			this.imgDeliveryDoc.Visible     = this.lblDeliveryDoc .Visible ;
			this.lblShowMember.Visible      = pjt.GetAccessPermission(classID,Username,cstDisplayMember);
			this.imgShowMember .Visible     = this.lblShowMember .Visible ;
			this.lblManagePermission.Visible= pjt.GetAccessPermission(classID,Username,cstTeamRight);
			this.imgManagePermission .Visible = this.lblManagePermission .Visible ;
			this.lblRemove.Visible = pjt.GetAccessPermission(classID,Username,cstProjectMove);
			this.imgRemove.Visible = this.lblRemove.Visible;
			

			#endregion
		
			#region 根据权限取出邮件数据
			/// <summary>
			/// 将某用户的取出邮件数据
			/// </summary>
			
			dataTable			  = mail.GetClassMails(classID,UserCookie.Value.ToString());
			dgMailList.DataSource = dataTable.DefaultView;
			dgMailList.DataBind(); 
			
			mail = null;
			
			#endregion

			#region 根据权限取出文档数据
			/// <summary>
			/// 将某用户的文档数据取出
			/// </summary>
			if(pjt.GetAccessPermission(classID,Username,cstRightToViewDocument)||bSubscription)
			{
				dataTable			  = doc.GetClassDocs(classID);
				dgDocList.DataSource  = dataTable.DefaultView;
				dgDocList.DataBind(); 
				dataTable = null;
			}
			else
			{
				IMG1.Visible	  = false;
				IMG4.Visible      = false;
				dgDocList.Visible = false;
			}
			#endregion

			#region 根据权限取出某项目的审批文档数据
			/// <summary>
			/// 将某项目的审批文档数据取出
			/// </summary>
			if(pjt.GetAccessPermission(classID,Username,cstRightToApproveDocument))
			{
				dataTable		         = doc.GetApproveClassDocs(classID);
				dgAppDocList.DataSource  = dataTable.DefaultView;
				dgAppDocList.DataBind(); 
				dataTable = null;
				doc		  = null;
			}
			else
			{
				IMG3.Visible		 = false;
				dgAppDocList.Visible = false;
				lblApp.Visible       = false;
			}
			#endregion
			*/
                #endregion
            
		}
		#endregion

		#region 订阅项目
		/// <summary>
		/// 订阅项目
		/// </summary>
		private void SubscribeProject() 
		{
			ProjectClass prj = new ProjectClass();
			try
			{
				
				prj.Subscribe(Username,classID);
				prj = null;
				Response.Write("<script language=javascript>alert('订阅成功!');</script>");
		
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../Error.aspx");

			}
						
			
		}
		#endregion

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

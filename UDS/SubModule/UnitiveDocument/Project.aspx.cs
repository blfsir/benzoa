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
	/// Project ��ժҪ˵����
	/// </summary>
	public class Project : System.Web.UI.Page
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
		protected System.Web.UI.HtmlControls.HtmlTable tblMailList;
		protected System.Web.UI.WebControls.DataGrid dgMailList;
		protected System.Web.UI.WebControls.DataGrid dgDocList;
		protected System.Web.UI.WebControls.DataGrid dgAppDocList;
		protected System.Web.UI.HtmlControls.HtmlImage IMG1;
		protected System.Web.UI.HtmlControls.HtmlImage IMG2;
		protected System.Web.UI.HtmlControls.HtmlImage IMG3;
		protected System.Web.UI.WebControls.Label lblApp;
		public static string Username;
		public static string Action="";
		protected System.Web.UI.WebControls.Label lblComposeMail;
		protected System.Web.UI.WebControls.Label lblShowMember;
		protected System.Web.UI.WebControls.Label lblManageDirectory;
		protected System.Web.UI.WebControls.Label lblManageProject;
		protected System.Web.UI.WebControls.Label lblSubscribe;
		protected System.Web.UI.WebControls.Label lblDeliveryDoc;
		protected System.Web.UI.WebControls.Label lblRemove;
		protected System.Web.UI.WebControls.Label lblManagePermission;
		protected System.Web.UI.WebControls.Image imgComposeMail;
		protected System.Web.UI.WebControls.Image imgSubscribe;
		protected System.Web.UI.WebControls.Image imgShowMember;
		protected System.Web.UI.WebControls.Image imgManageDirectory;
		protected System.Web.UI.WebControls.Image imgRemove;
		protected System.Web.UI.WebControls.Image imgManageProject;
		protected System.Web.UI.WebControls.Image imgManagePermission;
		protected System.Web.UI.WebControls.Image imgDeliveryDoc;
		protected System.Web.UI.HtmlControls.HtmlImage line1;
		protected System.Web.UI.HtmlControls.HtmlImage line2;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr2;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr3;
		protected System.Web.UI.HtmlControls.HtmlTableRow tr1;
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

		public string GetRealName(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "";
		}
		
		#region ��ʾ����
		/// <summary>
		/// ��ʾ����
		/// </summary>
		private void PopulateData()
		{
		
			#region ��ʼ������
            SqlDataReader dataReader = null;
            //try
            //{
                DataTable dataTable = new DataTable();

                ProjectClass pjt = new ProjectClass();
                MailClass mail = new MailClass();
                DocumentClass doc = new DocumentClass();
            #endregion

                #region ��ȡ��Ŀ��Ϣ
                dataReader = pjt.GetClassInfo(classID);
                try
                {
                    if (dataReader.Read())
                    {
                        this.lblClassName.Text = dataReader[0].ToString();
                        //			this.lblParentClassName.Text = dataReader[2].ToString();
                        //			this.lblBuildDate.Text	     = dataReader[3].ToString();
                        //			this.lblEndDate.Text		 = dataReader[4].ToString();
                        //			this.lblFinishedScale.Text   = dataReader[8].ToString();
                        //			this.lblDescription.Text	 = dataReader[7].ToString();

                    }
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region ��ȡ��Ŀ��Ա��Ϣ
                dataReader = pjt.GetMemberInClass(classID);
                int i = 0;
                try
                {
                    while (dataReader.Read())
                    {
                        if (i < 3)
                            this.lblMember.Text += "<a href='Mail/Compose.aspx?Action=3"
                                + "&ClassID=" + classID.ToString()
                                + "&Username=" + dataReader["Staff_Name"].ToString()
                                + "&Name=" + Server.UrlEncode(dataReader["RealName"].ToString())
                                + "'>"
                                + dataReader["RealName"].ToString()
                                + "</a> &nbsp;&nbsp;";
                        i++;
                    }
                    if (i >= 3) this.lblMember.Text += "..";
                    if (this.lblMember.Text == "") this.lblMember.Text = "";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region ����Ȩ����ʾ��ع��ܱ���
                // ����ȱʡֵ
                int cstRightToApproveDocument = 2;
                int cstRightToViewDocument = 10;
                int cstRightToBuildNode = 5;
                int cstDisplayMember = 6;
                int cstTeamRight = 7;
                int cstComposeMail = 11;
                int cstDeliveryDoc = 11;
                int cstProjectMove = 12;
                this.lblManageProject.Visible = pjt.GetAccessPermission(classID, Username, cstRightToBuildNode);
                this.imgManageProject.Visible = this.lblManageProject.Visible;
                this.lblManageDirectory.Visible = pjt.GetAccessPermission(classID, Username, cstRightToBuildNode);
                this.imgManageDirectory.Visible = this.lblManageDirectory.Visible;
                this.lblComposeMail.Visible = pjt.GetAccessPermission(classID, Username, cstComposeMail);
                this.imgComposeMail.Visible = this.lblComposeMail.Visible;
                this.lblDeliveryDoc.Visible = pjt.GetAccessPermission(classID, Username, cstDeliveryDoc);
                this.imgDeliveryDoc.Visible = this.lblDeliveryDoc.Visible;
                this.lblShowMember.Visible = pjt.GetAccessPermission(classID, Username, cstDisplayMember);
                this.imgShowMember.Visible = this.lblShowMember.Visible;
                this.lblManagePermission.Visible = pjt.GetAccessPermission(classID, Username, cstTeamRight);
                this.imgManagePermission.Visible = this.lblManagePermission.Visible;
                this.lblRemove.Visible = pjt.GetAccessPermission(classID, Username, cstProjectMove);
                this.imgRemove.Visible = this.lblRemove.Visible;

                //			this.tr1.Visible				  = pjt.GetAccessPermission(classID,Username,cstRightToViewDocument);
                //			this.tr3.Visible 				  = pjt.GetAccessPermission(classID,Username,cstRightToApproveDocument);


                this.line1.Visible = pjt.GetAccessPermission(classID, Username, cstRightToViewDocument);
                //this.IMG1.Visible = this.line1.Visible;
                this.dgDocList.Visible = this.line1.Visible;
                this.imgSubscribe.Visible = this.line1.Visible;
                this.lblSubscribe.Visible = this.line1.Visible;
                this.line2.Visible = pjt.GetAccessPermission(classID, Username, cstRightToApproveDocument);
                //this.IMG3.Visible = this.line2.Visible;
                this.dgAppDocList.Visible = this.line2.Visible;

                #endregion

                #region ����Ȩ��ȡ���ʼ�����
                /// <summary>
                /// ��ĳ�û���ȡ���ʼ�����
                /// </summary>

                dataTable = mail.GetClassMails(classID, Server.UrlDecode(Request.Cookies["UserName"].Value));
                dgMailList.DataSource = dataTable.DefaultView;
                dgMailList.DataBind();

                mail = null;

                #endregion

                #region ����Ȩ��ȡ���ĵ�����
                /// <summary>
                /// ��ĳ�û����ĵ�����ȡ��
                /// </summary>
                if (pjt.GetAccessPermission(classID, Username, cstRightToViewDocument) || bSubscription)
                {
                    dataTable = doc.GetClassDocs(classID);
                    dgDocList.DataSource = dataTable.DefaultView;
                    dgDocList.DataBind();
                    dataTable = null;
                }
                else
                {
                    //				IMG1.Visible	  = false;
                    //				IMG4.Visible      = false;
                    dgDocList.Visible = false;
                }
                #endregion

                #region ����Ȩ��ȡ��ĳ��Ŀ�������ĵ�����
                /// <summary>
                /// ��ĳ��Ŀ�������ĵ�����ȡ��
                /// </summary>
                if (pjt.GetAccessPermission(classID, Username, cstRightToApproveDocument))
                {
                    dataTable = doc.GetApproveClassDocs(classID);
                    dgAppDocList.DataSource = dataTable.DefaultView;
                    dgAppDocList.DataBind();
                    dataTable = null;
                    doc = null;
                }
                else
                {
                    //IMG3.Visible = false;
                    dgAppDocList.Visible = false;
                    lblApp.Visible = false;
                }
                #endregion

            //}
            //finally
            //{ dataReader.Close(); }
		}
		#endregion

		#region ������Ŀ
		/// <summary>
		/// ������Ŀ
		/// </summary>
		private void SubscribeProject() 
		{
			ProjectClass prj = new ProjectClass();
			try
			{
				
				prj.Subscribe(Username,classID);
				prj = null;
				Response.Write("<script language=javascript>alert('���ĳɹ�!');</script>");
		
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
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

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
	/// ProjectDetail ��ժҪ˵����
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

		#region ��ʾ����
		/// <summary>
		/// ��ʾ����
		/// </summary>
		private void PopulateData()
		{
		
			#region ��ʼ������
			DataTable dataTable      = new DataTable();
			SqlDataReader dataReader = null;
			ProjectClass pjt		 = new ProjectClass ();
			MailClass mail			 = new MailClass();
			DocumentClass doc		 = new DocumentClass();
			#endregion
                #region ��ȡ��Ŀ��Ϣ
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

                #region ��ȡ����Ŀ��Ϣ
                dataReader = pjt.GetSubClassInfo(classID);
                try
                {
                    while (dataReader.Read())
                    {
                        this.lblSubClass.Text += "<a href='Switch.aspx?Action=1&ClassID=" + dataReader[0].ToString() + "'>" + dataReader[1].ToString() + "</a>&nbsp;&nbsp;";
                    }
                    if (this.lblSubClass.Text == "") this.lblSubClass.Text = "��";
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
                    if (this.lblMember.Text == "") this.lblMember.Text = "��";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region ��ȡ��Ŀ�ϼ���������Ϣ
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
                    if (this.lblParentLeader.Text == "") this.lblParentLeader.Text = "��";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../Error.aspx");
                }
                dataReader = null;
                #endregion

                #region ��ȡ��Ŀ��������Ϣ
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
                    if (this.lblLeader.Text == "") this.lblLeader.Text = "��";
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

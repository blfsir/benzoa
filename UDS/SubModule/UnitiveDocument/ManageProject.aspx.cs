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
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// ManagerProject ��ժҪ˵����
	/// </summary>
	public class ManagerProject : System.Web.UI.Page
	{
		public static string ClassID="";
		protected System.Web.UI.WebControls.Label lblCreate;
		protected System.Web.UI.WebControls.Label lblDelete;
		protected System.Web.UI.WebControls.Label lblRevise;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv1;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.HtmlControls.HtmlInputText txtClassName;
		protected System.Web.UI.HtmlControls.HtmlInputText txtScale;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtBrief;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv2;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv3;
		protected System.Web.UI.WebControls.Button btnRevise;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.RadioButtonList Status;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfv4;
		public string Action="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			ClassID = (Request.QueryString["ClassID"]!=null)?Request.QueryString["ClassID"].ToString():"";
			Action  = (Request.QueryString["Action"]!=null)?Request.QueryString["Action"].ToString():"";
			
			if(!Page.IsPostBack)
			{	
				PopulateRadioList();
				if(Action=="1")
				{
					this.lblCreate.BackColor = Color.FromName("#1ED2CA");
					this.btnRevise.Visible = false;
					this.btnDelete.Visible = false;
				}
				if(Action=="2")
				{
					UDS.Components .ProjectClass prj = new ProjectClass();
					this.lblDelete.BackColor = Color.FromName("#1ED2CA");
					this.btnRevise .Visible = false;
					this.btnDelete.Visible = true;
					this.btnSubmit .Visible = false;
					PopulateReviseData();
					if(ClassID!="1")
					{
						if(prj.IsExistSubClass(Int32.Parse(ClassID)))
							this.btnDelete.Attributes["onClick"] = "javascript:alert('����Ŀ�������ӽڵ㣬����ɾ��!!');return false;";
						else
							this.btnDelete.Attributes["onClick"] = "javascript:return confirm('��ȷ����?');";
					}
					else
					{
						this.btnDelete.Attributes["onClick"] = "javascript:alert('���ڵ㲻�ܱ�ɾ��!');return false;";
					}
					
				}
				if(Action=="3")
				{
					this.lblRevise.BackColor = Color.FromName("#1ED2CA");
					this.btnSubmit.Visible = false;
					this.btnDelete .Visible = false;
					PopulateReviseData();
				}
			 }
          
            
		}


		#region �����Ŀ
		/// <summary>
		/// �����Ŀ
		/// </summary>
		private void AddProject() 
		{
			ProjectClass prj = new ProjectClass();
			HttpCookie UserCookie = Request.Cookies["Username"];
			String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			if(DateTime.Parse(Request.Form["txtStartDate"].ToString())>DateTime.Parse(Request.Form["txtEndDate"].ToString()))
			{
				Response.Write("<script language=javascript>alert('��ʼʱ�䲻�ܴ��ڽ���ʱ��!');</script>");
			}
			else
			{
				try
				{
				
					prj.Add(Int32.Parse(ClassID),this.txtClassName.Value.ToString(),this.txtBrief.Value.ToString(),
						Username,Int32.Parse(this.Status.SelectedIndex.ToString()),Int32.Parse(this.txtScale.Value.ToString()),
						DateTime.Parse(Request.Form["txtStartDate"].ToString()),DateTime.Parse(Request.Form["txtEndDate"].ToString()));
			
					prj = null;
					Response.Write("<script language=javascript>alert('��ӳɹ�!');parent.LeftFrame.location='ProjectTreeView.aspx?classID="+ClassID+"';</script>");
		
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");

				}
			}	
			
		}
		#endregion

		#region �޸���Ŀ
		/// <summary>
		/// �޸���Ŀ
		/// </summary>
		private void ReviseProject() 
		{
			ProjectClass prj = new ProjectClass();
			HttpCookie UserCookie = Request.Cookies["Username"];
			String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			if(DateTime.Parse(Request.Form["txtStartDate"].ToString())>DateTime.Parse(Request.Form["txtEndDate"].ToString()))
			{
				Response.Write("<script language=javascript>alert('��ʼʱ�䲻�ܴ��ڽ���ʱ��!');</script>");
			}
			else
			{
				try
				{
				
					prj.Revise(Int32.Parse(ClassID),this.txtClassName.Value.ToString(),this.txtBrief.Value.ToString(),
						Int32.Parse(this.Status.SelectedIndex.ToString()),Int32.Parse(this.txtScale.Value.ToString()),
						DateTime.Parse(Request.Form["txtStartDate"].ToString()),DateTime.Parse(Request.Form["txtEndDate"].ToString()));
			
					prj = null;
					Response.Write("<script language=javascript>alert('�޸ĳɹ�!');parent.LeftFrame.location='ProjectTreeView.aspx?classID="+ClassID+"';</script>");
		
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.ToString());
					Server.Transfer("../Error.aspx");

				}
			}
						
			
		}
		#endregion

		#region ɾ����Ŀ
		/// <summary>
		/// ɾ����Ŀ
		/// </summary>
		private void DeleteProject() 
		{
			ProjectClass prj = new ProjectClass();
			HttpCookie UserCookie = Request.Cookies["Username"];
			String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			try
			{
				prj.Delete(Int32.Parse(ClassID));
				prj = null;
				Response.Write("<script language=javascript>alert('ɾ���ɹ�!');parent.location.reload();</script>");
		
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../Error.aspx");

			}
						
			
		}
		#endregion

		#region ���޸�ʱ����
		/// <summary>
		/// ���޸�ʱ����
		/// </summary>
		private void PopulateReviseData() 
		{
			SqlDataReader dataReader = null; 
			ProjectClass prj = new ProjectClass();
            try
            {
                dataReader = prj.GetProjectDetail(Int32.Parse(ClassID));
                dataReader.Read();
                this.txtClassName.Value = dataReader[0].ToString();
                this.txtBrief.Value = dataReader[7].ToString();
                this.txtScale.Value = dataReader[6].ToString();
                this.txtStartDate.Text = ProjectClass.changeString(dataReader[3].ToString());
                this.txtEndDate.Text = ProjectClass.changeString(dataReader[4].ToString());
                this.Status.SelectedIndex = Int32.Parse(dataReader[5].ToString());
                prj = null;
                //dataReader = null;
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");

            }
            finally
            { dataReader.Close(); }
			
		}
		#endregion

		#region ��ʼ����ѡ��
		/// <summary>
		/// �Ե�ѡ����г�ʼ��
		/// </summary>
		private void PopulateRadioList() 
		{
			
			this.Status.Items.Add(new ListItem("������","1"));
			this.Status.Items.Add(new ListItem("�ȴ�����","2"));
			this.Status.Items.Add(new ListItem("����","3"));
			this.Status.Items.Add(new ListItem("ȡ��","4"));
			this.Status.Items.Add(new ListItem("���","5"));
			this.Status.SelectedIndex = 0;
			
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnRevise.Click += new System.EventHandler(this.btnRevise_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			AddProject();
		}

		private void btnRevise_Click(object sender, System.EventArgs e)
		{
			ReviseProject();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			DeleteProject();
		}

	
		

		

		

		
	}
}

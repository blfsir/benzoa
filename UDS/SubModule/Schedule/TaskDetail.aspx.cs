using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;

namespace UDS.SubModule.Schedule
{
	/// <summary>
	/// TaskDetail ��ժҪ˵����
	/// </summary>
	public class TaskDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTaskDetailTitle;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblArrangedBy;
		protected System.Web.UI.WebControls.Label lblStartTime;
		protected System.Web.UI.WebControls.Label lblEndTime;
		protected System.Web.UI.WebControls.Label lblProjectID;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblDetail;
		protected System.Web.UI.WebControls.Label lblType;
		protected System.Web.UI.WebControls.Label lblAttribute;
		protected System.Web.UI.WebControls.Label lblCooperator;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnAccept;
		protected System.Web.UI.WebControls.Button btnFinish;
		protected static string TaskID,Username,Date;
		protected System.Web.UI.WebControls.TextBox txtComment;
		protected System.Web.UI.WebControls.Button btnAddCom;
		protected System.Web.UI.HtmlControls.HtmlGenericControl TaskCommentFrm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Task task	  = new Task();
			if(!Page.IsPostBack)
			{
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				TaskID		  = (Request.QueryString["TaskID"]!=null)?Request.QueryString["TaskID"].ToString():"0";
				Date		  = (Request.QueryString["Date"]!=null)?Request.QueryString["Date"].ToString():DateTime.Today.ToShortDateString();
				
				TaskClass tsk = task.GetTaskDetail(Int32.Parse(TaskID)); 
				if(tsk.ArrangedBy==Username) 
				{
					this.btnDelete .Visible = true;
					this.btnFinish .Visible = true;
					this.btnCancel.Visible = false;
					this.btnAccept.Visible = false;
				}
				

				PopulateData(tsk);
				tsk = null;
				
				TaskCommentFrm.Attributes["src"] = "TaskComment.aspx?TaskID="+TaskID;
				this.btnFinish .Attributes["onclick"] = "javascript:return confirm('��ȷ����?')";
				this.btnDelete.Attributes["onclick"] = "javascript:return confirm('��ȷ��Ҫɾ����������?')";
			}

			SetStatus();
			int status = task.GetTaskStatusBySomeone(Int32.Parse(TaskID),Username);
			if(status==2)
			{
				this.btnAccept.Enabled = false;
				this.btnCancel .Enabled = false;
				this.btnFinish .Enabled = false;
			}
			
		}

		private void SetStatus()
		{
			string Username="",ActualUsername="";
			if(Session["Username"]!=null)
			{
				Username = Session["Username"].ToString();
				ActualUsername = Session["ActualUsername"].ToString();
			}
			else
			{
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
                ActualUsername = Username;
			}
			this.txtComment.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
			this.btnAccept.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
			this.btnCancel.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
			this.btnFinish.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
			this.btnDelete.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
			this.btnAddCom.Enabled = (ActualUsername.ToLower() ==Username.ToLower());
		}
		private void PopulateData(TaskClass tsk)
		{	
			string ClassName = "",Type="";
			
			switch (tsk.Type) {
			case 1:
				Type="����";
				break;
			case 2:
				Type="�İ�";
				break;
			case 3:
				Type="����";
				break;
			case 4:
				Type="�绰";
				break;
			case 5:
				Type="�߷�";
				break;
			case 6:
				Type="���";
				break;
			case 7:
				Type="����";
				break;
			case 8:
				Type="����";
				break;
			
			}
			
			
			
			this.lblSubject .Text		= tsk.Subject ;
			this.lblDetail .Text		= tsk.Detail ;
			this.lblStartTime .Text		= (DateTime.Parse(tsk.StartTime).ToShortTimeString()=="0:00")?DateTime.Parse(tsk.StartTime).ToShortDateString()+" 8:00":tsk.StartTime;
			this.lblEndTime .Text		= (DateTime.Parse(tsk.EndTime).ToShortTimeString()=="0:00")?DateTime.Parse(tsk.EndTime).ToShortDateString()+" 18:00":tsk.EndTime;
			this.lblArrangedBy .Text	= UDS.Components .Staff.GetRealNameByUsername(tsk.ArrangedBy) ;
			this.lblCooperator .Text    = UDS.Components .Staff.GetRealNameStrByUsernameStr(tsk.CooperatorList,0) ;
			
			this.lblType.Text			= Type;
			this.lblAttribute.Text		= tsk.Attribute.ToString()=="1"?"��ռ����":"��ʱ����";
			if(tsk.ProjectID!=0)
			{
				ProjectClass prj = new ProjectClass();
				SqlDataReader dataReader =  prj.GetProjectDetail(tsk.ProjectID);
                try
                {
                    if (dataReader.Read())
                        ClassName = dataReader["ClassName"].ToString();
                }
                finally
                {
                    dataReader.Close();
                }
				prj = null;
			}
            this.lblProjectID .Text = (tsk.ProjectID ==0)?"��":"<a href='#' onclick=javascript:window.close();window.dialogArguments.location='../UnitiveDocument/Project.aspx?classID="+tsk.ProjectID .ToString()+"'>"+ClassName+"</a>";

		}

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
			this.btnAddCom.Click += new System.EventHandler(this.btnAddCom_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			Task task	  = new Task();
			try
			{
				task.DeleteTask(Int32.Parse(TaskID));
				task = null;
				Response.Write("<script language=javascript>alert('ɾ���ɹ�!');window.dialogArguments.location='TaskList.aspx?displayType="+UDS.SubModule .Schedule.TaskList.displayType.ToString()+"';window.close();</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
		}

		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			Task task	  = new Task();
			try
			{
				task.DealTask(TaskID,2,Username,Date);
				task = null;
				Response.Write("<script language=javascript>alert('������ɲ����ɹ�!');window.dialogArguments.location='TaskList.aspx?displayType="+UDS.SubModule .Schedule.TaskList.displayType.ToString()+"';window.close();</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
		
		}

		private void btnAccept_Click(object sender, System.EventArgs e)
		{
			Task task	  = new Task();
			try
			{
				task.DealTask(TaskID,1,Username,Date);
				task = null;
				Response.Write("<script language=javascript>alert('������ܲ����ɹ�!');window.dialogArguments.location='TaskList.aspx?displayType="+UDS.SubModule .Schedule.TaskList.displayType.ToString()+"';window.close();</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Task task	  = new Task();
			try
			{
				task.DealTask(TaskID,0,Username,Date);
				task = null;
				Response.Write("<script language=javascript>alert('����ȡ�������ɹ�!');window.dialogArguments.location='TaskList.aspx?displayType="+UDS.SubModule .Schedule.TaskList.displayType.ToString()+"';window.close();</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
		
		}

		private void btnAddCom_Click(object sender, System.EventArgs e)
		{
			HttpCookie UserCookie = Request.Cookies["Username"];
            string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			Task task	  = new Task();
			try
			{
				task.AddTaskComment(Username,this.txtComment .Text,Int32.Parse(TaskID));
				task = null;
				Response.Write("<script language=javascript>alert('������ӳɹ�!');</script>");
				TaskCommentFrm.Attributes["src"] = "TaskComment.aspx?TaskID="+TaskID;
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
		
		}
	}
}

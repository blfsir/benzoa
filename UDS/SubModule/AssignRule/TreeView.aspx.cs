using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace UDS.SubModule.AssginRule
{
	/// <summary>
	/// TreeView ��ժҪ˵����
	/// </summary>
	public class frmAddRight : System.Web.UI.Page
	{
		public string SrcID;
		public string DisplayType;
		private string UserName;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

			if(!Page.IsPostBack)
			{
				//��Ȩ��select				

				if ((Request["SrcID"] == null) && (Request["DisplayType"] == null)) 
				{
					SrcID = "";
					DisplayType="";
				}
				else 
				{
					SrcID = Request["SrcID"].ToString();
					DisplayType = Request["DisplayType"].ToString();
				}
			}

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
			this.ID = "frmAddRight";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void cmdAdd_ServerClick(object sender, System.EventArgs e)
		{
			
//			UDS.Components.AssignRights ar = new UDS.Components.AssignRights(classID,displaytype,(int)UDS.Components.AssignRightsAction.RULE_ADD,ObjID.Text,Act.Items[Act.SelectedIndex].Value,"");
//			try
//			{
//				if(ar.execute())
//					Response.Redirect("RightListview.aspx?ObjID="+ar.SrcID+"&displayType="+ar.DisplayType);
//			}
//			catch(Exception ex)
//			{
//				UDS.Components.Error.Log(ex.ToString());
//				Server.Transfer("../Error.aspx");
//			}
		}

	}
}

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
using System.Data.SqlClient;
using System.IO;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// Flow 的摘要说明。
	/// </summary>
	public class Flow : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFlowName;
        protected System.Web.UI.WebControls.TextBox txtFlowClass;
		protected System.Web.UI.WebControls.TextBox txtFlowRemark;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList dpStyle;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button cmdNext;
		protected System.Web.UI.WebControls.Button cmdFinish;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.Button cmdPrevious;
        protected System.Web.UI.WebControls.FileUpload FileUpload1;
        protected System.Web.UI.WebControls.DropDownList ddl_FileType;
        
        protected System.Web.UI.HtmlControls.HtmlTextArea Content;
        protected System.Web.UI.HtmlControls.HtmlInputFile hif;

		private long FlowID;

        protected System.Web.UI.WebControls.Button btn_DelAtt;
        protected System.Web.UI.WebControls.ListBox lbx_AttList;
        protected System.Web.UI.WebControls.Button btn_UpAtt;

 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			FlowID = Request.QueryString["FlowID"]!=null?Int32.Parse(Request.QueryString["FlowID"].ToString()):0;
			
			if(!Page.IsPostBack)
			{				
				Bangding();
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
            
			this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
			this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
           
		}
		#endregion

		private void Bangding()
		{
			int StyleID=0;	
			if(FlowID>0)
			{
				UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
				DataTable dt;
				df.GetFlow(FlowID,out dt);
				if(dt.Rows.Count >0)
				{
					txtFlowName.Text	= dt.Rows[0]["Flow_Name"].ToString();
					txtFlowRemark.Text	= dt.Rows[0]["Remark"].ToString();
                    txtFlowClass.Text   = dt.Rows[0]["Flow_Class"].ToString();
					StyleID				= Int32.Parse(dt.Rows[0]["Style_ID"].ToString());

				}
			}
			FillStyle(StyleID);

		}
		private void FillStyle(int StyleID)
		{
			Database mySQL = new Database();
			SqlDataReader dr;

			mySQL.RunProc("sp_Flow_GetStyle",out dr);		
			dpStyle.Items.Clear();
            try
            {
                while (dr.Read())
                {
                    dpStyle.Items.Add(new ListItem(dr["style_name"].ToString(), dr["style_id"].ToString()));
                    if (dr["style_id"].ToString() == StyleID.ToString())
                        dpStyle.SelectedIndex = dpStyle.Items.Count - 1;
                }
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
		}

		private void cmdNext_Click(object sender, System.EventArgs e)
		{
			String UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
           
			if(FlowID<=0)
			{
                FlowID = df.AddFlow(txtFlowName.Text, txtFlowRemark.Text, UserName, Int32.Parse(dpStyle.Items[dpStyle.SelectedIndex].Value), txtFlowClass.Text);
				if(FlowID>0)
				{
                    UploadAtt(FlowID);
					Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=1");
				}
				df = null;
			}
			else
			{
                if (df.UpdateFlow(FlowID, txtFlowName.Text, txtFlowRemark.Text, UserName, Int32.Parse(dpStyle.Items[dpStyle.SelectedIndex].Value), txtFlowClass.Text) == 0)
				{
                    UploadAtt(FlowID);
					Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=1");
				}
				df = null;
			}
			
			Server.Transfer("Listview.aspx");
			
		}

		private void cmdFinish_Click(object sender, System.EventArgs e)
		{

			String UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

          
			if(FlowID<=0)
			{

                FlowID = df.AddFlow(txtFlowName.Text, txtFlowRemark.Text, UserName, Int32.Parse(dpStyle.Items[dpStyle.SelectedIndex].Value), txtFlowClass.Text);
				if(FlowID>0)
				{
                    UploadAtt(FlowID);
					Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());			
				}
				df = null;
			}
			else
			{

                if (df.UpdateFlow(FlowID, txtFlowName.Text, txtFlowRemark.Text, UserName, Int32.Parse(dpStyle.Items[dpStyle.SelectedIndex].Value), txtFlowClass.Text) == 0)
				{
                    UploadAtt(FlowID);
					Server.Transfer("EditTache.aspx?FlowID=" + FlowID.ToString() + "&StepID=1");
				}
				df = null;
				Server.Transfer("ManageFlow.aspx?FlowID=" + FlowID.ToString());			
			}
			
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx");					
		}


        /// <summary>
        /// 上载文件
        /// </summary>
        private void UploadAtt(long FlowID)
        {
            HtmlForm FrmCompose = (HtmlForm)this.Page.FindControl("Flow");
            UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();

            string FileName = "";
            string Extension = "";
            string SavedName = "";
            string TotalSavedName = "";
            try
            {
                if (System.IO.Directory.Exists(Server.MapPath(".") + "\\Attachment"))
                {
                    for (int i = 0; i < FrmCompose.Controls.Count; i++)
                    {
                        if (FrmCompose.Controls[i].GetType().ToString() == "System.Web.UI.HtmlControls.HtmlInputFile")
                        {
                            HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
                            if (hif.PostedFile.FileName.Trim() != "")
                            {
                                FileName = System.IO.Path.GetFileName(hif.PostedFile.FileName);
                                Extension = System.IO.Path.GetExtension(hif.PostedFile.FileName);

                                SavedName = "Flow" + FlowID.ToString();
                                TotalSavedName += SavedName + Extension;
                                hif.PostedFile.SaveAs(Server.MapPath(".") + "\\Attachment\\" + SavedName + Extension);
                            }
                            hif = null;
                        }
                    }
                 //   return (TotalSavedName);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(".") + "\\Attachment");
                    UploadAtt(FlowID);
                   // return (TotalSavedName);
                }
                UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
                if (TotalSavedName.Length <= 0)
                {
                    TotalSavedName = "noimg.jpg";
                }
                if (0 != df.UpdateAttatchFile(FlowID, TotalSavedName))
                {
                    Server.Transfer("../../Error.aspx");
                }
            }
            catch (Exception ioex)
            {
                UDS.Components.Error.Log(ioex.ToString());
                Server.Transfer("../../Error.aspx");
                 
            }

        }


     

       
	}
}

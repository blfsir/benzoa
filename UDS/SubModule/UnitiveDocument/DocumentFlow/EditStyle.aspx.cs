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


namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// EditStyle 的摘要说明。
	/// </summary>
	public class EditStyle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblStyleName;
		protected System.Web.UI.WebControls.Label lblStyleRemark;
		protected System.Web.UI.WebControls.Label lblStyleTeamlate;
		protected System.Web.UI.WebControls.Button cmdOK;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtStyleName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtStyleRemark;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileTemplate;
		protected System.Web.UI.WebControls.Label lblTemplate;
		protected System.Web.UI.HtmlControls.HtmlTableRow Template;
		public long StyleID=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			StyleID = Request.QueryString["StyleID"]!=null?Int32.Parse(Request.QueryString["StyleID"].ToString()):0;
			if(StyleID>0&&!Page.IsPostBack)
				Bangding();
			else
				Template.Visible  = false;

		}
		private void Bangding()
		{
			SqlDataReader dr;
			Database db = new Database();
			SqlParameter[] parms = {
										db.MakeInParam("@StyleID",SqlDbType.Int  ,4,StyleID),
									};
			db.RunProc("sp_Flow_GetStyle",parms,out dr);
            try
            {
                if (dr.Read())
                {
                    txtStyleName.Text = dr["Style_Name"].ToString();
                    txtStyleRemark.Text = dr["Style_Remark"].ToString();
                    lblTemplate.Text = "<a href='" + @"Template\" + dr["Template"].ToString() + "'>" + dr["Template"].ToString() + "</a>";
                    if (dr["Template"].ToString() == "")
                        Template.Visible = false;
                    else
                        Template.Visible = true;

                }
                else
                {
                    Template.Visible = false;
                }

                if (db != null)
                {
                    db.Close();
                    db = null;
                }
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
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
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			string FileName;
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			try
			{
				FileName = UploadFile();
				if(StyleID==0)
					StyleID = df.AddStyle(txtStyleName.Text,txtStyleRemark.Text,FileName);
				else
				{					
					df.UpdateStyle(StyleID,txtStyleName.Text,txtStyleRemark.Text,FileName,Server.MapPath(".")+@"\Template");
				}
			}
			finally
			{
				if(df!=null)
					df = null;
			}
			//Server.Transfer("ManageStyle.aspx");
			Server.Transfer("DefineStyle.aspx?StyleID=" + StyleID.ToString());

		}
		public string UploadFile()
		{
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("EditStyle");
			HtmlInputFile hif = (HtmlInputFile)(FrmCompose.FindControl("fileTemplate"));
			if(hif.PostedFile.FileName.Trim()!="")
			{					
				string FileName;
				FileName = System.IO.Path.GetFileName(hif.PostedFile.FileName);											
					
				//生成模板目录
				if(!System.IO.Directory.Exists(Server.MapPath(".")+"\\Template"))
				{
					System.IO.Directory.CreateDirectory(Server.MapPath(".")+"\\Template");						
				}
										
				//保存文件
				hif.PostedFile.SaveAs(Server.MapPath(".")+"\\Template\\" + FileName);
				hif=null;
				return FileName;
			}
			else
				return "";
			
		}

	}
}

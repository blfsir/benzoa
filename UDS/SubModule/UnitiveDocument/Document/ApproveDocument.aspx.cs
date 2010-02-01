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

namespace UDS.SubModule.UnitiveDocument.Document
{
	/// <summary>
	/// ApproveDocument 的摘要说明。
	/// </summary>
	public class ApproveDocument : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDocTitle;
		protected System.Web.UI.WebControls.Label lblDocApprover;
		protected System.Web.UI.WebControls.Label lblDocApproveDate;
		protected System.Web.UI.WebControls.Label lblAddedBy;
		protected System.Web.UI.WebControls.Label lblAddedDate;
		protected System.Web.UI.WebControls.Label lblDocViewedTimes;
		protected System.Web.UI.WebControls.Label lblClassName;
		protected System.Web.UI.WebControls.Label lblDocContent;
		protected System.Web.UI.WebControls.Label lblFileVisualPath;
		public static int DocID;
		protected System.Web.UI.WebControls.Button btnApprove;
		protected HttpCookie UserCookie;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			UserCookie = Request.Cookies["Username"];
			if(!Page.IsPostBack)
			{
				DocID = Int32.Parse(Request.QueryString["DocID"]);
				ShowBodyDetail();
			}
		}

		#region 使用DataReader显示文档内容
		protected void ShowBodyDetail()
		{
			
			UDS.Components.DocumentClass  doc = new UDS.Components.DocumentClass();
			SqlDataReader dataReader = null; 
			try
			{
                dataReader = doc.GetDocDetail(DocID, Server.UrlDecode(Request.Cookies["UserName"].Value));
			}
			catch
			{
				Server.Transfer("../../Error.aspx");
			}
			int count = 0;
            try
            {
                while (dataReader.Read())
                {
                    count++;
                    this.lblDocTitle.Text = dataReader["DocTitle"].ToString();
                    this.lblDocApprover.Text = UDS.Components.Staff.GetRealNameByUsername(dataReader["DocApprover"].ToString());
                    this.lblDocApproveDate.Text = dataReader["DocApproveDate"].ToString() == "1900-1-1 00:00:00" ? "" : dataReader["DocApproveDate"].ToString();
                    this.lblAddedBy.Text = UDS.Components.Staff.GetRealNameByUsername(dataReader["DocAddedby"].ToString());
                    this.lblAddedDate.Text = dataReader["DocAddedDate"].ToString();
                    this.lblDocViewedTimes.Text = dataReader["DocViewedTimes"].ToString();
                    this.lblClassName.Text = dataReader["ClassName"].ToString();
                    this.lblDocContent.Text = dataReader["DocContent"].ToString();
                    if (dataReader["FileCatlog"].ToString() != "")
                    {
                        if (dataReader["FileCatlog"].ToString() == "Mail")
                            this.lblFileVisualPath.Text += "&nbsp;<a href='Download.aspx?destFileName=\\" + dataReader["FileVisualPath"].ToString() + "'>" + dataReader["FileName"].ToString() + "</a><br>";
                        //this.lblFileVisualPath.Text += "<a href='../"+dataReader[21].ToString()+"'>"+dataReader[18].ToString()+"</a><br>&nbsp;&nbsp;";
                        else
                            this.lblFileVisualPath.Text += "<a href='Download.aspx?destFileName=\\Document\\" + dataReader["FileVisualPath"].ToString() + "'>" + dataReader["FileName"].ToString() + "</a><br>&nbsp;&nbsp;";
                    }
                }
            }
            finally
            {
                dataReader.Close();
            }
			doc = null;
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
			this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnApprove_Click(object sender, System.EventArgs e)
		{
			Database mySQL = new Database();
			String UserName;
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

			SqlParameter[] parameters = {												
											mySQL.MakeInParam("@DocIDs",SqlDbType.VarChar,300,DocID),
											mySQL.MakeInParam("@Approver",SqlDbType.VarChar,300,UserName)
										};
		
			if(mySQL.RunProc("sp_ApproveDocument",parameters)>0)
			{
				Response.Write("<script language='javascript'>window.alert('审批文件成功!');self.location='../Desktop.aspx';</script>");
			}	
			else
				Response.Write("<script language='javascript'>window.alert('审批文件成功!');self.location='../Desktop.aspx';</script>");
				
		}
	}
}

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
	/// BrowseDocument 的摘要说明。
	/// </summary>
	public class BrowseDocument : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDocApprover;
		protected System.Web.UI.WebControls.Label lblDocApproveDate;
		protected System.Web.UI.WebControls.Label lblAddedBy;
		protected System.Web.UI.WebControls.Label lblAddedDate;
		protected System.Web.UI.WebControls.Label lblDocViewedTimes;
		protected System.Web.UI.WebControls.Label lblDocContent;
		protected System.Web.UI.WebControls.Label lblFileVisualPath;
		protected System.Web.UI.WebControls.Label lblClassName;
		public static int DocID;
		protected System.Web.UI.WebControls.Label lblDocTitle;
		protected System.Web.UI.WebControls.DataList DataListDocument;
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
//			this.DataListDocument.DataSource = UDS.Components .Tools.ConvertDataReaderToDataTable(dataReader).DefaultView;
//			this.DataListDocument.DataBind();
			
			int count = 0;
            try
            {
                while (dataReader.Read())
                {
                    count++;
                    this.lblDocTitle.Text = dataReader["DocTitle"].ToString();
                    this.lblDocApprover.Text = UDS.Components.Staff.GetRealNameByUsername(dataReader["DocApprover"].ToString());
                    this.lblDocApproveDate.Text = dataReader["DocApproveDate"].ToString();
                    this.lblAddedBy.Text = UDS.Components.Staff.GetRealNameByUsername(dataReader["DocAddedBy"].ToString());
                    this.lblAddedDate.Text = dataReader["DocAddedDate"].ToString();
                    this.lblDocViewedTimes.Text = dataReader["DocViewedTimes"].ToString();
                    this.lblClassName.Text = dataReader["ClassName"].ToString();
                    this.lblDocContent.Text = dataReader["DocContent"].ToString();
                    if (dataReader["FileVisualPath"].ToString() != "")
                    {
                        if (dataReader["FileVisualPath"].ToString().Substring(0, 4) == "Mail")
                            this.lblFileVisualPath.Text += "&nbsp;<a target='blank' href='Download.aspx?destFileName=\\" + Server.UrlEncode(dataReader["FileVisualPath"].ToString()) + "'>" + dataReader["FileName"].ToString() + "</a><br>";
                        //this.lblFileVisualPath.Text += "<a href='../"+dataReader[21].ToString()+"'>"+dataReader[18].ToString()+"</a><br>&nbsp;&nbsp;";
                        else
                            this.lblFileVisualPath.Text += "<a target='blank' href='Download.aspx?destFileName=\\Document\\" + Server.UrlEncode(dataReader["FileVisualPath"].ToString()) + "'>" + dataReader["FileName"].ToString() + "</a><br>&nbsp;&nbsp;";
                    }
                }
            }
            finally
            {
                dataReader.Close();
                doc = null;
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

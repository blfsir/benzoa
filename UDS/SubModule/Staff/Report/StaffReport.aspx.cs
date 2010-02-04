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

namespace UDS.SubModule.Staff.Report
{
	/// <summary>
	/// StaffReport 的摘要说明。
	/// </summary>
	public class StaffReport : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer crv_StaffList;
		protected System.Web.UI.WebControls.Button btn_Change;
		protected System.Web.UI.WebControls.DropDownList ddl_FileFormat;
		protected System.Web.UI.WebControls.LinkButton lbtn_IEPrint;
	
		private StaffDataSet ds;
		private StaffList stafflistreport;

		private string staffname,mobile,gender,email,bound,dept;
		private int positionid;
		private string[] displayfields;

		private void Page_Load(object sender, System.EventArgs e)
		{
			ds = new StaffDataSet();
			DataTable dt =(DataTable)Cache["StaffList"];
			if(!Page.IsPostBack)
			{
				staffname = Session["staffname"].ToString();
				positionid = Int32.Parse(Session["positionid"].ToString());
				mobile = Session["mobile"].ToString();
				email = Session["email"].ToString();
				gender = Session["gender"].ToString();
                dept = Session["dept"].ToString();
				bound = Session["bound"].ToString();
				displayfields = (string[])Session["displayfieldsname"];

				ViewState["staffname"] = staffname;
				ViewState["positionid"] = positionid.ToString();
				ViewState["mobile"] = mobile.ToString();
				ViewState["email"] = email.ToString();
				ViewState["gender"] = gender.ToString();
                ViewState["dept"] = dept.ToString();
				ViewState["bound"] = bound.ToString();
				ViewState["displayfields"] = displayfields;

				Session["staffname"] = null;
				Session["positionid"] = null;
				Session["mobile"] = null;
				Session["gender"] = null;
                Session["dept"] = null;
				Session["displayfieldsname"] = null;
				Session["bound"] = null;
			}
			else
			{
				staffname = ViewState["staffname"].ToString();
				positionid = Int32.Parse(ViewState["positionid"].ToString());
				mobile = ViewState["mobile"].ToString();
				email = ViewState["email"].ToString();
				gender = ViewState["gender"].ToString();
                dept = ViewState["dept"].ToString();
				bound = ViewState["bound"].ToString();
				displayfields = (string[])ViewState["displayfields"];
			}

			if(dt==null)
			{
				//得不到缓存的内容，重新获取
				SqlDataReader dr;
				UDS.Components.Staff staff = new UDS.Components.Staff();
                dr = staff.Find(staffname, positionid, mobile, email, gender, dept,bound);
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);

				Cache["StaffList"] = dt;
				
			}

			//添加datatable中的数据
			foreach(DataRow row in dt.Rows)
			{
				DataRow staffviewrow = ds.StaffView.NewRow();
				staffviewrow["Staff_Name"] = row["Staff_Name"].ToString();
				staffviewrow["RealName"] = row["RealName"].ToString();
				staffviewrow["Mobile"] = row["Mobile"].ToString();
				staffviewrow["SexName"] = row["SexName"].ToString();
				staffviewrow["Email"] = row["Email"].ToString();
				staffviewrow["Position_Name"] = row["Position_Name"].ToString();
				ds.StaffView.AddStaffViewRow((StaffDataSet.StaffViewRow)staffviewrow);
			}

			stafflistreport = new StaffList();
			stafflistreport.SetDataSource(ds);
			crv_StaffList.ReportSource = stafflistreport;
			//根据用户选择隐藏字段
			foreach(string fieldname in displayfields)
			{
				stafflistreport.ReportDefinition.ReportObjects["ttl"+fieldname].ObjectFormat.EnableSuppress = false;
				stafflistreport.ReportDefinition.ReportObjects[fieldname].ObjectFormat.EnableSuppress = false;
			}
			
			crv_StaffList.DataBind();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.lbtn_IEPrint.Click += new System.EventHandler(this.lbtn_IEPrint_Click);
			this.ddl_FileFormat.SelectedIndexChanged += new System.EventHandler(this.ddl_FileFormat_SelectedIndexChanged);
			this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_Change_Click(object sender, System.EventArgs e)
		{
			string filetype = "";
			filetype = ddl_FileFormat.SelectedValue;
			string contenttype = "";
			

			string myfilename = Request.MapPath(".")+"\\ReportExportFile\\"+Session.SessionID+"."+filetype;
			CrystalDecisions.Shared.DiskFileDestinationOptions mydiskfiledestinationoptions = new CrystalDecisions.Shared.DiskFileDestinationOptions();
			mydiskfiledestinationoptions.DiskFileName = myfilename;
			CrystalDecisions.Shared.ExportOptions myExportOptions = stafflistreport.ExportOptions;
			myExportOptions.DestinationOptions = mydiskfiledestinationoptions;
			myExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;

			switch(ddl_FileFormat.SelectedItem.Value)
			{
				case "pdf":
					contenttype = "application/pdf";
					myExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
					break;
				case "doc":
					contenttype = "application/msword";
					myExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
					break;
			}
			
			
			stafflistreport.Export();

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = contenttype;
			Response.WriteFile(myfilename);
			Response.Flush();
			Response.Close();

			System.IO.File.Delete(myfilename);
		}

		private void lbtn_IEPrint_Click(object sender, System.EventArgs e)
		{
			if(lbtn_IEPrint.Text == "IE打印预览")
			{
				crv_StaffList.SeparatePages = false;
				crv_StaffList.DisplayToolbar = false;
				lbtn_IEPrint.Text = "取消IE打印预览";
			}
			else
			{
				crv_StaffList.SeparatePages = true;
				crv_StaffList.DisplayToolbar = true;
				lbtn_IEPrint.Text = "IE打印预览";
			}
		}

		private void ddl_FileFormat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

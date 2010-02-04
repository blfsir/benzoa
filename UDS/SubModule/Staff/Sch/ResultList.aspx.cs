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

namespace UDS.SubModule.Staff.Sch
{
	/// <summary>
	/// ResultList 的摘要说明。
	/// </summary>
	public class ResultList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrd_StaffList;
		private string staffname,mobile,gender,email,bound,dept;
		private int positionid;
		private int[] displayfieldsid;
		private string[] displayfieldsname;

		protected System.Web.UI.WebControls.Button btn_Print;
		//存放页眉文字
		private string[] headtext;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				headtext = new String[dgrd_StaffList.Columns.Count];
				for(int i=0;i<dgrd_StaffList.Columns.Count;i++)
				{
					headtext[i] = dgrd_StaffList.Columns[i].HeaderText;
				}
				ViewState["headtext"] = headtext;

				//获得来源页面的句柄
				Search searchform = (Search)Context.Handler;
				staffname = searchform.StaffName.Trim();
				positionid = searchform.Postion;
				mobile = (searchform.MobileSwitch==true)?searchform.Mobile:"";
				email = (searchform.EmailSwitch==true)?searchform.Email:"";
				gender = (searchform.GenderSwitch==true)?searchform.Gender:"";
                dept = (searchform.DeptSwitch == true) ? searchform.Dept : "";
				bound = searchform.SearchBound;
				displayfieldsid = searchform.SelectedFields;
				displayfieldsname = searchform.SelectedFieldsName;

				ViewState["staffname"] = staffname;
				ViewState["positionid"] = positionid.ToString();
				ViewState["mobile"] = mobile.ToString();
				ViewState["email"] = email.ToString();
				ViewState["gender"] = gender.ToString();
                ViewState["dept"] = dept.ToString();
				ViewState["bound"] = bound.ToString();
				ViewState["displayfiledsid"] = displayfieldsid;

				Session["staffname"] = staffname;
				Session["positionid"] = positionid;
				Session["mobile"] = mobile;
				Session["email"] = email.ToString();
				Session["gender"] = gender.ToString();
                Session["dept"] = dept.ToString();
				Session["bound"] = bound.ToString();
				Session["displayfieldsname"] = displayfieldsname;

				BindGrid(staffname,positionid,mobile,email,gender,dept,displayfieldsid);
				
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
				displayfieldsid = (int[])ViewState["displayfiledsid"];

				//把页眉复位
				headtext = (string[]) ViewState["headtext"];
				for(int i=0;i<dgrd_StaffList.Columns.Count;i++)
				{
					dgrd_StaffList.Columns[i].HeaderText = headtext[i];
				}
			}
		}

        private void BindGrid(string staffname, int positionid, string mobile, string email, string gender, string dept, int[] displayfiledsid)
		{
			SqlDataReader dr;
			UDS.Components.Staff staff = new UDS.Components.Staff();
			dr = staff.Find(staffname,positionid,mobile,email,gender,dept,bound);
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			if(ViewState["sortfield"]!=null)
				dt.DefaultView.Sort = ViewState["sortfield"] + " " + ViewState["sortdirect"];
			
			dgrd_StaffList.DataSource = dt.DefaultView;

			//放入高速缓存中便于打印
			Cache["StaffList"] = dt;

			for(int i=0;i<displayfieldsid.Length;i++)
			{
				dgrd_StaffList.Columns[displayfiledsid[i]].Visible = true;
			}
			dgrd_StaffList.DataBind();
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
			this.dgrd_StaffList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_StaffList_PageIndexChanged);
			this.dgrd_StaffList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgrd_StaffList_SortCommand);
			this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgrd_StaffList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
            BindGrid(staffname, positionid, mobile, email, gender, dept,displayfieldsid);
		}

		private void dgrd_StaffList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(ViewState["sortfield"] == null)
			{
				ViewState["sortfield"] = e.SortExpression;
				ViewState["sortdirect"] = "ASC";
			}
			else
			{
				if(ViewState["sortfield"].ToString()==e.SortExpression)
				{
					ViewState["sortdirect"] = (ViewState["sortdirect"].ToString()=="ASC"?"DESC":"ASC");
				}
				else
				{
					ViewState["sortfield"] = e.SortExpression;
					ViewState["sortdirect"] = "ASC";
				}
			}

			foreach(DataGridColumn col in  dgrd_StaffList.Columns)
			{
				if(col.SortExpression.ToString()==ViewState["sortfield"].ToString())
				{
					if(ViewState["sortdirect"].ToString() == "ASC")
						col.HeaderText += "<img src='../../../images/asc.gif' border=0/>";
					else
						col.HeaderText += "<img src='../../../images/desc.gif' border=0/>";
				}
			}

            BindGrid(staffname, positionid, mobile, email, gender, dept, displayfieldsid);


		}

		private void btn_Print_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.open('../Report/StaffReport.aspx','_blank')</script>");
		}
	}
}

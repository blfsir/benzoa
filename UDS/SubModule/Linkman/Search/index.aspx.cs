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

namespace UDS.SubModule.Linkman.Search
{
	/// <summary>
	/// index 的摘要说明。
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddl_SearchType;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_StaffSearch;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_LinkmanSearch;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_CutomSearch;
		protected System.Web.UI.WebControls.TextBox tbx_StaffMobile;
		protected System.Web.UI.WebControls.TextBox tbx_StaffEmail;
		protected System.Web.UI.WebControls.TextBox tbx_StaffName;
		protected System.Web.UI.WebControls.TextBox tbx_LinkmanName;
		protected System.Web.UI.WebControls.TextBox tbx_Telephone;
		protected System.Web.UI.WebControls.TextBox tbx_LinkmanUnit;
		protected System.Web.UI.WebControls.TextBox tbx_LinkmanEmail;
		protected System.Web.UI.WebControls.TextBox tbx_LinkmanMobile;
		protected System.Web.UI.WebControls.TextBox tbx_LinkmanPosition;
		protected System.Web.UI.WebControls.DropDownList ddl_LinkmanGender;
		protected System.Web.UI.WebControls.TextBox tbx_CutomName;
		protected System.Web.UI.WebControls.DropDownList ddl_CustomGender;
		protected System.Web.UI.WebControls.TextBox tbx_CutomEmail;
		protected System.Web.UI.WebControls.TextBox tbx_CutomMobile;
		protected System.Web.UI.WebControls.DropDownList ddl_CustomCatalog;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.DropDownList ddl_StaffPosition;
		protected System.Web.UI.WebControls.DataGrid dgrd_Staff;
		protected System.Web.UI.WebControls.DataGrid dgrd_Linkman;
		protected System.Web.UI.WebControls.DataGrid dgrd_Custom;
		protected System.Web.UI.WebControls.DropDownList ddl_StaffGender;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				tbl_StaffSearch.Visible = true;
				tbl_LinkmanSearch.Visible = false;
				tbl_CutomSearch.Visible = false;

				BindCutomTypeList();
				BindStaffPosition();
			}
			else
			{

			}
		}

		private void BindCutomTypeList()
		{
			UDS.Components.MyLinkman mylinkman = new UDS.Components.MyLinkman();
			ddl_CustomCatalog.DataSource = mylinkman.GetCustomLinkmanType();
			ddl_CustomCatalog.DataTextField = "Type";
			ddl_CustomCatalog.DataValueField = "ID";
			ddl_CustomCatalog.DataBind();

			ddl_CustomCatalog.Items.Insert(0,new ListItem("无限制","0"));

		}

		private void BindStaffPosition()
		{
			UDS.Components.Staff staff = new UDS.Components.Staff();
			ddl_StaffPosition.DataSource = staff.GetAllPosition();
			ddl_StaffPosition.DataTextField = "Position_Name";
			ddl_StaffPosition.DataValueField = "Position_ID";
			ddl_StaffPosition.DataBind();

			ddl_StaffPosition.Items.Insert(0,new ListItem("无限制","0"));
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
			this.ddl_SearchType.SelectedIndexChanged += new System.EventHandler(this.ddl_SearchType_SelectedIndexChanged);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddl_SearchType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(ddl_SearchType.SelectedValue)
			{
				case "staff":
					tbl_StaffSearch.Visible = true;
					tbl_LinkmanSearch.Visible = false;
					tbl_CutomSearch.Visible = false;
					break;
				case "linkman":
					tbl_StaffSearch.Visible = false;
					tbl_LinkmanSearch.Visible = true;
					tbl_CutomSearch.Visible = false;
					break;
				case "custom":
					tbl_StaffSearch.Visible = false;
					tbl_LinkmanSearch.Visible = false;
					tbl_CutomSearch.Visible = true;
					break;
			}
		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.MyLinkman linkman = new UDS.Components.MyLinkman();
			SqlDataReader dr_linkman=null;
			DataTable dt_linkman = new DataTable();
			string filter = "";
            try
            {
                switch (ddl_SearchType.SelectedValue)
                {
                    case "staff":
                        dr_linkman = linkman.GetMyLinkman(1, Int32.Parse(Request.Cookies["UserID"].Value));

                        if (tbx_StaffName.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("RealName LIKE '*" + tbx_StaffName.Text.Trim() + "*'") : filter + " and RealName LIKE '*" + tbx_StaffName.Text.Trim() + "*'";
                        }
                        if (tbx_StaffMobile.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Mobile LIKE '*" + tbx_StaffMobile.Text.Trim() + "*'") : filter + " and Mobile LIKE '*" + tbx_StaffMobile.Text.Trim() + "*'";
                        }
                        if (ddl_StaffGender.SelectedValue != "0")
                        {
                            if (ddl_StaffGender.SelectedValue == "male")
                            {
                                if (filter == "")
                                    filter = "Sex=True";
                                else
                                    filter += " and Sex=True";
                            }
                            else
                            {
                                if (filter == "")
                                    filter = "Sex=False";
                                else
                                    filter += " and Sex=False";
                            }
                        }
                        if (tbx_StaffEmail.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Email LIKE '*" + tbx_StaffEmail.Text.Trim() + "'") : filter + " and Email LIKE '*" + tbx_StaffEmail.Text.Trim() + "*'";
                        }
                        if (ddl_StaffPosition.SelectedValue != "0")
                        {
                            filter = (filter == "") ? ("Position_ID=" + ddl_StaffPosition.SelectedValue) : filter + " and Position_ID=" + ddl_StaffPosition.SelectedValue;
                        }

                        dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);

                        try
                        {

                            dt_linkman.DefaultView.RowFilter = filter;
                            dgrd_Staff.DataSource = dt_linkman.DefaultView;
                            dgrd_Staff.DataBind();

                        }
                        catch (Exception ex)
                        {
                            Response.Write(filter + "   " + ex.Message);
                        }


                        dgrd_Staff.Visible = true;
                        dgrd_Linkman.Visible = false;
                        dgrd_Custom.Visible = false;
                        break;

                    case "linkman":
                        dr_linkman = linkman.GetMyLinkman(2, Int32.Parse(Request.Cookies["UserID"].Value));

                        if (tbx_LinkmanName.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Name LIKE '*" + tbx_LinkmanName.Text.Trim() + "*'") : filter + " and Name LIKE '*" + tbx_LinkmanName.Text.Trim() + "*'";
                        }
                        if (tbx_Telephone.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Telephone LIKE '*" + tbx_Telephone.Text.Trim() + "*'") : filter + " and Telephone LIKE '*" + tbx_Telephone.Text.Trim() + "*'";
                        }
                        if (ddl_LinkmanGender.SelectedValue != "0")
                        {
                            if (ddl_LinkmanGender.SelectedValue == "male")
                            {
                                if (filter == "")
                                    filter = "Gender=True";
                                else
                                    filter += " and Gender=True";
                            }
                            else
                            {
                                if (filter == "")
                                    filter = "Gender=False";
                                else
                                    filter += " and Gender=False";
                            }
                        }
                        if (tbx_LinkmanEmail.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Email LIKE '*" + tbx_LinkmanEmail.Text.Trim() + "*'") : filter + " and Email LIKE '*" + tbx_LinkmanEmail.Text.Trim() + "*'";
                        }
                        if (tbx_LinkmanUnit.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("UnitName LIKE '*" + tbx_LinkmanUnit.Text.Trim() + "*'") : filter + " AND UnitName LIKE '*" + tbx_LinkmanUnit.Text.Trim() + "*'";
                        }
                        if (tbx_LinkmanPosition.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Position LIKE '*" + tbx_LinkmanPosition.Text.Trim() + "*'") : filter + " AND Position LIKE '*" + tbx_LinkmanPosition.Text.Trim() + "*'";
                        }
                        if (tbx_LinkmanMobile.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Mobile LIKE '*" + tbx_LinkmanMobile.Text.Trim() + "*'") : filter + " AND Mobile LIKE '*" + tbx_LinkmanMobile.Text.Trim() + "*'";
                        }

                        dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);

                        try
                        {

                            dt_linkman.DefaultView.RowFilter = filter;
                            dgrd_Linkman.DataSource = dt_linkman.DefaultView;
                            dgrd_Linkman.DataBind();

                        }
                        catch (Exception ex)
                        {
                            Response.Write(filter + "   " + ex.Message);
                        }


                        dgrd_Staff.Visible = false;
                        dgrd_Linkman.Visible = true;
                        dgrd_Custom.Visible = false;
                        break;

                    case "custom":
                        DataSet ds = new DataSet();
                        dr_linkman = linkman.GetMyLinkman(3, Int32.Parse(Request.Cookies["UserID"].Value));

                        if (tbx_CutomName.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Name LIKE '*" + tbx_CutomName.Text.Trim() + "*'") : filter + " and Name LIKE '*" + tbx_CutomName.Text.Trim() + "*'";
                        }

                        if (ddl_CustomGender.SelectedValue != "0")
                        {
                            if (ddl_CustomGender.SelectedValue == "male")
                            {
                                if (filter == "")
                                    filter = "Gender=True";
                                else
                                    filter += " and Gender=True";
                            }
                            else
                            {
                                if (filter == "")
                                    filter = "Gender=False";
                                else
                                    filter += " and Gender=False";
                            }
                        }
                        if (tbx_CutomEmail.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Email LIKE '*" + tbx_CutomEmail.Text.Trim() + "*'") : filter + " and Email LIKE '*" + tbx_CutomEmail.Text.Trim() + "*'";
                        }
                        if (tbx_CutomMobile.Text.Trim() != "")
                        {
                            filter = (filter == "") ? ("Mobile LIKE '*" + tbx_CutomMobile.Text.Trim() + "*'") : filter + " AND Mobile LIKE '*" + tbx_CutomMobile.Text.Trim() + "*'";
                        }
                        if (ddl_CustomCatalog.SelectedValue != "0")
                        {
                            SqlDataReader dr_linkmantype = linkman.GetLinkmanTypeRelation();
                            //DataTable dt_linkmantype = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkmantype);
                            //得到满足分类的联系人id
                            string ids = "";
                            while (dr_linkmantype.Read())
                            {
                                if (Convert.ToInt32(dr_linkmantype["TypeID"]) == Int32.Parse(ddl_CustomCatalog.SelectedValue))
                                {
                                    ids += dr_linkmantype["CustomLinkmanID"].ToString() + ",";
                                }
                            }
                            if (ids != "")
                                ids = ids.Substring(0, ids.Length - 1);

                            filter = (filter == "") ? ("ID IN (" + ids + ")") : (filter + " AND ID IN (" + ids + ")");
                        }


                        dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);


                        try
                        {

                            dt_linkman.DefaultView.RowFilter = filter;
                            dgrd_Custom.DataSource = dt_linkman.DefaultView;
                            dgrd_Custom.DataBind();

                        }
                        catch (Exception ex)
                        {
                            Response.Write(filter + "   " + ex.Message);
                        }


                        dgrd_Staff.Visible = false;
                        dgrd_Linkman.Visible = false;
                        dgrd_Custom.Visible = true;
                        break;
                }
            }
            finally
            {
                dr_linkman.Close();
                dr_linkman.Dispose();
            }

		}
	}
}

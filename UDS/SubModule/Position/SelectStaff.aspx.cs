using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace UDS.SubModule.Position
{
    public partial class SelectStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateData();
            }
        }

        #region 初始化下拉列表框
        /// <summary>
        /// 对数据进行初始化
        /// </summary>
        private void PopulateData()
        {

            UDS.Components.Staff staff = new UDS.Components.Staff();
            listAccount.Items.Clear();
            listAccount.DataSource = staff.GetAllStaffs();
            listAccount.DataTextField = "RealName";
            listAccount.DataValueField = "Staff_Name";
            listAccount.DataBind();

            listDept.DataSource = staff.GetPositionList(1);
            listDept.DataTextField = "Position_Name";
            listDept.DataValueField = "Position_ID";
            listDept.DataBind();
            listDept.Items.Insert(0, new ListItem("公司所有部门", "0"));
            listDept.SelectedIndex = 0;
            listDept.Attributes["onclick"] = "SaveValue()";
            staff = null;
        }
        #endregion

        #region 下拉列表事件
        public void DeptListChange(object sender, System.EventArgs e)
        {

            UDS.Components.Staff staff = new UDS.Components.Staff();
            if (listDept.SelectedItem.Value != "0")
            {

                listAccount.DataSource = staff.GetStaffByPosition(Int32.Parse(listDept.SelectedItem.Value));
            }
            else
            {
                listAccount.DataSource = staff.GetAllStaffs();
            }
            listAccount.DataTextField = "RealName";
            listAccount.DataValueField = "Staff_Name";
            listAccount.DataBind();
            staff = null;
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            UDS.Components.Staff staff = new UDS.Components.Staff();
            DataTable datatable = UDS.Components.Tools.ConvertDataReaderToDataTable(staff.FindStaffByName(this.txtSearchName.Text));
            listAccount.DataSource = datatable;
            listAccount.DataTextField = "RealName";
            listAccount.DataValueField = "Staff_Name";
            listAccount.DataBind();
            this.txtSearchName.Text = "";
            staff = null;
        }
    }
}

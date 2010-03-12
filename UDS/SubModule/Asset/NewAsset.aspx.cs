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
using ActiveRecord.Model;
using UDS.Components;
using System.Data.SqlClient;

namespace UDS.SubModule.Asset
{
    public partial class NewAsset : System.Web.UI.Page
    {
        public string SendTo = "", MobileSendTo = "", SendToRealName = "", MobileSendToRN = "", AdditionalNo = "", Type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDDL();
                BindDept();

                int assetID = 0;


                assetID = Request.QueryString["AssetID"] != null ? Int32.Parse(Request.QueryString["AssetID"].ToString()) : 0;
                if (assetID > 0 && !Page.IsPostBack)
                {
                    this.lblAssetID.Text = assetID.ToString();
                    Bangding(assetID);
                }
            }
        }
        private void BindDept()
        {
            UDS.Components.Database db = new UDS.Components.Database();
            SqlDataReader dr_department = null;
            SqlDataReader currentDept = null;
            try
            {
                db.RunProc("sp_GetAllDept", out dr_department);
                ddlOriginalDept.DataSource = dr_department;
                
                ddlOriginalDept.DataTextField = "Dept_Name";
                ddlOriginalDept.DataValueField = "Dept_ID";
                ddlOriginalDept.DataBind();

                db.RunProc("sp_GetAllDept", out currentDept);

                ddlCurrentDept.DataSource = currentDept;
                 
                ddlCurrentDept.DataTextField = "Dept_Name";
                ddlCurrentDept.DataValueField = "Dept_ID";
                ddlCurrentDept.DataBind();
                
            }
            finally
            {
                db.Close();
                dr_department.Close();
                currentDept.Close();
            }
        }


        private void BindDDL()
        {
            //8 droplist
            //location
            AssetCurrentLocation at = new AssetCurrentLocation();
            AssetCurrentLocation[] atArrary = AssetCurrentLocation.FindAll();
            DataTable dt = Converter.ConvertToDataTable(atArrary);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Name";
            this.ddlLocation.DataTextField = "Name";
            this.ddlLocation.DataValueField = "ID";
            this.ddlLocation.DataSource = dt;
            this.ddlLocation.DataBind();

            //state 
            AssetUseState[] auArrary = AssetUseState.FindAll();
            DataTable dt1 = Converter.ConvertToDataTable(auArrary);
            dt1.Columns[0].ColumnName = "ID";
            dt1.Columns[1].ColumnName = "Name";
            ddlUseState.DataTextField = "Name";
            this.ddlUseState.DataValueField = "ID";
            this.ddlUseState.DataSource = dt1;
            this.ddlUseState.DataBind();


            //type 
            AssetType[] attArrary = AssetType.FindAll();
            DataTable dt2 = Converter.ConvertToDataTable(attArrary);
            dt2.Columns[0].ColumnName = "ID";
            dt2.Columns[1].ColumnName = "Name";
            ddlType.DataTextField = "Name";
            this.ddlType.DataValueField = "ID";
            this.ddlType.DataSource = dt2;
            this.ddlType.DataBind();


            #region 协同人员列表初始化
            UDS.Components.Staff staff = new UDS.Components.Staff();
            try
            {

                ddlBuyUser.DataTextField = "Staff_Name";
                ddlBuyUser.DataValueField = "Staff_ID";
                ddlBuyUser.DataSource = staff.GetAllStaffs();
                ddlBuyUser.DataBind();

                ddlCurrentUser.DataTextField = "Staff_Name";
                ddlCurrentUser.DataValueField = "Staff_ID";
                ddlCurrentUser.DataSource = staff.GetAllStaffs();
                ddlCurrentUser.DataBind();

                ddlOriginalUser.DataTextField = "Staff_Name";
                ddlOriginalUser.DataValueField = "Staff_ID";
                ddlOriginalUser.DataSource = staff.GetAllStaffs();
                ddlOriginalUser.DataBind();




            }
            catch (Exception e)
            {
                UDS.Components.Error.Log(e.ToString());
                Server.Transfer("../Error.aspx");
            }
            finally
            {
                staff = null;
            }
            #endregion
            


        }


        private void Bangding(int assetID)
        {
            ActiveRecord.Model.Asset at = new ActiveRecord.Model.Asset();
            at = ActiveRecord.Model.Asset.Find(assetID);

            this.txtName.Text = at.AssetName;
            this.txtNumber.Text = at.AssetNumber.ToString();
            this.ddlType.SelectedValue = at.AssetTypeID.ToString();
            this.ddlOriginalUser.SelectedValue = at.AssetPreviousUserID.ToString();
            this.ddlOriginalDept.SelectedValue = at.AssetPreviousUserDept.ToString();
            this.ddlCurrentUser.SelectedValue = at.AssetCurrentUserID.ToString();
            this.ddlCurrentDept.SelectedValue = at.AssetCurrentUserDept.ToString();
            this.ddlLocation.SelectedValue = at.AssetCurrentLocation.ToString();
            this.ddlUseState.SelectedValue = at.AssetCurrentUseState.ToString();
            this.ddlBuyUser.SelectedValue = at.AssetBuyUserID.ToString();
            txtBuyDate.Text = at.AssetBuyDate.ToShortDateString();
            txtMoveDate.Text = at.AssetMoveDate.ToShortDateString();
            txtWarrantyPeriod.Text = at.AssetWarrantyPeriod;

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            ActiveRecord.Model.Asset asset = new ActiveRecord.Model.Asset();
            asset.AssetName = this.txtName.Text;
            asset.AssetTypeID = int.Parse(ddlType.SelectedValue);
            string number = this.txtNumber.Text == "" ? "0" : this.txtNumber.Text;
            asset.AssetNumber = int.Parse(number);
            asset.AssetPreviousUserID = int.Parse(ddlOriginalUser.SelectedValue);
            asset.AssetPreviousUserDept = int.Parse(ddlOriginalDept.SelectedValue);
            asset.AssetCurrentUserID = int.Parse(ddlCurrentUser.SelectedValue);
            asset.AssetCurrentUserDept = int.Parse(ddlCurrentDept.SelectedValue);
            asset.AssetCurrentLocation = int.Parse(ddlLocation.SelectedValue);
            asset.AssetCurrentUseState = int.Parse(ddlUseState.SelectedValue);
            asset.AssetBuyUserID = int.Parse(ddlBuyUser.SelectedValue);
            string buyDate = (Request.Form["txtBuyDate"].ToString()=="")?"1900-1-1":Request.Form["txtBuyDate"].ToString();
            asset.AssetBuyDate = DateTime.Parse(buyDate);
            string moveDate = (Request.Form["txtMoveDate"].ToString() == "") ? "1900-1-1" : Request.Form["txtMoveDate"].ToString();
            asset.AssetMoveDate = DateTime.Parse(moveDate);
           // asset.AssetCreateDate = DateTime.Now;
            asset.AssetWarrantyPeriod = this.txtWarrantyPeriod.Text;


            if (this.lblAssetID.Text == "")
            {
                asset.Save();
                Response.Write("<script language=javascript>alert('新增IT设备保存完毕！');</script>");
                Response.Redirect("AssetMange.aspx");
            }
            else
            {
                asset.ID = int.Parse(this.lblAssetID.Text);
                asset.Update();
                Response.Write("<script language=javascript>alert('IT设备更新完毕！');</script>");
                Response.Redirect("AssetMange.aspx");
            }

           

        }
    }
}

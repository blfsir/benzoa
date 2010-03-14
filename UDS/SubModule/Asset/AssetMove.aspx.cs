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

namespace UDS.SubModule.Asset
{
    public partial class AssetMove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDDL();
            }
        }

        private void BindDDL()
        {
            #region 协同人员列表初始化
            UDS.Components.Staff staff = new UDS.Components.Staff();
            try
            {

                ddlMoveTo.DataTextField = "Staff_Name";
                ddlMoveTo.DataValueField = "Staff_ID";
                ddlMoveTo.DataSource = staff.GetAllStaffs();
                ddlMoveTo.DataBind();

               
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           string  selectedID = (Request.QueryString["AssetIDs"] == null) ? "" : Request.QueryString["AssetIDs"].ToString();
           string[] ids = selectedID.Split(',');
            foreach (string id in ids)
            {
                //原使用人
                ActiveRecord.Model.Asset asset = new ActiveRecord.Model.Asset();
                asset = ActiveRecord.Model.Asset.Find(int.Parse(id));

                ActiveRecord.Model.AssetHistory ah = new ActiveRecord.Model.AssetHistory();
                ah.AssetID = asset.ID;
                ah.AssetName = asset.AssetName;
                ah.UserID = asset.AssetCurrentUserID;
                ah.UserName = "";
                ah.CreateDate = DateTime.Now;
                ah.Save();
                asset.AssetPreviousUserID = asset.AssetCurrentUserID;
                asset.AssetPreviousUserDept = asset.AssetCurrentUserDept;
                asset.AssetCurrentUserID = int.Parse(ddlMoveTo.SelectedValue);
                asset.Update();
                //现使用人
            }
        }
    }
}

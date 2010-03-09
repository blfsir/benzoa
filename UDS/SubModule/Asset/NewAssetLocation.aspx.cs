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

namespace UDS.SubModule.Asset
{
    public partial class NewAssetLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int assetID = 0;


            assetID = Request.QueryString["LocationID"] != null ? Int32.Parse(Request.QueryString["LocationID"].ToString()) : 0;
            if (assetID > 0 && !Page.IsPostBack)
            {
                this.lblAssetID.Text = assetID.ToString();
                Bangding(assetID);
            }


        }

        private void Bangding(int assetID)
        {
            AssetCurrentLocation at = new AssetCurrentLocation();
            at = AssetCurrentLocation.Find(assetID);
            this.txtName.Text = at.AssetCurrentLocationName;
            this.txtRemark.Text = at.AssetCurrentLocationRemark;

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            AssetCurrentLocation at = new AssetCurrentLocation();
            //  at.ID = this.lblAssetID.Text ==""?0:int.Parse(this.lblAssetID.Text);
            at.AssetCurrentLocationName = this.txtName.Text;
            at.AssetCurrentLocationRemark = this.txtRemark.Text;

            if (this.lblAssetID.Text == "")
            {
                at.Save();
                Response.Write("<script language=javascript>alert('存放位置保存完毕！');</script>");
            }
            else
            {
                at.ID = int.Parse(this.lblAssetID.Text);
                at.Update();
                Response.Write("<script language=javascript>alert('存放位置更新完毕！');</script>");
            }



        }
    }
}

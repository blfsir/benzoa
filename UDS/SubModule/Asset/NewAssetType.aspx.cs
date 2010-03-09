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

namespace UDS.SubModule.Asset
{
    public partial class NewAssetType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int assetID = 0;


            assetID = Request.QueryString["AssetID"] != null ? Int32.Parse(Request.QueryString["AssetID"].ToString()) : 0;
            if (assetID > 0 && !Page.IsPostBack)
            {
                this.lblAssetID.Text = assetID.ToString();
                Bangding(assetID);
            }

        
        }

        private void Bangding(int assetID)
        {
            AssetType at = new AssetType();
            at = AssetType.Find(assetID);
            this.txtAssetTypeName.Text = at.AssetTypeName;
            this.txtRemark.Text = at.AssetTypeRemark;
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            AssetType at = new AssetType();
          //  at.ID = this.lblAssetID.Text ==""?0:int.Parse(this.lblAssetID.Text);
            at.AssetTypeName = this.txtAssetTypeName.Text;
            at.AssetTypeRemark = this.txtRemark.Text;

            if (this.lblAssetID.Text == "")
            {
                at.Save();
                Response.Write("<script language=javascript>alert('规格型号保存完毕！');</script>");		
            }
            else
            {
                at.ID = int.Parse(this.lblAssetID.Text);
                at.Update();
                Response.Write("<script language=javascript>alert('规格型号更新完毕！');</script>");		
            }


             
        }
    }
}

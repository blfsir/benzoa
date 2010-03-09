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
    public partial class NewAssetState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int assetID = 0;


            assetID = Request.QueryString["StateID"] != null ? Int32.Parse(Request.QueryString["StateID"].ToString()) : 0;
            if (assetID > 0 && !Page.IsPostBack)
            {
                this.lblAssetID.Text = assetID.ToString();
                Bangding(assetID);
            }


        }

        private void Bangding(int assetID)
        {
            AssetUseState at = new AssetUseState();
            at = AssetUseState.Find(assetID);
            this.txtName.Text = at.AssetCurrentUseStateName;
            this.txtRemark.Text = at.AssetCurrentUseStateRemark;
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            AssetUseState at = new AssetUseState();
            //  at.ID = this.lblAssetID.Text ==""?0:int.Parse(this.lblAssetID.Text);
            at.AssetCurrentUseStateName = this.txtName.Text;
            at.AssetCurrentUseStateRemark = this.txtRemark.Text;

            if (this.lblAssetID.Text == "")
            {
                at.Save();
                Response.Write("<script language=javascript>alert('设备使用状态保存完毕！');</script>");
            }
            else
            {
                at.ID = int.Parse(this.lblAssetID.Text);
                at.Update();
                Response.Write("<script language=javascript>alert('设备使用状态更新完毕！');</script>");
            }



        }
    }
}

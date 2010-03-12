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
using UDS.Components;

namespace UDS.SubModule.Asset
{
    public partial class AssetSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            ActiveRecord.Model.Asset at = new ActiveRecord.Model.Asset();
            ActiveRecord.Model.Asset[] atArrary = ActiveRecord.Model.Asset.Find(this.txtName.Text); 

            DataTable dt = Converter.ConvertToDataTable(atArrary);

            this.dgAssetList.DataSource = dt;
            this.dgAssetList.DataBind();

             
        }


        protected void dgAssetList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgAssetList.CurrentPageIndex = e.NewPageIndex;
            Bangding();
        }

        private void Bangding()
        {
            ActiveRecord.Model.Asset at = new ActiveRecord.Model.Asset();
            ActiveRecord.Model.Asset[] atArrary = ActiveRecord.Model.Asset.Find(this.txtName.Text);

            DataTable dt = Converter.ConvertToDataTable(atArrary);

            this.dgAssetList.DataSource = dt;
            this.dgAssetList.DataBind();
        }
    }
}

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
    public partial class AssetStateManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bangding();
            }
        }

        private void Bangding()
        {
            AssetUseState at = new AssetUseState();
            AssetUseState[] atArrary = AssetUseState.FindAll();

            DataTable dt = Converter.ConvertToDataTable(atArrary);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Name";
            dt.Columns[2].ColumnName = "Remark";

            this.dgAssetType.DataSource = dt;
            this.dgAssetType.DataBind();

        }



        protected void dbStaffList_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string StyleID = dgAssetType.DataKeys[e.Item.ItemIndex].ToString();
            AssetUseState at = new AssetUseState();
            at.ID = int.Parse(StyleID);
            at.Delete();

            Bangding();
        }

        protected void dbStaffList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgAssetType.CurrentPageIndex = e.NewPageIndex;
            Bangding();
        }
    }
}

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
    public partial class NewAsset : System.Web.UI.Page
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
            AssetUseState at = new AssetUseState();
            AssetUseState[] atArrary = AssetUseState.FindAll();
            DataTable dt1 = Converter.ConvertToDataTable(atArrary);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Name";
            ddlUseState.DataTextField = "Name";
            this.ddlUseState.DataValueField = "ID";
            this.ddlUseState.DataSource = dt1;
            this.ddlUseState.DataBind();


            //type
            AssetType at = new AssetType();
            AssetType[] atArrary = AssetType.FindAll();
            DataTable dt = Converter.ConvertToDataTable(atArrary);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Name";
            ddlType.DataTextField = "Name";
            this.ddlType.DataValueField = "ID";
            this.ddlType.DataSource = dt1;
            this.ddlType.DataBind();
            


        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            
        }
    }
}

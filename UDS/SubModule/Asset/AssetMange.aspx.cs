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
    public partial class AssetMange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bangding(); 
                btnMove.Attributes.Add("OnClick", "return confirm('是否转移设备？');");
            }
        }

        private void Bangding()
        {
            ActiveRecord.Model.Asset at = new ActiveRecord.Model.Asset();
            ActiveRecord.Model.Asset[] atArrary = ActiveRecord.Model.Asset.FindAll();

            DataTable dt = Converter.ConvertToDataTable(atArrary);

            this.dgAssetList.DataSource = dt;
            this.dgAssetList.DataBind();

        }



       
        protected void dgAssetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dgAssetList_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string StyleID = dgAssetList.DataKeys[e.Item.ItemIndex].ToString();
            ActiveRecord.Model.Asset at = new ActiveRecord.Model.Asset();
            at.ID = int.Parse(StyleID);
            at.Delete();

            Bangding();
        }

        protected void dgAssetList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgAssetList.CurrentPageIndex = e.NewPageIndex;
            Bangding();
        }

        protected void btnMove_Click(object sender, EventArgs e)
        {
            string strStaffID = this.GetSelectedItemID("chkStaff_ID");
            if (strStaffID.Trim() != "")
                Response.Redirect("AssetMove.aspx?AssetIDs=" + strStaffID);
            else
                //Response.Write("<script language=javascript>alert('请选择要调职的人员！');</script>");		
                Page.RegisterStartupScript("window", "<script language=javascript>alert('请选择要转移的设备！');</script>"); 
        }

        private string GetSelectedItemID(string controlID)
        {
            string selectedID;
            selectedID = "";
            //遍历DataGrid获得checked的ID
            foreach (DataGridItem item in dgAssetList.Items)
            {
                if (((CheckBox)item.FindControl(controlID)).Checked == true)
                    selectedID += dgAssetList.DataKeys[item.ItemIndex] + ",";
            }
            if (selectedID.Length > 0)
                selectedID = selectedID.Substring(0, selectedID.Length - 1);
            return selectedID;
        }



        
    }
}

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
using System.Data.SqlClient;
using UDS.Components;
using BLL;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
    public partial class SetupField : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.DataGrid dgStyleList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bangding();
            }

        }

        private void Bangding()
        {
            SqlDataReader dr = null; //存放人物的数据
            Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetField", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                dgStyleList.DataSource = dt.DefaultView;
                dgStyleList.DataBind();
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }
	
        protected void MyDataGrid_Delete(object source, DataGridCommandEventArgs e)
        {
          
            
            string StyleID = dgStyleList.DataKeys[e.Item.ItemIndex].ToString();
            if (FlowFieldObject.IsStyleInUse(StyleID))
            {
                Response.Write("<script laguage='javascript'>alert('此字段被表单使用，不能删除。请先从表单中删除。');</script>");
                return;
            }
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            df.DeleteField(Int32.Parse(StyleID));
            df = null;
            Bangding();
        }

        //private string GetSelectedItemID(string controlID)
        //{
        //    String selectedID;
        //    selectedID = "";
        //    //遍历DataGrid获得checked的ID
        //    foreach (DataGridItem item in dgStyleList.Items)
        //    {
        //        if (((CheckBox)item.FindControl(controlID)).Checked == true)
        //            selectedID += dgStyleList.DataKeys[item.ItemIndex] + ",";
        //    }
        //    if (selectedID.Length > 0)
        //        selectedID = selectedID.Substring(0, selectedID.Length - 1);
        //    return selectedID;
        //}


        //private void cmdDeleteStyle_Click(object sender, System.EventArgs e)
        //{
        //    string StyleID = GetSelectedItemID("cboStyleID");

        //    if (StyleID != "")
        //    {
        //        if (StyleID.IndexOf(",") < 0)
        //        {
        //            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
        //            df.DeleteStyle(Int32.Parse(StyleID), Server.MapPath("."));
        //            df = null;
        //            Bangding();
        //        }
        //        else
        //            Response.Write("<script laguage='javascript'>alert('只能删除一个！');</script>");
        //    }
        //    else
        //        Response.Write("<script laguage='javascript'>alert('请选择一个要删除的样式！');</script>");



        //}

        protected void DataGrid_PageChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgStyleList.CurrentPageIndex = e.NewPageIndex;
            Bangding();
		
        }
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        { 
            this.Load += new System.EventHandler(this.Page_Load);

        }

        protected void dgStyleList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            
                e.Item.Cells[5].Text = "<a href=\"SetupFieldValue.aspx?FieldID=" + e.Item.Cells[0].Text + "&FieldName=" + e.Item.Cells[1].Text + "\">" + "设置选项列表</a>";
             
        }
		
    }
}

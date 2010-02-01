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

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
    public partial class SetupFieldValue : System.Web.UI.Page
    {
        public int FieldID = 0;
        public string FieldName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            FieldID = Request.QueryString["FieldID"] != null ? Int32.Parse(Request.QueryString["FieldID"].ToString()) : 0;
            FieldName = Request.QueryString["FieldName"] != null ? Server.UrlDecode(Request.QueryString["FieldName"].ToString()) : "字段名为空";
            if (!Page.IsPostBack)
            {
                this.lblFieldName.Text = FieldName;
                this.lblFieldID.Text = FieldID.ToString();
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
											mySQL.MakeInParam("@FieldID",SqlDbType.Int ,4,FieldID)
										};

                mySQL.RunProc("sp_Flow_GetFieldValue_all", parameters, out dr);

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

            //string StyleID = dgStyleList.DataKeys[e.Item.ItemIndex].ToString();

            string StyleID = e.Item.Cells[0].Text;

            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            df.DeleteFieldValue(Int32.Parse(StyleID));
            df = null;
            Bangding();
        }


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

        }

    }
}

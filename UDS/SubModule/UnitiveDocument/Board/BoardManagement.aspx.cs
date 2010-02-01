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

namespace UDS.SubModule.UnitiveDocument.Board
{
    public partial class BoardManagement : System.Web.UI.Page
    {
        public bool isAdmin = false;	

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie UserCookie = Request.Cookies["Username"];
            string  Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            if (Username.Equals("admin"))
                isAdmin = true;

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
											mySQL.MakeInParam("@BoardID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetBoard", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //if (isAdmin == true)
                //{

                    dgStyleListAdmin.DataSource = dt.DefaultView;
                    dgStyleListAdmin.DataBind();
                //}
                //else
                //{
                //dgStyleList.DataSource = dt.DefaultView;
                //dgStyleList.DataBind();
                //}
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

            string StyleID = dgStyleListAdmin.DataKeys[e.Item.ItemIndex].ToString();
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            df.DeleteBoard(Int32.Parse(StyleID));
            df = null;
            Bangding();
        }

        

        protected void DataGrid_PageChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgStyleListAdmin.CurrentPageIndex = e.NewPageIndex;
            Bangding();

        }
    }
}

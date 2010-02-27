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

namespace UDS.SubModule.UnitiveDocument.News
{
    public partial class NewsList : System.Web.UI.Page
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
            SqlDataReader dr = null; //存放人物的数据
            Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@NewsID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetNews", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                dgStyleListAdmin.DataSource = dt.DefaultView;
                dgStyleListAdmin.DataBind();

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

        protected void DataGrid_PageChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgStyleListAdmin.CurrentPageIndex = e.NewPageIndex;
            Bangding();

        }
    }
}

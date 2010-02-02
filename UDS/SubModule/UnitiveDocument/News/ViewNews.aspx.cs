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
    public partial class ViewNews : System.Web.UI.Page
    {
        public int BoardID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BoardID = Request.QueryString["NewsID"] != null ? Int32.Parse(Request.QueryString["NewsID"].ToString()) : 0;
            if (BoardID > 0 && !Page.IsPostBack)
            {
                Bangding();
            }
        }

        private void Bangding()
        {
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@NewsID",SqlDbType.Int  ,4,BoardID),
									};
            db.RunProc("sp_Flow_GetNews", parms, out dr);
            try
            {
                if (dr.Read())
                {
                    // txtBoardName.Text = dr["Board_Name"].ToString();

                    this.board_content.InnerHtml = dr["News_Content"].ToString();
                }

                if (db != null)
                {
                    db.Close();
                    db = null;
                }
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }

        }
    }
}

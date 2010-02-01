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
using System.Data.SqlClient;

namespace UDS.SubModule.UnitiveDocument.Board
{
    public partial class ViewBoard : System.Web.UI.Page
    {
        public int BoardID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BoardID = Request.QueryString["BoardID"] != null ? Int32.Parse(Request.QueryString["BoardID"].ToString()) : 0;
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
										db.MakeInParam("@BoardID",SqlDbType.Int  ,4,BoardID),
									};
            db.RunProc("sp_Flow_GetBoard", parms, out dr);
            try
            {
                if (dr.Read())
                {
                   // txtBoardName.Text = dr["Board_Name"].ToString();
                
                    this.board_content.InnerHtml = dr["Board_Content"].ToString();
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

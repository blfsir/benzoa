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
    public partial class EditNews : System.Web.UI.Page
    {
        public int NewsID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
 


            NewsID = Request.QueryString["NewsID"] != null ? Int32.Parse(Request.QueryString["NewsID"].ToString()) : 0;
            if (NewsID > 0 && !Page.IsPostBack)
            {
                Bangding();
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            try
            {
                if (NewsID == 0)
                    NewsID = df.AddNews(txtNewsName.Text, FCKeditor1.Value);
                else
                {
                    df.UpdateNews(NewsID, txtNewsName.Text, FCKeditor1.Value);
                }
            }
            finally
            {
                if (df != null)
                    df = null;
            }
            Server.Transfer("NewsManagement.aspx");
        }

        private void Bangding()
        {
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@NewsID",SqlDbType.Int  ,4,NewsID),
									};
            db.RunProc("sp_Flow_GetNews", parms, out dr);
            try
            {
                if (dr.Read())
                {
                    txtNewsName.Text = dr["News_Name"].ToString();
                    FCKeditor1.Value = dr["News_Content"].ToString();
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

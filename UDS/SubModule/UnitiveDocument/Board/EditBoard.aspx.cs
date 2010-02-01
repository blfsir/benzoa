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
    public partial class EditBoard : System.Web.UI.Page
    {
        //public bool isAdmin = false;	

        public int BoardID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpCookie UserCookie = Request.Cookies["Username"];
            //string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            //if (Username.Equals("admin"))
            //    isAdmin = true;


            BoardID = Request.QueryString["BoardID"] != null ? Int32.Parse(Request.QueryString["BoardID"].ToString()) : 0;
            if (BoardID > 0 && !Page.IsPostBack)
            {
                Bangding();
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            try
            {
                if (BoardID == 0)
                    BoardID = df.AddBoard(txtBoardName.Text, FCKeditor1.Value);
                else
                {
                    df.UpdateBoard(BoardID, txtBoardName.Text, FCKeditor1.Value);
                }
            }
            finally
            {
                if (df != null)
                    df = null;
            }
            Server.Transfer("BoardManagement.aspx");
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
                    txtBoardName.Text = dr["Board_Name"].ToString();
                    FCKeditor1.Value = dr["Board_Content"].ToString();
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

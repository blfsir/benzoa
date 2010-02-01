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
    public partial class EditFieldValue : System.Web.UI.Page
    {
        public int FieldID = 0;

        public int FieldValueID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
          

                FieldID = Request.QueryString["FieldID"] != null ? Int32.Parse(Request.QueryString["FieldID"].ToString()) : 0;


                FieldValueID = Request.QueryString["FieldValueID"] != null ? Int32.Parse(Request.QueryString["FieldValueID"].ToString()) : 0;

                if (FieldValueID > 0 && !Page.IsPostBack)
                {
                    Bangding();
                }
            

        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {

            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            try
            {
                if (FieldValueID == 0)
                    FieldValueID = df.AddFieldValue(txtFieldName.Text, FieldID);
                else
                {
                    df.UpdateFieldValue(FieldValueID, txtFieldName.Text);
                }
            }
            finally
            {
                if (df != null)
                    df = null;
            }
            Server.Transfer("SetupFieldValue.aspx");
            //Server.Transfer("DefineStyle.aspx?StyleID=" + StyleID.ToString());

        }
        private void Bangding()
        {
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@FieldValueID",SqlDbType.Int  ,4,FieldValueID),
									};
            db.RunProc("sp_Flow_GetFieldValue", parms, out dr);
            try
            {
                if (dr.Read())
                {
                    txtFieldName.Text = dr["FieldValue_Name"].ToString();
                   // FieldID = int.Parse(dr["Field_ID"].ToString());
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

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
    public partial class EditField : System.Web.UI.Page
    {
        public int FieldID = 0;  
        protected System.Web.UI.WebControls.TextBox txtFieldName;
        protected System.Web.UI.WebControls.RadioButton ddlYes;
        protected System.Web.UI.WebControls.RadioButton ddlNo;

        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;

        protected void Page_Load(object sender, EventArgs e)
        {
            FieldID = Request.QueryString["FieldID"] != null ? Int32.Parse(Request.QueryString["FieldID"].ToString()) : 0;
            if (FieldID > 0 && !Page.IsPostBack)
            {
                Bangding();
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {

            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            try
            {
                if (FieldID == 0)
                    FieldID = df.AddField(txtFieldName.Text, ddlYes.Checked ? 1 : 0);
                else
                {
                    df.UpdateField(FieldID, txtFieldName.Text, ddlYes.Checked ? 1 : 0);
                }
            }
            finally
            {
                if (df != null)
                    df = null;
            }
            Server.Transfer("SetupField.aspx");
             //Server.Transfer("DefineStyle.aspx?StyleID=" + StyleID.ToString());

        }
        private void Bangding()
        {
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@FieldID",SqlDbType.Int  ,4,FieldID),
									};
            db.RunProc("sp_Flow_GetField", parms, out dr);
            try
            {
                if (dr.Read())
                {
                    txtFieldName.Text = dr["Field_Name"].ToString();
                    if ("True" == dr["is_ddl"].ToString())
                    {
                        this.ddlYes.Checked = true;
                    }
                    else
                    {
                        this.ddlNo.Checked = true;
                    } 
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

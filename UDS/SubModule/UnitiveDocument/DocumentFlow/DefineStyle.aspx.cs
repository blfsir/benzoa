using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;
using System.Data.SqlClient;


namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// DefineStyle 的摘要说明。
	/// </summary>
	public class DefineStyle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdUpdate;
		protected System.Web.UI.WebControls.TextBox tbWidth;
		protected System.Web.UI.WebControls.TextBox tbHeight;
		protected System.Web.UI.WebControls.TextBox tbPosition;
		protected System.Web.UI.WebControls.TextBox tbExample;
		protected System.Web.UI.WebControls.Table tabDemo;
		protected System.Web.UI.WebControls.Button cmdDelete;
		public long StyleID;
		protected System.Web.UI.WebControls.RadioButton JudgedYes;
		protected System.Web.UI.WebControls.RadioButton JudgedNo;
		protected System.Web.UI.WebControls.RadioButton MultiLineYes;
		protected System.Web.UI.WebControls.RadioButton MultiLineNo;
		public long DescriptionID;
		protected System.Web.UI.WebControls.DropDownList ddlFieldName;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox tbFieldDescription;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;


        //protected System.Web.UI.WebControls.RadioButton rdbChar;
        //protected System.Web.UI.WebControls.RadioButton rdbDate;
        //protected System.Web.UI.WebControls.RadioButton rdbNumber;

        protected System.Web.UI.WebControls.DropDownList ddlFieldType;
        



		public long Position;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			StyleID			= Request.QueryString["StyleID"]!=null?Int32.Parse(Request.QueryString["StyleID"]):0;
			DescriptionID	= Request.QueryString["DescriptionID"]!=null?Int32.Parse(Request.QueryString["DescriptionID"]):0;
			Position		= Request.QueryString["Position"]!=null?Int32.Parse(Request.QueryString["Position"]):0;
			//if(StyleID>0)
            if (!Page.IsPostBack)
            {
                //FillFieldName();
                BandDDL();
                Bangding();
            }
			// 在此处放置用户代码以初始化页面
			
		}

        private void BandDDL()
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

                ddlFieldType.DataSource = dt;
                ddlFieldType.DataTextField = dt.Columns["Field_Name"].ToString();
                ddlFieldType.DataValueField  = dt.Columns["Field_ID"].ToString();
                ddlFieldType.DataBind();

                ListItem liDate = new ListItem("日期型", "d");
                ddlFieldType.Items.Insert(0, liDate);

                ListItem liNumber = new ListItem("数值型", "n");
                ddlFieldType.Items.Insert(0, liNumber);

                ListItem liChar = new ListItem("字符型", "c");
                ddlFieldType.Items.Insert(0, liChar);
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

		private void Bangding()
		{
			InitControls();

			FillFieldName(ddlFieldName);

//			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("DefineStyle");			
//
			SqlDataReader dr; //存放人物的数据
				
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.GetStyleDescription(StyleID,out dr); 
		
//			tabDemo.Style["Left"]="1px";
//			tabDemo.Style["Top"]="1px";

			AddHeadlin();
            try
            {
                while (dr.Read())
                {
                    TextBox txt = new TextBox();

                    txt.ID = "txt" + dr["Field_Name"].ToString();
                    if (dr["MultiLine"].ToString() != "False")
                    {
                        txt.TextMode = TextBoxMode.MultiLine;
                    }
                    txt.Height = Int32.Parse(dr["Height"].ToString());
                    txt.Width = Int32.Parse(dr["Width"].ToString());
                    txt.CssClass = "Input3";


                    TableRow tr = new TableRow();
                    TableCell tl = new TableCell();
                    TableCell tc = new TableCell();
                    TableCell ta = new TableCell();

                    Literal lt = new Literal();
                    RadioButton rb = new RadioButton();
                    if (Position.ToString() == dr["Position"].ToString())
                    {
                        rb.Checked = true;
                    }
                    rb.Enabled = false;

                    rb.GroupName = "rbSelect";
                    rb.Text = "<a href='DefineStyle.aspx?StyleID=" + StyleID.ToString() + "&DescriptionID=" + dr["Description_ID"].ToString() + "&Position=" + dr["Position"].ToString() + "'>" + dr["Position"].ToString() + "</a>";
                    ta.Controls.Add(rb);

                    ta.VerticalAlign = VerticalAlign.Top;
                    ta.Width = Unit.Percentage(5);
                    lt.Text = dr["Example"].ToString();

                    tc.Controls.Add(txt);
                    tc.Controls.Add(lt);
                    tc.Width = Unit.Percentage(80);

                    tl.Text = dr["Field_Description"].ToString() + ":";
                    tl.Width = Unit.Percentage(15);

                    if (dr["MultiLine"].ToString() != "False")
                        tl.VerticalAlign = VerticalAlign.Top;
                    else
                        tl.VerticalAlign = VerticalAlign.Middle;
                    tl.HorizontalAlign = HorizontalAlign.Right;

                    tr.Cells.Add(ta);
                    tr.Cells.Add(tl);
                    tr.Cells.Add(tc);
                    tabDemo.Rows.Add(tr);

                    tc = null;
                    tl = null;
                    tr = null;

                }
            }
            finally
            {
              
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }
			
			AddAttachControl();			
//			FrmNewDocument.Controls.Add(tabDemo);
			
			if(DescriptionID>0)
				GetValue(DescriptionID);


			
		}

		private void InitControls()
		{
			if(DescriptionID>0)
			{
				cmdUpdate.Enabled = true;
				cmdDelete.Enabled = true;
			}
			else
			{
				cmdUpdate.Enabled = false;
				cmdDelete.Enabled = false;
			}
		}

		private void GetValue(long DescriptionID)
		{
			SqlDataReader dr;
			
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

			df.GetDescription(DescriptionID,out dr);
            try
            {
                if (dr.Read())
                {
                    for (int i = 0; i < ddlFieldName.Items.Count; i++)
                    {
                        if (ddlFieldName.Items[i].Value == dr["Field_Name"].ToString())
                            ddlFieldName.SelectedIndex = i;
                    }


                    tbFieldDescription.Text = dr["Field_Description"].ToString();
                    if (dr["judged"].ToString() == "True")
                        JudgedYes.Checked = true;
                    else
                        JudgedNo.Checked = true;
                    if (dr["multiline"].ToString() == "True")
                        MultiLineYes.Checked = true;
                    else
                        MultiLineNo.Checked = true;

                    if ("n" == dr["Field_Type"].ToString())
                    {
                        //rdbNumber.Checked = true;
                        ddlFieldType.SelectedValue = "n";
                    }
                    else if ("d" == dr["Field_Type"].ToString())
                    {
                        //rdbDate.Checked = true;
                        ddlFieldType.SelectedValue = "d";
                    }
                    else if ("c" == dr["Field_Type"].ToString())
                    {
                        //rdbChar.Checked = true;
                        ddlFieldType.SelectedValue = "c";
                    }
                    else
                    {
                        ddlFieldType.SelectedValue = dr["Field_Type"].ToString();
                    }

                    tbWidth.Text = dr["Width"].ToString();
                    tbHeight.Text = dr["Height"].ToString();
                    tbPosition.Text = dr["Position"].ToString();
                    tbExample.Text = dr["Example"].ToString();

                }
            }
            finally
            {
                
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }

		}

		private void FillFieldName(DropDownList ddl)
		{

			string text;
			ddl.Items.Clear();
			for(int i=1;i<=26;i++)
			{
				text = ((char)((int)'a'+i-1)).ToString();
				ddl.Items.Add(new ListItem(i.ToString(),text));				
			}			
		}
		private void AddAttachControl()
		{
			string Template;
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			Template = df.GetStyleTemplateEx(StyleID);
			if(Template!="")
			{
				TableRow  tr	= new TableRow();
				TableCell td	= new TableCell();
				TableCell tl	= new TableCell();
				TableCell tt	= new TableCell();

				tt.Text =" ";
				tr.Cells.Add(tt);

				td.Text  = "<a href='" + Template + "' style='text-decoration: underline' titile='模板下载'>模板</a>:";
				td.HorizontalAlign = HorizontalAlign.Right;
				tr.Cells.Add(td);
			
				System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
				hif.ID				= "fileTemplate";
				hif.Name			= "fileTemplate";
				hif.Style["width"]	= "450px";
				hif.Style["Class"]	= "Input3";
				
				tl.Controls.Add(hif);				
				tr.Cells.Add(tl);
				
				tabDemo.Rows.Add(tr);

				td = null;
				tr = null;

			}

			df = null;

		}
		private void AddHeadlin()
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			TableRow  tr					= new TableRow();
			TableCell td					= new TableCell();
			
			td.Text							= "自定义表单";
			td.ColumnSpan					= 3;
			td.Height						= 28;
			
			tr.Cells.Add(td);
			
			tr.HorizontalAlign				= HorizontalAlign.Center;
			//tr.BackColor					= Color.FromArgb(0xff,0xff,0xef);
			td.Attributes["background"]="../../../Images/treetopbg.jpg";
			tabDemo.Rows.Add(tr);

			td = null;
			tr = null;
			df = null;

		}

		#region Web Form Designer generated code
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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rb_CheckedChanged(object sender, System.EventArgs e)
		{
		
			Server.Transfer("DefineStyle.aspx?StyleID=" + StyleID.ToString() + "&DescriptionID=" + ((RadioButton)sender).Text.ToString() );
		}
		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            string fieldType = "c";//字段类型 
            fieldType = ddlFieldType.SelectedValue;
             
            //if (rdbDate.Checked)
            //{
            //    fieldType = "d";
            //}
            //if (rdbNumber.Checked)
            //{
            //    fieldType = "n";
            //}

            if (df.AddStyleDescription(StyleID, ddlFieldName.SelectedItem.Value, tbFieldDescription.Text, JudgedYes.Checked ? 1 : 0, MultiLineYes.Checked ? 1 : 0, Int32.Parse(tbHeight.Text), Int32.Parse(tbWidth.Text), Int32.Parse(tbPosition.Text), tbExample.Text, fieldType) != 0)
			{
				Response.Write("<script language='javascript'>alert('所加的字段有重复！');</script>");
			}
			Bangding();
			

		}

		private void cmdUpdate_Click(object sender, System.EventArgs e)
		{
            string fieldType = "c";//字段类型 
            fieldType = ddlFieldType.SelectedValue;
            //if (rdbDate.Checked)
            //{
            //    fieldType = "d";
            //}
            //if (rdbNumber.Checked)
            //{
            //    fieldType = "n";
            //}
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            if (df.UpdateStyleDescription(DescriptionID, StyleID, ddlFieldName.SelectedItem.Value, tbFieldDescription.Text, JudgedYes.Checked ? 1 : 0, MultiLineYes.Checked ? 1 : 0, Int32.Parse(tbHeight.Text), Int32.Parse(tbWidth.Text), Int32.Parse(tbPosition.Text), tbExample.Text, fieldType) != 0)
			{
				Response.Write("<script language='javascript'>alert('所修改的字段有重复！');</script>");
			}
			Bangding();			
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteStyleDescription(DescriptionID);
			tbFieldDescription.Text ="";
			tbWidth.Text = "450";
			tbHeight.Text = "20";
			tbPosition.Text  = "1";
			Bangding();
		
		}
	}
}

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
using System.Data.SqlClient;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// DisplayStyle ��ժҪ˵����
	/// </summary>
	public class DisplayStyle : System.Web.UI.Page
	{
	
		private long StyleID;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			StyleID = Request.QueryString["StyleID"]!=null?Int32.Parse(Request.QueryString["StyleID"]):0;
			Bangding();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Bangding()
		{

			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("DisplayStyle");

			SqlDataReader dr; //������������
				
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.GetStyleDescription(StyleID,out dr); 

			Table tt = new Table();
								
			tt.HorizontalAlign = HorizontalAlign.Center;
			tt.Width = Unit.Percentage(100);
			tt.Style.Add("left","0px");
			tt.Style.Add("top","0px");
			tt.CssClass = "GbText";
			tt.BorderWidth = 1;

			AddRow(tt,"��ʾ��","../../../Images/treetopbg.jpg");
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
                    tt.Rows.Add(tr);

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
			AddAttachControl(tt);			
			AddRow(tt,"<a href='#' onclick='history.back();'>����</a>","");					

			FrmNewDocument.Controls.Add(tt);
			
				
		}

		private void AddAttachControl(Table tab)
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

				td.Text  = "<a href='" + Template + "' style='text-decoration: underline' titile='ģ������'>ģ��</a>:";
				td.HorizontalAlign = HorizontalAlign.Right;
				tr.Cells.Add(td);
			
				System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
				hif.ID				= "fileTemplate";
				hif.Name			= "fileTemplate";
				hif.Style["width"]	= "450px";
				hif.Style["Class"]	= "Input3";
				
				tl.Controls.Add(hif);				
				tr.Cells.Add(tl);
				
				tab.Rows.Add(tr);

				td = null;
				tr = null;

			}
			
			df = null;

		}
		private void AddRow(Table tab,string Caption,string BackGround)
		{
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			TableRow  tr					= new TableRow();
			TableCell td					= new TableCell();
			
			td.Text							= Caption;
			td.ColumnSpan					= 3;
			td.Height						= 28;
			
			tr.Cells.Add(td);
			
			tr.HorizontalAlign				= HorizontalAlign.Center;			
			td.Attributes["background"]=BackGround;
			tab.Rows.Add(tr);
			

			td = null;
			tr = null;
			df = null;

		}
	}
}

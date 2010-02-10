using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;

namespace UDS.SubModule.Position
{
	/// <summary>
	/// NewStaff 的摘要说明。
	/// </summary>
	public class NewStaff : System.Web.UI.Page
	{
		public	static string  PositionID;	
		private static long StaffID=0;
		private static int sex=1;
		private static int EditStatus =0;
		public	int ReturnPage=0;
		protected static string Username;
		protected System.Web.UI.WebControls.TextBox txtStaffName;
		protected System.Web.UI.WebControls.TextBox txtRealName;
		protected System.Web.UI.WebControls.TextBox txtBirthday;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RadioButton rb_male;
		protected System.Web.UI.WebControls.RadioButton rb_female;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmail;
		protected System.Web.UI.WebControls.Literal message;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmobile;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.DropDownList cboPosition;
        
        protected System.Web.UI.WebControls.DropDownList dplDept;

		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1; //记录所属部门
		protected System.Web.UI.HtmlControls.HtmlTableRow myposition;
		protected System.Web.UI.WebControls.TextBox txtRePassword;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Web.UI.HtmlControls.HtmlTable AutoNumber1;
		protected System.Web.UI.WebControls.TextBox txtCaste;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.CheckBox cbRemind;
	//	protected System.Web.UI.WebControls.DropDownList cboPosition;
		protected System.Web.UI.WebControls.TextBox txtPassword;

        protected System.Web.UI.WebControls.TextBox txtContractDate          ;
		protected System.Web.UI.WebControls.TextBox txtInsuranceStatus       ;
		protected System.Web.UI.WebControls.TextBox txtAccumulationStatus    ;
		protected System.Web.UI.WebControls.TextBox txtIDNumber              ;
		protected System.Web.UI.WebControls.TextBox txtMarriage              ;
		protected System.Web.UI.WebControls.TextBox txtAddress               ;
		protected System.Web.UI.WebControls.TextBox txtBirthPlace            ;
		protected System.Web.UI.WebControls.TextBox txtEducation             ;
		protected System.Web.UI.WebControls.TextBox txtFeatures              ;
		protected System.Web.UI.WebControls.TextBox txtRemark                ;
		protected System.Web.UI.WebControls.TextBox txtInsuranceBase         ;
		protected System.Web.UI.WebControls.TextBox txtEndowmentCompany      ;
		protected System.Web.UI.WebControls.TextBox txtEndowmentPersonal     ;
		protected System.Web.UI.WebControls.TextBox txtUnemploymentCompany   ;
		protected System.Web.UI.WebControls.TextBox txtUnemploymentPersonal  ;
		protected System.Web.UI.WebControls.TextBox txtInjury                ;
		protected System.Web.UI.WebControls.TextBox txtMaternity             ;
		protected System.Web.UI.WebControls.TextBox txtMedicalCompany        ;
		protected System.Web.UI.WebControls.TextBox txtMedicalPersonal       ;
		protected System.Web.UI.WebControls.TextBox txtInsuranceCompanyTotal ;
		protected System.Web.UI.WebControls.TextBox txtInsurancePersonalTotal;
		protected System.Web.UI.WebControls.TextBox txtAccumulationBase      ;
		protected System.Web.UI.WebControls.TextBox txtAccumulationCompany   ;
		protected System.Web.UI.WebControls.TextBox txtAccumulationPersonal  ;

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				//绑定部门
				BindPosition();
                BindDept();
				//修改于2003-10-8日 目的：改正生日103岁问题
				//txtBirthday.Text = DateTime.Now.ToShortDateString();
				if(Request.QueryString["PositionID"]!=null)
				{
					PositionID = Request.QueryString["PositionID"].ToString();
					SelectPosition(Int32.Parse(PositionID));
				}
				else
					PositionID = "0";

				if(Request.QueryString["StaffID"]!=null)
				{
					
					StaffID = Int32.Parse(Request.QueryString["StaffID"].ToString());
					GetStaffInfo(StaffID);
					EditStatus = 1;	
					cbRemind.Visible =false;
					//cboPosition.Visible =false;
					cboPosition.Enabled =false;
                  //  dplDept.Enabled = false; //部门字段在员工信息修改时可重新设置
				
				}				
				else
				{
					EditStatus = 0;
					sex = 1;
				}								
			}

			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
			}
			else
				ReturnPage = 0;
			
			//if(PositionID!="0")
				//myposition.Visible = false;
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
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindPosition()
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr_position = null;
            try
            {
                db.RunProc("sp_GetAllPosition", out dr_position);
                cboPosition.DataSource = dr_position;
                cboPosition.DataTextField = "Position_Name";
                cboPosition.DataValueField = "Position_ID";
                cboPosition.DataBind();
            }
            finally
            {
                db.Close();
                dr_position.Close();
            }
		}

        private void BindDept()
        {
            UDS.Components.Database db = new UDS.Components.Database();
            SqlDataReader dr_department = null;
            try
            {
                db.RunProc("sp_GetAllDept", out dr_department);
                dplDept.DataSource = dr_department;
                //cboPosition.DataSource = dr_position;
                dplDept.DataTextField = "Dept_Name";
                dplDept.DataValueField = "Dept_Name";
                dplDept.DataBind();
            }
            finally
            {
                db.Close();
                dr_department.Close();
            }
        }
		private void GetStaffInfo(long StaffID)
		{
			SqlDataReader dr;
			UDS.Components.Staff person = new UDS.Components.Staff();
			dr = person.GetStaffInfo(StaffID);
			txtPassword.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
			txtRePassword.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
            try
            {
                if (dr.Read())
                {

                    txtStaffName.Text = dr["Staff_Name"].ToString();
                    txtStaffName.ReadOnly = true;
                    txtRealName.Text = dr["RealName"].ToString();
                    if (dr["Sex"].ToString() == "True")
                    {
                        rb_male.Checked = true;
                        sex = 1;
                    }
                    else
                    {
                        rb_female.Checked = true;
                        sex = 0;
                    }




                    //修改于2003-10-8日 目的：改正生日103岁问题
                    //				if( txtBirthday.Text =="")
                    //					txtBirthday.Text = DateTime.Now.ToShortDateString();
                    //				txtBirthday.Text = dr["Birthday"].ToString().IndexOf(" ")>0?dr["Birthday"].ToString().Substring(0,dr["Birthday"].ToString().IndexOf(" ")):dr["Birthday"].ToString() ;


                    txtBirthday.Text = ((dr["Birthday"] == DBNull.Value) || (DateTime.Parse(dr["Birthday"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "-" : DateTime.Parse(dr["Birthday"].ToString()).ToLongDateString();
                    txtPassword.Text = dr["Password"].ToString();
                    txtRePassword.Text = dr["Password"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtMobile.Text = dr["Mobile"].ToString();
                    txtCaste.Text = dr["Caste"].ToString();
                    PositionID = dr["Position_ID"].ToString();

                    SelectPosition(Int32.Parse(dr["Position_ID"].ToString()));

                    txtContractDate.Text = ((dr["ContractDate"] == DBNull.Value) || (DateTime.Parse(dr["ContractDate"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "-" : DateTime.Parse(dr["ContractDate"].ToString()).ToLongDateString(); //dr["ContractDate"].ToString();
                    txtInsuranceStatus.Text = dr["InsuranceStatus"].ToString();
                    txtAccumulationStatus.Text = dr["AccumulationStatus"].ToString();
                    txtIDNumber.Text = dr["IDNumber"].ToString();
                    txtMarriage.Text = dr["Marriage"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtBirthPlace.Text = dr["BirthPlace"].ToString();
                    txtEducation.Text = dr["Education"].ToString();
                    txtFeatures.Text = dr["Features"].ToString();
                    txtRemark.Text = dr["Remark"].ToString();
                    txtInsuranceBase.Text = dr["InsuranceBase"].ToString();
                    txtEndowmentCompany.Text = dr["EndowmentCompany"].ToString();
                    txtEndowmentPersonal.Text = dr["EndowmentPersonal"].ToString();
                    txtUnemploymentCompany.Text = dr["UnemploymentCompany"].ToString();
                    txtUnemploymentPersonal.Text = dr["UnemploymentPersonal"].ToString();
                    txtInjury.Text = dr["Injury"].ToString();
                    txtMaternity.Text = dr["Maternity"].ToString();
                    txtMedicalCompany.Text = dr["MedicalCompany"].ToString();
                    txtMedicalPersonal.Text = dr["MedicalPersonal"].ToString();
                    txtInsuranceCompanyTotal.Text = dr["InsuranceCompanyTotal"].ToString();
                    txtInsurancePersonalTotal.Text = dr["InsurancePersonalTotal"].ToString();
                    txtAccumulationBase.Text = dr["AccumulationBase"].ToString();
                    txtAccumulationCompany.Text = dr["AccumulationCompany"].ToString();
                    txtAccumulationPersonal.Text = dr["AccumulationPersonal"].ToString();
                    dplDept.SelectedValue = dr["staff_dept"].ToString();


                }
                person = null;
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
		
		private void SelectPosition(int PositionID)
		{
			for(int i = 0;i<cboPosition.Items.Count;i++ )
			{
				if(Int32.Parse(cboPosition.Items[i].Value) == PositionID)
					cboPosition.SelectedIndex = i;
			}
		}


	

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			if(rb_male.Checked==true)
				sex =1;
			else
				sex =0;

			if(EditStatus ==0)
			{
				UDS.Components.Database db = new UDS.Components.Database();
				SqlDataReader dr=null;
                try
                {
                    if (myposition.Visible == true)
                        PositionID = cboPosition.Items[cboPosition.SelectedIndex].Value.ToString();

                    SqlParameter[] prams = {
										   db.MakeInParam("@StaffName",SqlDbType.VarChar,300,txtStaffName.Text),
										   db.MakeInParam("@Password",SqlDbType.VarChar,300,txtPassword.Text ),
										   db.MakeInParam("@RealName",SqlDbType.VarChar,300,txtRealName.Text),
										   db.MakeInParam("@Sex",SqlDbType.Int,4,sex),
										   db.MakeInParam("@Status",SqlDbType.Int,4,0),
										   db.MakeInParam("@Email",SqlDbType.VarChar,300,txtEmail.Text),
										   db.MakeInParam("@RegistedDate",SqlDbType.DateTime,8,DateTime.Now.ToString()),
										   db.MakeInParam("@PositionID",SqlDbType.Int,4,Int32.Parse(PositionID)),
										   db.MakeInParam("@Phone",SqlDbType.VarChar,50,txtPhone.Text),
										   db.MakeInParam("@Mobile",SqlDbType.VarChar,50,txtMobile.Text),
										   db.MakeInParam("@Birthday",SqlDbType.DateTime,8,(Request.Form["txtBirthday"].ToString()=="")?"1900-1-1":Request.Form["txtBirthday"].ToString()),
										   db.MakeInParam("@Caste",SqlDbType.Int,4,Int32.Parse(txtCaste.Text)),
                                           
                                           db.MakeInParam("@ContractDate",SqlDbType.DateTime,8,(Request.Form["txtContractDate"].ToString()=="")?"1900-1-1":Request.Form["txtContractDate"].ToString()),

                                           db.MakeInParam("@InsuranceStatus",SqlDbType.VarChar,300,txtInsuranceStatus.Text),
                                        db.MakeInParam("@AccumulationStatus",SqlDbType.VarChar,300,txtAccumulationStatus.Text),
                                        db.MakeInParam("@IDNumber",SqlDbType.VarChar,300,txtIDNumber.Text),
                                        db.MakeInParam("@Marriage",SqlDbType.VarChar,300,txtMarriage.Text),
                                        db.MakeInParam("@Address",SqlDbType.VarChar,300,txtAddress.Text),
                                        db.MakeInParam("@BirthPlace",SqlDbType.VarChar,300,txtBirthPlace.Text),
                                        db.MakeInParam("@Education ",SqlDbType.VarChar,300,txtEducation .Text),
                                        db.MakeInParam("@Features",SqlDbType.VarChar,300,txtFeatures.Text),
                                        db.MakeInParam("@Remark",SqlDbType.VarChar,300,txtRemark.Text),

                                        db.MakeInParam("@InsuranceBase",SqlDbType.Money,21, decimal.Parse( txtInsuranceBase.Text == "" ? "0" : txtInsuranceBase.Text)),
                                        db.MakeInParam("@EndowmentCompany",SqlDbType.Money,21, decimal.Parse(txtEndowmentCompany.Text==""?"0":txtEndowmentCompany.Text)),
                                        db.MakeInParam("@EndowmentPersonal ",SqlDbType.Money,21, decimal.Parse(txtEndowmentPersonal.Text==""?"0":txtEndowmentPersonal.Text)),
                                        db.MakeInParam("@UnemploymentCompany ",SqlDbType.Money,21, decimal.Parse(txtUnemploymentCompany.Text==""?"0":txtUnemploymentCompany.Text)),
                                        db.MakeInParam("@UnemploymentPersonal",SqlDbType.Money,21, decimal.Parse(txtUnemploymentPersonal.Text==""?"0":txtUnemploymentPersonal.Text)),
                                        db.MakeInParam("@Injury",SqlDbType.Money,21, decimal.Parse(txtInjury.Text==""?"0":txtInjury.Text)),
                                        db.MakeInParam("@Maternity ",SqlDbType.Money,21, decimal.Parse(txtMaternity.Text==""?"0":txtMaternity.Text)),
                                        db.MakeInParam("@MedicalCompany ",SqlDbType.Money,21, decimal.Parse(txtMedicalCompany.Text==""?"0":txtMedicalCompany.Text)),
                                        db.MakeInParam("@MedicalPersonal",SqlDbType.Money,21, decimal.Parse(txtMedicalPersonal.Text==""?"0":txtMedicalPersonal.Text)),
                                        db.MakeInParam("@InsuranceCompanyTotal ",SqlDbType.Money,21, decimal.Parse( txtInsuranceCompanyTotal.Text==""?"0":txtInsuranceCompanyTotal.Text)),
                                        db.MakeInParam("@InsurancePersonalTotal",SqlDbType.Money,21, decimal.Parse(txtInsurancePersonalTotal.Text==""?"0":txtInsurancePersonalTotal.Text)),
                                        db.MakeInParam("@AccumulationBase",SqlDbType.Money,21, decimal.Parse(txtAccumulationBase.Text==""?"0":txtAccumulationBase.Text)),
                                        db.MakeInParam("@AccumulationCompany ",SqlDbType.Money,21, decimal.Parse(txtAccumulationCompany.Text==""?"0":txtAccumulationCompany.Text)),
                                        db.MakeInParam("@AccumulationPersonal",SqlDbType.Money,21, decimal.Parse(txtAccumulationPersonal.Text == "" ? "0" : txtAccumulationPersonal.Text)),
                                        db.MakeInParam("@staff_dept",SqlDbType.VarChar,200,dplDept.Items[dplDept.SelectedIndex].Value.ToString())
                                         
									   };
                    db.RunProc("sp_AddStaff", prams, out dr);
                    if (dr.Read())
                    {
                        SqlDataReader dr_isok;//所有在职人员
                        UDS.Components.Staff sta = new UDS.Components.Staff();
                        dr_isok = sta.GetAllStaffs();
                        //处理短信提醒
                        if (this.cbRemind.Checked == true)
                        {
                            try
                            {
                                while (dr_isok.Read())
                                {
                                    SMS sm = new SMS();
                                    sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), cboPosition.SelectedItem.Text + "处新到员工 " + txtRealName.Text + ",特此通知.", 1, DateTime.Now, "", 0, 0);
                                    //sm.SendMsg(Username,mailbody.MailReceiverStr+mailbody.MailCcToAddr+mailbody.MailBccToAddr,"您从"+Username+"处收到了一封新的邮件",1,DateTime.Now,"",0,0);
                                    sm = null;
                                }
                            }
                            finally
                            {
                                dr_isok.Close();
                                dr_isok = null;
                            }
                        }
                        if (ReturnPage == 0)
                            Response.Redirect("ListView.aspx?Position_ID=" + PositionID);
                        else
                            Response.Redirect("../Staff/ManageStaff.aspx");
                        dr = null;
                    }
                    else
                        message.Text = "<font color=red>该用户已经存在！</font>";

                }
                finally
                {
                    if (db != null)
                    { db.Close(); }
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
			}
			else
			{
				UDS.Components.Staff person = new UDS.Components.Staff();
                txtContractDate.Text=(Request.Form["txtContractDate"].ToString()=="-")?"1900-1-1":Request.Form["txtContractDate"].ToString();
                txtBirthday.Text = (Request.Form["txtBirthday"].ToString() == "-") ? "1900-1-1" : Request.Form["txtBirthday"].ToString();
                switch (person.UpdateInfo(StaffID, txtRealName.Text, sex, txtBirthday.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text, txtMobile.Text, Int32.Parse(cboPosition.Items[cboPosition.SelectedIndex].Value), Int32.Parse(txtCaste.Text), txtContractDate.Text
, txtInsuranceStatus.Text
, txtAccumulationStatus.Text
, txtIDNumber.Text
, txtMarriage.Text
, txtAddress.Text
, txtBirthPlace.Text
, txtEducation.Text
, txtFeatures.Text
, txtRemark.Text
, txtInsuranceBase.Text == "" ? "0" : txtInsuranceBase.Text
, txtEndowmentCompany.Text==""?"0":txtEndowmentCompany.Text
, txtEndowmentPersonal.Text==""?"0":txtEndowmentPersonal.Text
, txtUnemploymentCompany.Text==""?"0":txtUnemploymentCompany.Text
, txtUnemploymentPersonal.Text==""?"0":txtUnemploymentPersonal.Text
, txtInjury.Text==""?"0":txtInjury.Text
, txtMaternity.Text==""?"0":txtMaternity.Text
, txtMedicalCompany.Text==""?"0":txtMedicalCompany.Text
, txtMedicalPersonal.Text==""?"0":txtMedicalPersonal.Text
, txtInsuranceCompanyTotal.Text==""?"0":txtInsuranceCompanyTotal.Text
, txtInsurancePersonalTotal.Text==""?"0":txtInsurancePersonalTotal.Text
, txtAccumulationBase.Text==""?"0":txtAccumulationBase.Text
, txtAccumulationCompany.Text==""?"0":txtAccumulationCompany.Text
, txtAccumulationPersonal.Text == "" ? "0" : txtAccumulationPersonal.Text
, dplDept.Items[dplDept.SelectedIndex].Value.ToString()
))
				{
					case 0:
						PositionID = Int32.Parse(cboPosition.Items[cboPosition.SelectedIndex].Value ).ToString();
						if(ReturnPage==0)
							Response.Redirect("ListView.aspx?Position_ID="+PositionID);	
						else
							Response.Redirect("../Staff/ManageStaff.aspx");	
						message.Text = "修改成功！";
						break;
					case -1:
						message.Text = "验证密码不对！";
						break;
					default:
						break;
				}
			}
		
		}
	}
}

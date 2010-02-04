using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration ;

namespace UDS.Components
{
	/// <summary>
	/// Staff ������
	/// </summary>
	public class Staff
	{

		#region ��½��֤
		/// <summary>
		/// ��½��֤
		/// </summary>
		/// <param name="userName">�û���</param>
		/// <param name="password">����</param>
		/// <returns>�����û�ID</returns>
		public string Login(string userName, string password) 
		{
			string UserID,IsNeedKey;
			
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 25, userName),
									   data.MakeInParam("@password",    SqlDbType.VarChar, 25, password),
									   data.MakeOutParam("@UserID", SqlDbType.VarChar, 25),
									   data.MakeOutParam("@IsNeedKey", SqlDbType.Bit, 1)	
								   };
			data.RunProc("sp_StaffLogin", prams);   
			UserID = (string) prams[2].Value;   
			IsNeedKey = prams[3].Value.ToString();
			if (UserID == string.Empty)
				return null;
			else
				return UserID+"-"+IsNeedKey;
		}
		#endregion

		#region �û��˳�
		/// <summary>
		/// �û��˳�
		/// </summary>
		/// <param name="userName">�û���</param>
		public void Logout(string userName) 
		{
					
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 25, userName)
								   };
			data.RunProc("sp_StaffLogout", prams);   
		}
		#endregion

		#region ��ȡ�û�������Ϣ
		/// <summary>
		/// ��ȡ�û�������Ϣ
		/// </summary>
		/// <param name="StaffID">�û�ID</param>
		/// <returns>����DataReader</returns>
		public SqlDataReader GetStaffInfo(long StaffID) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@StaffID",    SqlDbType.Int, 4, StaffID),
									   
								   };
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffInfo",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
			
		}
		#endregion

		#region ��ȡ�û�������Ϣ
		/// <summary>
		/// ��ȡ�û�������Ϣ
		/// </summary>
		/// <param name="StaffID">�û�ID</param>
		/// <returns>����DataReader</returns>
		public SqlDataReader GetStaffInfo(string StaffIDs) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@StaffIDs",    SqlDbType.VarChar, 10000, StaffIDs),
									   
			};
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffInfoEx",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
			
		}
		#endregion
		#region �����û����Ż�ȡ�û���ʵ����
		/// <summary>
		/// ��ȡ�û�������Ϣ
		/// </summary>
		/// <param name="Username">�û�����</param>
		/// <returns>������ʵ����</returns>
		public static string GetRealNameByUsername(string Username) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",    SqlDbType.NVarChar, 30, Username),
									   
			};
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetRealNameByUsername",prams,out dataReader);
				if(dataReader.Read())
				{
					
					return dataReader[0].ToString();
					
				}
				else
				{
					
					return "";
					
				}

			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
			finally
			{
				dataReader.Close();
				data.Dispose();

			}
			
		}
		#endregion

		#region �����û������ַ��������û���ʵ�����ַ���
		/// <summary>
		/// �����û������ַ��������û���ʵ�����ַ���
		/// </summary>
		/// <param name="Username">�û������ַ���</param>
		/// <param name="Username">���صĸ���</param>
		/// <returns>������ʵ�����ַ���</returns>
		public static string GetRealNameStrByUsernameStr(string Username,int number) 
		{
			string RealNameStr = "";
			if(Username=="")
				return "";
			if(Username.EndsWith(","))
				Username = Username.Substring(0,Username.Length-1);
			string[] UnameAr = System.Text.RegularExpressions.Regex.Split(Username ,",");
			if(number==0)
			{
				number=UnameAr.Length;
			}
			if(number>UnameAr.Length)
				number = UnameAr.Length;
			try 
			{
				for(int k=0;k<number;k++)
				{
					RealNameStr+=GetRealNameByUsername(UnameAr[k].ToString())+",";
				}
				RealNameStr = RealNameStr.Substring(0,RealNameStr.Length-1);
				if(number<UnameAr.Length)
				{
					RealNameStr+="..";

				}
				return RealNameStr;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("�����û������ַ��������û���ʵ�����ַ�������!",ex);
			}
			
		}
		#endregion

		#region ��ȡ��ǰְλ�е��û���Ϣ
		/// <summary>
		/// ��ȡ��ǰ�����е��û���Ϣ
		/// </summary>
		/// <param name="Username">�û���½��</param>
		/// <returns>����DataReader</returns>
		public SqlDataReader GetStaffFromPosition(string Username) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@StaffName",    SqlDbType.NVarChar , 30, Username),
									   
			};
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffFromPosition",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ��Ϣ����!",ex);
			}
			
		}

		/// <summary>
		/// �õ��ó�Աְλ�еĳ�Ա��Ϣ
		/// </summary>
		/// <param name="Username">�û���</param>
		/// <param name="positionwidth">���λ1��ʾ����ͬ����Ա����͵ڶ�λ��ʾ�����¼�</param>
		/// <param name="postiondepth">�¼�����ȣ����λ1��ʾֱ���¼���Ա����͵ڶ�λ1��ʾֱ���¼����¼���Ա</param>
		/// <returns></returns>
		public SqlDataReader GetStaffFromPosition(string Username,int positionwidth,int postiondepth) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									    data.MakeInParam("@StaffName",    SqlDbType.NVarChar , 30, Username),
										data.MakeInParam("@Inherit",    SqlDbType.Int , 4, postiondepth),
										data.MakeInParam("@Upsides",    SqlDbType.Int , 4, positionwidth),
									   
			};
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffFromPosition",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ��Ϣ����!",ex);
			}
			
		}
		#endregion

		#region ����û��Ƿ���ְλ�������Ȩ��
		/// <summary>
		/// ����û��Ƿ������Ȩ�޲����Ĳ�����
		/// </summary>
		/// <param name="classid">����ͼ�Ľڵ�ֵ</param>
		/// <param name="username">�û�����</param>
		/// <param name="actid">Ȩ������id</param>
		/// <param name="inherit">�̳и��ڵ��Ȩ��</param>
		/// <returns>boolֵ��ʾ�Ƿ���Ȩ��</returns>
		public bool GetRightInPosition(int classid,string username,int actid,bool inherit)
		{
            bool isHavePermission = false;//����ֵ
			int intInherit;
			Database data = new Database();
			SqlDataReader dr=null;
			//������inheritת����int�Ա��ڴ洢���̵���
			if (inherit)
				intInherit = 1;
			else
				intInherit = 0;

	
			SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",SqlDbType.Int,4,classid),
									   data.MakeInParam("@UserName",SqlDbType.VarChar,255,username),
									   data.MakeInParam("@ACT_ID",SqlDbType.Int,4,actid),
									   data.MakeInParam("@Inherit",SqlDbType.Int,4,intInherit)
								   };
            try
            {
                data.RunProc("sp_GetRightInPositionToHandleClass", prams, out dr);
                isHavePermission = dr.Read();
            }
            finally {
                if (data != null)
                {
                    data.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return isHavePermission;
		}
		#endregion
		
		#region ����û������Ƿ���ӵ�����Ȩ��
		/// <summary>
		/// ����û������Ƿ���ӵ�����Ȩ��
		/// </summary>
		/// <param name="classid">����ͼ�Ľڵ�ֵ</param>
		/// <param name="username">�û�����</param>
		/// <param name="actid">Ȩ������</param>
		/// <param name="inherit">�̳и��ڵ��Ȩ��</param>
		/// <returns>boolֵ��ʾ�Ƿ���Ȩ��</returns>
		public bool GetRightInPerson(int classid,string username,int actid,bool inherit)
		{
            bool isHavePermission = false;//����ֵ

			int intInherit;
			Database data = new Database();
			SqlDataReader dr=null;
			//������inheritת����int�Ա��ڴ洢���̵���
			if (inherit)
				intInherit = 1;
			else
				intInherit = 0;

	
			SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",SqlDbType.Int,4,classid),
									   data.MakeInParam("@UserName",SqlDbType.VarChar,255,username),
									   data.MakeInParam("@ACT_ID",SqlDbType.Int,4,actid),
									   data.MakeInParam("@Inherit",SqlDbType.Int,4,intInherit)
								   };
            try
            {
                data.RunProc("sp_GetRightInPersonToHandleClass", prams, out dr);
                isHavePermission = dr.Read();

            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return isHavePermission;
		}
		#endregion
		
		#region ����û��Ƿ��ڽ�ɫ��ӵ�����Ȩ��
		/// <summary>
		/// ����û��Ƿ���ӵ�����Ȩ�޲����Ľ�ɫ��
		/// </summary>
		/// <param name="classid">����ͼ�Ľڵ�ֵ</param>
		/// <param name="username">�û�����</param>
		/// <param name="actid">Ȩ������</param>
		/// <param name="inherit">�̳и��ڵ��Ȩ��</param>
		/// <returns>boolֵ��ʾ�Ƿ���Ȩ��</returns>
		public bool GetRightInRole(int classid,string username,int actid,bool inherit)
		{
            bool isHavePermission = false;//����ֵ

			int intInherit;
			Database data = new Database();
			SqlDataReader dr=null;
			//������inheritת����int�Ա��ڴ洢���̵���
			if (inherit)
				intInherit = 1;
			else
				intInherit = 0;

	
			SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",SqlDbType.Int,4,classid),
									   data.MakeInParam("@UserName",SqlDbType.VarChar,255,username),
									   data.MakeInParam("@ACT_ID",SqlDbType.Int,4,actid),
									   data.MakeInParam("@Inherit",SqlDbType.Int,4,intInherit)
								   };
            try
            {
                data.RunProc("sp_GetRightInRoleToHandleClass", prams, out dr);
                isHavePermission = dr.Read();//����ֵ
            }
            finally {
                if (data != null)
                {
                    data.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return isHavePermission;
		}
		#endregion

		#region ����û��Ƿ�������ӵ�������
		/// <summary>
		/// ����û��Ƿ�������ӵ�������
		/// </summary>
		/// <param name="classid">����ͼ�Ľڵ�ֵ</param>
		/// <param name="username">�û�����</param>
		/// <param name="actid">Ȩ������</param>
		/// <param name="inherit">�̳и��ڵ��Ȩ��</param>
		/// <returns>boolֵ��ʾ�Ƿ���Ȩ��</returns>
		public bool GetRightInTeam(int classid,string username,int actid,bool inherit)
		{
            bool isHavePermission = false;//����ֵ

			int intInherit;
			Database data = new Database();
			SqlDataReader dr=null;
			//������inheritת����int�Ա��ڴ洢���̵���
			if (inherit)
				intInherit = 1;
			else
				intInherit = 0;

	
			SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",SqlDbType.Int,4,classid),
									   data.MakeInParam("@UserName",SqlDbType.VarChar,255,username),
									   data.MakeInParam("@ACT_ID",SqlDbType.Int,4,actid),
									   data.MakeInParam("@Inherit",SqlDbType.Int,4,intInherit)
								   };
            try
            {
                data.RunProc("sp_GetRightInTeamToHandleClass", prams, out dr);
                isHavePermission = dr.Read();//����ֵ
            }
            finally {
                if (data != null)
                {
                    data.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return isHavePermission;
		}
		#endregion

		#region ����û��Ƿ�����Ӧ������Ȩ��
		/// <summary>
		/// ����û��Ƿ�����Ӧ������Ȩ��
		/// </summary>
		/// <param name="classid">����ͼ�Ľڵ�ֵ</param>
		/// <param name="username">�û�����</param>
		/// <param name="actid">Ȩ������</param>
		/// <param name="inherit">�̳и��ڵ��Ȩ��</param>
		/// <returns>boolֵ��ʾ�Ƿ���Ȩ��</returns>
		public bool CheckRight(int classid,string username,int actid,bool inherit)
		{
			if (GetRightInPosition(classid, username, actid, inherit))
				return true;
			else
				if (GetRightInPerson(classid, username, actid, inherit))
				return true;
			else
				if (GetRightInRole(classid, username, actid, inherit))
				return true;
			else
				if (GetRightInTeam(classid, username, actid, inherit))
				return true;
			else
				return false;
		}
		#endregion

		#region ʹ��Ա��ְ
		/// <summary>
		/// ʹ��Ա��ְ
		/// </summary>
		/// <param name="staffids">��Աid����</param>
		/// <returns>�Ƿ�ɹ�</returns>
		public bool ReturnPosition(string staffids)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,staffids)
									};
			return((db.RunProc("sp_StaffRehab",prams)==0)?true:false);	
		}
		#endregion

		#region ��Ա����
		/// <summary>
		/// ��Ա����
		/// </summary>
		/// <param name="StaffID">��ԱID</param>
		/// <returns>�����Ƿ�ɹ�</returns>
        public int UpdateInfo(long StaffID, string RealName, int Sex, string Birthday, string Password, string Email, string Phone, string Mobile, long PositionID, int Caste, string ContractDate
, string InsuranceStatus
, string AccumulationStatus
, string IDNumber
, string Marriage
, string Address
, string BirthPlace
, string Education
, string Features
, string Remark
, string InsuranceBase
, string EndowmentCompany
, string EndowmentPersonal
, string UnemploymentCompany
, string UnemploymentPersonal
, string Injury
, string Maternity
, string MedicalCompany
, string MedicalPersonal
, string InsuranceCompanyTotal
, string InsurancePersonalTotal
, string AccumulationBase
, string AccumulationCompany
, string AccumulationPersonal
, string staff_dept) 
		{
			UDS.Components.Database db = new UDS.Components.Database();						

			SqlParameter[] prams = {
										db.MakeInParam("@StaffID",SqlDbType.Int,4,StaffID),
										db.MakeInParam("@RealName",SqlDbType.VarChar,50,RealName),
										db.MakeInParam("@Sex",SqlDbType.Bit ,1,Sex),	
										db.MakeInParam("@Birthday",SqlDbType.DateTime ,8,Birthday),
										db.MakeInParam("@Password",SqlDbType.VarChar,255,Password),
										db.MakeInParam("@Email",SqlDbType.VarChar,500,Email),
										db.MakeInParam("@Phone",SqlDbType.VarChar,50,Phone),						
										db.MakeInParam("@Mobile",SqlDbType.VarChar,50,Mobile),																					   
										db.MakeInParam("@PositionID",SqlDbType.Int,4,PositionID),
										db.MakeInParam("@Caste",SqlDbType.Int,4,Caste),

                                           db.MakeInParam("@ContractDate",SqlDbType.DateTime,8,ContractDate),
                                         db.MakeInParam("@InsuranceStatus",SqlDbType.VarChar,300,InsuranceStatus),
                                        db.MakeInParam("@AccumulationStatus",SqlDbType.VarChar,300,AccumulationStatus),
                                        db.MakeInParam("@IDNumber",SqlDbType.VarChar,300,IDNumber),
                                        db.MakeInParam("@Marriage",SqlDbType.VarChar,300,Marriage),
                                        db.MakeInParam("@Address",SqlDbType.VarChar,300,Address),
                                        db.MakeInParam("@BirthPlace",SqlDbType.VarChar,300,BirthPlace),
                                        db.MakeInParam("@Education ",SqlDbType.VarChar,300,Education ),
                                        db.MakeInParam("@Features",SqlDbType.VarChar,300,Features),
                                        db.MakeInParam("@Remark",SqlDbType.VarChar,300,Remark),

                                        db.MakeInParam("@InsuranceBase",SqlDbType.Money,21, decimal.Parse(InsuranceBase)),
                                        db.MakeInParam("@EndowmentCompany",SqlDbType.Money,21, decimal.Parse(EndowmentCompany)),
                                        db.MakeInParam("@EndowmentPersonal ",SqlDbType.Money,21, decimal.Parse(EndowmentPersonal )),
                                        db.MakeInParam("@UnemploymentCompany ",SqlDbType.Money,21, decimal.Parse(UnemploymentCompany )),
                                        db.MakeInParam("@UnemploymentPersonal",SqlDbType.Money,21, decimal.Parse(UnemploymentPersonal)),
                                        db.MakeInParam("@Injury",SqlDbType.Money,21, decimal.Parse(Injury)),
                                        db.MakeInParam("@Maternity ",SqlDbType.Money,21, decimal.Parse(Maternity )),
                                        db.MakeInParam("@MedicalCompany ",SqlDbType.Money,21, decimal.Parse(MedicalCompany )),
                                        db.MakeInParam("@MedicalPersonal",SqlDbType.Money,21, decimal.Parse(MedicalPersonal)),
                                        db.MakeInParam("@InsuranceCompanyTotal ",SqlDbType.Money,21, decimal.Parse(InsuranceCompanyTotal )),
                                        db.MakeInParam("@InsurancePersonalTotal",SqlDbType.Money,21, decimal.Parse(InsurancePersonalTotal)),
                                        db.MakeInParam("@AccumulationBase",SqlDbType.Money,21, decimal.Parse(AccumulationBase)),
                                        db.MakeInParam("@AccumulationCompany ",SqlDbType.Money,21, decimal.Parse(AccumulationCompany )),
                                        db.MakeInParam("@AccumulationPersonal",SqlDbType.Money,21, decimal.Parse(AccumulationPersonal)),
                                        db.MakeInParam("@staff_dept",SqlDbType.VarChar,200,staff_dept)
									
									};
			return db.RunProc("sp_UpdateStaffInfo",prams);			
		}

		#endregion

		#region ��Ա��ְ
		/// <summary>
		/// ��Ա��ְ
		/// </summary>
		/// <param name="StaffID">��ԱID</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool Dimission(string StaffIDS) 
		{
			UDS.Components.Database db = new UDS.Components.Database();
			if(StaffIDS.Length>0)
			{
				SqlParameter[] prams = {
										   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,StaffIDS.ToString())
									   };
				return db.RunProc("sp_StaffDimission",prams)==0?true:false;				
			}			
			else
				return false;
		}

		#endregion

		#region ��Ա��ְ
		/// <summary>
		/// ��Ա��ְ
		/// </summary>
		/// <param name="StaffID">��ԱID</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool Rehab(string StaffIDS) 
		{
			UDS.Components.Database db = new UDS.Components.Database();
			if(StaffIDS.Length >0)
			{
				SqlParameter[] prams = {
										   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,StaffIDS.ToString())
									   };
				return db.RunProc("sp_StaffRehab",prams)==0?true:false;				
			}			
			else
				return false;
		}

		#endregion

		#region ��ȡ������Ϣ
		/// <summary>
		/// ��ȡ������Ϣ
		/// </summary>
		/// <param name="RootPositionID">������ID</param>
		/// <returns>����DataReader</returns>
		public SqlDataReader GetPositionList(int RootPositionID) 
		{
			RootPositionID=1;
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@Position_id",    SqlDbType.Int , 5, RootPositionID),
									   
			};
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetAllChildPosition",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ��Ϣ����!",ex);
			}
			
		}

		public SqlDataReader GetAllPosition()
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetAllPosition",out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ��Ϣ����!",ex);
			}
		}
		#endregion

		#region �õ�ʣ����ڸ���Ա
		/// <summary>
		/// �õ�ʣ����ڸ���Ա
		/// </summary>
		/// <param name="staffids">ԭ����Ա,�ָ�</param>
		/// <returns></returns>
		public SqlDataReader GetRemainStaff(string staffids)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@staffids",SqlDbType.VarChar,300,staffids)
			};

			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetRemainStaff", prams,out dataReader);
				return(dataReader);			
				
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				return null;
			}
			finally
			{
				data = null;
			}

		}

		#endregion

		#region �õ�������ְ��Ա
		public SqlDataReader GetAllStaffs()
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetAllStaff",out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
		}
		#endregion

		#region �õ�������Ա
		public SqlDataReader GetTotalStaffs()
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetTotalStaff",out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
		}
		#endregion

		#region �����û���ʵ�����õ�id
		public SqlDataReader GetStaffIDByRealName(string realname)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   db.MakeInParam("@realname",SqlDbType.VarChar,100,realname)
								   };
			db.RunProc("sp_GetStaffIDByRealName",prams,out dr);
			return(dr);
		}
		#endregion

		#region ����roleid�õ�staff
		public SqlDataReader GetStaffsFromRole(int role)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			try 
			{
				// run the stored procedure
				SqlParameter[] prams = {
										   data.MakeInParam("@RoleID",SqlDbType.Int,4,role)
									   };
				data.RunProc("sp_GetStaffInRole",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��Ϣ��ȡ����!",ex);
			}
		}
		#endregion

		#region �����û���Ϣ�ӿڣ������û������û�������
		/// <summary>
		/// �����û���Ϣ�ӿڣ������û�ID���û�������
		/// </summary>

		public ICollection  GetStaffInTeam(int teamID) 
		{
			// create data object and params
			SqlDataReader dataReader = null;
			Database data = new Database();
			DataTable datatable = new DataTable ();
			SqlParameter[] prams = {
										data.MakeInParam("@ClassID",      SqlDbType.Int, 8, teamID),
			};

            try
            {
                // run the stored procedure
                data.RunProc("sp_GetMemberInClass", prams, out dataReader);
                data = null;
                datatable = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader);
                return datatable.DefaultView;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
            finally {
                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
		}

		#endregion

		#region ����ĳ�����û���Ϣ�ӿڣ������û������û�������
		/// <summary>
		/// �����û���Ϣ�ӿڣ������û�ID���û�������
		/// </summary>

		public ICollection  GetStaffInDetp(int PositionID) 
		{
			// create data object and params
			SqlDataReader dataReader = null;
			Database data = new Database();
			DataTable datatable = new DataTable ();
			SqlParameter[] prams = {
									   data.MakeInParam("@Position_id",      SqlDbType.Int, 8, PositionID),
			};

			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffInPosition", prams,out dataReader);
				data = null;
				datatable = UDS.Components.Tools.ConvertDataReaderToDataTable (dataReader);
				return datatable.DefaultView ;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				return null;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
		}

		#endregion

		#region ����ĳ���ż��¼������û���Ϣ�ӿڣ������û������û�������
		/// <summary>
		/// �����û���Ϣ�ӿڣ������û�ID���û�������
		/// </summary>

		public ICollection  GetStaffByPosition(int PositionID) 
		{
			// create data object and params
			SqlDataReader dataReader = null;
			Database data = new Database();
			DataTable datatable = new DataTable ();
			SqlParameter[] prams = {
									   data.MakeInParam("@PositionID",      SqlDbType.Int, 8, PositionID),
			};

            try
            {
                // run the stored procedure
                data.RunProc("sp_GetStaffByPosition", prams, out dataReader);
                data = null;
                datatable = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader);
                return datatable.DefaultView;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
            finally
            {

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
		}

		#endregion

		#region ��Ա��ѯ
		/// <summary>
		/// ��Ա��ѯ
		/// </summary>
		/// <param name="staffname">�û���������ʵ����</param>
		/// <param name="positionid">ְλid</param>
		/// <param name="mobile">�ֻ�����</param>
		/// <param name="email">email</param>
		/// <param name="gender">�Ա�</param>
		/// <returns></returns>
        public SqlDataReader Find(string staffname, int positionid, string mobile, string email, string gender, string dept, string searchbound)
		{
			Database db = new Database();
			SqlDataReader dr;
			try 
			{
				// run the stored procedure
				SqlParameter[] prams = {
										   db.MakeInParam("@Name",SqlDbType.VarChar,200,staffname),
										   db.MakeInParam("@Mobile",SqlDbType.VarChar,100,mobile),
										   db.MakeInParam("@Email",SqlDbType.VarChar,100,email),
										   db.MakeInParam("@Gender",SqlDbType.VarChar,100,gender),
										   db.MakeInParam("@PositionID",SqlDbType.Int,4,positionid),
										   db.MakeInParam("@SearchBound",SqlDbType.VarChar,50,searchbound),
                                            db.MakeInParam("@Dept",SqlDbType.VarChar,100,dept),
									   };
				db.RunProc("UDS_StaffSearch",prams,out dr);
				return dr;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ա��ѯ����!",ex);
			}

		}
		#endregion

		#region �����û��Ƿ���ҪӲ��KEY��֤
		/// <summary>
		/// �����û��Ƿ���ҪӲ��KEY��֤
		/// </summary>
		/// <param name="StaffID">��ԱID</param>
		/// <param name="IsNeedKey">�Ƿ���Ҫ��½</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public bool SetIsNeedKey(string  StaffIDs,bool IsNeedKey) 
		{
			UDS.Components.Database db = new UDS.Components.Database();
			if(StaffIDs.Length >0)
			{
				SqlParameter[] prams = {
										   db.MakeInParam("@StaffIDs",SqlDbType.VarChar,1000,StaffIDs),
										   db.MakeInParam("@IsNeedKey",SqlDbType.Bit ,1,IsNeedKey)
									   };
				return db.RunProc("sp_Staff_SetIsNeedKey",prams)==0?true:false;				
			}
			else
				return false;

		}

		#endregion		

   }
}

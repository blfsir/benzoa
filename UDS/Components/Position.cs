using System;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	/// <summary>
	/// ���Ŵ�����
	/// </summary>
	public class Position
	{

		public Position()
		{
		}
		/// <summary>
		/// ��Ӳ���
		/// </summary>
		/// <param name="pid">�����ŵĸ�����id</param>
		/// <param name="name">�����ŵ�����</param>
		/// <param name="description">�����ŵ�����</param>
		/// <returns>�����ŷ��䵽��id</returns>
		public static long Add(long ParentPositionID,string name,string description)
		{
			Database db = new Database();
			SqlParameter[] prams = new SqlParameter[3];
			
			prams[0] = new SqlParameter();
			prams[1] = new SqlParameter();
			prams[2] = new SqlParameter();
			
			
			prams[0].SqlDbType = SqlDbType.Int;
			prams[0].ParameterName = "@Position_ParentID";
			prams[0].Value = ParentPositionID;

			
			prams[1].SqlDbType = SqlDbType.VarChar;
			prams[1].Size = 255;
			prams[1].ParameterName = "@Position_Name";
			prams[1].Value = name.Trim();

			
			prams[2].SqlDbType = SqlDbType.Text;
			prams[2].ParameterName = "@Position_Remark";
			prams[2].Value = description.Trim();
			

			//prams[3] = new SqlParameter();
			//prams[3].SqlDbType = SqlDbType.Int;
			//prams[3].ParameterName = "@ID";
			//prams[3].Direction = ParameterDirection.ReturnValue;

			return (db.RunProc("sp_AddPosition",prams));
		}
		/// <summary>
		/// ��ӿ���ʱ��
		/// </summary>
		/// <param name="id">����id</param>
		/// <param name="ondutytime">�ϰ�ʱ��</param>
		/// <param name="offdutytime">�°�ʱ��</param>
		/// <returns></returns>
		public static int AddDutyTime(long PositionID,DateTime ondutytime,DateTime offdutytime)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@positionid",SqlDbType.Int,4,PositionID),
									   db.MakeInParam("@ondutytime",SqlDbType.DateTime,8,ondutytime),
									   db.MakeInParam("@offdutytime",SqlDbType.DateTime,8,offdutytime)
								   };
			return (db.RunProc("sp_WA_AddPositionDutyTime",prams));
		}
		/// <summary>
		/// ���Ĳ��ſ���ʱ��
		/// </summary>
		/// <param name="id">����id</param>
		/// <param name="ondutytime">�ϰ�ʱ��</param>
		/// <param name="offdutytime">�°�ʱ��</param>
		/// <returns></returns>
		public static int UpdateDutyTime(long PositionID,DateTime ondutytime,DateTime offdutytime)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@positionid",SqlDbType.Int,4,PositionID),
									   db.MakeInParam("@ondutytime",SqlDbType.VarChar,20,ondutytime.ToShortTimeString()),
									   db.MakeInParam("@offdutytime",SqlDbType.VarChar,20,offdutytime.ToShortTimeString())
								   };
			return (db.RunProc("sp_WA_UpdatePositionDutyTime",prams));
		}

		public static int DeleteDutyTime(long PositionID)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@positionid",SqlDbType.Int,4,PositionID)
								   };
			return (db.RunProc("sp_WA_DeletePositionDutyTime",prams));
		}


		public static int Delete(long PositionID)
		{
			Database db = new Database();
			SqlParameter[] prams = {
										db.MakeInParam("@Position_id",SqlDbType.Int,4,PositionID)
								   };
			return(db.RunProc("sp_DeletePosition",prams));
		}

		public static int Modify(long PositionID,string dep_name,string dep_description)
		{
			Database db = new Database();
			SqlParameter[] prams = {
										db.MakeInParam("@position_id",SqlDbType.Int,4,PositionID),
										db.MakeInParam("@position_name",SqlDbType.VarChar,300,dep_name.Trim()),
										db.MakeInParam("@position_description",SqlDbType.VarChar,300,dep_description.Trim())
								   };
			return (db.RunProc("sp_UpdatePositionInfo",prams));
		}
		
		public SqlDataReader GetPositionInfo(long PositionID)
		{
			Database db = new Database();
			SqlDataReader dr;
			SqlParameter[] prams = {
									   db.MakeInParam("@position_id",SqlDbType.Int,4,PositionID)
								   };
			db.RunProc("sp_GetPositionInfo",prams,out dr);

			return dr;
			
		}

		public SqlDataReader GetPositionDutyTime(long PositionID)
		{
			Database db = new Database();
			SqlDataReader dr;
			SqlParameter[] prams = {
									   db.MakeInParam("@PositionID",SqlDbType.Int,4,PositionID)
								   };
			db.RunProc("sp_GetPositionDutyTime",prams,out dr);

			return dr;
			
		}
		public int MoveDeparement(long FromPositionID,long ToPositionID)
		{

			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@FromPositionID",SqlDbType.Int,4,FromPositionID),
									   db.MakeInParam("@ToPositionID",SqlDbType.Int,4,ToPositionID),
								   };
			return (db.RunProc("sp_MovePosition",prams));

		}

		#region ��Աְλ�������
		/// <summary>
		/// ��Աְλ�������
		/// </summary>
		/// <param name="PositionID">ְλID</param>
		/// <param name="NewCaste">��ְ��</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public static int UpdateCaste(long PositionID,int NewCaste) 
		{
			UDS.Components.Database db = new UDS.Components.Database();						

			SqlParameter[] prams = {
									   db.MakeInParam("@PositionID",SqlDbType.Int,4,PositionID),
									   db.MakeInParam("@NewCaste",SqlDbType.Int,4,NewCaste)
									
								   };
			return db.RunProc("sp_UpdatePositionCaste",prams);			
		}

		#endregion

		#region ���ְλ����
		/// <summary>
		/// ���ְλ����
		/// </summary>
		/// <param name="PositionID">ְλID</param>
		/// <returns>ְλ����</returns>
		public static string GetPositionName(long PositionID) 
		{
			string PositionName = "";

			Database db = new Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   db.MakeInParam("@position_id",SqlDbType.Int,4,PositionID)
								   };
            try
            {
                db.RunProc("sp_GetPositionInfo", prams, out dr);

                if (dr.Read())
                {
                    PositionName = dr["Position_Name"].ToString();
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
                    dr.Dispose();
                }
            }
			

			return PositionName;
		}
		#endregion

	}
}

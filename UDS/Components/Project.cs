using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;

namespace UDS.Components
{
    /// <summary>
    /// Project ��
    /// </summary>
    public class ProjectClass
    {

        #region ������Ŀ�����Ϣ
        /// <summary>
        /// ������Ŀ�����Ϣ
        /// </summary>
        public SqlDataReader GetClassInfo(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetTeamInfo", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ��Ϣ��ȡ����!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region ��������Ŀ�����Ϣ
        /// <summary>
        /// ��������Ŀ�����Ϣ
        /// </summary>
        public SqlDataReader GetSubClassInfo(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetSubClass", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����Ŀ��Ϣ��ȡ����!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region ����ĳ��Ŀ���Ƿ��������Ŀ
        /// <summary>
        /// ����ĳ��Ŀ���Ƿ��������Ŀ
        /// </summary>
        public bool IsExistSubClass(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@Class_id" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetAllChildClassID", prams, out dataReader);
                if (dataReader.Read())
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����Ŀ��Ϣ��ȡ����!", ex);
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
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region ������Ŀ��Ա�����Ϣ
        /// <summary>
        /// ������Ŀ��Ա�����Ϣ
        /// </summary>
        public SqlDataReader GetMemberInClass(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetMemberInClass", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ��Ա��Ϣ��ȡ����!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region �����ϼ���Ŀ�����������Ϣ
        /// <summary>
        /// �����ϼ���Ŀ�����������Ϣ
        /// </summary>
        public SqlDataReader GetParentLeader(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            int RightCode = 10; //ȱʡֵ
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID),
									   data.MakeInParam("@RightCode" , SqlDbType.Int, 20, RightCode)	
								   };

            try
            {
                data.RunProc("sp_GetParentLeader", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ�ϼ���������Ϣ��ȡ����!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region ������Ŀ�����������Ϣ
        /// <summary>
        /// ������Ŀ�����������Ϣ
        /// </summary>
        public SqlDataReader GetLeader(int classID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID)
									};

            try
            {
                data.RunProc("sp_GetLeader", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ��������Ϣ��ȡ����!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region ����Ƿ���Ȩ�޷���
        /// <summary>
        /// ����Ƿ���Ȩ�޷���
        /// </summary>
        public bool GetAccessPermission(int classID, string UserName, int actID)
        {
            int flag = 0;
            // �������ݿ�����༰DataReader
            Database data = new Database();

            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@Class_ID" , SqlDbType.Int, 20, classID),
									   data.MakeInParam("@UserName" , SqlDbType.NVarChar, 20, UserName),
									   data.MakeInParam("@Act_ID" , SqlDbType.Int, 20, actID),
									  // data.MakeInParam("@Inheit" , SqlDbType.Bit, 1, 1),	
									   data.MakeOutParam("@ReturnValue",SqlDbType.Int,20)
									 };

            try
            {
                data.RunProc("sp_GetAccessPermission", prams);
                flag = Int32.Parse(prams[3].Value.ToString());
                return (flag == 1) ? true : false;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��ȡ����Ȩ����", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region ��Ŀ�ƶ�
        /// <summary>
        /// ��Ŀ�ƶ�
        /// </summary>
        public void Remove(int souID, int desID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();

            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@FromTeamID" , SqlDbType.Int, 20, souID),
									   data.MakeInParam("@ToTeamID" , SqlDbType.NVarChar, 20, desID)
									  
								   };

            try
            {
                data.RunProc("sp_MoveTeam", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ�ƶ�����", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
                 
                data = null;
            }

        }
        #endregion

        #region ��Ŀ����
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <param name="souID">Դ��Ŀid</param>
        /// <param name="desID">Ŀ����Ŀid</param>
        /// <param name="operatorman">������</param>
        public void Copy(int souID, int desID, string operatorman)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();

            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@FromTeamID" , SqlDbType.Int, 20, souID),
									   data.MakeInParam("@ToTeamID" , SqlDbType.NVarChar, 20, desID),
									   data.MakeInParam("@operator" , SqlDbType.VarChar, 50, operatorman)
									  
								   };

            try
            {
                data.RunProc("sp_CopyTeam", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ�ƶ�����", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region ��Ŀ���
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public void Add(int ParentID, string ProjectName, string ProjectRemark, string Wright, int Status, int Scale, DateTime StartDate, DateTime EndDate)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();

            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@ParentID" , SqlDbType.Int, 20, ParentID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName.Trim()),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark.Trim()),
									   data.MakeInParam("@Wright" , SqlDbType.NVarChar, 40, Wright),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };

            try
            {
                data.RunProc("sp_AddProject", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ��ӳ���", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region ��Ŀ����
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public void Subscribe(string Username, int ClassID)
        {

            // �������ݿ�����༰DataReader
            Database data = new Database();

            // ִ�д洢���̣�������SqlDataReader����
            SqlParameter[] prams = {
									   data.MakeInParam("@StaffName" , SqlDbType.NVarChar, 50, Username),
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 10, ClassID)
									};

            try
            {
                data.RunProc("sp_SubscibeProject", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��Ŀ���ĳ���", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region ��ȡĳ��Ŀ����
        /// <summary>
        /// ��ȡĳ��Ŀ����
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
        public static string GetProjectName(int ClassID)
        {
            string ProjectName = "";
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
									data.MakeInParam("@projectid",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetProjectName", prams, out dataReader);
                if (dataReader.Read())
                    ProjectName = dataReader[0].ToString();
                return ProjectName;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return "";
            }
            finally
            {

                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

        }
        #endregion

        #region ��ȡĳ��Ŀ��ϸ��Ϣ
        /// <summary>
        /// ��ȡĳ��Ŀ��ϸ��Ϣ
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
        public SqlDataReader GetProjectDetail(int ClassID)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
										data.MakeInParam("@TeamID",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetTeamInfo", prams, out dataReader);
                return dataReader;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region �޸�ĳ��Ŀ��Ϣ
        /// <summary>
        /// �޸�ĳ��Ŀ��ϸ��Ϣ
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
        public void Revise(int ClassID, string ProjectName, string ProjectRemark, int Status, int Scale, DateTime StartDate, DateTime EndDate)
        {

            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@ProjectID" , SqlDbType.Int, 20, ClassID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName.Trim()),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark.Trim()),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };
            try
            {
                data.RunProc("sp_UpdateProject", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                 if (data != null)
                {
                    data.Close();
                } 
            }
        }
        #endregion

        #region ɾ��ĳ��Ŀ
        /// <summary>
        /// ɾ��ĳ��Ŀ
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
        public void Delete(int ClassID)
        {

            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, ClassID),
								   };
            try
            {
                data.RunProc("sp_DeleteTeam", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                 if (data != null)
                {
                    data.Close();
                } 
            }

        }
        #endregion

        #region ���ַ��������պ����ʱ��ȥ��
        /// <summary>
        /// ���ַ��������պ����ʱ��ȥ��
        /// </summary>
        public static string changeString(string ss)
        {
            string lkk = "";
            for (int i = ss.Length; i > 0; i--)
            {
                char lk = ss[i - 1];
                if (lk == ' ')
                {
                    lkk = ss.Substring(0, i);
                    break;
                }
            }
            return lkk;
        }
        #endregion
    }
}

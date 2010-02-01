using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Web;



namespace UDS.Components
{
    /// <summary>
    /// BBS 的摘要说明。
    /// </summary>
    public class BBSClass
    {
        #region 判断是否有BBS管理权限
        /// <summary>
        /// 判断是否有管理权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>bool</returns>
        public bool AdminBBS(string username, int classid)
        {
            if (classid != 0)
            {
                int actid = 8;
                Database db = new Database();
                SqlParameter[] prams = {
										   db.MakeInParam("@Class_ID",SqlDbType.Int,4,classid),
										   db.MakeInParam("@Username",SqlDbType.VarChar,100,username),
										   db.MakeInParam("@Act_ID",SqlDbType.Int,4,actid),
										   db.MakeOutParam("@ReturnValue",SqlDbType.Int,4)
									   };
                try
                {
                    db.RunProc("sp_GetAccessPermission", prams);
                    //					仅做测试用
                    //					return(true);
                    return ((Int32.Parse(prams[3].Value.ToString()) == 1) ? true : false);

                }
                catch (Exception ex)
                {
                    Error.Log(ex.Message);
                    throw new Exception("BBS权限判断错误!", ex);
                }
                finally
                {
                    db.Close();
                    db.Dispose();
                }
            }
            else
                return (false);

        }

        #endregion

        #region 判断是否有发布系统公告权限
        /// <summary>
        /// 判断是否有发布系统公告权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>bool</returns>
        public bool AdminSysBulletin(string username, int classid)
        {
            if (classid != 0)
            {
                int actid = 9;
                Database db = new Database();
                SqlParameter[] prams = {
										   db.MakeInParam("@Class_ID",SqlDbType.Int,4,classid),
										   db.MakeInParam("@Username",SqlDbType.VarChar,100,username),
										   db.MakeInParam("@Act_ID",SqlDbType.Int,4,actid),
										   db.MakeOutParam("@ReturnValue",SqlDbType.Int,4)
									   };
                try
                {
                    db.RunProc("sp_GetAccessPermission", prams);
                    //					仅做测试用
                    //					return(true);
                    return ((Int32.Parse(prams[3].Value.ToString()) == 1) ? true : false);

                }
                catch (Exception ex)
                {
                    Error.Log(ex.Message);
                    throw new Exception("BBS权限判断错误!", ex);
                }
                finally
                {
                    db.Close();
                    db.Dispose();
                }
            }
            else
                return (false);

        }

        #endregion

        #region 判断是否是板块斑竹
        /// <summary>
        /// 判断是否是板块斑竹
        /// </summary>
        /// <param name="boardid">板块ID</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool IsBoardMaster(int boardid, string username)
        {
            Database db = new Database();
            SqlParameter[] prams = {
									   db.MakeInParam("@board_id",SqlDbType.Int,4,boardid),
									   db.MakeInParam("@staff_name",SqlDbType.VarChar,100,username)
								   };
            try
            {
                if (db.RunProc("sp_BBSISBoardMaster", prams) == 1)
                    return (true);
                else
                    return (false);
            }
            catch (Exception ex)
            {
                Error.Log(ex.Message);
                throw new Exception("BBS斑竹权限判断错误!", ex);
            }

        }
        #endregion

        #region 新增分栏信息
        //给uds_bbs_catalog表,新增记录
        public bool AddBBSCatalog(BBSCatalog BBSCatalog)  //string CatalogName,string CatalogDescription
        {
            //参数 CatalogName 表示BBS中的title , 参数 CatalogDescription 表示BBS中的content
            //给存储过程传递参数
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@title",  SqlDbType.VarChar, 300, BBSCatalog.CatalogName),
									   data.MakeInParam("@content", SqlDbType.NText, 16, BBSCatalog.CatalogDescription),
			};
            try
            {
                data.RunProc("sp_BBS_AddCatalog", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
            return true;

        }
        #endregion

        #region 查询BBS贴子
        public SqlDataReader Find(string key, BBSSearchOption option, DataTable boards)
        {
            string boardids = "";
            string sql = "select * from UDS_Bbs_ForumItem";
            SqlDataReader dr = null;


            if (option.searchtype == BBSSearchType.author)
            {
                sql += " where sender like '%" + key + "%'";
            }
            else if (option.searchtype == BBSSearchType.title)
            {
                sql += " where title like '%" + key + "%'";
            }

            if (option.BoardID != 0)
            {
                sql += " and board_id=" + option.BoardID;
            }
            else
            {
                foreach (DataRow row in boards.Rows)
                {
                    boardids += row["board_id"].ToString() + ",";
                }

                if (boardids != "")
                    boardids = boardids.Substring(0, boardids.Length - 1);



                sql += " and board_id in (" + boardids + ")";
            }
            if (option.TimeBound != TimeSpan.MaxValue)
            {
                //计算时间段
                sql += " and datediff(d,send_time,getdate())< " + option.TimeBound.Days.ToString();
            }


            UDS.Components.Database db = new UDS.Components.Database();
            SqlParameter[] prams = {
									   db.MakeInParam("@SQL",  SqlDbType.NText, 5000, sql),
			};

            db.RunProc("sp_RunSQL", prams, out dr);
            return dr;
        }
        #endregion

        #region 修改分栏信息时根据CatalogID显示数据
        public SqlDataReader GetModifyBBSCatalog(int m_CatalogID)
        {
            //参数CatalogID表示存储过程中的@catalog_id int	分栏ID
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@catalog_id",  SqlDbType.Int, 4, m_CatalogID),
			};
            try
            {
                data.RunProc("sp_BBS_GetCatalogInfo", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                //				throw new Exception("BBS类别增加错误!",ex);
                return null;
            }
        }
        #endregion

        #region 修改（编缉分栏信息）
        //更新分类栏信息
        public bool EditBBSCatalog(BBSCatalog BBSCatalog)
        {
            //	@catalog_id int,				:	分栏ID
            //	@catalog_name varchar(300),		:	分栏名称
            //	@catalog_description varchar(300)	:	分栏介绍
            // 给存储过程传递参数
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@catalog_id",  SqlDbType.Int, 4, BBSCatalog.CatalogID),
									   data.MakeInParam("@catalog_name", SqlDbType.VarChar, 300, BBSCatalog.CatalogName),
									   data.MakeInParam("@catalog_description", SqlDbType.VarChar ,300, BBSCatalog.CatalogDescription),
			};
            try
            {
                data.RunProc("sp_BBS_UpdateCatalogInfo", prams);
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("BBS类别编缉错误!", ex);

            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 删除分栏（分栏信息）

        public int DelBBSCatalog(int catalog_id)
        {
            Database db = new Database();
            SqlParameter[] prams = {
									   db.MakeInParam("@catalog_id ",SqlDbType.Int,4,catalog_id)
								   };
            try
            {
                return (db.RunProc("sp_BBS_DeleteCatalog", prams));
            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }

        #endregion

        #region 在分类中新增一个板块（添加板块）
        //在BBS大类中 添加板块
        public bool BBSAddBoard(BBSBoard BBSBoard)
        {
            //需向存储过程传递的参数如下
            //@catalog_id (int) 分类ID号, @title (varchar(300)) 抬头的名称, @content ntext 板块内容, @boardtype bit 板块类型

            Database data = new Database();
            SqlParameter[] prams = { 
									   data.MakeInParam ("@catalog_id", SqlDbType.Int, 4, BBSBoard.CatalogID ),
									   data.MakeInParam ("@title", SqlDbType.VarChar, 300, BBSBoard.BoardName ),
									   data.MakeInParam ("@content", SqlDbType.NText, 16, BBSBoard.BoardDescription ),
									   data.MakeInParam ("@boardtype", SqlDbType.Bit, 1, BBSBoard.BoardType ),
			};

            try
            {
                data.RunProc("sp_BBS_AddBoard", prams);

            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
            return true;

        }

        #endregion

        #region 修改板块时根据BoardID显示数据

        public SqlDataReader GetModifyBBSBoard(int m_BoardID)
        {
            //参数m_BoardID表示存储过程中的@board_id int	:	板块ID
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@board_id",  SqlDbType.Int, 4, m_BoardID),
			};
            try
            {
                data.RunProc("sp_BBS_GetBoardInfo", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                //				throw new Exception("BBS类别增加错误!",ex);
                return null;
            }
        }

        #endregion

        #region 修改（编缉板块）
        //更新板块信息
        public bool EditBBSBoard(BBSBoard BBSBoard)
        {
            //@board_id int,				:	被更新的板块ID			
            //@board_name varchar(300)		:	板块名称
            //@board_description varchar(300),	:	板块介绍
            //@board_type bit				:	板块类型(公共型，私有型)
            // 给存储过程传递参数
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@board_id",  SqlDbType.Int, 4, BBSBoard.BoardID),
									   data.MakeInParam("@board_name", SqlDbType.VarChar, 300, BBSBoard.BoardName),
									   data.MakeInParam("@board_description", SqlDbType.VarChar ,300, BBSBoard.BoardDescription),
									   data.MakeInParam("@board_type", SqlDbType.Bit, 1 ,BBSBoard.BoardType),
			};
            //try
            {
                try
                {
                    data.RunProc("sp_BBS_UpdateBoardInfo", prams);
                }
                finally
                {
                    if (data != null)
                    {
                        data.Close();
                        data.Dispose();
                    }
                }
                return true;
            }
            //catch (Exception ex)
            {
                //	Error.Log(ex.ToString());
                //	throw new Exception("BBS板块编缉错误!",ex);

            }
        }
        #endregion

        #region 删除（删除板块）

        public int DelBBSBoard(int board_id)
        {
            //@board_id 	:	板块ID
            Database db = new Database();
            SqlParameter[] prams = {
									   db.MakeInParam("@board_id ",SqlDbType.Int,4,board_id)
								   };
            return (db.RunProc("sp_BBS_DeleteBoard", prams));
        }

        #endregion

        #region 斑竹操作
        //得到版块版主
        public SqlDataReader GetBoardMaster()
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            //SqlParameter[] prams = {
            //						   data.MakeInParam("@board_id",  SqlDbType.Int, 4, master.BoardID),
            //};
            try
            {
                data.RunProc("sp_BBS_GetAllBoardMaster", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }


        //删除版主
        public int DeleteBoardMaster(BBSBoardmaster master)
        {
            //参数:
            //      @BoardID 	:	版块ID
            //   	@StaffID 	:	员工ID
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@BoardID", SqlDbType.Int, 4, master.BoardID),
									   data.MakeInParam("@StaffID", SqlDbType.Int, 4, master.StaffID), 
			};
            return (data.RunProc("sp_BBS_DeleteBoardMaster", prams));
        }


        //设置版主
        public bool SetupBoardMaster(BBSBoardmaster master)
        {
            //参数:	
            //       @BoardID int		:	板块ID
            //     	@StaffID int		:	员工ID
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@BoardID", SqlDbType.Int, 4, master.BoardID),
									   data.MakeInParam("@StaffID", SqlDbType.Int, 4, master.StaffID), 
			};
            try
            {
                data.RunProc("sp_BBS_SetupBoardMaster", prams);
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }


        //取所有在职的用户名称
        public SqlDataReader GetAllStaff()
        {
            //参数  无   默认取在职的所有人员名称
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                data.RunProc("sp_getallstaff", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }

        #endregion

        #region 私有板块成员操作
        //得到版块成员
        public SqlDataReader GetBoardMember()
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                data.RunProc("sp_BBS_GetAllBoardMember", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }


        //删除成员
        public int DeleteBoardMember(BBSBoardmember member)
        {
            //参数:
            //      @BoardID 	:	版块ID
            //   	@StaffID 	:	员工ID
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@StaffID", SqlDbType.Int, 4, member.StaffID)
			};
            return (data.RunProc("sp_BBS_DeleteBoardMember", prams));
        }


        //设置成员
        public bool SetupBoardMember(int boardid, int staffid)
        {
            //参数:	
            //       @BoardID int		:	板块ID
            //     	@StaffID int		:	员工ID
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@BoardID", SqlDbType.Int, 4, boardid),
									   data.MakeInParam("@StaffID", SqlDbType.Int, 4, staffid), 
			};
            try
            {
                data.RunProc("sp_BBS_SetupBoardMember", prams);
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }

        #endregion

        #region 显示所有分栏信息
        public SqlDataReader GetBBSCatalog()
        {
            //参数:			无
            SqlDataReader dataReader = null;
            Database data = new Database();

            try
            {
                data.RunProc("sp_GetBBSCatalog", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 显示个人的分类栏的版块
        public SqlDataReader GetBBSBoard(string m_StaffName)
        {
            //参数:  m_StaffName        :   员工姓名
            //@catalog_id int			:	分类栏ID
            // @staff_name varchar(50)=''	:	员工姓名
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@staff_name",  SqlDbType.VarChar, 50, m_StaffName)
			};
            try
            {
                data.RunProc("sp_BBS_GetAllBoardByStaff", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 显示所有板块
        public SqlDataReader GetAllBBSBoard()
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                data.RunProc("sp_BBS_GetAllBoard", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 显示该版块的所有帖子
        public SqlDataReader GetBBSForumItem(BBSForumItem item)
        {
            //参数:	@board_id int		:	该版块ID
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@board_id",  SqlDbType.Int, 4, item.BoardID),
			};
            try
            {
                data.RunProc("sp_GetBBSForumItem", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 得到所有系统公告
        /// <summary>
        /// 得到所有系统公告
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetSysBulletin()
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                SqlParameter[] prams = {
										   data.MakeInParam("@type",  SqlDbType.Int, 4, -1),
				};
                data.RunProc("sp_BBS_GetBulletin", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region 得到所有桌面公告
        /// <summary>
        /// 得到所有桌面公告
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetDeskTopBulletin()
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                SqlParameter[] prams = {
										   data.MakeInParam("@type",  SqlDbType.Int, 4, -2),
				};
                data.RunProc("sp_BBS_GetBulletin", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region 得到板块公告
        /// <summary>
        /// 得到板块公告
        /// </summary>
        /// <param name="boardid">板块id,=0则取出所有板块的公告</param>
        /// <returns></returns>
        public SqlDataReader GetBulletin(int boardid)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            try
            {
                SqlParameter[] prams = {
										   data.MakeInParam("@type",  SqlDbType.Int, 4, boardid),
				};
                data.RunProc("sp_BBS_GetBulletin", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region 读取论坛帖子
        public SqlDataReader ReadBBSForumItem(BBSForumItem item)
        {
            //参数:			@item_id int		:	帖子ID	
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@item_id",  SqlDbType.Int, 4, item.ItemID),
			};
            try
            {
                data.RunProc("sp_ReadBBSForumItem", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }

        public void ReadBBSForumItemStruct(BBSForumItem item)
        {
            //参数:			@item_id int		:	帖子ID	
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@item_id",  SqlDbType.Int, 4, item.ItemID),
			};
            try
            {
                data.RunProc("sp_ReadBBSForumItem", prams, out dataReader);
                while (dataReader.Read())
                {
                    item.BoardID = Int32.Parse(dataReader["board_id"].ToString());
                    item.Title = dataReader["title"].ToString();
                    item.Content = dataReader["content"].ToString();
                    item.Sender = dataReader["sender"].ToString();
                    item.SendTime = DateTime.Parse(dataReader["send_time"].ToString());
                    item.HitTimes = Int32.Parse(dataReader["hit_times"].ToString());
                    item.ReplayTimes = Int32.Parse(dataReader["replay_times"].ToString());
                    item.LastReplayer = dataReader["last_replayer"].ToString();
                    item.LastReplayTime = dataReader["last_replay_time"].ToString();
                    item.IP = dataReader["ip"].ToString();
                    item.Bulletin = Convert.ToBoolean(dataReader["bulletin"]);
                    item.SysBulletin = Convert.ToBoolean(dataReader["sysbulletin"]);
                    item.DeskTop = Convert.ToBoolean(dataReader["desktop"]);
                }

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
                    data.Dispose();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }
        }
        #endregion

        #region 修改论坛帖子
        public void ModBBSForumItem(BBSForumItem item)
        {
            //参数:			@item_id int		:	帖子ID	
            Database data = new Database();
            SqlParameter[] prams = {
									    data.MakeInParam("@item_id",  SqlDbType.Int, 4, item.ItemID),
										data.MakeInParam("@board_id",  SqlDbType.Int, 4, item.BoardID),
										data.MakeInParam("@title",  SqlDbType.VarChar, 300, item.Title),
										data.MakeInParam("@content",  SqlDbType.NText, 5000, item.Content),
										data.MakeInParam("@sender",  SqlDbType.VarChar, 50, item.Sender),
										data.MakeInParam("@send_time",  SqlDbType.DateTime, 8, item.SendTime),
										data.MakeInParam("@hit_times",  SqlDbType.Int, 4, item.HitTimes),
										data.MakeInParam("@replay_times",  SqlDbType.Int, 4, item.ReplayTimes),
										data.MakeInParam("@last_replayer",  SqlDbType.VarChar, 50, item.LastReplayer),
										data.MakeInParam("@last_replay_time",  SqlDbType.DateTime, 8, item.LastReplayTime==""?Convert.DBNull:item.LastReplayTime),
										data.MakeInParam("@ip",  SqlDbType.VarChar, 50, item.IP),
										data.MakeInParam("@bulletin",  SqlDbType.Bit, 4, item.Bulletin),
										data.MakeInParam("@sysbulletin",  SqlDbType.Bit, 4, item.SysBulletin),
										data.MakeInParam("@desktop",  SqlDbType.Bit, 4, item.DeskTop),
			};
            try
            {
                data.RunProc("sp_BBS_UpdateItemInfo", prams);

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
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 读取帖子回复
        public SqlDataReader ReadBBSForumItemReplay(BBSForumItem item)
        {
            //参数:			@item_id int		:	帖子ID
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@item_id",  SqlDbType.Int, 4, item.ItemID),
			};
            try
            {
                data.RunProc("sp_ReadBBSForumItemReplay", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 删除回复
        public void DelReplay(BBSReplay replay)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									    data.MakeInParam("@replayid",  SqlDbType.Int, 4,replay.ReplayId),
										data.MakeInParam("@itemid",SqlDbType.Int,4,replay.ItemID)
			};
            try
            {
                data.RunProc("sp_BBS_DeleteReplay", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 回复贴子
        public int ReplayItem(BBSReplay replay)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									    data.MakeInParam("@item_id",  SqlDbType.Int, 4, replay.ItemID),
										data.MakeInParam("@content",  SqlDbType.NText,5000, replay.Content),
										data.MakeInParam("@replayer",  SqlDbType.VarChar,300, replay.Replayer),
										data.MakeInParam("@replay_ip",  SqlDbType.VarChar,50, replay.ReplayId)
			};
            try
            {
                return (data.RunProc("sp_BBSReplay", prams));
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("回复出错！");
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }

        }
        #endregion

        #region 发布贴子
        public int SendItem(BBSForumItem item)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@board_id",  SqlDbType.Int, 4,item.BoardID),
									   data.MakeInParam("@title",  SqlDbType.VarChar,300,item.Title),
									   data.MakeInParam("@content",  SqlDbType.NText,5000,item.Content),
									   data.MakeInParam("@sender",  SqlDbType.VarChar,100,item.Sender),
									   data.MakeInParam("@ip",  SqlDbType.VarChar,50,item.IP ),
									   data.MakeInParam("@bulletin",SqlDbType.Bit,1,item.Bulletin),
									   data.MakeInParam("@sysbulletin",SqlDbType.Bit,1,item.SysBulletin),
									   data.MakeInParam("@desktop",SqlDbType.Bit,1,item.DeskTop)	
								   };
            try
            {
                return (data.RunProc("sp_BBSAddItem", prams));
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("发布出错！");
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 增加板主
        public void AddBoardMaster(int boardid, int staffid)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@BoardID",  SqlDbType.Int, 4,boardid),
									   data.MakeInParam("@StaffID",  SqlDbType.Int, 4,staffid)
								   };
            try
            {
                data.RunProc("sp_BBS_SetupBoardMaster", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }

        }
        #endregion

        #region 删除板主
        public void DelBoardMaster(int boardid, int staffid)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@BoardID",  SqlDbType.Int, 4,boardid),
									   data.MakeInParam("@StaffID",  SqlDbType.Int, 4,staffid)
								   };
            try
            {
                data.RunProc("sp_BBS_DeleteBoardMaster", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }

        #endregion

        #region 移动论坛贴子
        public void MoveBoardItem(BBSForumItem olditem, BBSForumItem newitem)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@item_id",  SqlDbType.Int, 4,olditem.ItemID),
									   data.MakeInParam("@to_board_id",  SqlDbType.Int, 4,newitem.BoardID)
								   };
            try
            {
                data.RunProc("sp_BBSMoveItem", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 删除论坛贴子
        public void DelItem(BBSForumItem item)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@item_id",  SqlDbType.Int, 4,item.ItemID)
									  
								   };
            try
            {
                data.RunProc("sp_BBSDeleteItem", prams);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }
        #endregion

        #region 得到所有论坛
        public SqlDataReader GetAllBoard()
        {
            Database data = new Database();
            SqlDataReader dr = null;
            data.RunProc("sp_BBSGetMoveToBoard", out dr);
            return (dr);
        }
        #endregion

        #region 上传一个文件得到id号
        public int InsertFile(string name, string extension)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@name",SqlDbType.VarChar,200,name),
									   data.MakeInParam("@extension",SqlDbType.VarChar,100,extension)
								   };
            try
            {

                return (data.RunProc("sp_BBS_AddFile", prams));
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }
        }

        #endregion

        #region 根据id得到上传附件信息
        public SqlDataReader GetAttachmentByID(int id)
        {
            Database data = new Database();
            SqlDataReader dr = null;
            SqlParameter[] prams = {
									   data.MakeInParam("@id",SqlDbType.Int,4,id)
								   };
            data.RunProc("sp_BBS_GetAttachmentByID", prams, out dr);
            return (dr);
        }
        #endregion

    }
}

public class BBSBoard
{
    private int m_BoardID;
    private int m_CatalogID;
    private string m_BoardName;
    private string m_BoardDescription;
    private int m_BoardType;

    public int BoardID
    {
        //
        get { return m_BoardID; }
        set { m_BoardID = value; }
    }

    public int CatalogID
    {
        //
        get { return m_CatalogID; }
        set { m_CatalogID = value; }
    }

    public string BoardName
    {
        //
        get { return m_BoardName; }
        set { m_BoardName = value; }
    }

    public string BoardDescription
    {
        //
        get { return m_BoardDescription; }
        set { m_BoardDescription = value; }
    }

    public int BoardType
    {
        //
        get { return m_BoardType; }
        set { m_BoardType = value; }
    }
}

public class BBSBoardmaster
{
    // 板主信息
    private int m_BoardID;
    private int m_StaffID;

    public int BoardID
    {
        //
        get { return m_BoardID; }
        set { m_BoardID = value; }
    }

    public int StaffID
    {
        //
        get { return m_StaffID; }
        set { m_StaffID = value; }
    }

}

public class BBSBoardmember
{
    //BBS里的会员
    private int m_StaffID;
    private int m_BoardID;

    public int StaffID
    {
        //
        get { return m_StaffID; }
        set { m_StaffID = value; }
    }

    public int BoardID
    {
        //
        get { return m_BoardID; }
        set { m_BoardID = value; }
    }

}

public class BBSCatalog
{
    //BBS 类别
    private int m_CatalogID;
    private string m_CatalogName;
    private string m_CatalogDescription;

    public int CatalogID
    {
        //类别ID号
        get { return m_CatalogID; }
        set { m_CatalogID = value; }
    }

    public string CatalogName
    {
        // 类别名称
        get { return m_CatalogName; }
        set { m_CatalogName = value; }
    }

    public string CatalogDescription
    {
        // 类别备注
        get { return m_CatalogDescription; }
        set { m_CatalogDescription = value; }
    }

}

public class BBSForumItem
{
    //
    private int m_ItemID;
    private int m_BoardID;
    private string m_Title;
    private string m_Content;
    private string m_Sender;
    private DateTime m_SendTime;
    private int m_HitTimes;
    private int m_ReplayTimes;
    private string m_LastReplayer;
    private string m_LastReplayTime;
    private string m_IP;
    private bool m_Bulletin;
    private bool m_SysBulletin;
    private bool m_DeskTop;

    public int ItemID
    {
        //
        get { return m_ItemID; }
        set { m_ItemID = value; }
    }

    public int BoardID
    {
        //
        get { return m_BoardID; }
        set { m_BoardID = value; }
    }

    public string Title
    {
        //
        get { return m_Title; }
        set { m_Title = value; }
    }

    public string Content
    {
        //
        get { return m_Content; }
        set { m_Content = value; }
    }

    public string Sender
    {
        //
        get { return m_Sender; }
        set { m_Sender = value; }
    }

    public DateTime SendTime
    {
        //发送时间
        get { return m_SendTime; }
        set { m_SendTime = value; }
    }

    public int HitTimes
    {
        //
        get { return m_HitTimes; }
        set { m_HitTimes = value; }
    }

    public int ReplayTimes
    {
        //回复次数
        get { return m_ReplayTimes; }
        set { m_ReplayTimes = value; }
    }

    public string LastReplayer
    {
        //
        get { return m_LastReplayer; }
        set { m_LastReplayer = value; }
    }

    public string LastReplayTime
    {
        //
        get { return m_LastReplayTime; }
        set { m_LastReplayTime = value; }
    }

    public string IP
    {
        //
        get { return m_IP; }
        set { m_IP = value; }
    }
    /// <summary>
    /// 版面公告
    /// </summary>
    public bool Bulletin
    {
        get { return m_Bulletin; }
        set { m_Bulletin = value; }
    }
    /// <summary>
    /// 系统公告
    /// </summary>
    public bool SysBulletin
    {
        get { return m_SysBulletin; }
        set { m_SysBulletin = value; }
    }

    /// <summary>
    /// 公告桌面显示
    /// </summary>
    public bool DeskTop
    {
        get { return m_DeskTop; }
        set { m_DeskTop = value; }
    }

    /// <summary>
    /// 将贴子附件与自身绑定
    /// </summary>
    /// <param name="filenames">文件名（多个文件名用 , 分开）</param>
    public void Attach(string filenames)
    {
        UDS.Components.Database data = new UDS.Components.Database();

        string[] arrfilename = filenames.Split(',');
        try
        {
            for (int i = 0; i < arrfilename.Length; i++)
            {
                if (arrfilename[i].Trim() != "")
                {
                    SqlParameter[] prams = {
										   data.MakeInParam("@itemid",  SqlDbType.Int, 4,this.ItemID),
										   data.MakeInParam("@filename",  SqlDbType.VarChar, 500,arrfilename[i])
									   };
                    data.RunProc("sp_BBS_AttachmentToItem", prams);
                }

            }
        }
        finally
        {
            if (data != null)
            {
                data.Close();
                data.Dispose();
            }
        }

    }

    /// <summary>
    /// 删除附件
    /// </summary>
    public void DelAttachment(string attachmentmd)
    {
        UDS.Components.Database data = new UDS.Components.Database();
        try
        {
            //删除所有回复附件
            //得到所有回复
            UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
            SqlDataReader dr1 = null;
            dr1 = bbs.ReadBBSForumItemReplay(this);
            try
            {
                while (dr1.Read())
                {
                    BBSReplay replay = new BBSReplay();
                    replay.ReplayId = Int32.Parse(dr1["replay_id"].ToString());
                    replay.DelAttachment(attachmentmd);
                }
            }
            finally
            {
                dr1.Close();
                dr1.Dispose();
            }
            //删除贴子本身附件
            SqlParameter[] prams = {
								   data.MakeInParam("@itemid",  SqlDbType.Int, 4,this.ItemID),
		};
            SqlDataReader dr = null;
            try
            {
                data.RunProc("sp_BBS_GetItemAttachment", prams, out dr);
                while (dr.Read())
                {
                    System.IO.File.Delete(attachmentmd + "\\" + dr["filename"].ToString());
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
            }

            SqlParameter[] prams1 = {
									data.MakeInParam("@itemid",  SqlDbType.Int, 4,this.ItemID),
		};
            data.RunProc("sp_BBS_DelAttachmentToItem", prams1);
        }
        finally
        {
            if (data != null)
            {
                data.Close();
                data.Dispose();
            }
        }

    }
}


public class BBSReplay
{
    private int m_ReplayId;
    private int m_ItemId;
    private string m_Content;
    private string m_Replayer;
    private string m_ReplayTime;
    private string m_ReplayIP;

    public int ReplayId
    {
        //
        get { return m_ReplayId; }
        set { m_ReplayId = value; }
    }

    public int ItemID
    {
        //
        get { return m_ItemId; }
        set { m_ItemId = value; }
    }

    public string Content
    {
        //
        get { return m_Content; }
        set { m_Content = value; }
    }

    public string Replayer
    {
        //
        get { return m_Replayer; }
        set { m_Replayer = value; }
    }

    public string ReplayTime
    {
        //
        get { return m_ReplayTime; }
        set { m_ReplayTime = value; }
    }

    public string ReplayIP
    {
        //
        get { return m_ReplayIP; }
        set { m_ReplayIP = value; }
    }

    /// <summary>
    /// 将附件和回复绑定
    /// </summary>
    /// <param name="filenames">文件名,多个文件名用 , 分开</param>
    public void Attach(string filenames)
    {
        UDS.Components.Database data = new UDS.Components.Database();
        string[] arrfilename = filenames.Split(',');
        try
        {
            for (int i = 0; i < arrfilename.Length; i++)
            {
                if (arrfilename[i].Trim() != "")
                {
                    SqlParameter[] prams = {
										   data.MakeInParam("@replayid",  SqlDbType.Int, 4,this.ReplayId),
										   data.MakeInParam("@filename",  SqlDbType.VarChar, 500,arrfilename[i])
									   };
                    data.RunProc("sp_BBS_AttachmentToReplay", prams);
                }

            }
        }
        finally
        {
            if (data != null)
            {
                data.Close();
                data.Dispose();
            }
        }
    }

    /// <summary>
    /// 删除附件
    /// </summary>
    public void DelAttachment(string attachmentmd)
    {
        UDS.Components.Database data = new UDS.Components.Database();
        SqlParameter[] prams = {
								   data.MakeInParam("@replayid",  SqlDbType.Int, 4,this.ReplayId),
							   };

        SqlDataReader dr = null;
        try
        {

            data.RunProc("sp_BBS_GetReplayAttachment", prams, out dr);
            while (dr.Read())
            {
                System.IO.File.Delete(attachmentmd + "\\" + dr["filename"].ToString());
            }

            dr.Close();
            SqlParameter[] prams1 = {
								        data.MakeInParam("@replayid",  SqlDbType.Int, 4,this.ReplayId),
		                            };
            data.RunProc("sp_BBS_DelAttachmentToReplay", prams1);
        }
        finally
        {
            if (dr != null)
            {
                dr.Close();
                dr.Dispose();
            }
            if (data != null)
            {
                data.Close();
                data.Dispose();
            }

        }
    }

}

public class BBSSearchOption
{
    private int _boardid;
    private TimeSpan _time;
    private BBSSearchType _searchtype;

    public int BoardID
    {
        get
        {
            return _boardid;
        }
        set
        {
            _boardid = value;
        }
    }

    public TimeSpan TimeBound
    {
        get
        {
            return _time;
        }
        set
        {
            _time = value;
        }
    }

    public BBSSearchType searchtype
    {
        get
        {
            return _searchtype;
        }
        set
        {
            _searchtype = value;
        }
    }

}

public enum BBSSearchType { author, title }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Castle.ActiveRecord;

using NHibernate;
using Castle.ActiveRecord.Framework.Config;
using ActiveRecord.Model;
using NHibernate.Criterion;


namespace ActiveRecord.Model
{
    [ActiveRecord("[Diary]")]
    public class Diary : ActiveRecordBase
    {
    //    ID				int	identity(1,1)	not null,					--ID(自增ID)
    //Contents		text		not	null,					--内容
    //UserID			int					not null,					--提交人ID
    //UserName		varchar(100)					not null,					--提交人ID
    //SubmitDate		datetime			null default getdate() 		--提交日期
	 

         private int id;
        private string diary_content;//计划内容
        private string diary_creator_name;//计划创建者
        private int diary_creator_id;//计划创建者  
        private DateTime diary_create_date;//计划创建日期

         

        public Diary()
        {
            InitialBaseAR ib = InitialBaseAR.Instance;
        }


        [PrimaryKey]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        [Property]
        public string Contents
        {
            get { return diary_content; }
            set { diary_content = value; }
        }

        [Property]
        public int UserID
        {
            get { return diary_creator_id; }
            set { diary_creator_id = value; }
        }
        [Property]
        public string UserName
        {
            get { return diary_creator_name; }
            set { diary_creator_name = value; }
        }
        [Property]
        public DateTime SubmitDate
        {
            get { return diary_create_date; }
            set { diary_create_date = value; }
        }

        public static Diary Find(int id)
        {
            return (Diary)ActiveRecordBase.FindByPrimaryKey(typeof(Diary), id);
        }
    }
}

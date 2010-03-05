using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using NHibernate;
using Castle.ActiveRecord.Framework.Config;
using ActiveRecord.Model;
using Castle.ActiveRecord.Queries;
using System.Data;
using Castle.ActiveRecord;



namespace ActiveRecord.Model
{
    [ActiveRecord("AssetCurrentUseState")]
    public class AssetUseState : ActiveRecordBase
    {
        private int id;
        private string state;
        private string remark;


        public AssetUseState()
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
        public string AssetCurrentUseStateName
        {
            get { return state; }
            set { state = value; }
        }

        [Property]
        public string AssetCurrentUseStateRemark
        {
            get { return remark; }
            set { remark = value; }
        }


        public static AssetCurrentLocation Find(int id)
        {
            return (AssetCurrentLocation)ActiveRecordBase.FindByPrimaryKey(typeof(AssetCurrentLocation), id);
        }


//--现使用状况
//create table AssetCurrentUseState
//(
//    ID			int	identity(1,1)	not null,				--ID(自增ID)
//    AssetCurrentUseStateName		varchar(100)		null,					--现使用状况
//    AssetCurrentUseStateRemark		varchar(500)		null,					--备注

    }
}

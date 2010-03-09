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
    [ActiveRecord("[AssetCurrentLocation]")]
   public  class AssetCurrentLocation : ActiveRecordBase
    {

        private int id;
        private string name;
        private string remark;

        
        public AssetCurrentLocation()
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
        public string AssetCurrentLocationName
        {
            get { return name; }
            set { name = value; }
        }


        [Property]
        public string AssetCurrentLocationRemark
        {
            get { return remark; }
            set { remark = value; }
        }


        public static AssetCurrentLocation Find(int id)
        {
            return (AssetCurrentLocation)ActiveRecordBase.FindByPrimaryKey(typeof(AssetCurrentLocation), id);
        }

        public static AssetCurrentLocation[] FindAll()
        {
            return (AssetCurrentLocation[])ActiveRecordBase.FindAll(typeof(AssetCurrentLocation));
        }

        
    }
}

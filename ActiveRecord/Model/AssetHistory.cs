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
    [ActiveRecord("AssetHistory")]
    public class AssetHistory : ActiveRecordBase
    {
        private int id; 
        private int assetID;
        private string assetName;
        private int userID;
        private string userName;
        private DateTime createDate; 
        private string remark;

        public AssetHistory()
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
        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        [Property]
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        [Property]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        [Property]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        [Property]
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }


        [Property]
        public string AssetHistoryRemark
        {
            get { return remark; }
            set { remark = value; }
        }


        public static AssetHistory Find(int id)
        {
            return (AssetHistory)ActiveRecordBase.FindByPrimaryKey(typeof(AssetHistory), id);
        }
    }
}

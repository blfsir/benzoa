using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Castle.ActiveRecord;

using NHibernate;
using Castle.ActiveRecord.Framework.Config;
using ActiveRecord.Model;
using Castle.ActiveRecord.Queries;
using System.Data;

namespace ActiveRecord.Model
{

    [ActiveRecord("[AssetType]")]
   public  class AssetType : ActiveRecordBase
    {
        private int id;
        private string assetType;
        private string assetTypeRemark;

        public AssetType()
        {
            InitialBaseAR ib = InitialBaseAR.Instance;
        
        }

        [PrimaryKey]
        public int ID
        {
            get {return id;}
            set{id=value;}
        }

       [Property]
        public string AssetTypeName
        {
            get {return assetType;}
            set{assetType=value;}
        }

       [Property]
        public string AssetTypeRemark
        {
            get {return assetTypeRemark;}
            set{assetTypeRemark=value;}
        }


       public static AssetType Find(int id)
       {
           return (AssetType)ActiveRecordBase.FindByPrimaryKey(typeof(AssetType), id);
       }

       public static AssetType[] FindAll()
       {
           return (AssetType[])ActiveRecordBase.FindAll(typeof(AssetType));
       }
       public void SaveOrUpdate()
       {
           AssetType at = new AssetType();
           at = AssetType.Find(this.ID);//.Find(this.PlanObjectType, this.PlanPeriodType, this.PlanYear, this.PlanPeriod, this.PlanCreator);
           if (at != null)
           {
               at.AssetTypeName = this.AssetTypeName;
               at.AssetTypeRemark = this.AssetTypeRemark;
               at.Update();
           }
           else
           {
               this.Save();
           }

       }

    }
}

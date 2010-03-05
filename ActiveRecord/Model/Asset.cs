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
    [ActiveRecord("[uds_asset]")]
    public class Asset : ActiveRecordBase
    {
        private int id;
        private string assetcode;
        private string assetname;
        private int assettypeid;
        private int assetnumber;
        private int assetprevioususerid;
        private int assetprevioususerdept;
        private int assetcurrentuserid;
        private int assetcurrentuserdept;
        private int assetcurrentlocation;
        private int assetcurrentusersate;
        private int assetbuyuserid;
        private DateTime assetbuydate;
        private DateTime assetmovedate;
        private string assetwarrantyperiod;
        private string assetattachfile;
        private string assetremark;
        private DateTime assetcreatedate;
        private int assetcreateuserid;
        private int isdelete;

        public Asset()
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
        public bool IsDelete
        {
            get
            {
                return isdelete == 1 ? true : false;
            }
            set
            {
                isdelete = value == true ? 1 : 0;
            }
        }
        [Property]
        public string AssetCode
        {
            get
            {
                return assetcode;
            }
            set
            {

                assetcode = value;
            }
        }

        [Property]
        public string AssetName
        {
            get
            {
                return assetname;
            }
            set { assetname = value; }
        }

        [Property]
        public int AssetTypeID
        {
            get { return assettypeid; }
            set { assettypeid = value; }
        }

        [Property]
        public int AssetNumber
        {
            get { return assetnumber; }
            set { assetnumber = value; }
        }

        [Property]
        public int AssetPreviousUserID
        {
            get { return assetprevioususerid; }
            set { assetprevioususerid = value; }
        }

        [Property]
        public int AssetPreviousUserDept
        {
            get { return assetprevioususerdept; }
            set { assetprevioususerdept = value; }
        }

        [Property]
        public int AssetCurrentUserID
        {
            get { return assetcurrentuserid; }
            set { assetcurrentuserid = value; }
        }

        [Property]
        public int AssetCurrentUserDept
        {
            get { return assetcurrentuserdept; }
            set { assetcurrentuserdept = value; }
        }
        public string AssetCurrentUserDeptName
        {
            get {
                return Dept.Find(this.AssetCurrentUserDept).Dept_Name;
            }
        }
        [Property]
        public int AssetCurrentLocation
        {
            get { return assetcurrentlocation; }
            set { assetcurrentlocation = value; }
        }
        [Property]
        public int AssetCurrentUseState
        {
            get { return assetcurrentusersate; }
            set { assetcurrentusersate = value; }
        }
        [Property]
        public int AssetBuyUserID
        {
            get { return assetbuyuserid; }
            set { assetbuyuserid = value; }
        }

        
        [Property]
        public DateTime AssetBuyDate
        {
            get { return assetbuydate; }
            set { assetbuydate = value; }
        }

        [Property]
        public DateTime AssetMoveDate
        {
            get { return assetmovedate; }
            set { assetmovedate = value; }
        }

        [Property]
        public string AssetWarrantyPeriod
        {
            get { return assetwarrantyperiod; }
            set { assetwarrantyperiod = value; }
        }
        [Property]
        public string AssetAttachFile
        {
            get { return assetattachfile; }
            set { assetattachfile = value; }
        }
        [Property]
        public string AssetRemark
        {
            get { return assetremark; }
            set { assetremark = value; }
        }
        [Property]
        public DateTime AssetCreateDate
        {
            get { return assetcreatedate; }
            set { assetcreatedate = value; }
        }
        [Property]
        public int AssetCreateUserID
        {
            get { return assetcreateuserid; }
            set { assetcreateuserid = value; }
        }

        public string AssetCreateUserName
        {
            get 
            {
                string username = "";
              
                if (this.AssetCreateUserID > 0)
                {
                    Staff s = new Staff();
                    s = Staff.Find(this.AssetCreateUserID);
                     

                    username = s.Staff_Name;
                }
                return username; 
            }
        }




        public static Asset Find(int id)
        {
            return (Asset)ActiveRecordBase.FindByPrimaryKey(typeof(Asset), id);
        }



    }
}

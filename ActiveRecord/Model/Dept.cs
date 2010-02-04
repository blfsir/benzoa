using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

using NHibernate;
using Castle.ActiveRecord.Framework.Config;
using ActiveRecord.Model;

namespace ActiveRecord
{
    [ActiveRecord("[UDS_Department]")]
    public class Dept : ActiveRecordBase
    {
        private int ID;
        private int ParentID;
        private string Name;
        private string Remark;

        

        public Dept()
        {
           InitialBaseAR ib =  InitialBaseAR.Instance;
        }

        [PrimaryKey]
        public int Dept_ID
        {
            get { return ID; }
            set { ID = value; }
        }

        [Property]
        public int Dept_Parent_ID
        {
            get { return ParentID; }
            set { ParentID = value; }
        }

        [Property]
        public string Dept_Name
        {
            get { return Name; }
            set { Name = value; }
        }


        [Property]
        public string Dept_Remark
        {
            get { return Remark; }
            set {Remark  = value; }
        }
    }
}

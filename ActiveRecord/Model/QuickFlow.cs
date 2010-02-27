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
    [ActiveRecord("[UDS_QuickFlow]")]
    public class QuickFlow : ActiveRecordBase
    {
         private string staff_name;//当前年份
        private string flow_ids;//当前期间：周，月，年，季

        public QuickFlow()
        {
            InitialBaseAR ib = InitialBaseAR.Instance;
        }


        [PrimaryKey]
        public string  StaffName
        {
            get { return staff_name; }
            set { staff_name = value; }
        }


        [Property]
        public string FlowIDs
        {
            get { return flow_ids; }
            set { flow_ids = value; }
        }

        public QuickFlow Find(string staff_name)
        {
            QuickFlow myqf = null;
            try
            {
                object   qf=ActiveRecordBase.FindByPrimaryKey(typeof(QuickFlow), staff_name);
                if (null != qf)
                {
                    myqf= (QuickFlow)qf;
                }
                
            }
            catch(Exception ex)
            { }

            return myqf;
           
        }
         
    }
}

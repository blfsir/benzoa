using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
 
namespace ActiveRecord.Service
{
    public class DeptService
    {
        public DeptService()
        {
            Castle.ActiveRecord.Framework.IConfigurationSource config = ActiveRecordSectionHandler.Instance;

            ActiveRecordStarter.Initialize(config, typeof(Dept));
        }

        public void Save(Dept dept)
        {
            dept.Save();
        }
    }
}

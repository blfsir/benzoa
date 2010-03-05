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

    [ActiveRecord("[uds_staff]")]
   public  class Staff :ActiveRecordBase
    {
       private int ID;
       private string username;

       [PrimaryKey]
       public int Staff_ID
       {
           get { return ID; }
           set { ID = value; }

       }

       [Property]
       public string Staff_Name
       {
           get { return username; }
           set { username = value; }
       }

       public static Staff Find(int id)
       {
           return (Staff)ActiveRecordBase.FindByPrimaryKey(typeof(Staff), id);
       }
    }
}

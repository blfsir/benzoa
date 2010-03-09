using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace ActiveRecord.Model
{
    public sealed  class InitialBaseAR
    {
        private static InitialBaseAR _instance = new InitialBaseAR();

        private InitialBaseAR()
        {
            Castle.ActiveRecord.Framework.IConfigurationSource config = Castle.ActiveRecord.Framework.Config.ActiveRecordSectionHandler.Instance;

            Castle.ActiveRecord.ActiveRecordStarter.Initialize(config, typeof(Dept), typeof(Plan), typeof(QuickFlow), typeof(Diary), typeof(Staff), typeof(Asset), typeof(AssetType), typeof(AssetCurrentLocation), typeof(AssetUseState));
            //ActiveRecordStarter.Initialize(ActiveRecordLayer, config);
        }

        public static InitialBaseAR Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}


//public sealed class Singleton
//{
//    private static Singleton _instance = new Singleton();

//    private Singleton() { }

//    public static Singleton Instance
//    {
//        get
//        {
//            return _instance;
//        }
//    }
//}

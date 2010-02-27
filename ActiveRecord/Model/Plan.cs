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
    [ActiveRecord("[UDS_Plan]")]
    public class Plan : ActiveRecordBase
    {
        private int id;
        private string plan_object_type; //计划对象类型：个人计划，部门计划
        private string plan_period_type;//计划时间区间类型：周计划，月计划，季计划，年计划
        private string plan_content;//计划内容
        private string plan_attach;//计划附件
        private string plan_conclusion;//总结内容
        private string plan_conclusion_attach;//总结附件

        private string plan_creator;//计划创建者
        private DateTime plan_create_date;//计划创建日期


        //private DateTime plan_begin_date;//开始时间
        //private DateTime plan_end_date;//结束时间

        private string plan_year;//当前年份
        private string plan_period;//当前期间：周，月，年，季

        public Plan()
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
        public string PlanObjectType
        {
            get { return plan_object_type; }
            set { plan_object_type = value; }
        }
        [Property]
        public string PlanPeriodType
        {
            get { return plan_period_type; }
            set { plan_period_type = value; }

        }
        [Property]
        public string PlanContent
        {
            get { return plan_content; }
            set { plan_content = value; }
        }

        [Property]
        public string PlanAttach
        {
            get { return plan_attach; }
            set { plan_attach = value; }
        
        }


        [Property]
        public string PlanConclusion
        {
            get { return plan_conclusion; }
            set { plan_conclusion = value; }
        
        }

        [Property]
        public string PlanConclusionAttach
        {
            get { return plan_conclusion_attach; }
            set { plan_conclusion_attach = value; }
        }

        [Property]
        public string PlanCreator
        {
            get { return plan_creator; }
            set { plan_creator = value; }
        }

        [Property]
        public DateTime PlanCreateDate
        {
            get { return plan_create_date; }
            set { plan_create_date = value; }
        }

        [Property]
        public string PlanYear
        {
            get { return plan_year; }
            set { plan_year = value; }
        }

        [Property]
        public string PlanPeriod
        {
            get { return plan_period; }
            set { plan_period = value; }
        }

        public static Plan Find(int id)
        {
            return (Plan)ActiveRecordBase.FindByPrimaryKey(typeof(Plan), id);
        }

        public  Plan Find(string planObjectType, string planPeroidType,string planYear, string planPeriod,string planCreator)
        {
             
            // Note that we use the property name, _not_ the column name
            return (Plan)FindOne(typeof(Plan), Expression.Eq("PlanObjectType", planObjectType), Expression.Eq("PlanPeriodType", planPeroidType), Expression.Eq("PlanYear", planYear), Expression.Eq("PlanPeriod", planPeriod), Expression.Eq("PlanCreator", planCreator));
        }

        public Plan Find(string planObjectType, string planPeroidType, string planYear, string planPeriod)
        {

            // Note that we use the property name, _not_ the column name
            return (Plan)FindOne(typeof(Plan), Expression.Eq("PlanObjectType", planObjectType), Expression.Eq("PlanPeriodType", planPeroidType), Expression.Eq("PlanYear", planYear), Expression.Eq("PlanPeriod", planPeriod));
        }

        public void SaveOrUpdate()
        {
            Plan plan = new Plan().Find(this.PlanObjectType, this.PlanPeriodType, this.PlanYear, this.PlanPeriod,this.PlanCreator);
            if (plan != null)
            {
                plan.PlanConclusion = this.PlanConclusion;
                if (this.PlanContent != null)
                {
                    plan.PlanContent = this.PlanContent;
                }
                plan.Update();
            }
            else
            {
                this.Save();
            }
           
        }

        
    }
}

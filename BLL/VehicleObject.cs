using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class VehicleObject : BusinessObjectBase
    {
        public static string InsertVehicle(object[] param)
       {
           VehicleDAL obj = new VehicleDAL();
           return obj.InsertVehicle(param, "exit");
       }

        #region 车辆管理
        //车辆
        public static string InsertCar(object[] param)
        {
            VehicleDAL obj = new VehicleDAL();
            return obj.InsertCar(param, "exit");
        }

        public static string UpdateCar(object[] param)
        {
            VehicleDAL obj = new VehicleDAL();
            return obj.UpdateCar(param, "exit");
        }

        public static string DeleteCar(object[] param)
        {
            VehicleDAL obj = new VehicleDAL();
            return obj.DeleteCar(param, "exit");
        }

        public static DataTable GetCarByID(object[] param)
        {
            VehicleDAL obj = new VehicleDAL();
            return obj.GetCarByID(param);
        }

        public static DataTable GetAllCar(object[] param)
        {
            VehicleDAL obj = new VehicleDAL();
            return obj.GetAllCar(param);
        }
        #endregion


        public static DataTable GetVehicleByDate(object[] param)
       {
           VehicleDAL obj = new VehicleDAL();
           return obj.GetVehicleByDate(param);
       }

       /// <summary>
       /// 车辆使用查询
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
       public static DataTable SearchVehicle(object[] param)
       {
           VehicleDAL obj = new VehicleDAL();
           return obj.SearchVehicle(param);
       }
  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class VehicleDAL : DALBase
    {
        public string InsertVehicle(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertVehicle", outParameterName);
        }

        #region  车 辆 管 理
        public string InsertCar(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertCar", outParameterName);
        }

        public string UpdateCar(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_UpdateCar", outParameterName);
        }

        public string DeleteCar(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_DeleteCar", outParameterName);
        }

        public DataTable GetCarByID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetCarByID");
        }

        public DataTable GetAllCar(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetAllCar");
        }
        #endregion

        public DataTable GetVehicleByDate(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetVehicleByDate");
        }

        /// <summary>
        /// 车辆使用查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable SearchVehicle(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_SearchVehicle");
        }
        
    }
}

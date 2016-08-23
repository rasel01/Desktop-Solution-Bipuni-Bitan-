using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Setup
{
    public class MessurmentManager
    {
        public bool saveUpdateMesurerment(string MessID, string MessName, string remarks)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_Measurement";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@Measurement_id", MessID));
                parameters.Add(new SqlParameter("@Measurement_name", MessName));
                parameters.Add(new SqlParameter("@Measurement_remarks", remarks));
                parameters.Add(new SqlParameter("@createby", AuthenticationManager.LoginUserId));
                parameters.Add(new SqlParameter("@createDate", DateTime.Now));
                parameters.Add(new SqlParameter("@modifyby", AuthenticationManager.LoginUserId));
                parameters.Add(new SqlParameter("@modifyDate", DateTime.Now));
                result = db.ExecuteNonQueryMethod(spname, parameters, out error);
                if (error != String.Empty)
                {
                    General.ErrorMessage(error);
                }
                if (result > 0)
                {
                    flag = true;
                }


            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }


            return flag;
        }

        public DataSet GetDgvMeasurmentUnit()
        {
            DataSet ds = null;

            try
            {
                string sql = "LoadMeasurmentUnitListDgv";
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                string error;
                ds = db.ReturnExecuteDatasetMethod(sql, parameters, out error);
                if (error != String.Empty)
                {
                    General.ErrorMessage(error);
                }

            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
            return ds;
        }

        public bool DeleteMeasurementList(string id)
        {
            bool result = false;
            try
            {
                string sql = "DeleteFromMeasurementUnit";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Mess_id", id));
                int exe = db.ExecuteNonQueryMethod(sql, parameters, out error);
                if (error != String.Empty)
                {
                    General.ErrorMessage(error);
                }
                if (exe > 0)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
            return result;
        }

        public DataSet LoadMeasurementList()
        {
            DataSet ds = null;
            try
            {
                string sql = @"GetMeasurementList";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                ds = db.ReturnExecuteDatasetMethod(sql, parameters, out error);
                if (error != String.Empty)
                {
                    General.ErrorMessage(error);
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }

            return ds;
        }
    }
}

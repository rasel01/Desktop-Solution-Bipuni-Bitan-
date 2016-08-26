using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Setup
{
    public class SupplierManager
    {
        public bool saveUpdateSupplier(string SuppID, string SuppName, string suppAddress, string suppCompanyName, string suppContactPersonName, string suppPhoneNumber,
            string suppCountry, string suppCity, string suppEmail, string suppWebAddress)
        {

            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_Supplier";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@SuppID", SuppID));
                parameters.Add(new SqlParameter("@SuppName", SuppName));
                parameters.Add(new SqlParameter("@suppAddress", suppAddress));
                parameters.Add(new SqlParameter("@suppCompanyName", suppCompanyName));
                parameters.Add(new SqlParameter("@suppContactPersonName", suppContactPersonName));
                parameters.Add(new SqlParameter("@suppPhoneNumber", suppPhoneNumber));
                parameters.Add(new SqlParameter("@suppCountry", suppCountry));
                parameters.Add(new SqlParameter("@suppCity", suppCity));
                parameters.Add(new SqlParameter("@suppEmail", suppEmail));
                parameters.Add(new SqlParameter("@suppWebAddress", suppWebAddress));
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
                // commit

            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex.Message);
            }
            //commit

            return flag;
        }

        public DataSet GetSupplierList()
        {
            DataSet ds = null;

            try
            {
                string sql = "LoadSupplierListDgv";
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

        public bool DeleteSupplierList(string id)
        {
            bool result = false;
            try
            {
                string sql = "DeleteFromSupply";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Supp_id", id));
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

        public DataSet LoadSupplierList()
        {
            DataSet ds = null;

            try
            {
                string sql = "GetSupplierList";
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
    }
}

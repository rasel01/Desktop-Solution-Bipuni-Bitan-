using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Transaction
{
    public class ItemReturnManager
    {
        public DataSet DistributeItmList(string id)
        {
            DataSet ds = null;
            try
            {
                string sql = "GetDistributionInfo";
                DbClass db = new DbClass();
                string error;
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DistID",id));               
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

        public bool SaveUpdate_ItemReturn(string dtime, string sellPrice, string totalQuantity, string remarks, string itemName, string dtributorName, string distrinutionCode, string itemCode, string userCode)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_ItemReturn";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@dtime", Convert.ToDateTime(dtime)));
                parameters.Add(new SqlParameter("@sellPrice", sellPrice));
                parameters.Add(new SqlParameter("@totalQuantity", totalQuantity));
                parameters.Add(new SqlParameter("@remarks", remarks));
                parameters.Add(new SqlParameter("@distributionCode", distrinutionCode));
                parameters.Add(new SqlParameter("@itemCode", itemCode));
                parameters.Add(new SqlParameter("@userCode", userCode));
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
    }
}

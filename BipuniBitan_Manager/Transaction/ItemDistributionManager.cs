using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Transaction
{
    public class ItemDistributionManager
    {

        public DataSet LoadItemList()
        {
            DataSet ds = null;
            try
            {
                string sql = "GetReceivedItemList";
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

        public DataSet LoadDistributorList()
        {
            DataSet ds = null;
            try
            {
                string sql = "GetDistributorList";
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

        public DataSet GetItemReceiveInfo(string itemId)
        {
            DataSet ds = null;
            try
            {
                string sql = "GetReceiveItemInfo";
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ItemCode", itemId));
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

        public bool SaveUpdate_ItemDistribution(string dtime, string sellPrice, string quantity, string remarks, string itemName, string distributorname, string distributionId)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_ItemDistribution";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@dtime", dtime));
                parameters.Add(new SqlParameter("@sellPrice", sellPrice));
                parameters.Add(new SqlParameter("@Quantity", quantity));
                parameters.Add(new SqlParameter("@remarks", remarks));
                parameters.Add(new SqlParameter("@itemID", itemName));
                parameters.Add(new SqlParameter("@DistributorID", distributorname));
                parameters.Add(new SqlParameter("@DistID", distributionId));
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

        public DataSet GetDistributionList()
        {
            DataSet ds = null;
            try
            {
                string sql = "LoadDistributionListDgv";
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

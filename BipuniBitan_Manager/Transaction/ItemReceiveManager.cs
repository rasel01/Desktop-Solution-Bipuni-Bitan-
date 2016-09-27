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

namespace BipuniBitan_Manager.Transaction
{
    public class ItemReceiveManager
    {
        public bool SaveUpdate_ItemReceive(string dtime, string buyPrice, string sellPrice, string totalQuantity, string totalPrice, string remarks, string itemName, string supplierName, string ItemReceID)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_ItemReceive";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@dtime", Convert.ToDateTime(dtime)));
                parameters.Add(new SqlParameter("@buyPrice", buyPrice));
                parameters.Add(new SqlParameter("@sellPrice", sellPrice));
                parameters.Add(new SqlParameter("@totalQuantity", totalQuantity));
                parameters.Add(new SqlParameter("@totalPrice", totalPrice));
                parameters.Add(new SqlParameter("@remarks", remarks));
                parameters.Add(new SqlParameter("@itemID", itemName));
                parameters.Add(new SqlParameter("@supplierID", supplierName));
                parameters.Add(new SqlParameter("@ItemReceID", ItemReceID));
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

        public bool DeleteReceItemList(string id)
        {
            bool result = false;
            try
            {
                string sql = "DeleteFromReceiveItem";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ReceiveItem_id", id));
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

        public DataSet ReceivedItmList()
        {
            DataSet ds = null;
            try
            {
                string sql = "LoadReceiveItmDgv";
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

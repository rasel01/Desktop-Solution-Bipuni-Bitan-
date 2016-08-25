using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Setup
{
    public class ItemManager
    {
        public DataSet LoadBrandListCatagoryWise(string catagory)
        {
            DataSet ds = null;
            try
            {
                string sql = @"GetBrandNameListCatagoryWise";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter>parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@catagory_Id",catagory));
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

        public bool saveUpdateItem(byte[] image, string ItemName, string catagoryId, string branID, string unitID, string itemDes, string itemID)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_Item";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@image", image));
                parameters.Add(new SqlParameter("@ItemName", ItemName));
                parameters.Add(new SqlParameter("@catagoryId", catagoryId));
                parameters.Add(new SqlParameter("@branID", branID));
                parameters.Add(new SqlParameter("@unitID", unitID));
                parameters.Add(new SqlParameter("@itemDes", itemDes));
                parameters.Add(new SqlParameter("@itemID", itemID));
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


            return flag;
            
        }

        public DataSet GetItemList()
        {
            DataSet ds = null;
            try
            {

                string sql = @"LoadDgvItemList";
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

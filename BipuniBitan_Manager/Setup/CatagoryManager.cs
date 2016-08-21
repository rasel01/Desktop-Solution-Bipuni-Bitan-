using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using BipuniBitan_DB;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Setup
{
    public class CatagoryManager
    {

        AuthenticationManager AuthManager = new AuthenticationManager();

        public bool saveUpdateCatagory(string name, string id, string remarks)
        {
            bool flag = false;
            try
            {
                string error;
                int result = 0;
                string spname = "Insert_Update_Catagory";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DbClass db = new DbClass();
                parameters.Add(new SqlParameter("@catagory_id", id));
                parameters.Add(new SqlParameter("@catagory_name", name));
                parameters.Add(new SqlParameter("@catagory_remarks", remarks));
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

        public DataSet GetDgvCatagoryList()
        {
            DataSet ds = null;
            
            try
            {
                string sql = "LoadCatagoryListDgv";
                DbClass db = new DbClass();
                List<SqlParameter>parameters = new List<SqlParameter>();
                string error;
                ds = db.ReturnExecuteDatasetMethod(sql, parameters, out error);
                if (error!= String.Empty)
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



        public bool DeleteCatagoryList(string id)
        {
            bool result = false;
            try
            {
                string sql = "DeleteFromCatagory";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter>parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@catagory_id", id));
                int exe = db.ExecuteNonQueryMethod(sql, parameters, out error);
                if (error!=String.Empty)
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
    }
}

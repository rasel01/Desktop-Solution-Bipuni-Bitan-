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
    public class BrandManager
    {

        public DataSet GetCatagoryList()
        {
            DataSet ds = null;
            try
            {
                string sql = @"GetCatagoryList";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                ds = db.ReturnExecuteDatasetMethod(sql, parameters, out error);
                if (error!=String.Empty)
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

        public bool saveUpdateBrand(string BrandID, string catagoryName, string Brandremarks, string BrandName)
        {
            bool flag = false;
            try
            {
                int result;
                string sql = @"Insert_Update_Brand";//commit
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@BrandID", BrandID));
                parameters.Add(new SqlParameter("@catagoryID", catagoryName));
                parameters.Add(new SqlParameter("@Brandremarks", Brandremarks));
                parameters.Add(new SqlParameter("@BrandName", BrandName));
                parameters.Add(new SqlParameter("@createby", AuthenticationManager.LoginUserId));
                parameters.Add(new SqlParameter("@createDate", DateTime.Now));
                parameters.Add(new SqlParameter("@modifyby", AuthenticationManager.LoginUserId));
                parameters.Add(new SqlParameter("@modifyDate", DateTime.Now));  
                result = db.ExecuteNonQueryMethod(sql, parameters, out error);
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

        public DataSet GetDgvBrandList()
        {
            DataSet ds = null;
            try
            {
                string sql = "LoadBrandListDgv";
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

        public bool DeleteCatagoryList(string id)
        {
            bool result = false;
            try
            {
                string sql = "DeleteFromBrand";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Brand_id", id));
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
    }
}

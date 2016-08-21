using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Windows.Forms;
using BipuniBitan_DB;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Security
{
    public class AuthenticationManager
    {
        //public TYPE Type { get; set; }
        public static string LoginUserId { get; set; }
        public static string LoginUserName { get; set; }
        public static string LoginUserPass { get; set; }


        

        public bool GetRegisteredUserName(string userName,string pass)
        {
            string error;
            bool flag = false;
            try
            {
                string sql = "GetRegisteredUserName";
                DbClass db = new DbClass();
                List<SqlParameter> SqlParameter = new List<SqlParameter>();
                SqlParameter.Add(new SqlParameter("@username", userName));
                SqlParameter.Add(new SqlParameter("@user_Password", pass));
                DataTable dt = db.ReturnExecuteDataTableMethod(sql, SqlParameter, out error);
                if (dt.Rows.Count> 0 )
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


        public int SaveNewRegisterUser(string fullName, string userName, string password, string mobileNumber, string address, string sex)
        {
            int result = 0;
            try
            {
                //string type = "user";
                string procedureName = "Insert_Update_UserInfo";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@name", fullName));
                parameters.Add(new SqlParameter("@user_Name", userName));
                parameters.Add(new SqlParameter("@user_Password", password));
                parameters.Add(new SqlParameter("@Mobile_Number", mobileNumber));
                parameters.Add(new SqlParameter("@address", address));
                parameters.Add(new SqlParameter("@user_Sex", sex));
                parameters.Add(new SqlParameter("@user_Type", "user"));
                parameters.Add(new SqlParameter("@user_status", 1));
                parameters.Add(new SqlParameter("@createby", "admin"));
                parameters.Add(new SqlParameter("@createDate", DateTime.Now));
                parameters.Add(new SqlParameter("@modifyby", userName));
                parameters.Add(new SqlParameter("@modifyDate", DateTime.Now));

                result = db.ExecuteNonQueryMethod(procedureName, parameters, out error);
                if (error != String.Empty)
                {
                    General.ErrorMessage(error);
                }



            }
            catch (Exception ex)
            {
                    
               General.ErrorMessage(ex.Message);
            }
            return result;
        }

        public DataTable GetLoginUserInfo(string id, string pass)
        {
            DataTable dt = null;
            string error;
            try
            {
                string sql = "GetRegisteredUserName";
                DbClass db = new DbClass();
                List<SqlParameter> SqlParameter = new List<SqlParameter>();
                SqlParameter.Add(new SqlParameter("@username", id));
                SqlParameter.Add(new SqlParameter("@user_Password", pass));
                 dt = db.ReturnExecuteDataTableMethod(sql, SqlParameter, out error);
                 if (error!=string.Empty)
                {
                    General.ErrorMessage(error);
                }


            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
            return dt;
        }
    }
}

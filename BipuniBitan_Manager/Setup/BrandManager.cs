using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BipuniBitan_DB;
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
    }
}

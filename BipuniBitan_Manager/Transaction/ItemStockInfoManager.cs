using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BipuniBitan_DB;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_Manager.Transaction
{
    public class ItemStockInfoManager
    {
        public DataSet GetItemStockList(string id,string name)
        {
            DataSet ds = null;
            try
            {
                string Sql = @"LoadStockInfoDgv";
                string error;
                DbClass db = new DbClass();
                List<SqlParameter>parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ItemCode", id));
                parameters.Add(new SqlParameter("@ItemName", name));
                ds = db.ReturnExecuteDatasetMethod(Sql, parameters, out error);

            }
            catch (Exception ex)
            {
                    
               General.ErrorMessage(ex.Message);
            }

            return ds;
        }
    }
}

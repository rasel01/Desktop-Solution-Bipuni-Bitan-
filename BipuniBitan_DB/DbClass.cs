using System;
using System.Collections.Generic;
using  System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BipuniBitan_DB
{
    public class DbClass
    {
        // COMMIT
        // Connection String Info :
       // COKNLNLDN
        string cs = ConfigurationManager.ConnectionStrings["BipuniBitan"].ConnectionString;
        // commitvhvvvvvj


        // method for insert,update, delete operation
        public int ExecuteNonQueryMethod(string storeprocedure,List<SqlParameter> parameters, out string errorMessage )
        {
            errorMessage = String.Empty;
            int result = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storeprocedure,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters.Count > 0)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.ParameterName,param.Value);
                            }
                        }

                        result = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }
            return result;


        }



        //  command.ExecuteScalar() :  Executes the query + 
        //and returns the first column of the first row in the result set returned by the query+
        //Additional columns or rows are ignored.

        // Method for getting only one object from a select command
        public object ExecuteScalerMethod(string storeprocedure, List<SqlParameter> parameters, out string errorMessage)
        {

            Object obj = new object();
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storeprocedure,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters.Count  > 0)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.ParameterName, param.Value);
                            }
                        }

                        obj = command.ExecuteScalar();

                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }
            return obj;

        }


        // Method for Execute a select command and get a dataset
        public DataSet ReturnExecuteDatasetMethod(string storeprocedure, List<SqlParameter> parameters, out string errorMessage)
        {
            DataSet ds = new DataSet();
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storeprocedure,connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters.Count > 0)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.ParameterName, param.Value);
                            }
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(ds);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }

            return ds;

        }

        
        // Method for Execute a select command and get a datatable
        public DataTable ReturnExecuteDataTableMethod(string storeprocedure, List<SqlParameter> parameters, out string errorMessage)
        {
            DataTable dt = new DataTable();
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storeprocedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters.Count > 0)
                        {
                            foreach (var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.ParameterName, param.Value);
                            }
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }

            return dt;

        }


        //public static  void 




    }
}

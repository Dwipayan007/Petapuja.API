using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Petapuja.API.Common
{
    public  class DbInstancce
    {

        /// <summary>
        /// Returns SQL Connection for defined Connection String
        /// </summary>
        public MySqlConnection OpenConnection()
        {
            try
            {
                //TODO Use using
                MySqlConnection scon= new MySqlConnection();
                //string connectionString = string.Empty;
                scon = new MySqlConnection(WebConfigurationManager.ConnectionStrings["MySqlServer"].ConnectionString);
                scon.Open();
                return scon;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Execute Specified Query and Returns Row as Data Table
        /// </summary>
        public DataTable GetDataTable(MySqlCommand mysqlCommand)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection tempmySQLConnection = OpenConnection())
                {
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                    mysqlCommand.Connection = tempmySQLConnection;
                    sqlDataAdapter.SelectCommand = mysqlCommand;
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Execute Specified SQL Command
        /// </summary>
        public void ExecuteNonQuery(MySqlCommand mysqlCommand)
        {
            try
            {
                using (mysqlCommand.Connection = OpenConnection())
                {
                    mysqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Execute Specified SQL Command and Returns Output Value
        /// </summary>
        public int ExecuteNonQueryWithReturnValue(MySqlCommand mysqlCommand)
        {
            try
            {
                using (mysqlCommand.Connection = OpenConnection())
                {
                    //var returnParameter = mysqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int);
                   // returnParameter.Direction = ParameterDirection.ReturnValue;
                    mysqlCommand.ExecuteNonQuery();
                    return (int)mysqlCommand.Parameters["@ReturnValue"].Value;
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Execute Specified SQL Command and Returns Output Value
        /// </summary>
        public string ExecuteNonQueryWithReturnValueString(MySqlCommand mysqlCommand)
        {
            try
            {
                using (mysqlCommand.Connection = OpenConnection())
                {
                    //var returnParameter = mysqlCommand.Parameters.Add("@ReturnValue", SqlDbType.VarChar);
                    //returnParameter.Direction = ParameterDirection.Output;
                    mysqlCommand.ExecuteNonQuery();
                    return (string)mysqlCommand.Parameters["@ReturnValue"].Value;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Execute Specified SQL Command and Returns Output Value
        /// </summary>
        public int ExecuteScalarWithReturnValue(MySqlCommand mysqlCommand)
        {
            try
            {
                using (mysqlCommand.Connection = OpenConnection())
                {
                    return (int)mysqlCommand.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Execute Specified SQL Command and Returns Output Value As String
        /// </summary>
        public string ExecuteScalarWithReturnValueString(MySqlCommand sqlCommand)
        {
            try
            {
                using (sqlCommand.Connection = OpenConnection())
                {
                    return (string)sqlCommand.ExecuteScalar();
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
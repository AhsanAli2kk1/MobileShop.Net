using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
{
    class DBAccess
    {
        private static SqlConnection connection = new SqlConnection();
        private static SqlCommand command = new SqlCommand();
     
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        public SqlTransaction DbTran;

        public static string strConnString = "Data Source=AHSANALI\\SQLEXPRESS;Initial Catalog=SHOPDB.MDF;Integrated Security=True";



        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void closeConn()
        {
            connection.Close();
        }


        public int executeDataAdapter(DataTable tblName, string strSelectSql)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }

                adapter.SelectCommand.CommandText = strSelectSql;
                adapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(adapter);


                string insert = DbCommandBuilder.GetInsertCommand().CommandText.ToString();
                string update = DbCommandBuilder.GetUpdateCommand().CommandText.ToString();
                string delete = DbCommandBuilder.GetDeleteCommand().CommandText.ToString();


                return adapter.Update(tblName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void readDatathroughAdapter(string query, DataTable tblName)
        {
            try
            {
                
                if (connection.State == ConnectionState.Closed)
                {
                   
                    createConn();
                }

             
                command.Connection = connection;
                
                command.CommandText = query;
                

                command.CommandType = CommandType.Text;
              

                adapter = new SqlDataAdapter(command);
                

                adapter.Fill(tblName);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void readDatathroughAdapter_2(string query, DataTable tblName, SqlParameter parameter)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;

                // Add the parameter to the command
                command.Parameters.Clear();
                command.Parameters.Add(parameter);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(tblName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public SqlDataReader readDatathroughReader(string query)
        {
            //DataReader used to sequentially read data from a data source
            SqlDataReader reader;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int executeQuery(SqlCommand dbCommand)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }

                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;


                return dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object executeQuery_2(SqlCommand command)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Ensure the command has a valid connection
                if (command.Connection == null)
                {
                    command.Connection = connection;
                }

                // Check if the command is a SELECT query
                if (command.CommandText.ToUpperInvariant().Contains("SELECT"))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader[0]; // Assuming a single value is expected
                        }
                    }
                }
                else
                {
                    // For non-SELECT queries
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return null;
        }



    }


    }
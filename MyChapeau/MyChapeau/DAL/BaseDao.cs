using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public abstract class BaseDao
    {
        private SqlConnection sqlConnection;

        public BaseDao()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ChapeauDatabase"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        protected SqlConnection OpenConnection()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sqlConnection;
        }

        private void CloseConnection()
        {
            sqlConnection.Close();
        }

        protected void ExecuteNonQuery(string sqlQuery, Action<SqlCommand> parameterSetter = null)
        {
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                command.Connection = OpenConnection();
                parameterSetter?.Invoke(command);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        
        protected SqlDataReader ExecuteReader(string sqlQuery, Action<SqlCommand> parameterSetter = null)
        {
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                command.Connection = OpenConnection();
                parameterSetter?.Invoke(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        protected T ExecuteScalar<T>(string sqlQuery, Action<SqlCommand> parameterSetter = null)
        {
            var result = default(T);
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                command.Connection = OpenConnection();
                parameterSetter?.Invoke(command);
                var scalarResult = command.ExecuteScalar();
                if (scalarResult != DBNull.Value)
                {
                    result = (T)scalarResult;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { CloseConnection(); }
            return result;
        }

    }

}

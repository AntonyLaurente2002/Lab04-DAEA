using System;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    static class SqlHelper
    {
        public static string Connection { get; } = "Data Source=LAB1504-18\\SQLEXPRESS;" +
                                                   "Initial Catalog=Neptuno;User Id=antony;Password=123456;TrustServerCertificate=true";

        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(Connection, commandText, commandType, parameters);
        }

        public static Object ExecuteScalar(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            return ExecuteScalar(Connection, commandText, commandType, parameters);
        }

        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            return ExecuteReader(Connection, commandText, commandType, parameters);
        }

        public static Int32 ExecuteNonQuery(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Object ExecuteScalar(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteReader(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}

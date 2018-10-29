using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DiretorSkinner.Util.Acesso
{
    public class Conexao
    {
        #region Fields

        internal static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
            }
        }

        [ThreadStatic]
        private static SqlConnection conn = null;

        #endregion Fields

        #region Methods

        public static void CloseConnection()
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
                conn = null;
            }
        }

        public static DataSet ExecutarDataSet(SqlCommand cmd, bool closeConnection = false)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.Connection = GetConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.FillLoadOption = LoadOption.OverwriteChanges;
                da.Fill(ds);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open && closeConnection)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return ds;
        }

        public static IEnumerable<T> ExecutarDtoEnumerable<T>(SqlCommand cmd, Func<IDataRecord, T> generator, bool closeConnection = false)
        {
            IEnumerable<T> ret = null;

            if (generator == null)
            {
                throw new ArgumentNullException("generator");
            }

            ret = ProcessarDataReader<IEnumerable<T>>(cmd, closeConnection,
                reader => reader.GetEnumerator<T>(generator).ToArray(),
                () => new T[0],
                result => result.Count()
                );

            return ret;
        }

        public static IEnumerable<T> ExecutarEnumerable<T>(SqlCommand cmd, Func<IDataRecord, T> generator, bool closeConnection = false)

        {
            IEnumerable<T> ret = null;

            if (generator == null)
            {
                throw new ArgumentNullException("generator");
            }

            ret = ProcessarDataReader<IEnumerable<T>>(cmd, closeConnection,
                reader => reader.GetEnumerator<T>(generator).ToArray(),
                () => new T[0],
                result => result.Count()
                );

            return ret;
        }

        public static int ExecuteNonQuery(SqlCommand cmd, bool closeConnection = false)
        {
            int result;

            try
            {
                cmd.Connection = GetConnection();

                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open && closeConnection)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return result;
        }

        public static SqlCommand NewCommand(string commandText, CommandType cmdType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = commandText;
            cmd.CommandType = cmdType;

            return cmd;
        }

        public static SqlConnection GetConnection()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
            }

            return conn;
        }

        private static object SqlDecimalToDecimal(System.Data.SqlTypes.SqlDecimal valor)
        {
            if (valor.IsNull)
                return DBNull.Value;

            return Convert.ToDecimal(valor.ToDouble());
        }

        private static T ProcessarDataReader<T>(SqlCommand cmd, bool closeConnection, Func<SqlDataReader, T> createEnumerable, Func<T> createEmptyEnumerable, Func<T, long> getCount)
        {
            if (createEmptyEnumerable == null)
            {
                throw new ArgumentNullException("createEmptyEnumerable");
            }

            if (createEnumerable == null)
            {
                throw new ArgumentNullException("createEnumerable");
            }

            T dataTable;

            SqlDataReader dataReader = null;

            try
            {
                cmd.Connection = GetConnection();

                dataReader = cmd.ExecuteReader();

                dataTable = createEnumerable(dataReader);
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }

                if (conn != null && conn.State == ConnectionState.Open && closeConnection)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return dataTable;
        }

        public static object ExecuteScalar(SqlCommand cmd)
        {
            object retorno;

            try
            {
                cmd.Connection = GetConnection();

                retorno = cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return retorno;
        }

        #endregion Methods
    }
}

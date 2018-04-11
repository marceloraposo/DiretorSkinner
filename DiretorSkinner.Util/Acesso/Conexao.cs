using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DiretorSkinner.Util.Acesso
{
    public class Conexao
    {

        internal static string StringConnection
        {
            get
            {
                string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(executable));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
                return string.Format("Data Source={0}{1}", "|DataDirectory|", ConfigurationManager.AppSettings["HostSql"]);
            }
        }


        [ThreadStatic]
        private static SQLiteConnection conn = null;

        public static SQLiteConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(StringConnection);
                conn.Open();
            }

            return conn;
        }

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

        public static DataSet ExecutarDataSet(SQLiteCommand cmd)
        {

            DataSet ds = new DataSet();

            try
            {
                cmd.Connection = GetConnection();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.FillLoadOption = LoadOption.OverwriteChanges;
                da.Fill(ds);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return ds;
        }

        public static int ExecuteNonQuery(SQLiteCommand cmd)
        {
            int qtd = 0;

            try
            {
                cmd.Connection = GetConnection();

                qtd = cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn = null;
                }
            }

            return qtd;
        }

        public static object ExecuteScalar(SQLiteCommand cmd)
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

    }
}

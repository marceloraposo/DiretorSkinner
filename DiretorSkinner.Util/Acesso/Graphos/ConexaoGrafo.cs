using Neo4jClient;
using System;
using System.Configuration;

namespace DiretorSkinner.Util.Acesso.Graphos
{
    public class ConexaoGrafo
    {
        internal static string StringConnection
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["HostGrafo"]);
            }
        }

        [ThreadStatic]
        private static GraphClient conn = null;

        public static GraphClient GetConnection()
        {
            if (conn == null)
            {
                conn = new GraphClient(new Uri(StringConnection), ConfigurationManager.AppSettings["UsrGrafo"], ConfigurationManager.AppSettings["PwdGrafo"]);
            }

            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }

    }
}

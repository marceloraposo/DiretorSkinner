using Neo4jClient;
using System;
using System.Configuration;
using System.Net;

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

        internal static string UserConnection
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["UsrGrafo"]);
            }
        }

        internal static string PwdConnection
        {
            get
            {
                return string.Format(ConfigurationManager.AppSettings["PwdGrafo"]);
            }
        }

        [ThreadStatic]
        private static GraphClient conn = null;

        public static GraphClient GetConnection()
        {
            if (conn == null)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (conn = new GraphClient(new Uri(StringConnection), UserConnection, PwdConnection))
                {
                    conn.Connect(); // 👍
                }
                //conn = new GraphClient(new Uri(StringConnection), UserConnection, PwdConnection);
                // conn.Connect();
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

        public static GraphClient Client
        {
            get
            {
                GraphClient retorno;

                try
                {
                    retorno = GetConnection();
                }
                finally
                {
                    if (conn != null && conn.IsConnected)
                    {
                        conn.Dispose();
                        conn = null;
                    }
                }

                return retorno;
            }
        }

    }
}

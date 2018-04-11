using DiretorSkinner.Interface;
using DiretorSkinner.Negocio;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Xml;

namespace DiretorSkinner.Servico
{
    public partial class DiretorSkinnerHost : ServiceBase
    {

        #region Fields

        private ServiceHost _hostDiretorSkinner;
        private DiretorSkinner _server;

        #endregion Fields

        #region Constructors

        public DiretorSkinnerHost()
        {
            InitializeComponent();

            this.ServiceName = "DiretorSkinnerHost";

            _hostDiretorSkinner = null;
        }

        #endregion Constructors

        #region Methods

        public void StartServer()
        {
            try
            {
                _server = new DiretorSkinner();

                _hostDiretorSkinner = new ServiceHost(_server);

                Binding tcpBinding = CreateTcpBinding();

                //Use base address as address
                string _hostString = ConfigurationManager.AppSettings["Host"];

                _hostDiretorSkinner.Open();

            }
            catch (CommunicationException ex)
            {
                EventLog.WriteEntry(ex.Message);
            }
        }

        public void StopServer()
        {
            try
            {
                if (_hostDiretorSkinner != null)
                {
                    if (_hostDiretorSkinner.State == CommunicationState.Opened)
                        _hostDiretorSkinner.Close();

                    _hostDiretorSkinner = null;
                }
            }
            catch (CommunicationException ex)
            {
                EventLog.WriteEntry(ex.Message);

                if (_hostDiretorSkinner != null)
                {
                    _hostDiretorSkinner.Abort();
                }
            }
            finally
            {
                if (_server != null)
                {
                    _server.Dispose();
                    _server = null;
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            StartServer();
        }

        protected override void OnStop()
        {
            StopServer();
        }

        private NetTcpBinding CreateTcpBinding()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            System.ServiceModel.Channels.BindingElementCollection bElementCollection = tcpBinding.CreateBindingElements();

            tcpBinding.Name = "SeymourSkinner";
            tcpBinding.CloseTimeout = TimeSpan.FromHours(2); // new TimeSpan(1, 0, 0); // 1 hora
            tcpBinding.OpenTimeout = TimeSpan.FromHours(2); // new TimeSpan(1, 0, 0); // 1 hora
            tcpBinding.ReceiveTimeout = TimeSpan.FromHours(2); // new TimeSpan(1, 0, 0); // 1 hora
            tcpBinding.SendTimeout = TimeSpan.FromHours(2); // new TimeSpan(1, 0, 0); // 1 hora
            tcpBinding.MaxBufferPoolSize = 2147483647;
            tcpBinding.MaxBufferSize = 2147483647;
            tcpBinding.MaxReceivedMessageSize = 2147483647;

            tcpBinding.ReliableSession.InactivityTimeout = new TimeSpan(1, 0, 0);
            tcpBinding.Security.Mode = SecurityMode.None;

            System.ServiceModel.Channels.TcpTransportBindingElement tcp = bElementCollection.Find<System.ServiceModel.Channels.TcpTransportBindingElement>();
            tcp.ConnectionPoolSettings.MaxOutboundConnectionsPerEndpoint = 500;
            tcp.ConnectionPoolSettings.LeaseTimeout = TimeSpan.MaxValue;
            tcp.ConnectionPoolSettings.IdleTimeout = TimeSpan.MaxValue;
            tcp.ChannelInitializationTimeout = TimeSpan.MaxValue;
            tcp.ConnectionBufferSize = int.MaxValue;
            tcp.MaxBufferPoolSize = long.MaxValue;
            tcp.MaxBufferSize = int.MaxValue;
            tcp.MaxReceivedMessageSize = long.MaxValue;

            XmlDictionaryReaderQuotas quotas = tcpBinding.ReaderQuotas;

            quotas.MaxStringContentLength = int.MaxValue;
            quotas.MaxArrayLength = int.MaxValue;
            quotas.MaxBytesPerRead = int.MaxValue;
            quotas.MaxDepth = int.MaxValue;
            quotas.MaxNameTableCharCount = int.MaxValue;

            tcpBinding.GetType().GetProperty("ReaderQuotas").SetValue(tcpBinding, quotas, null);

            return tcpBinding;
        }

        #endregion Methods

    }
}

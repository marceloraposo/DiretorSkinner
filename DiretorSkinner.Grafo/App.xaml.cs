using DiretorSkinner.Grafo.Seymour;
using DiretorSkinner.Grafo.Tranporte;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DiretorSkinner.Grafo
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            this.Exit += new ExitEventHandler(this.Application_Exit);
            this.Startup += new StartupEventHandler(App_Startup);
        }

        public static DiretorSkinnerGrafoClient Server
        {
            get
            {
                return new DiretorSkinner.Grafo.Seymour.DiretorSkinnerGrafoClient();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (Application.Current.Properties.Contains("pessoa"))
                Application.Current.Properties.Remove("pessoa");
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {

            Login login = new Login();

            login.LoginDispatcher += (s, evt) =>
            {
                CarregarPessoa(login.Pessoa);
                MainWindow main = new MainWindow();
                Application.Current.MainWindow = main;
                main.ShowDialog();
            };

            login.ShowDialog();
        }


        public void CarregarPessoa(string login)
        {
            //vai validar
            PessoaDto pessoa = App.Server.ListarPessoaPorCodigo(login);
            if (pessoa != null)
            {
                Application.Current.Properties["pessoa"] = pessoa;
            }
            else
            {
                MessageBox.Show("Pessoa não encontrada.");
                //abrir login de novo
            }
        }
    }
}

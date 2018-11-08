using DiretorSkinner.Grafo;
using System;
using System.Windows;

namespace DiretorSkinner
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string pessoa;

        public Login()
        {
            InitializeComponent();
        }

        public string Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        public event EventHandler LoginDispatcher;

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            var result = App.Server.ListarPessoaPorCodigo(this.txtPessoa.Text);

            if (result != null)
            {
                try
                {
                    this.Hide();
                    this.Pessoa = result.Codigo;

                    if (LoginDispatcher != null)
                        LoginDispatcher(this, new EventArgs());
                }
                finally
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("Pessoa não identificada.");
        }
    }
}

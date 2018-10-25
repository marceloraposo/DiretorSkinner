using DiretorSkinner.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Relatorio
{
    /// <summary>
    /// Interaction logic for PessoaPorConceito.xaml
    /// </summary>
    public partial class PessoaPorConceito : UserControl
    {
        private ObservableCollection<PessoaPorConceitoDto> listaPessoaPorConceito;
        public ObservableCollection<PessoaPorConceitoDto> ListaPessoaPorConceito
        {
            get { return listaPessoaPorConceito; }
            set { listaPessoaPorConceito = value; }
        }

        public PessoaPorConceito()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarPessoaPorConceito();
        }

        public void CarregarPessoaPorConceito()
        {
            //colocar regras para visualizações
            this.ListaPessoaPorConceito = new ObservableCollection<PessoaPorConceitoDto>(App.Server.ListarPessoaPorTodosConceitos());
        }

    }
}

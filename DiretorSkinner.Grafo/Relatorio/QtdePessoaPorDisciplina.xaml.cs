using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Grafo.Relatorio
{
    /// <summary>
    /// Interaction logic for QtdePessoaPorDisciplina.xaml
    /// </summary>
    public partial class QtdePessoaPorDisciplina : UserControl
    {
        private ObservableCollection<QtdePessoaPorDisciplinaDto> listaQtdePessoaPorDisciplina;
        public ObservableCollection<QtdePessoaPorDisciplinaDto> ListaQtdePessoaPorDisciplina
        {
            get { return listaQtdePessoaPorDisciplina; }
            set { listaQtdePessoaPorDisciplina = value; }
        }

        public QtdePessoaPorDisciplina()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarQtdePessoaPorDisciplina();
        }

        public void CarregarQtdePessoaPorDisciplina()
        {
            //colocar regras para visualizações
            this.ListaQtdePessoaPorDisciplina = new ObservableCollection<QtdePessoaPorDisciplinaDto>(App.Server.ListarQtdePessoaPorTodasDisciplinas());
        }

    }
}

using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Grafo.Relatorio
{
    /// <summary>
    /// Interaction logic for RepetenciaDeDisciplinaPorTipoPessoa.xaml
    /// </summary>
    public partial class RepetenciaDeDisciplinaPorTipoPessoa : UserControl
    {
        private ObservableCollection<RepetenciaDeDisciplinaPorTipoPessoaDto> listaRepetenciaDeDisciplinaPorTipoPessoa;
        public ObservableCollection<RepetenciaDeDisciplinaPorTipoPessoaDto> ListaRepetenciaDeDisciplinaPorTipoPessoa
        {
            get { return listaRepetenciaDeDisciplinaPorTipoPessoa; }
            set { listaRepetenciaDeDisciplinaPorTipoPessoa = value; }
        }

        public RepetenciaDeDisciplinaPorTipoPessoa()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarRepetenciaDeDisciplinaPorTipoPessoa();
        }

        public void CarregarRepetenciaDeDisciplinaPorTipoPessoa()
        {
            //colocar regras para visualizações
            this.ListaRepetenciaDeDisciplinaPorTipoPessoa = new ObservableCollection<RepetenciaDeDisciplinaPorTipoPessoaDto>(App.Server.ListarRepetenciaPorTodosTipos());
        }

    }
}

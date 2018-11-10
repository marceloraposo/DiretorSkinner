using DiretorSkinner.Grafo.Tranporte;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DiretorSkinner.Grafo.Carga
{
    /// <summary>
    /// Interaction logic for CargaConceito.xaml
    /// </summary>
    public partial class CargaConceito : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int tamanho;
        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        private ProcessamentoDto processamentoDto;
        public ProcessamentoDto ProcessamentoDto
        {
            get { return processamentoDto; }
            set { processamentoDto = value; OnPropertyChanged("ProcessamentoDto"); }
        }

        public CargaConceito()
        {
            InitializeComponent();

            this.DataContext = this;
        }


        public void EfetuarCarga()
        {
            if (this.Tamanho > 0)
            {
                if (this.rdInserir.IsChecked.HasValue && this.rdInserir.IsChecked.Value)
                {
                    this.ProcessamentoDto = App.Server.CargaInserirConceito(Tamanho);
                }
                else if (this.rdAlterar.IsChecked.HasValue && this.rdAlterar.IsChecked.Value)
                {
                    this.ProcessamentoDto = App.Server.CargaAlterarConceito(Tamanho);
                }
                else if (this.rdExcluir.IsChecked.HasValue && this.rdExcluir.IsChecked.Value)
                {
                    this.ProcessamentoDto = App.Server.CargaExcluirConceito(Tamanho);
                }
                else if (this.rdSelecionar.IsChecked.HasValue && this.rdSelecionar.IsChecked.Value)
                {
                    this.ProcessamentoDto = App.Server.CargaSelecionarConceito(Tamanho);
                }
                else if (this.rdRelatorio.IsChecked.HasValue && this.rdRelatorio.IsChecked.Value)
                {
                    this.ProcessamentoDto = App.Server.CargaRelatorioConceito(Tamanho);
                }
                else
                {
                    MessageBox.Show("Preencha os filtros");
                }
            }
            else
            {
                MessageBox.Show("Preencha os filtros");
            }
        }

        private void btnCarga_Click(object sender, RoutedEventArgs e)
        {
             this.EfetuarCarga();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}

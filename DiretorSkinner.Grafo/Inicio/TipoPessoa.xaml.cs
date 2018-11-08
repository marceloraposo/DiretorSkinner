using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Grafo.Inicio
{
    /// <summary>
    /// Interaction logic for TipoPessoa.xaml
    /// </summary>
    public partial class TipoPessoa : UserControl
    {
        private ObservableCollection<TipoPessoaDto> listaTiposPessoa;
        public ObservableCollection<TipoPessoaDto> ListaTiposPessoa
        {
            get { return listaTiposPessoa; }
            set { listaTiposPessoa = value; }
        }

        public TipoPessoa()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarTiposPessoa();
        }

        public void CarregarTiposPessoa()
        {
            //colocar regras para visualizações
            this.ListaTiposPessoa = new ObservableCollection<TipoPessoaDto>(App.Server.ListarTiposPessoa());
        }

        private void dgTipoPessoa_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            TipoPessoaDto tipoPessoaDto = e.Row.DataContext as TipoPessoaDto;


            SalvarTipoPessoa(tipoPessoaDto);
        }

        private void dgTipoPessoa_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Tipo de Pessoa ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            TipoPessoaDto tipoPessoaDto = row as TipoPessoaDto;
                            App.Server.DeletarTipoPessoa(tipoPessoaDto);
                        }
                        MessageBox.Show("Tipo de Pessoa removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarTipoPessoa(TipoPessoaDto tipoPessoaDto)
        {
            if (tipoPessoaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", tipoPessoaDto.Nome), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarTipoPessoa(tipoPessoaDto);
                    MessageBox.Show(string.Format("{0} alterado.", tipoPessoaDto.Nome), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }
    }
}

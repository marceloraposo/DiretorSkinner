using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Grafo.Inicio
{
    /// <summary>
    /// Interaction logic for TipoDisciplina.xaml
    /// </summary>
    public partial class TipoDisciplina : UserControl
    {
        private ObservableCollection<TipoDisciplinaDto> listaTiposDisciplina;
        public ObservableCollection<TipoDisciplinaDto> ListaTiposDisciplina
        {
            get { return listaTiposDisciplina; }
            set { listaTiposDisciplina = value; }
        }

        public TipoDisciplina()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarTiposDisciplina();
        }

        public void CarregarTiposDisciplina()
        {
            //colocar regras para visualizações
            this.ListaTiposDisciplina = new ObservableCollection<TipoDisciplinaDto>(App.Server.ListarTiposDisciplina().ToList());
        }

        private void dgTipoDisciplina_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            TipoDisciplinaDto tipoPessoaDto = e.Row.DataContext as TipoDisciplinaDto;


            SalvarTipoDisciplina(tipoPessoaDto);
        }

        private void dgTipoDisciplina_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Tipo de de Disciplina ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            TipoDisciplinaDto tipoPessoaDto = row as TipoDisciplinaDto;
                            App.Server.DeletarTipoDisciplina(tipoPessoaDto);
                        }
                        MessageBox.Show("Tipo de de Disciplina removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarTipoDisciplina(TipoDisciplinaDto tipoPessoaDto)
        {
            if (tipoPessoaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", tipoPessoaDto.Nome), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarTipoDisciplina(tipoPessoaDto);
                    MessageBox.Show(string.Format("{0} alterado.", tipoPessoaDto.Nome), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }
    }
}

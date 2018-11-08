using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Grafo.Inicio
{
    /// <summary>
    /// Interaction logic for Disciplina.xaml
    /// </summary>
    public partial class Disciplina : UserControl
    {
        private ObservableCollection<DisciplinaDto> listaDisciplinas;
        public ObservableCollection<DisciplinaDto> ListaDisciplinas
        {
            get { return listaDisciplinas; }
            set { listaDisciplinas = value; }
        }

        private ObservableCollection<TipoDisciplinaDto> listaTipoDisciplina;
        public ObservableCollection<TipoDisciplinaDto> ListaTipoDisciplina
        {
            get { return listaTipoDisciplina; }
            set { listaTipoDisciplina = value; }
        }

        public Disciplina()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarDisciplinas();
            CarregarTiposDisciplina();
        }

        public void CarregarDisciplinas()
        {
            //colocar regras para visualizações
            this.ListaDisciplinas = new ObservableCollection<DisciplinaDto>(App.Server.ListarDisciplinas());
        }

        public void CarregarTiposDisciplina()
        {
            this.ListaTipoDisciplina = new ObservableCollection<TipoDisciplinaDto>(App.Server.ListarTiposDisciplina());
        }

        private void dgDisciplina_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            DisciplinaDto disciplinaDto = e.Row.DataContext as DisciplinaDto;


            SalvarDisciplina(disciplinaDto);
        }

        private void dgDisciplina_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Disciplina ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            DisciplinaDto disciplinaDto = row as DisciplinaDto;
                            App.Server.DeletarDisciplina(disciplinaDto);
                        }
                        MessageBox.Show("Disciplina removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarDisciplina(DisciplinaDto disciplinaDto)
        {
            if (disciplinaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", disciplinaDto.Nome), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarDisciplina(disciplinaDto);
                    MessageBox.Show(string.Format("{0} alterado.", disciplinaDto.Nome), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }
    }
}

using DiretorSkinner.Tranporte;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Inicio
{
    /// <summary>
    /// Interaction logic for Turma.xaml
    /// </summary>
    public partial class Turma : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<TurmaDto> listaTurmas;
        public ObservableCollection<TurmaDto> ListaTurmas
        {
            get { return listaTurmas; }
            set { listaTurmas = value; OnPropertyChanged("ListaTurmas"); }
        }

        private ObservableCollection<PessoaDto> listaPessoa;
        public ObservableCollection<PessoaDto> ListaPessoa
        {
            get { return listaPessoa; }
            set { listaPessoa = value; }
        }

        private ObservableCollection<DisciplinaDto> listaDisciplina;
        public ObservableCollection<DisciplinaDto> ListaDisciplina
        {
            get { return listaDisciplina; }
            set { listaDisciplina = value; }
        }

        private ObservableCollection<ConceitoDto> listaConceito;
        public ObservableCollection<ConceitoDto> ListaConceito
        {
            get { return listaConceito; }
            set { listaConceito = value; }
        }

        private int? pessoaId;
        public int? PessoaId
        {
            get { return pessoaId; }
            set { pessoaId = value; }
        }

        private int? conceitoId;
        public int? ConceitoId
        {
            get { return conceitoId; }
            set { conceitoId = value; }
        }

        private int? disciplinaId;
        public int? DisciplinaId
        {
            get { return disciplinaId; }
            set { disciplinaId = value; }
        }

        public Turma()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarTurmas(PessoaId,DisciplinaId,ConceitoId);
            CarregarPessoa();
            CarregarDisciplina();
            CarregarConceito();
        }

        public void CarregarTurmas(int? pessoaId, int? disciplinaId, int? conceitoId)
        {
            //colocar regras para visualizações
            //this.ListaTurmas = new ObservableCollection<TurmaDto>(App.Server.ListarTurmas());
            if (pessoaId.HasValue || disciplinaId.HasValue || conceitoId.HasValue)
            {
                this.ListaTurmas = new ObservableCollection<TurmaDto>(App.Server.ListarTurma(conceitoId.HasValue ? new ConceitoDto() { Id = conceitoId.Value } : null, disciplinaId.HasValue ? new DisciplinaDto() { Id = disciplinaId.Value } : null, pessoaId.HasValue ? new PessoaDto() { Id = pessoaId.Value } : null));
            }
            else
            {
                this.ListaTurmas = new ObservableCollection<TurmaDto>();
            }
        }

        public void CarregarPessoa()
        {
            //colocar regras para visualizações
            this.ListaPessoa = new ObservableCollection<PessoaDto>(App.Server.ListarPessoas());
        }

        public void CarregarDisciplina()
        {
            //colocar regras para visualizações
            this.ListaDisciplina = new ObservableCollection<DisciplinaDto>(App.Server.ListarDisciplinas());
        }

        public void CarregarConceito()
        {
            //colocar regras para visualizações
            this.ListaConceito = new ObservableCollection<ConceitoDto>(App.Server.ListarConceitos());
        }

        private void dgTurma_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            TurmaDto turmaDto = e.Row.DataContext as TurmaDto;


            SalvarTurma(turmaDto);
        }

        private void dgTurma_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Turma ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            TurmaDto turmaDto = row as TurmaDto;
                            App.Server.DeletarTurma(turmaDto);
                        }
                        MessageBox.Show("Turma removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarTurma(TurmaDto turmaDto)
        {
            if (turmaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", turmaDto.Semestre), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarTurma(turmaDto);
                    MessageBox.Show(string.Format("{0} alterado.", turmaDto.Semestre), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            this.CarregarTurmas(PessoaId,DisciplinaId,ConceitoId);
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

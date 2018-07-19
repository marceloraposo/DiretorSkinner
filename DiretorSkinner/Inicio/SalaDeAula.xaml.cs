using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Inicio
{
    /// <summary>
    /// Interaction logic for SalaDeAula.xaml
    /// </summary>
    public partial class SalaDeAula : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int turmaId;
        public int TurmaId
        {
            get { return turmaId; }
            set { turmaId = value; }
        }

        private ObservableCollection<SalaDeAulaDto> listaSalasDeAula;
        public ObservableCollection<SalaDeAulaDto> ListaSalasDeAula
        {
            get { return listaSalasDeAula; }
            set { listaSalasDeAula = value; OnPropertyChanged("ListaSalasDeAula"); }
        }

        private ObservableCollection<PessoaDto> listaPessoa;
        public ObservableCollection<PessoaDto> ListaPessoa
        {
            get { return listaPessoa; }
            set { listaPessoa = value; OnPropertyChanged("ListaPessoa"); }
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

        private string filtro;
        public string Filtro
        {
            get { return filtro; }
            set { filtro = value; }
        }

        public SalaDeAula(int _turmaId)
        {
            InitializeComponent();

            this.DataContext = this;

            this.TurmaId = _turmaId;

            this.CarregarDados();
        }

        public SalaDeAula()
        {
            InitializeComponent();

            this.DataContext = this;

            this.CarregarDados();
        }

        public void CarregarDados()
        {
            CarregarSalaDeAulas(null, null, null);
            CarregarDisciplina();
            CarregarConceito();
        }

        public void CarregarSalaDeAulas(int? pessoaId, int? disciplinaId, int? conceitoId)
        {
            //colocar regras para visualizações
            if (pessoaId.HasValue || disciplinaId.HasValue || conceitoId.HasValue)
            {
                pessoaId = pessoaId.HasValue && pessoaId == 0 ? null : pessoaId;
                disciplinaId = disciplinaId.HasValue && disciplinaId == 0 ? null : disciplinaId;
                conceitoId = conceitoId.HasValue && conceitoId == 0 ? null : conceitoId;
                this.ListaSalasDeAula = new ObservableCollection<SalaDeAulaDto>(App.Server.ListarSalaDeAula(conceitoId.HasValue ? new ConceitoDto() { Id = conceitoId.Value } : null, disciplinaId.HasValue ? new DisciplinaDto() { Id = disciplinaId.Value } : null, pessoaId.HasValue ? new PessoaDto() { Id = pessoaId.Value } : null, new TurmaDto() { Id = TurmaId } ));
            }
            else
            {
                this.ListaSalasDeAula = new ObservableCollection<SalaDeAulaDto>(App.Server.ListarSalaDeAulaPorTurma(new TurmaDto() { Id = TurmaId })); 
            }

        }

        public void CarregarDisciplina()
        {
            //colocar regras para visualizações
            this.ListaDisciplina = new ObservableCollection<DisciplinaDto>(App.Server.ListarDisciplinas());
            this.ListaDisciplina.Insert(0, new DisciplinaDto());
        }

        public void CarregarConceito()
        {
            //colocar regras para visualizações
            this.ListaConceito = new ObservableCollection<ConceitoDto>(App.Server.ListarConceitos());
            this.ListaConceito.Insert(0,new ConceitoDto());
        }

        public bool CarregarPessoa(string _filtro)
        {
            //colocar regras para visualizações
            if (!string.IsNullOrEmpty(_filtro) && _filtro.Length > 3)
            {
                this.ListaPessoa = new ObservableCollection<PessoaDto>(App.Server.ListarPessoasPesquisa(_filtro));
                this.ListaPessoa.Insert(0, new PessoaDto());
                return true;
            }
            return false;
        }

        private void dgSalaDeAula_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            SalaDeAulaDto SalaDeAulaDto = e.Row.DataContext as SalaDeAulaDto;
            SalaDeAulaDto.TurmaId = TurmaId;

            SalvarSalaDeAula(SalaDeAulaDto);
        }

        private void dgSalaDeAula_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover SalaDeAula ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            SalaDeAulaDto SalaDeAulaDto = row as SalaDeAulaDto;
                            App.Server.DeletarSalaDeAula(SalaDeAulaDto);
                        }
                        MessageBox.Show("SalaDeAula removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarSalaDeAula(SalaDeAulaDto SalaDeAulaDto)
        {
                if (SalaDeAulaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", SalaDeAulaDto.Semestre), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.DeletarSalaDeAula(SalaDeAulaDto);
                    App.Server.SalvarSalaDeAula(SalaDeAulaDto);
                    MessageBox.Show(string.Format("{0} alterado.", SalaDeAulaDto.Semestre), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            this.CarregarSalaDeAulas(PessoaId, DisciplinaId, ConceitoId);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void cmbGridPessoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            System.Windows.Controls.Primitives.Popup popupGrid = (System.Windows.Controls.Primitives.Popup)(((StackPanel)comboBox.Parent).Parent);
            TextBox textBox = (TextBox)((Grid)popupGrid.Parent).Children[0];
            this.ListaPessoa = new ObservableCollection<PessoaDto>();
            popupGrid.IsOpen = false;
        }

        private void cmbGridPessoa_TextInputUpdate(object sender, TextCompositionEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            string _filtro = string.Format("{0}{1}",comboBox.Text,e.Text);

            if (string.IsNullOrEmpty(_filtro) || _filtro.Length <= 3)
            {
                _filtro = string.Empty;
                return;
            }

            comboBox.IsDropDownOpen = CarregarPessoa(_filtro);

            comboBox.ItemsSource = this.ListaPessoa;

        }
    }
}

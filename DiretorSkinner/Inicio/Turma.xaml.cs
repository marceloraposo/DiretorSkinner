using DiretorSkinner.Tranporte;
using System;
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

        public Turma()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarTurmas();
        }

        public void CarregarTurmas()
        {
            //colocar regras para visualizações
            this.ListaTurmas = new ObservableCollection<TurmaDto>(App.Server.ListarTurmas());
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
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", turmaDto.Codigo), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarTurma(turmaDto);
                    MessageBox.Show(string.Format("{0} alterado.", turmaDto.Codigo), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            var _dpEffDate = sender as DatePicker;

            _dpEffDate.DisplayDateEnd = DateTime.Now;
            _dpEffDate.DisplayDateStart = DateTime.Now.AddDays(-30);
            _dpEffDate.DisplayDate = DateTime.Now;

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void AbrirPopUp_Click(object sender, RoutedEventArgs e)
        {
            int turmaId = (int)((Button)sender).CommandParameter;
            SalaDeAula salaDeAulaWindow = new SalaDeAula(turmaId);
            //salaDeAulaWindow.TurmaId = turmaId;

            Window window = new Window
            {
                Title = "Sala de Aula",
                Content = salaDeAulaWindow,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.CanResizeWithGrip,
                WindowStyle = WindowStyle.SingleBorderWindow
            };

            window.ShowDialog();

            //this.btnFechar.Content = string.Format("{0}: {1}","Fechar", turmaId);
            //popUpServer.IsOpen = true;
        }
    }
}

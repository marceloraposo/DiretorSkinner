using DiretorSkinner.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiretorSkinner.Inicio
{
    /// <summary>
    /// Interaction logic for Conceito.xaml
    /// </summary>
    public partial class Conceito : UserControl
    {
        private ObservableCollection<ConceitoDto> listaConceitos;
        public ObservableCollection<ConceitoDto> ListaConceitos
        {
            get { return listaConceitos; }
            set { listaConceitos = value; }
        }

        public Conceito()
        {
            InitializeComponent();

            this.CarregarDados();

            this.DataContext = this;
        }

        public void CarregarDados()
        {
            CarregarConceitos();
        }

        public void CarregarConceitos()
        {
            //colocar regras para visualizações
            this.ListaConceitos = new ObservableCollection<ConceitoDto>(App.Server.ListarConceitos());
        }

        private void dgConceito_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            ConceitoDto conceitoDto = e.Row.DataContext as ConceitoDto;


            SalvarConceito(conceitoDto);
        }

        private void dgConceito_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Conceito ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            ConceitoDto conceitoDto = row as ConceitoDto;
                            App.Server.DeletarConceito(conceitoDto);
                        }
                        MessageBox.Show("Conceito removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarConceito(ConceitoDto conceitoDto)
        {
            if (conceitoDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", conceitoDto.Nome), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarConceito(conceitoDto);
                    MessageBox.Show(string.Format("{0} alterado.", conceitoDto.Nome), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }
    }
}

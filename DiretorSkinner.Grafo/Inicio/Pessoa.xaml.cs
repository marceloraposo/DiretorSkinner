using DiretorSkinner.Grafo.Tranporte;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;
using System.Windows.Data;
using System.ComponentModel;

namespace DiretorSkinner.Grafo.Inicio
{
    /// <summary>
    /// Interaction logic for Pessoa.xaml
    /// </summary>
    public partial class Pessoa : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<PessoaDto> listaPessoas;
        public ObservableCollection<PessoaDto> ListaPessoas
        {
            get { return listaPessoas; }
            set { listaPessoas = value; OnPropertyChanged("ListaPessoas");  }
        }

        private ObservableCollection<TipoPessoaDto> listaTipoPessoa;
        public ObservableCollection<TipoPessoaDto> ListaTipoPessoa
        {
            get { return listaTipoPessoa; }
            set { listaTipoPessoa = value; }
        }

        private string pesquisa;
        public string Pesquisa
        {
            get { return pesquisa; }
            set { pesquisa = value; }
        }

        public Pessoa()
        {
            InitializeComponent();

            
            this.DataContext = this;
            this.CarregarDados();
        }

        public void CarregarDados()
        {
            CarregarPessoas(Pesquisa);
            CarregarTiposPessoa();
        }

        public void CarregarPessoas(string filtro)
        {
            //colocar regras para visualizações
            //this.ListaPessoas = new ObservableCollection<PessoaDto>(App.Server.ListarPessoas());
            if (!string.IsNullOrEmpty(filtro))
            {
                this.ListaPessoas = new ObservableCollection<PessoaDto>(App.Server.ListarPessoasPesquisa(filtro));
            }else
            {
                this.ListaPessoas = new ObservableCollection<PessoaDto>();
            }
        }

        public void CarregarTiposPessoa()
        {
            this.ListaTipoPessoa = new ObservableCollection<TipoPessoaDto>(App.Server.ListarTiposPessoa());
        }

        private void dgPessoa_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            PessoaDto pessoaDto = e.Row.DataContext as PessoaDto;

            SalvarPessoa(pessoaDto);
        }

        private void dgPessoa_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (Microsoft.Windows.Controls.DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show(string.Format("Confirma remover Pessoa ?"), "Remover", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            PessoaDto pessoaDto = row as PessoaDto;
                            App.Server.DeletarPessoa(pessoaDto);
                        }
                        MessageBox.Show("Pessoa removida.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        this.CarregarDados();
                }
            }
        }

        private void SalvarPessoa(PessoaDto pessoaDto)
        {
            if (pessoaDto != null)
            {
                var confirmaInserir = MessageBox.Show(string.Format("Confirma salvar {0} ?", pessoaDto.Nome), "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmaInserir == MessageBoxResult.Yes)
                {
                    App.Server.SalvarPessoa(pessoaDto);
                    MessageBox.Show(string.Format("{0} alterado.", pessoaDto.Nome), "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.CarregarDados();
                }
                else
                    this.CarregarDados();
            }
        }

        private void dgPessoa_InitializingNewItem(object sender, Microsoft.Windows.Controls.InitializingNewItemEventArgs e)
        {
            PessoaDto pessoaDto = (PessoaDto)e.NewItem;
            pessoaDto.TipoPessoas = this.ListaTipoPessoa.ToList();
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
             this.CarregarPessoas(Pesquisa);
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

    public class TipoPessoaBoolMultiCoverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PessoaDto pessoaDto = ((PessoaDto)((System.Windows.FrameworkElement)values[2]).DataContext);
            TipoPessoaDto tipoPessoaDto = ((TipoPessoaDto)values[1]);
            if (values.Length > 0)
            {
                if (pessoaDto.TipoPessoas.Any(x => x.Id == tipoPessoaDto.Id && x.Selecionado == true))
                {
                    pessoaDto.TipoPessoas.FirstOrDefault(x => x.Id == tipoPessoaDto.Id).Selecionado = true;
                    return pessoaDto.TipoPessoas.Any(x => x.Id == tipoPessoaDto.Id && x.Selecionado == true);
                }else
                {
                    return false;
                }
            }
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[] { value, Binding.DoNothing, Binding.DoNothing };
        }

        #endregion
    }
}

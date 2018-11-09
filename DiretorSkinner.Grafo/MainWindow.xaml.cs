using DiretorSkinner.Grafo.Carga;
using DiretorSkinner.Grafo.Inicio;
using DiretorSkinner.Grafo.Relatorio;
using DiretorSkinner.Grafo.Tranporte;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DiretorSkinner.Grafo
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.CarregarUsuario();

            this.CarregarMenu();
        }

        private void CarregarMenu()
        {
            PessoaDto pessoa;

            if (Application.Current.Properties.Contains("pessoa"))
            {
                pessoa = ((PessoaDto)Application.Current.Properties["pessoa"]);
            }
        }

        private void CarregarUsuario()
        {
            PessoaDto pessoa;

            if (Application.Current.Properties.Contains("pessoa"))
            {
                pessoa = ((PessoaDto)Application.Current.Properties["pessoa"]);
                this.txtPessoa.Text = string.Format("{0}({1})", pessoa.Nome, pessoa.Codigo);
            }
            else
            {
                this.txtPessoa.Text = null;
                Application.Current.Shutdown();
            }
        }

        private void MenuItemConceito_Click(object sender, RoutedEventArgs e)
        {
            var conceitoUserControl = new Conceito();
            conceitoUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(conceitoUserControl);

            textBlockTitulo.Text = "Conceito";
        }

        private void MenuItemTurma_Click(object sender, RoutedEventArgs e)
        {
            var turmaUserControl = new Turma();
            turmaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(turmaUserControl);

            textBlockTitulo.Text = "Turma";
        }

        private void MenuItemDisciplina_Click(object sender, RoutedEventArgs e)
        {
            var disciplinaUserControl = new Disciplina();
            disciplinaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(disciplinaUserControl);

            textBlockTitulo.Text = "Disciplina";
        }

        private void MenuItemPessoa_Click(object sender, RoutedEventArgs e)
        {
            var pessoaUserControl = new Pessoa();
            pessoaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(pessoaUserControl);

            textBlockTitulo.Text = "Pessoa";
        }

        private void MenuItemTipoPessoa_Click(object sender, RoutedEventArgs e)
        {
            var tipoPessoaUserControl = new TipoPessoa();
            tipoPessoaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(tipoPessoaUserControl);

            textBlockTitulo.Text = "Tipo Pessoa";
        }

        private void MenuItemTipoDisciplina_Click(object sender, RoutedEventArgs e)
        {
            var tipoDisciplinaoUserControl = new TipoDisciplina();
            tipoDisciplinaoUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(tipoDisciplinaoUserControl);

            textBlockTitulo.Text = "Tipo Disciplina";
        }

        private void MenuItemSobre_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder st = new StringBuilder();
            foreach (CustomAttributeData atributedata in this.GetType().Assembly.CustomAttributes)
            {
                foreach (CustomAttributeTypedArgument argumentset in atributedata.ConstructorArguments)
                {
                    if (argumentset.Value != null)
                        st.AppendLine(string.Format("{0}", argumentset.Value));
                }
            }

            MessageBox.Show(st.ToString(), "Sobre");
        }

        private void MenuItemSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuRelatPessoaPorConceito_Click(object sender, RoutedEventArgs e)
        {
            var pessoaPorConceitoUserControl = new PessoaPorConceito();
            pessoaPorConceitoUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(pessoaPorConceitoUserControl);

            textBlockTitulo.Text = "Pessoa por Conceito";
        }

        private void MenuRelatRepetenciaDeDisciplinaPorTipoPessoa_Click(object sender, RoutedEventArgs e)
        {
            var relatRepetenciaDeDisciplinaPorTipoPessoaUserControl = new RepetenciaDeDisciplinaPorTipoPessoa();
            relatRepetenciaDeDisciplinaPorTipoPessoaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(relatRepetenciaDeDisciplinaPorTipoPessoaUserControl);

            textBlockTitulo.Text = "Repetência de Disciplina por Tipo de Pessoa";
        }

        private void MenuRelatQtdePessoaPorDisciplina_Click(object sender, RoutedEventArgs e)
        {
            var relatQtdePessoaPorDisciplinaUserControl = new QtdePessoaPorDisciplina();
            relatQtdePessoaPorDisciplinaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(relatQtdePessoaPorDisciplinaUserControl);

            textBlockTitulo.Text = "Qtde de Pessoa por Disciplina";
        }

        private void menuItemCargaConceito_Click(object sender, RoutedEventArgs e)
        {
            var conceitoUserControl = new CargaConceito();
            conceitoUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(conceitoUserControl);

            textBlockTitulo.Text = "Carga de Conceito";
        }

        private void menuItemCargaDisciplina_Click(object sender, RoutedEventArgs e)
        {
            var disciplinaUserControl = new CargaDisciplina();
            disciplinaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(disciplinaUserControl);

            textBlockTitulo.Text = "Carga de Disciplina";
        }

        private void menuItemCargaSalaDeAula_Click(object sender, RoutedEventArgs e)
        {
            var salaDeAulaUserControl = new CargaSalaDeAula();
            salaDeAulaUserControl.SetValue(DockPanel.DockProperty, Dock.Top);
            dockPanelCentral.Children.Clear();
            dockPanelCentral.Children.Add(salaDeAulaUserControl);

            textBlockTitulo.Text = "Carga de Sala De Aula";
        }

    }
}

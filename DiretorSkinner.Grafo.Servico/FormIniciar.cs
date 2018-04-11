using System;
using System.Windows.Forms;

namespace DiretorSkinner.Grafo.Servico
{
    public partial class FormIniciar : Form
    {
        private DiretorSkinnerGrafoHost servico;
        public FormIniciar()
        {
            InitializeComponent();
            servico = new DiretorSkinnerGrafoHost();
            bntIniciar.Enabled = true;
            btnParar.Enabled = false;
        }

        private void bntIniciar_Click(object sender, EventArgs e)
        {
            servico.StartServer();
            bntIniciar.Enabled = false;
            btnParar.Enabled = true;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            servico.StopServer();
            bntIniciar.Enabled = true;
            btnParar.Enabled = false;
        }
    }
}

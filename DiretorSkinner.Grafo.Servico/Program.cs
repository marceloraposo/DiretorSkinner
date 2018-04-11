using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace DiretorSkinner.Grafo.Servico
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormIniciar());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new DiretorSkinnerGrafoHost()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

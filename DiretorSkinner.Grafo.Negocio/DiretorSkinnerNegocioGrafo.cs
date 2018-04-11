using DiretorSkinner.Grafo.Interface;
using System;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Negocio
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo, IDisposable
    {
        public DiretorSkinnerNegocioGrafo()
        {

        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

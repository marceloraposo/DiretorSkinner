using DiretorSkinner.Interface;
using System;
using System.ServiceModel;

namespace DiretorSkinner.Negocio
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, MaxItemsInObjectGraph = int.MaxValue)]
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio, IDisposable
    {
        public DiretorSkinnerNegocio()
        {

        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

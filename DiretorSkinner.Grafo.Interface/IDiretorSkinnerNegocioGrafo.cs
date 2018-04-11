using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
    }
}

using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public partial interface IDiretorSkinnerNegocio
    {
    }
}

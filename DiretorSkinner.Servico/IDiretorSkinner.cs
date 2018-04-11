using DiretorSkinner.Interface;
using System.ServiceModel;

namespace DiretorSkinner.Servico
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDiretorSkinner" in both code and config file together.
    [ServiceContract]
    public interface IDiretorSkinner : IDiretorSkinnerNegocio
    {
        [OperationContract]
        string GetData(int value);

    }
}

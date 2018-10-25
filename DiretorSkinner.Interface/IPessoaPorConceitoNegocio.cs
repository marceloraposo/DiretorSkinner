using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(PessoaPorConceitoDto))]
    public partial interface IDiretorSkinnerNegocio
    {
        [OperationContract]
        List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos();

        [OperationContract]
        List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id);
    }
}

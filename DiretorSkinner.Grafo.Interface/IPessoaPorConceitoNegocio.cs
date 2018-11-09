using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(PessoaPorConceitoDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos();

        [OperationContract]
        List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id);
    }
}

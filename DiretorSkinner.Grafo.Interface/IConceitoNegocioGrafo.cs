using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(ConceitoDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<ConceitoDto> ListarConceitos();

        [OperationContract]
        ConceitoDto ListarConceito(int id);

        [OperationContract]
        void SalvarConceito(ConceitoDto conceito);

        [OperationContract]
        void DeletarConceito(ConceitoDto conceito);
    }
}

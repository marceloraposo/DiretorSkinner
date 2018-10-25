using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(ProcessamentoDto))]
    public partial interface IDiretorSkinnerNegocio
    {

        [OperationContract]
        ProcessamentoDto CargaInserirConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarConceito(int tamanho);
    }
}

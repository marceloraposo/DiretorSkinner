using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(RootDto))]
    [ServiceKnownType(typeof(TurmaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<TurmaDto> ListarTurmas();

        [OperationContract]
        void SalvarTurma(TurmaDto turma);

        [OperationContract]
        void DeletarTurma(TurmaDto turma);
    }
}

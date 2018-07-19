using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(RootDto))]
    [ServiceKnownType(typeof(TurmaDto))]
    public partial interface IDiretorSkinnerNegocio
    {
        [OperationContract]
        List<TurmaDto> ListarTurmas();

        [OperationContract]
        void SalvarTurma(TurmaDto turma);

        [OperationContract]
        void DeletarTurma(TurmaDto turma);

    }
}

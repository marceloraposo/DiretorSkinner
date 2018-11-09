using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(QtdePessoaPorDisciplinaDto))]
    public partial interface IDiretorSkinnerNegocio
    {
        [OperationContract]
        List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorTodasDisciplinas();

        [OperationContract]
        List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorDisciplina(int id);
    }
}

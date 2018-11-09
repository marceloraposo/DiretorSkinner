using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(QtdePessoaPorDisciplinaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorTodasDisciplinas();

        [OperationContract]
        List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorDisciplina(int id);
    }
}

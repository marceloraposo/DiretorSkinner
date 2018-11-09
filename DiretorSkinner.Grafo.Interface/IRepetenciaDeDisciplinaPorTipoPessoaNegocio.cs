using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(RepetenciaDeDisciplinaPorTipoPessoaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTodosTipos();

        [OperationContract]
        List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTipo(int id);
    }
}

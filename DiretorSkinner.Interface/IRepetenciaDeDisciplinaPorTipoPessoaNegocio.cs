using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(RepetenciaDeDisciplinaPorTipoPessoaDto))]
    public partial interface IDiretorSkinnerNegocio
    {
        [OperationContract]
        List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTodosTipos();

        [OperationContract]
        List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTipo(int id);
    }
}

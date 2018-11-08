using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(TipoDisciplinaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<TipoDisciplinaDto> ListarTiposDisciplina();

        [OperationContract]
        TipoDisciplinaDto ListarTipoDisciplina(int id);

        [OperationContract]
        void SalvarTipoDisciplina(TipoDisciplinaDto tipoDisciplina);

        [OperationContract]
        void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplina);
    }
}

using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(TipoDisciplinaDto))]
    public partial interface IDiretorSkinnerNegocio
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

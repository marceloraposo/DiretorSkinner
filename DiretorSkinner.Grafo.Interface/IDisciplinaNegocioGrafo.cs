using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(DisciplinaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<DisciplinaDto> ListarDisciplinas();

        [OperationContract]
        List<DisciplinaDto> ListarDisciplinaPorTipo(TipoDisciplinaDto tipoDisciplina);

        [OperationContract]
        DisciplinaDto ListarDisciplina(int id);

        [OperationContract]
        void SalvarDisciplina(DisciplinaDto disciplina);

        [OperationContract]
        void DeletarDisciplina(DisciplinaDto disciplina);
    }
}

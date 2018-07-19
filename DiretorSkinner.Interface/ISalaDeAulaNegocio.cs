using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(RootDto))]
    [ServiceKnownType(typeof(SalaDeAulaDto))]
    public partial interface IDiretorSkinnerNegocio
    {
        [OperationContract]
        List<SalaDeAulaDto> ListarSalasDeAula();

        [OperationContract]
        List<SalaDeAulaDto> ListarSalaDeAulaPorPessoa(PessoaDto pessoa);

        [OperationContract]
        List<SalaDeAulaDto> ListarSalaDeAulaPorDisciplina(DisciplinaDto disciplina);

        [OperationContract]
        List<SalaDeAulaDto> ListarSalaDeAulaPorConceito(ConceitoDto conceito);

        [OperationContract]
        List<SalaDeAulaDto> ListarSalaDeAulaPorTurma(TurmaDto turma);

        [OperationContract]
        List<SalaDeAulaDto> ListarSalaDeAula(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa, TurmaDto turma);

        [OperationContract]
        void SalvarSalaDeAula(SalaDeAulaDto SalaDeAula);

        [OperationContract]
        void DeletarSalaDeAula(SalaDeAulaDto SalaDeAula);

    }
}

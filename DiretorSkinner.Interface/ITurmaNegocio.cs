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
        List<TurmaDto> ListarTurmaPorPessoa(PessoaDto pessoa);

        [OperationContract]
        List<TurmaDto> ListarTurmaPorDisciplina(DisciplinaDto disciplina);

        [OperationContract]
        List<TurmaDto> ListarTurmaPorConceito(ConceitoDto conceito);

        [OperationContract]
        List<TurmaDto> ListarTurma(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa);

        [OperationContract]
        void SalvarTurma(TurmaDto turma);

        [OperationContract]
        void DeletarTurma(TurmaDto turma);

    }
}

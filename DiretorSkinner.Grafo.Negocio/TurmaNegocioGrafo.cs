using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Tranporte;
using System.Collections.Generic;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<TurmaDto> ListarTurmas()
        {
            List<TurmaDto> list = new List<TurmaDto>();

            return list;
        }

        public List<TurmaDto> ListarTurmaPorDisciplina(DisciplinaDto disciplinaDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();

            return list;
        }

        public List<TurmaDto> ListarTurmaPorConceito(ConceitoDto conceitoDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();

            return list;
        }

        public List<TurmaDto> ListarTurmaPorPessoa(PessoaDto pessoaDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();

            return list;
        }

        public List<TurmaDto> ListarTurma(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa)
        {
            List<TurmaDto> list = new List<TurmaDto>();


            return list;
        }

        public void SalvarTurma(TurmaDto turma)
        {

        }

        public void DeletarTurma(TurmaDto turma)
        {
        }
    }
}

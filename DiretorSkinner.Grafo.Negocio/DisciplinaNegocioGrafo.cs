using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;


namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<DisciplinaDto> ListarDisciplinas()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<DisciplinaDto> list = graphClient.Cypher.Match($"(e:{typeof(DisciplinaDto).Name})")
                                     .Return(e => e.As<DisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<DisciplinaDto> ListarDisciplinaPorTipo(TipoDisciplinaDto tipoDisciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<DisciplinaDto> list = graphClient.Cypher.Match($"(e:{typeof(DisciplinaDto).Name})")
                                     .Where<DisciplinaDto>(e => e.TipoDisciplinaId == tipoDisciplinaDto.Id)
                                     .Return(e => e.As<DisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public DisciplinaDto ListarDisciplina(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            DisciplinaDto disciplina = graphClient.Cypher.Match($"(e:{typeof(DisciplinaDto).Name})")
                                     .Where<DisciplinaDto>(e => e.Id == id)
                                     .Return(e => e.As<DisciplinaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return disciplina;
        }

        public void SalvarDisciplina(DisciplinaDto disciplina)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (disciplina.Id > 0)
            {

                graphClient.Cypher.Match($"(e:{typeof(DisciplinaDto).Name})")
                                         .Where<DisciplinaDto>(e => e.Id == disciplina.Id)
                                         .Set("e = {model}")
                                         .WithParam("model", disciplina)
                                         .Return(e => e.As<DisciplinaDto>())
                                         .Results
                                         .Single();
            }
            else
            {
                graphClient.Cypher.Create($"(e:{typeof(DisciplinaDto).Name} {{model}})")
                                         .WithParam("model", disciplina)
                                         .Return(e => e.As<DisciplinaDto>())
                                         .Results
                                         .Single();
            }

            graphClient.Dispose();
        }

        public void DeletarDisciplina(DisciplinaDto disciplina)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(e:{typeof(DisciplinaDto).Name})")
                              .Where<DisciplinaDto>(e => e.Id == disciplina.Id)
                              .DetachDelete("e")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}

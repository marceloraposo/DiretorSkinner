using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<TurmaDto> ListarTurmas()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<TurmaDto> list = graphClient.Cypher.Match($"(turma:Turma)")
                                     .Return(turma => turma.As<TurmaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public void SalvarTurma(TurmaDto turmaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (turmaDto.Id > 0)
            {

                graphClient.Cypher.Match("(turma:Turma)")
                                         .Where<TurmaDto>(turma => turma.Id == turmaDto.Id)
                                         .Set("turma.DataIngresso = {DataIngresso}")
                                         .Set("turma.Codigo = {Codigo}")
                                         .WithParam("DataIngresso", turmaDto.DataIngresso)
                                         .WithParam("Codigo", turmaDto.Codigo)
                                         .ExecuteWithoutResults();
            }
            else
            {
                turmaDto.Id = graphClient.Cypher.Match($"(turma:Turma)")
                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(turma.Id)"))
                         .Results
                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(turma :Turma  { DataIngresso: {DataIngresso}, Codigo: {Codigo} , Id: {Id} })")
                                         .WithParam("DataIngresso", turmaDto.DataIngresso)
                                         .WithParam("Codigo", turmaDto.Codigo)
                                         .WithParam("Id", turmaDto.Id)
                                         .ExecuteWithoutResults();
            }

            //DeletarTurmaTipoTurma(turmaDto);
            //SalvarTurmaTipoTurma(turmaDto);

            graphClient.Dispose();
        }

        public void DeletarTurma(TurmaDto turmaDto)
        {
            //DeletarDisciplinaTipoDisciplina(disciplinaDto);

            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(turma :Turma)")
                              .Where<DisciplinaDto>(turma => turma.Id == turmaDto.Id)
                              .DetachDelete("turma")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}

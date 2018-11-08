using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
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
            List<DisciplinaDto> list = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                                     .Return(disciplina => disciplina.As<DisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<DisciplinaDto> ListarDisciplinaPorTipo(TipoDisciplinaDto tipoDisciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<DisciplinaDto> list = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                                     .Where<DisciplinaDto>(disciplina => disciplina.TipoDisciplinaId == tipoDisciplinaDto.Id)
                                     .Return(disciplina => disciplina.As<DisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public DisciplinaDto ListarDisciplina(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            DisciplinaDto disciplinaDto = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                                     .Where<DisciplinaDto>(disciplina => disciplina.Id == id)
                                     .Return(disciplina => disciplina.As<DisciplinaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return disciplinaDto;
        }

        public void SalvarDisciplina(DisciplinaDto disciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (disciplinaDto.Id > 0)
            {

                graphClient.Cypher.Match("(disciplina:Disciplina)")
                                         .Where<DisciplinaDto>(disciplina => disciplina.Id == disciplinaDto.Id)
                                         .Set("disciplina.Nome = {Nome}")
                                         .Set("disciplina.Codigo = {Codigo}")
                                         .Set("disciplina.TipoDisciplinaId = {TipoDisciplinaId}")
                                         .WithParam("Nome", disciplinaDto.Nome)
                                         .WithParam("Codigo", disciplinaDto.Codigo)
                                         .WithParam("TipoDisciplinaId", disciplinaDto.TipoDisciplinaId)
                                         .ExecuteWithoutResults();
            }
            else
            {
                disciplinaDto.Id = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(disciplina.Id)"))
                         .Results
                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(disciplina :Disciplina  { Nome: {Nome}, Codigo: {Codigo} ,TipoDisciplinaId: {TipoDisciplinaId}, Id: {Id} })")
                                         .WithParam("Nome", disciplinaDto.Nome)
                                         .WithParam("Codigo", disciplinaDto.Codigo)
                                         .WithParam("TipoDisciplinaId", disciplinaDto.TipoDisciplinaId)
                                         .WithParam("Id", disciplinaDto.Id)
                                         .ExecuteWithoutResults();
            }

            DeletarDisciplinaTipoDisciplina(disciplinaDto);
            SalvarDisciplinaTipoDisciplina(disciplinaDto);

            graphClient.Dispose();
        }

        public void SalvarDisciplinaTipoDisciplina(DisciplinaDto disciplinaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(disciplina:Disciplina)", "(tipoDisciplina:TipoDisciplina)")
                                    .Where<DisciplinaDto>(disciplina => disciplina.Id == disciplinaDto.Id)
                                    .AndWhere<TipoDisciplinaDto>(tipoDisciplina => tipoDisciplina.Id == disciplinaDto.TipoDisciplinaId)
                                    .Create("(disciplina)-[DisciplinaPertenceTipoDisciplina:DISCIPLINA_PERTENCE_TIPO_DISCIPLINA]->(tipoDisciplina)")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarDisciplina(DisciplinaDto disciplinaDto)
        {
            DeletarDisciplinaTipoDisciplina(disciplinaDto);

            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(disciplina:Disciplina)")
                              .Where<DisciplinaDto>(disciplina => disciplina.Id == disciplinaDto.Id)
                              .DetachDelete("disciplina")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarDisciplinaTipoDisciplina(DisciplinaDto disciplinaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(disciplina)-[DisciplinaPertenceTipoDisciplina:DISCIPLINA_PERTENCE_TIPO_DISCIPLINA]->(tipoDisciplina)")
                                    .Where<DisciplinaDto>(disciplina => disciplina.Id == disciplinaDto.Id)
                                    .Delete("DisciplinaPertenceTipoDisciplina")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}

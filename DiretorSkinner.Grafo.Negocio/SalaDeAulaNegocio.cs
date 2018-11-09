using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<SalaDeAulaDto> ListarSalasDeAula()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<SalaDeAulaDto> list = graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                     .Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public SalaDeAulaDto ListarSalaDeAula(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            SalaDeAulaDto salaDeAulaDto = graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                     .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == id)
                                     .Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return salaDeAulaDto;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorTurma(TurmaDto turmaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            List<SalaDeAulaDto> list = graphClient.Cypher.Match("(salaDeAula:SalaDeAula),(pessoa:Pessoa)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId ")
                                     .With(" salaDeAula,{ PessoaId: pessoa.Id, PessoaNome: pessoa.Nome} as Pessoas")
                                     .With(" { Id: salaDeAula.Id, Semestre: salaDeAula.Semestre, DisciplinaId: salaDeAula.DisciplinaId,Nota: salaDeAula.Nota,TurmaId: salaDeAula.TurmaId, PessoaId: Pessoas.PessoaId, PessoaNome: Pessoas.PessoaNome} as salaDeAula")
                                     .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.TurmaId == turmaDto.Id)     
                                     .Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorDisciplina(DisciplinaDto disciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            List<SalaDeAulaDto> list = graphClient.Cypher.Match("(salaDeAula:SalaDeAula),(pessoa:Pessoa)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId ")
                                     .With(" salaDeAula,{ PessoaId: pessoa.Id, PessoaNome: pessoa.Nome} as Pessoas")
                                     .With(" { Id: salaDeAula.Id, Semestre: salaDeAula.Semestre, DisciplinaId: salaDeAula.DisciplinaId,Nota: salaDeAula.Nota,TurmaId: salaDeAula.TurmaId, PessoaId: Pessoas.PessoaId, PessoaNome: Pessoas.PessoaNome} as salaDeAula")
                                      .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.DisciplinaId == disciplinaDto.Id).Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();
            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorConceito(ConceitoDto conceitoDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            List<SalaDeAulaDto> list = graphClient.Cypher.Match("(salaDeAula:SalaDeAula),(pessoa:Pessoa)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId ")
                                     .With(" salaDeAula,{ PessoaId: pessoa.Id, PessoaNome: pessoa.Nome} as Pessoas")
                                     .With(" { Id: salaDeAula.Id, Semestre: salaDeAula.Semestre, DisciplinaId: salaDeAula.DisciplinaId,Nota: salaDeAula.Nota,TurmaId: salaDeAula.TurmaId, PessoaId: Pessoas.PessoaId, PessoaNome: Pessoas.PessoaNome} as salaDeAula")
                                      .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.DisciplinaId == conceitoDto.Id).Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();
            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorPessoa(PessoaDto pessoaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            List<SalaDeAulaDto> list = graphClient.Cypher.Match("(salaDeAula:SalaDeAula),(pessoa:Pessoa)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId ")
                                     .With(" salaDeAula,{ PessoaId: pessoa.Id, PessoaNome: pessoa.Nome} as Pessoas")
                                     .With(" { Id: salaDeAula.Id, Semestre: salaDeAula.Semestre, DisciplinaId: salaDeAula.DisciplinaId,Nota: salaDeAula.Nota,TurmaId: salaDeAula.TurmaId, PessoaId: Pessoas.PessoaId, PessoaNome: Pessoas.PessoaNome} as salaDeAula")
                                      .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.PessoaId == pessoaDto.Id).Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();
            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorFiltros(ConceitoDto conceitoDto, DisciplinaDto disciplinaDto, PessoaDto pessoaDto, TurmaDto turmaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            Nullable<int> valorNulo = null;

            List<SalaDeAulaDto> list = graphClient.Cypher.Match("(salaDeAula:SalaDeAula), (pessoa:Pessoa) , (conceito:Conceito)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo")
                                     .With(" salaDeAula,{ PessoaId: pessoa.Id, PessoaNome: pessoa.Nome} as Pessoas, conceito")
                                     .With(" conceito,{ Id: salaDeAula.Id, Semestre: salaDeAula.Semestre, DisciplinaId: salaDeAula.DisciplinaId,Nota: salaDeAula.Nota,TurmaId: salaDeAula.TurmaId, PessoaId: Pessoas.PessoaId, PessoaNome: Pessoas.PessoaNome} as salaDeAula")
                                     .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.TurmaId == turmaDto.Id)

                                     .AndWhere(" salaDeAula.DisciplinaId = coalesce({disciplinaId},salaDeAula.DisciplinaId)  ")
                                     .WithParam("disciplinaId", disciplinaDto == null ? valorNulo : disciplinaDto.Id)

                                     .AndWhere(" salaDeAula.PessoaId = coalesce({pessoaId},salaDeAula.PessoaId)  ")
                                     .WithParam("pessoaId", pessoaDto == null ? valorNulo : pessoaDto.Id)

                                     .AndWhere(" conceito.Id = coalesce({conceitoId},conceito.Id)  ")
                                     .WithParam("conceitoId", conceitoDto == null ? valorNulo : conceitoDto.Id)

                                     .Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();
            return list;
        }

        public void SalvarSalaDeAula(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            if (salaDeAulaDto.Id > 0)
            {

                graphClient.Cypher.Match("(salaDeAula:SalaDeAula)")
                                         .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                         .Set("salaDeAula.Nota = {Nota}")
                                         .Set("salaDeAula.PessoaId = {PessoaId}")
                                         .Set("salaDeAula.Semestre = {Semestre}")
                                         .Set("salaDeAula.TurmaId = {TurmaId}")
                                         .Set("salaDeAula.DisciplinaId = {DisciplinaId}")
                                         .WithParam("Nota", salaDeAulaDto.Nota)
                                         .WithParam("PessoaId", salaDeAulaDto.PessoaId)
                                         .WithParam("Semestre", salaDeAulaDto.Semestre)
                                         .WithParam("TurmaId", salaDeAulaDto.TurmaId)
                                         .WithParam("DisciplinaId", salaDeAulaDto.DisciplinaId)
                                         .ExecuteWithoutResults();
            }
            else
            {

                salaDeAulaDto.Id = graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(salaDeAula.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(salaDeAula:SalaDeAula{ Id: {Id}, PessoaId: {PessoaId}, Semestre: {Semestre} , TurmaId: {TurmaId}, DisciplinaId: {DisciplinaId},Nota: {Nota} } )")
                                         .WithParam("PessoaId", salaDeAulaDto.PessoaId)
                                         .WithParam("Semestre", salaDeAulaDto.Semestre)
                                         .WithParam("TurmaId", salaDeAulaDto.TurmaId)
                                         .WithParam("DisciplinaId", salaDeAulaDto.DisciplinaId)
                                         .WithParam("Nota", salaDeAulaDto.Nota)
                                         .WithParam("Id", salaDeAulaDto.Id)
                                         .ExecuteWithoutResults();
            }

            DeletarSalaDeAulaDisciplina(salaDeAulaDto);
            DeletarSalaDeAulaPessoa(salaDeAulaDto);
            DeletarSalaDeAulaTurma(salaDeAulaDto);

            SalvarSalaDeAulaDisciplina(salaDeAulaDto);
            SalvarSalaDeAulaPessoa(salaDeAulaDto);
            SalvarSalaDeAulaTurma(salaDeAulaDto);

            graphClient.Dispose();
        }

        public void DeletarSalaDeAula(SalaDeAulaDto salaDeAulaDto)
        {
            DeletarSalaDeAulaDisciplina(salaDeAulaDto);
            DeletarSalaDeAulaPessoa(salaDeAulaDto);
            DeletarSalaDeAulaTurma(salaDeAulaDto);

            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                              .Where<PessoaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                              .DetachDelete("salaDeAula")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void SalvarSalaDeAulaDisciplina(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(disciplina:Disciplina)", "(salaDeAula:SalaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .AndWhere<DisciplinaDto>(disciplina => disciplina.Id == salaDeAulaDto.DisciplinaId)
                                    .Create("(disciplina)-[tem:TEM]->(salaDeAula)")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarSalaDeAulaDisciplina(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(disciplina)-[tem:TEM]->(salaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .Delete("tem")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void SalvarSalaDeAulaPessoa(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(pessoa:Pessoa)", "(salaDeAula:SalaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .AndWhere<PessoaDto>(pessoa => pessoa.Id == salaDeAulaDto.PessoaId)
                                    .Create("(pessoa)-[esta:ESTA]->(salaDeAula)")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarSalaDeAulaPessoa(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(pessoa)-[esta:ESTA]->(salaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .Delete("esta")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void SalvarSalaDeAulaTurma(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(turma:Turma)", "(salaDeAula:SalaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .AndWhere<TurmaDto>(turma => turma.Id == salaDeAulaDto.TurmaId)
                                    .Create("(turma)-[esta:ESTA]->(salaDeAula)")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarSalaDeAulaTurma(SalaDeAulaDto salaDeAulaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match("(turma)-[esta:ESTA]->(salaDeAula)")
                                    .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == salaDeAulaDto.Id)
                                    .Delete("esta")
                                    .ExecuteWithoutResults();

            graphClient.Dispose();
        }

    }
}

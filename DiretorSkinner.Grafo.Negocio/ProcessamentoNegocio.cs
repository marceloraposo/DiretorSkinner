using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        #region Conceito

        public ProcessamentoDto CargaInserirConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            ConceitoDto conceitoDto = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            for (int i= 0;i < tamanho;i++)
            {
                conceitoDto = new ConceitoDto();
                conceitoDto.Nome = string.Format("Conceito {0}",i);
                conceitoDto.Codigo = string.Format("{0:000}", i);
                conceitoDto.Aprovado = true;
                conceitoDto.Minimo = 0;
                conceitoDto.Maximo = 0;
                list.Add(conceitoDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                item.Id = graphClient.Cypher.Match($"(conceito:Conceito)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(conceito.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Create("(conceito:Conceito{ Nome: {Nome}, Codigo: {Codigo} , Aprovado: {Aprovado},Minimo: {Minimo},Maximo: {Maximo}, Id: {Id} } )")
                                         .WithParam("Nome", item.Nome)
                                         .WithParam("Codigo", item.Codigo)
                                         .WithParam("Aprovado", item.Aprovado)
                                         .WithParam("Minimo", item.Minimo)
                                         .WithParam("Maximo", item.Maximo)
                                         .WithParam("Id", item.Id)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            ConceitoDto conceitoDto = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            foreach(var item in ListarConceitos().Take(tamanho)) 
            {
                conceitoDto = new ConceitoDto();
                conceitoDto.Id = item.Id;
                conceitoDto.Nome = item.Nome; //string.Format("Conceito {0}", i * 3);
                conceitoDto.Codigo = item.Codigo; //string.Format("{0:000}", i * 3);
                conceitoDto.Aprovado = item.Aprovado;
                conceitoDto.Minimo = item.Minimo;
                conceitoDto.Maximo = item.Maximo;
                list.Add(conceitoDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match("(conceito:Conceito)")
                                         .Where<ConceitoDto>(conceito => conceito.Id == item.Id)
                                         .Set("conceito.Nome = {Nome}")
                                         .Set("conceito.Codigo = {Codigo}")
                                         .Set("conceito.Aprovado = {Aprovado}")
                                         .Set("conceito.Minimo = {Minimo}")
                                         .Set("conceito.Maximo = {Maximo}")
                                         .WithParam("Nome", item.Nome)
                                         .WithParam("Codigo", item.Codigo)
                                         .WithParam("Aprovado", item.Aprovado)
                                         .WithParam("Minimo", item.Minimo)
                                         .WithParam("Maximo", item.Maximo)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            ConceitoDto conceitoDto = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            foreach (var item in ListarConceitos().Where(x => x.Id > 4).Take(tamanho))
            {
                conceitoDto = new ConceitoDto();
                conceitoDto.Id = item.Id;
                list.Add(conceitoDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match($"(conceito:Conceito)")
                                  .Where<PessoaDto>(conceito => conceito.Id == conceitoDto.Id)
                                  .DetachDelete("conceito")
                                  .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            var graphClient = ConexaoGrafo.Client;

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            List<ConceitoDto> lista = graphClient.Cypher.Match($"(conceito:Conceito)")
                                     .Return(conceito => conceito.As<ConceitoDto>())
                                     .Limit(tamanho)
                                     .Results
                                     .ToList();

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            graphClient.Dispose();

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion

        #region Disciplina

        public ProcessamentoDto CargaInserirDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            DisciplinaDto disciplinaDto = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            for (int i = 0; i < tamanho; i++)
            {
                disciplinaDto = new DisciplinaDto();
                disciplinaDto.Nome = string.Format("Disciplina {0}", i);
                disciplinaDto.Codigo = string.Format("{0:000}", i);
                disciplinaDto.TipoDisciplinaId = 1;
                list.Add(disciplinaDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                item.Id = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(disciplina.Id)"))
                         .Results
                         .SingleOrDefault() + 1;


                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Create("(disciplina :Disciplina  { Nome: {Nome}, Codigo: {Codigo} ,TipoDisciplinaId: {TipoDisciplinaId}, Id: {Id} })")
                                         .WithParam("Nome", item.Nome)
                                         .WithParam("Codigo", item.Codigo)
                                         .WithParam("TipoDisciplinaId", item.TipoDisciplinaId)
                                         .WithParam("Id", item.Id)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                DeletarDisciplinaTipoDisciplina(item);
                SalvarDisciplinaTipoDisciplina(item);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            DisciplinaDto disciplinaDto = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            foreach (var item in ListarDisciplinas().Take(tamanho))
            {
                disciplinaDto = new DisciplinaDto();
                disciplinaDto.Id = item.Id;
                disciplinaDto.Nome = item.Nome; //string.Format("Disciplina {0}", i * 3);
                disciplinaDto.Codigo = item.Codigo; //string.Format("{0:000}", i * 3);
                disciplinaDto.TipoDisciplinaId = item.TipoDisciplinaId;
                list.Add(disciplinaDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match("(disciplina:Disciplina)")
                                         .Where<DisciplinaDto>(disciplina => disciplina.Id == disciplinaDto.Id)
                                         .Set("disciplina.Nome = {Nome}")
                                         .Set("disciplina.Codigo = {Codigo}")
                                         .Set("disciplina.TipoDisciplinaId = {TipoDisciplinaId}")
                                         .WithParam("Nome", disciplinaDto.Nome)
                                         .WithParam("Codigo", disciplinaDto.Codigo)
                                         .WithParam("TipoDisciplinaId", disciplinaDto.TipoDisciplinaId)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                DeletarDisciplinaTipoDisciplina(item);
                SalvarDisciplinaTipoDisciplina(item);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            DisciplinaDto disciplinaDto = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            foreach (var item in ListarDisciplinas().Where(x => x.Id > 2).Take(tamanho))
            {
                disciplinaDto = new DisciplinaDto();
                disciplinaDto.Id = item.Id;
                list.Add(disciplinaDto);
            }

            foreach (var item in list)
            {
                DeletarDisciplinaTipoDisciplina(disciplinaDto);

                var graphClient = ConexaoGrafo.Client;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match($"(disciplina:Disciplina)")
                                  .Where<DisciplinaDto>(disciplina => disciplina.Id == item.Id)
                                  .DetachDelete("disciplina")
                                  .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            var graphClient = ConexaoGrafo.Client;

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            List<DisciplinaDto> lista = graphClient.Cypher.Match($"(disciplina:Disciplina)")
                                     .Return(disciplina => disciplina.As<DisciplinaDto>())
                                     .Limit(tamanho)
                                     .Results
                                     .ToList();

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            graphClient.Dispose();

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion

        #region SalaDeAula

        public ProcessamentoDto CargaInserirSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            SalaDeAulaDto salaDeAulaDto = null;
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            for (int i = 0; i < tamanho; i++)
            {
                salaDeAulaDto = new SalaDeAulaDto();
                salaDeAulaDto.TurmaId = 1;
                salaDeAulaDto.DisciplinaId = i % 2 == 0 ? 1 : 2;
                salaDeAulaDto.Nota = i % 2 == 0 ? 7 : 6;
                salaDeAulaDto.Semestre = "2018.2";
                salaDeAulaDto.PessoaId = i;
                list.Add(salaDeAulaDto);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;

                item.Id = graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(salaDeAula.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Create("(salaDeAula:SalaDeAula{ Id: {Id}, PessoaId: {PessoaId}, Semestre: {Semestre} , TurmaId: {TurmaId}, DisciplinaId: {DisciplinaId},Nota: {Nota} } )")
                                         .WithParam("PessoaId", item.PessoaId)
                                         .WithParam("Semestre", item.Semestre)
                                         .WithParam("TurmaId", item.TurmaId)
                                         .WithParam("DisciplinaId", item.DisciplinaId)
                                         .WithParam("Nota", item.Nota)
                                         .WithParam("Id", item.Id)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                DeletarSalaDeAulaDisciplina(item);
                DeletarSalaDeAulaPessoa(item);
                DeletarSalaDeAulaTurma(item);

                SalvarSalaDeAulaDisciplina(item);
                SalvarSalaDeAulaPessoa(item);
                SalvarSalaDeAulaTurma(item);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            SalaDeAulaDto SalaDeAula = null;
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            foreach (var item in ListarSalaDeAulaPorTurma(new TurmaDto() { Id = 1 }).Take(tamanho))
            {
                SalaDeAula = new SalaDeAulaDto();
                SalaDeAula.Id = item.Id;
                SalaDeAula.TurmaId = item.TurmaId;
                SalaDeAula.DisciplinaId = item.DisciplinaId;
                SalaDeAula.Nota = item.Nota;
                SalaDeAula.Semestre = item.Semestre;
                SalaDeAula.PessoaId = item.PessoaId;
                list.Add(SalaDeAula);
            }

            foreach (var item in list)
            {
                var graphClient = ConexaoGrafo.Client;


                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match("(salaDeAula:SalaDeAula)")
                                         .Where<SalaDeAulaDto>(salaDeAula => salaDeAula.Id == item.Id)
                                         .Set("salaDeAula.Nota = {Nota}")
                                         .Set("salaDeAula.PessoaId = {PessoaId}")
                                         .Set("salaDeAula.Semestre = {Semestre}")
                                         .Set("salaDeAula.TurmaId = {TurmaId}")
                                         .Set("salaDeAula.DisciplinaId = {DisciplinaId}")
                                         .WithParam("Nota", item.Nota)
                                         .WithParam("PessoaId", item.PessoaId)
                                         .WithParam("Semestre", item.Semestre)
                                         .WithParam("TurmaId", item.TurmaId)
                                         .WithParam("DisciplinaId", item.DisciplinaId)
                                         .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                DeletarSalaDeAulaDisciplina(item);
                DeletarSalaDeAulaPessoa(item);
                DeletarSalaDeAulaTurma(item);

                SalvarSalaDeAulaDisciplina(item);
                SalvarSalaDeAulaPessoa(item);
                SalvarSalaDeAulaTurma(item);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;

            SalaDeAulaDto SalaDeAula = null;
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            foreach (var item in ListarSalaDeAulaPorTurma(new TurmaDto() { Id = 1 }).Where(x => x.Id > 11).Take(tamanho))
            {
                SalaDeAula = new SalaDeAulaDto();
                SalaDeAula.Id = item.Id;
                list.Add(SalaDeAula);
            }

            foreach (var item in list)
            {
                DeletarSalaDeAulaDisciplina(item);
                DeletarSalaDeAulaPessoa(item);
                DeletarSalaDeAulaTurma(item);

                var graphClient = ConexaoGrafo.Client;

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                  .Where<PessoaDto>(salaDeAula => salaDeAula.Id == item.Id)
                                  .DetachDelete("salaDeAula")
                                  .ExecuteWithoutResults();

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

                graphClient.Dispose();
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            var graphClient = ConexaoGrafo.Client;

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            List<SalaDeAulaDto> lista = graphClient.Cypher.Match($"(salaDeAula:SalaDeAula)")
                                     .Return(salaDeAula => salaDeAula.As<SalaDeAulaDto>())
                                     .Limit(tamanho)
                                     .Results
                                     .ToList();

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            graphClient.Dispose();

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion
    }
}

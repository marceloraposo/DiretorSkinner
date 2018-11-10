using DiretorSkinner.Interface;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        #region Conceito

        public ProcessamentoDto CargaInserirConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            ConceitoDto conceito = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            for (int i= 0;i < tamanho;i++)
            {
                conceito = new ConceitoDto();
                conceito.Nome = string.Format("Conceito {0}",i);
                conceito.Codigo = string.Format("{0:000}", i);
                conceito.Aprovado = true;
                conceito.Minimo = 0;
                conceito.Maximo = 0;
                list.Add(conceito);
            }

            foreach (var item in list)
            {                
                comando = string.Format("insert into conceito (Nome,Codigo,Aprovado,Minimo,Maximo) values (@Nome,@Codigo,@Aprovado,@Minimo,@Maximo)");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Nome", item.Nome));
                pars.Add(new SqlParameter("Codigo", item.Codigo));
                pars.Add(new SqlParameter("Aprovado", item.Aprovado));
                pars.Add(new SqlParameter("Minimo", item.Minimo));
                pars.Add(new SqlParameter("Maximo", item.Maximo));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            ConceitoDto conceito = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            foreach(var item in ListarConceitos().Take(tamanho)) 
            {
                conceito = new ConceitoDto();
                conceito.Id = item.Id;
                conceito.Nome = item.Nome; //string.Format("Conceito {0}", i * 3);
                conceito.Codigo = item.Codigo; //string.Format("{0:000}", i * 3);
                conceito.Aprovado = item.Aprovado;
                conceito.Minimo = item.Minimo;
                conceito.Maximo = item.Maximo;
                list.Add(conceito);
            }

            foreach (var item in list)
            {
                comando = string.Format("update conceito set Nome = @Nome, Codigo = @Codigo, Aprovado = @Aprovado, Minimo = @Minimo, Maximo = @Maximo where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Nome", item.Nome));
                pars.Add(new SqlParameter("Codigo", item.Codigo));
                pars.Add(new SqlParameter("Aprovado", item.Aprovado));
                pars.Add(new SqlParameter("Minimo", item.Minimo));
                pars.Add(new SqlParameter("Maximo", item.Maximo));
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            ConceitoDto conceito = null;
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            foreach (var item in ListarConceitos().Where(x => x.Id > 4).Take(tamanho))
            {
                conceito = new ConceitoDto();
                conceito.Id = item.Id;
                list.Add(conceito);
            }

            foreach (var item in list)
            {
                comando = string.Format("delete from conceito where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) from Conceito");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaRelatorioConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) id,codigo,nome,media,(select cc.Id from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitoid,(select cc.Nome from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitonome FROM (SELECT p.id,p.codigo,p.nome,AVG(sda.nota) AS media FROM saladeaula sda,pessoa p,conceito c WHERE p.id = sda.pessoaid AND sda.nota >= c.minimo AND   sda.nota <= c.maximo GROUP BY p.nome, p.codigo, p.codigo,p.id ) x");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion

        #region Disciplina

        public ProcessamentoDto CargaInserirDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            DisciplinaDto Disciplina = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            for (int i = 0; i < tamanho; i++)
            {
                Disciplina = new DisciplinaDto();
                Disciplina.Nome = string.Format("Disciplina {0}", i);
                Disciplina.Codigo = string.Format("{0:000}", i);
                Disciplina.TipoDisciplinaId = 1;
                list.Add(Disciplina);
            }

            foreach (var item in list)
            {
                comando = string.Format("insert into Disciplina (Nome,Codigo,TipoDisciplinaId) values (@Nome,@Codigo,@TipoDisciplinaId)");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Nome", item.Nome));
                pars.Add(new SqlParameter("Codigo", item.Codigo));
                pars.Add(new SqlParameter("TipoDisciplinaId", item.TipoDisciplinaId));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            DisciplinaDto Disciplina = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            foreach (var item in ListarDisciplinas().Take(tamanho))
            {
                Disciplina = new DisciplinaDto();
                Disciplina.Id = item.Id;
                Disciplina.Nome = item.Nome; //string.Format("Disciplina {0}", i * 3);
                Disciplina.Codigo = item.Codigo; //string.Format("{0:000}", i * 3);
                Disciplina.TipoDisciplinaId = item.TipoDisciplinaId;
                list.Add(Disciplina);
            }

            foreach (var item in list)
            {
                comando = string.Format("update Disciplina set Nome = @Nome, Codigo = @Codigo, TipoDisciplinaId = @TipoDisciplinaId  where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Nome", item.Nome));
                pars.Add(new SqlParameter("Codigo", item.Codigo));
                pars.Add(new SqlParameter("TipoDisciplinaId", item.TipoDisciplinaId));
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            DisciplinaDto Disciplina = null;
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            foreach (var item in ListarDisciplinas().Where(x => x.Id > 71).Take(tamanho))
            {
                Disciplina = new DisciplinaDto();
                Disciplina.Id = item.Id;
                list.Add(Disciplina);
            }

            foreach (var item in list)
            {
                comando = string.Format("delete from Disciplina where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) from Disciplina");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaRelatorioDisciplina(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<DisciplinaDto> list = new List<DisciplinaDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) disciplina.Id as DisciplinaId , disciplina.Nome as DisciplinaNome, count(salaDeAula.pessoaId) as Quantidade from SalaDeAula salaDeAula , Disciplina disciplina where disciplina.Id = salaDeAula.disciplinaId group by disciplina.Id, disciplina.Nome");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion

        #region SalaDeAula

        public ProcessamentoDto CargaInserirSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            SalaDeAulaDto SalaDeAula = null;
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            for (int i = 0; i < tamanho; i++)
            {
                SalaDeAula = new SalaDeAulaDto();
                SalaDeAula.TurmaId = 1;
                SalaDeAula.DisciplinaId = i % 2 == 0 ? 1 : 2;
                SalaDeAula.Nota = i % 2 == 0 ? 7 : 6;
                SalaDeAula.Semestre = "2018.2";
                SalaDeAula.PessoaId = i;
                list.Add(SalaDeAula);
            }

            foreach (var item in list)
            {
                comando = string.Format("insert into SalaDeAula (TurmaId,DisciplinaId,Nota,Semestre,PessoaId) values (@TurmaId,@DisciplinaId,@Nota,@Semestre,@PessoaId)");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("TurmaId", item.TurmaId));
                pars.Add(new SqlParameter("DisciplinaId", item.DisciplinaId));
                pars.Add(new SqlParameter("Nota", item.Nota));
                pars.Add(new SqlParameter("Semestre", item.Semestre));
                pars.Add(new SqlParameter("PessoaId", item.PessoaId));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
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
                comando = string.Format("update SalaDeAula set Nota = @Nota, PessoaId = @PessoaId, DisciplinaId = @DisciplinaId, Semestre = @Semestre where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("TurmaId", item.TurmaId));
                pars.Add(new SqlParameter("DisciplinaId", item.DisciplinaId));
                pars.Add(new SqlParameter("Nota", item.Nota));
                pars.Add(new SqlParameter("Semestre", item.Semestre));
                pars.Add(new SqlParameter("PessoaId", item.PessoaId));
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
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
                comando = string.Format("delete from SalaDeAula where Id = @Id");
                pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("Id", item.Id));

                SqlCommand cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().PrivateMemorySize64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) from SalaDeAula");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaRelatorioSalaDeAula(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            Stopwatch st = new Stopwatch();
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().PrivateMemorySize64;
            st.Start();

            SqlCommand cmd = new SqlCommand("select top (@tamanho) pessoa.Id as PessoaId,pessoa.Nome as PessoaNome,tipoPessoa.Id as TipoPessoaId,tipoPessoa.Nome as TipoPessoaNome,disciplina.Nome as DisciplinaNome,conceito.Nome as conceitoNome,salaDeAula.Semestre as Semestre from SalaDeAula salaDeAula ,Disciplina disciplina ,Pessoa pessoa ,TipoPessoa tipoPessoa, PessoaTipoPessoa pessoaTipoPessoa ,Conceito conceito where disciplina.Id = salaDeAula.DisciplinaId   and pessoa.Id = salaDeAula.PessoaId  and pessoa.Id = pessoaTipoPessoa.pessoaId  and tipoPessoa.Id = pessoaTipoPessoa.tipoPessoaId  and salaDeAula.Nota > conceito.Minimo   and salaDeAula.Nota <= conceito.Maximo");
            pars.Add(new SqlParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().PrivateMemorySize64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }
        #endregion
    }
}

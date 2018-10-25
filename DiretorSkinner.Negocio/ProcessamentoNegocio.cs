using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
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
                pars.Add(new SQLiteParameter("Nome", item.Nome));
                pars.Add(new SQLiteParameter("Codigo", item.Codigo));
                pars.Add(new SQLiteParameter("Aprovado", item.Aprovado));
                pars.Add(new SQLiteParameter("Minimo", item.Minimo));
                pars.Add(new SQLiteParameter("Maximo", item.Maximo));

                SQLiteCommand cmd = new SQLiteCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().WorkingSet64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().WorkingSet64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaAlterarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
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
                pars.Add(new SQLiteParameter("Nome", item.Nome));
                pars.Add(new SQLiteParameter("Codigo", item.Codigo));
                pars.Add(new SQLiteParameter("Aprovado", item.Aprovado));
                pars.Add(new SQLiteParameter("Minimo", item.Minimo));
                pars.Add(new SQLiteParameter("Maximo", item.Maximo));
                pars.Add(new SQLiteParameter("Id", item.Id));

                SQLiteCommand cmd = new SQLiteCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().WorkingSet64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().WorkingSet64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaExcluirConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
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
                pars.Add(new SQLiteParameter("Id", item.Id));

                SQLiteCommand cmd = new SQLiteCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());

                cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
                memoria = Process.GetCurrentProcess().WorkingSet64;
                st.Start();

                Conexao.ExecuteNonQuery(cmd);

                st.Stop();
                memoriaTotal += (Process.GetCurrentProcess().WorkingSet64 - memoria);
                cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);
            }

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        public ProcessamentoDto CargaSelecionarConceito(int tamanho)
        {
            string comando = string.Empty;
            long memoria = 0; long memoriaTotal = 0;
            long cpuUso = 0; long cpuUsoTotal = 0;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            Stopwatch st = new Stopwatch();
            List<ConceitoDto> list = new List<ConceitoDto>();

            cpuUso = Process.GetCurrentProcess().TotalProcessorTime.Milliseconds;
            memoria = Process.GetCurrentProcess().WorkingSet64;
            st.Start();

            SQLiteCommand cmd = new SQLiteCommand("select * from conceito limit @tamanho");
            pars.Add(new SQLiteParameter("tamanho", tamanho));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);

            st.Stop();
            memoriaTotal += (Process.GetCurrentProcess().WorkingSet64 - memoria);
            cpuUsoTotal += (Process.GetCurrentProcess().TotalProcessorTime.Milliseconds - cpuUso);

            return new ProcessamentoDto() { Tempo = st.ElapsedMilliseconds, Memoria = memoriaTotal, Cpu = cpuUsoTotal, Tamanho = tamanho };
        }

        #endregion
    }
}

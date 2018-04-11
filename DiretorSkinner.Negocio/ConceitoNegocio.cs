using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<ConceitoDto> ListarConceitos()
        {
            List<ConceitoDto> list = new List<ConceitoDto>();
            Conceito conceito;
            SQLiteCommand cmd = new SQLiteCommand("select * from conceito");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                conceito = new Conceito();
                conceito.Id = item.ToInteger("Id");
                conceito.Nome = item.ToString("Nome");
                conceito.Codigo = item.ToString("codigo");
                conceito.Aprovado = item.ToBoolean("aprovado");
                list.Add(conceito.ToDto());
            }

            return list;
        }

        public ConceitoDto ListarConceito(int id)
        {
            Conceito conceito = null;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from conceito where id = @id"));
            pars.Add(new SQLiteParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                conceito = new Conceito();
                conceito.Id = item.ToInteger("Id");
                conceito.Nome = item.ToString("Nome");
                conceito.Codigo = item.ToString("codigo");
                conceito.Aprovado = item.ToBoolean("aprovado");
            }

            return conceito == null ? null : conceito.ToDto();
        }

        public void SalvarConceito(ConceitoDto conceito)
        {
            string comando = string.Empty;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();

            if (conceito.Id > 0)
            {
                comando = string.Format("update conceito set Nome = @Nome, Codigo = @Codigo, Aprovado = @Aprovado where Id = @Id");
                pars.Add(new SQLiteParameter("Nome", conceito.Nome));
                pars.Add(new SQLiteParameter("Codigo", conceito.Codigo));
                pars.Add(new SQLiteParameter("Aprovado", conceito.Aprovado));
                pars.Add(new SQLiteParameter("Id", conceito.Id));
            }
            else
            {
                comando = string.Format("insert into conceito (Nome,Codigo,Aprovado) values (@Nome,@Codigo,@Aprovado)");
                pars.Add(new SQLiteParameter("Nome", conceito.Nome));
                pars.Add(new SQLiteParameter("Codigo", conceito.Codigo));
                pars.Add(new SQLiteParameter("Aprovado", conceito.Aprovado));
            }
            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarConceito(ConceitoDto conceito)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from conceito where Id = @Id"));
            pars.Add(new SQLiteParameter("Id", conceito.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

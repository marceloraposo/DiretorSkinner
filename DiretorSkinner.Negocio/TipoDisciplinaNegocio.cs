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
        public List<TipoDisciplinaDto> ListarTiposDisciplina()
        {
            List<TipoDisciplinaDto> list = new List<TipoDisciplinaDto>();
            TipoDisciplina TipoDisciplina;
            SQLiteCommand cmd = new SQLiteCommand("select * from TipoDisciplina");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                TipoDisciplina = new TipoDisciplina();
                TipoDisciplina.Id = item.ToInteger("Id");
                TipoDisciplina.Nome = item.ToString("Nome");
                TipoDisciplina.Codigo = item.ToString("codigo");
                list.Add(TipoDisciplina.ToDto());
            }

            return list;
        }

        public TipoDisciplinaDto ListarTipoDisciplina(int id)
        {
            TipoDisciplina tipoDisciplina = null;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from TipoDisciplina where id = @id"));
            pars.Add(new SQLiteParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                tipoDisciplina = new TipoDisciplina();
                tipoDisciplina.Id = item.ToInteger("Id");
                tipoDisciplina.Nome = item.ToString("Nome");
                tipoDisciplina.Codigo = item.ToString("codigo");
            }

            return tipoDisciplina == null ? null : tipoDisciplina.ToDto();
        }

        public void SalvarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            string comando = string.Empty;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();

            if (tipoDisciplina.Id > 0)
            {
                comando = string.Format("update TipoDisciplina set Nome = @Nome, Codigo = @Codigo where Id = @Id");
                pars.Add(new SQLiteParameter("Nome", tipoDisciplina.Nome));
                pars.Add(new SQLiteParameter("Codigo", tipoDisciplina.Codigo));
                pars.Add(new SQLiteParameter("Id", tipoDisciplina.Id));
            }
            else
            {
                comando = string.Format("insert into TipoDisciplina (Nome,Codigo) values (@Nome,@Codigo)");
                pars.Add(new SQLiteParameter("Nome", tipoDisciplina.Nome));
                pars.Add(new SQLiteParameter("Codigo", tipoDisciplina.Codigo));
            }
            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from TipoDisciplina where Id = @Id"));
            pars.Add(new SQLiteParameter("Id", tipoDisciplina.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

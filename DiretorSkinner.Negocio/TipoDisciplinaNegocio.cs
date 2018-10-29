using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<TipoDisciplinaDto> ListarTiposDisciplina()
        {
            List<TipoDisciplinaDto> list = new List<TipoDisciplinaDto>();
            TipoDisciplina TipoDisciplina;
            SqlCommand cmd = new SqlCommand("select * from TipoDisciplina");
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from TipoDisciplina where id = @id"));
            pars.Add(new SqlParameter("id", id));
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
            List<SqlParameter> pars = new List<SqlParameter>();

            if (tipoDisciplina.Id > 0)
            {
                comando = string.Format("update TipoDisciplina set Nome = @Nome, Codigo = @Codigo where Id = @Id");
                pars.Add(new SqlParameter("Nome", tipoDisciplina.Nome));
                pars.Add(new SqlParameter("Codigo", tipoDisciplina.Codigo));
                pars.Add(new SqlParameter("Id", tipoDisciplina.Id));
            }
            else
            {
                comando = string.Format("insert into TipoDisciplina (Nome,Codigo) values (@Nome,@Codigo)");
                pars.Add(new SqlParameter("Nome", tipoDisciplina.Nome));
                pars.Add(new SqlParameter("Codigo", tipoDisciplina.Codigo));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from TipoDisciplina where Id = @Id"));
            pars.Add(new SqlParameter("Id", tipoDisciplina.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

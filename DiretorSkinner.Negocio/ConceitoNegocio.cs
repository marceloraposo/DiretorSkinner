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
        public List<ConceitoDto> ListarConceitos()
        {
            List<ConceitoDto> list = new List<ConceitoDto>();
            Conceito conceito;
            SqlCommand cmd = new SqlCommand("select * from conceito");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                conceito = new Conceito();
                conceito.Id = item.ToInteger("Id");
                conceito.Nome = item.ToString("Nome");
                conceito.Codigo = item.ToString("codigo");
                conceito.Aprovado = item.ToBoolean("aprovado");
                conceito.Minimo = item.ToInteger("minimo");
                conceito.Maximo = item.ToInteger("maximo");
                list.Add(conceito.ToDto());
            }

            return list;
        }

        public ConceitoDto ListarConceito(int id)
        {
            Conceito conceito = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from conceito where id = @id"));
            pars.Add(new SqlParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                conceito = new Conceito();
                conceito.Id = item.ToInteger("Id");
                conceito.Nome = item.ToString("Nome");
                conceito.Codigo = item.ToString("codigo");
                conceito.Aprovado = item.ToBoolean("aprovado");
                conceito.Minimo = item.ToInteger("minimo");
                conceito.Maximo = item.ToInteger("maximo");
            }

            return conceito == null ? null : conceito.ToDto();
        }

        public void SalvarConceito(ConceitoDto conceito)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = new List<SqlParameter>();

            if (conceito.Id > 0)
            {
                comando = string.Format("update conceito set Nome = @Nome, Codigo = @Codigo, Aprovado = @Aprovado, Minimo = @Minimo, Maximo = @Maximo where Id = @Id");
                pars.Add(new SqlParameter("Nome", conceito.Nome));
                pars.Add(new SqlParameter("Codigo", conceito.Codigo));
                pars.Add(new SqlParameter("Aprovado", conceito.Aprovado));
                pars.Add(new SqlParameter("Minimo", conceito.Minimo));
                pars.Add(new SqlParameter("Maximo", conceito.Maximo));
                pars.Add(new SqlParameter("Id", conceito.Id));
            }
            else
            {
                comando = string.Format("insert into conceito (Nome,Codigo,Aprovado,Minimo,Maximo) values (@Nome,@Codigo,@Aprovado,@Minimo,@Maximo)");
                pars.Add(new SqlParameter("Nome", conceito.Nome));
                pars.Add(new SqlParameter("Codigo", conceito.Codigo));
                pars.Add(new SqlParameter("Aprovado", conceito.Aprovado));
                pars.Add(new SqlParameter("Minimo", conceito.Minimo));
                pars.Add(new SqlParameter("Maximo", conceito.Maximo));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarConceito(ConceitoDto conceito)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from conceito where Id = @Id"));
            pars.Add(new SqlParameter("Id", conceito.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

    }
}

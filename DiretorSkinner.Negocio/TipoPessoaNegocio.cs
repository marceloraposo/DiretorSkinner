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
        public List<TipoPessoaDto> ListarTiposPessoa()
        {
            List<TipoPessoaDto> list = new List<TipoPessoaDto>();
            TipoPessoa TipoPessoa;
            SqlCommand cmd = new SqlCommand("select * from TipoPessoa");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                TipoPessoa = new TipoPessoa();
                TipoPessoa.Id = item.ToInteger("Id");
                TipoPessoa.Nome = item.ToString("Nome");
                TipoPessoa.Codigo = item.ToString("codigo");
                list.Add(TipoPessoa.ToDto());
            }

            return list;
        }

        public TipoPessoaDto ListarTipoPessoa(int id)
        {
            TipoPessoa tipoPessoa = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from TipoPessoa where id = @id"));
            pars.Add(new SqlParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                tipoPessoa = new TipoPessoa();
                tipoPessoa.Id = item.ToInteger("Id");
                tipoPessoa.Nome = item.ToString("Nome");
                tipoPessoa.Codigo = item.ToString("codigo");
            }

            return tipoPessoa == null ? null : tipoPessoa.ToDto();
        }

        public List<TipoPessoaDto> ListarTipoPessoaPorPessoa(PessoaDto pessoa)
        {
            List<TipoPessoaDto> list = new List<TipoPessoaDto>();
            TipoPessoa TipoPessoa;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select tp.Id,tp.nome,tp.codigo,count(ptp.pessoaId) as Selecionado from tipoPessoa tp left join pessoaTipoPessoa ptp on ptp.tipoPessoaId = tp.id and ptp.pessoaId = @pessoaId group by tp.Id, tp.nome, tp.codigo"));
            pars.Add(new SqlParameter("pessoaId", pessoa.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                TipoPessoa = new TipoPessoa();
                TipoPessoa.Id = item.ToInteger("Id");
                TipoPessoa.Nome = item.ToString("Nome");
                TipoPessoa.Codigo = item.ToString("codigo");
                TipoPessoa.Selecionado = item.ToBoolean("Selecionado");
                list.Add(TipoPessoa.ToDto());
            }

            return list;
        }

        public void SalvarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = new List<SqlParameter>();

            if (tipoPessoa.Id > 0)
            {
                comando = string.Format("update tipopessoa set Nome = @Nome, Codigo = @Codigo where Id = @Id");
                pars.Add(new SqlParameter("Nome", tipoPessoa.Nome));
                pars.Add(new SqlParameter("Codigo", tipoPessoa.Codigo));
                pars.Add(new SqlParameter("Id", tipoPessoa.Id));
            }
            else
            {
                comando = string.Format("insert into tipopessoa (Nome,Codigo) values (@Nome,@Codigo)");
                pars.Add(new SqlParameter("Nome", tipoPessoa.Nome));
                pars.Add(new SqlParameter("Codigo", tipoPessoa.Codigo));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from tipopessoa where Id = @Id"));
            pars.Add(new SqlParameter("Id", tipoPessoa.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

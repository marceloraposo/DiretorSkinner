using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<PessoaDto> ListarPessoas()
        {
            List<PessoaDto> list = new List<PessoaDto>();
            Pessoa pessoa; PessoaDto pessoaDto;
            SqlCommand cmd = new SqlCommand("select * from pessoa");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });
                list.Add(pessoaDto);
            }

            return list;
        }

        public List<PessoaDto> ListarPessoasPesquisa(string filtro)
        {
            List<PessoaDto> list = new List<PessoaDto>();
            List<SqlParameter> pars = new List<SqlParameter>();
            Pessoa pessoa; PessoaDto pessoaDto;
            SqlCommand cmd = new SqlCommand("select * from pessoa where (UPPER(Nome) like '%' + @Nome + '%' or UPPER(Apelido) like '%' + @Apelido + '%' or UPPER(codigo) like '%' + @codigo + '%')");
            pars.Add(new SqlParameter("Nome", filtro.ToUpper()));
            pars.Add(new SqlParameter("Apelido", filtro.ToUpper()));
            pars.Add(new SqlParameter("Codigo", filtro.ToUpper()));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });
                list.Add(pessoaDto);
            }

            return list;
        }

        public List<PessoaDto> ListarPessoaPorTipo(TipoPessoaDto tipoPessoaDto)
        {
            List<PessoaDto> list = new List<PessoaDto>();
            Pessoa pessoa; PessoaDto pessoaDto;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from pessoa where tipopessoaId = @tipopessoaId"));
            pars.Add(new SqlParameter("tipopessoaId", tipoPessoaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });
                list.Add(pessoaDto);
            }

            return list;
        }

        public PessoaDto ListarPessoa(int id)
        {
            Pessoa pessoa = null; PessoaDto pessoaDto = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from pessoa where id = @id"));
            pars.Add(new SqlParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });

            }

            return pessoaDto;
        }

        public PessoaDto ListarPessoaPorApelido(string apelido)
        {
            Pessoa pessoa = null; PessoaDto pessoaDto = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from pessoa where apelido = @apelido"));
            pars.Add(new SqlParameter("apelido", apelido));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });
            }

            return pessoaDto;
        }

        public PessoaDto ListarPessoaPorCodigo(string codigo)
        {
            Pessoa pessoa = null; PessoaDto pessoaDto = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from pessoa where codigo = @codigo"));
            pars.Add(new SqlParameter("codigo", codigo));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pessoa = new Pessoa();
                pessoa.Id = item.ToInteger("Id");
                pessoa.Nome = item.ToString("Nome");
                pessoa.Codigo = item.ToString("codigo");
                pessoa.Apelido = item.ToString("apelido");
                pessoaDto = pessoa.ToDto();
                pessoaDto.TipoPessoas = ListarTipoPessoaPorPessoa(new PessoaDto() { Id = pessoa.Id });
            }

            return pessoaDto;
        }

        public void SalvarPessoa(PessoaDto pessoa)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = new List<SqlParameter>();

            if (pessoa.Id > 0)
            {
                comando = string.Format("update pessoa set Nome = @Nome, Codigo = @Codigo,Apelido = @Apelido where Id = @Id");
                pars.Add(new SqlParameter("Nome", pessoa.Nome));
                pars.Add(new SqlParameter("Apelido", pessoa.Apelido));
                pars.Add(new SqlParameter("Codigo", pessoa.Codigo));
                pars.Add(new SqlParameter("Id", pessoa.Id));
            }
            else
            {
                comando = string.Format("insert into pessoa (Nome,Codigo,Apelido) values (@Nome,@Codigo,@Apelido); SELECT IDENT_CURRENT('Pessoa');");
                pars.Add(new SqlParameter("Nome", pessoa.Nome));
                pars.Add(new SqlParameter("Apelido", pessoa.Apelido));
                pars.Add(new SqlParameter("Codigo", pessoa.Codigo));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            object retorno = Conexao.ExecuteScalar(cmd);

            if (pessoa.Id <= 0)
                pessoa.Id = Convert.ToInt32(retorno.ToString());

            DeletarPessoaTipoPessoa(pessoa);
            SalvarPessoaTipoPessoa(pessoa);
        }

        public void SalvarPessoaTipoPessoa(PessoaDto pessoa)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = null;
            SqlCommand cmd = null;

            foreach (var tipoPessoa in pessoa.TipoPessoas.Where(x => x.Selecionado))
            {
                pars = new List<SqlParameter>();
                comando = string.Format("insert into pessoaTipoPessoa (pessoaId,TipoPessoaId) values (@pessoaId,@TipoPessoaId)");
                pars.Add(new SqlParameter("pessoaId", pessoa.Id));
                pars.Add(new SqlParameter("TipoPessoaId", tipoPessoa.Id));
                cmd = new SqlCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());
                Conexao.ExecuteNonQuery(cmd);
            }
        }

        public void DeletarPessoa(PessoaDto pessoa)
        {
            DeletarPessoaTipoPessoa(pessoa);
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from pessoa where Id = @Id"));
            pars.Add(new SqlParameter("Id", pessoa.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarPessoaTipoPessoa(PessoaDto pessoa)
        {
            foreach (var tipoPessoa in pessoa.TipoPessoas)
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                SqlCommand cmd = new SqlCommand(string.Format("delete from pessoaTipoPessoa where pessoaId = @pessoaId"));
                pars.Add(new SqlParameter("pessoaId", pessoa.Id));
                //pars.Add(new SqlParameter("TipoPessoaId", tipoPessoa.Id));
                cmd.Parameters.AddRange(pars.ToArray());
                Conexao.ExecuteNonQuery(cmd);
            }
        }
    }
}

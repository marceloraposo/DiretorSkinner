using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<PessoaDto> ListarPessoas()
        {
            List<PessoaDto> list = new List<PessoaDto>();
            Pessoa pessoa; PessoaDto pessoaDto;
            SQLiteCommand cmd = new SQLiteCommand("select * from pessoa");
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            Pessoa pessoa; PessoaDto pessoaDto;
            SQLiteCommand cmd = new SQLiteCommand("select * from pessoa where (UPPER(Nome) like '%' || :Nome || '%' or UPPER(Apelido) like '%' || :Apelido || '%' or UPPER(codigo) like '%' || :codigo || '%')");
            pars.Add(new SQLiteParameter("Nome", filtro.ToUpper()));
            pars.Add(new SQLiteParameter("Apelido", filtro.ToUpper()));
            pars.Add(new SQLiteParameter("Codigo", filtro.ToUpper()));
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from pessoa where tipopessoaId = @tipopessoaId"));
            pars.Add(new SQLiteParameter("tipopessoaId", tipoPessoaDto.Id));
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from pessoa where id = @id"));
            pars.Add(new SQLiteParameter("id", id));
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from pessoa where apelido = @apelido"));
            pars.Add(new SQLiteParameter("apelido", apelido));
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from pessoa where codigo = @codigo"));
            pars.Add(new SQLiteParameter("codigo", codigo));
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();

            if (pessoa.Id > 0)
            {
                comando = string.Format("update pessoa set Nome = @Nome, Codigo = @Codigo,Apelido = @Apelido where Id = @Id");
                pars.Add(new SQLiteParameter("Nome", pessoa.Nome));
                pars.Add(new SQLiteParameter("Apelido", pessoa.Apelido));
                pars.Add(new SQLiteParameter("Codigo", pessoa.Codigo));
                pars.Add(new SQLiteParameter("Id", pessoa.Id));
            }
            else
            {
                comando = string.Format("insert into pessoa (Nome,Codigo,Apelido) values (@Nome,@Codigo,@Apelido); SELECT last_insert_rowid();");
                pars.Add(new SQLiteParameter("Nome", pessoa.Nome));
                pars.Add(new SQLiteParameter("Apelido", pessoa.Apelido));
                pars.Add(new SQLiteParameter("Codigo", pessoa.Codigo));
            }
            SQLiteCommand cmd = new SQLiteCommand(comando);
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
            List<SQLiteParameter> pars = null;
            SQLiteCommand cmd = null;

            foreach (var tipoPessoa in pessoa.TipoPessoas.Where(x => x.Selecionado))
            {
                pars = new List<SQLiteParameter>();
                comando = string.Format("insert into pessoaTipoPessoa (pessoaId,TipoPessoaId) values (@pessoaId,@TipoPessoaId)");
                pars.Add(new SQLiteParameter("pessoaId", pessoa.Id));
                pars.Add(new SQLiteParameter("TipoPessoaId", tipoPessoa.Id));
                cmd = new SQLiteCommand(comando);
                cmd.Parameters.AddRange(pars.ToArray());
                Conexao.ExecuteNonQuery(cmd);
            }
        }

        public void DeletarPessoa(PessoaDto pessoa)
        {
            DeletarPessoaTipoPessoa(pessoa);
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from pessoa where Id = @Id"));
            pars.Add(new SQLiteParameter("Id", pessoa.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarPessoaTipoPessoa(PessoaDto pessoa)
        {
            foreach (var tipoPessoa in pessoa.TipoPessoas)
            {
                List<SQLiteParameter> pars = new List<SQLiteParameter>();
                SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from pessoaTipoPessoa where pessoaId = @pessoaId"));
                pars.Add(new SQLiteParameter("pessoaId", pessoa.Id));
                //pars.Add(new SQLiteParameter("TipoPessoaId", tipoPessoa.Id));
                cmd.Parameters.AddRange(pars.ToArray());
                Conexao.ExecuteNonQuery(cmd);
            }
        }
    }
}

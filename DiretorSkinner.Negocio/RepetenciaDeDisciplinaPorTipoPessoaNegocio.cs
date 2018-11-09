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
        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTodosTipos()
        {
            List<RepetenciaDeDisciplinaPorTipoPessoaDto> list = new List<RepetenciaDeDisciplinaPorTipoPessoaDto>();
            RepetenciaDeDisciplinaPorTipoPessoa RepetenciaDeDisciplinaPorTipoPessoa;
            SqlCommand cmd = new SqlCommand("SELECT pessoa.Id as PessoaId,pessoa.Nome as PessoaNome,tipoPessoa.Id as TipoPessoaId,tipoPessoa.Nome as TipoPessoaNome,disciplina.Nome as DisciplinaNome,conceito.Nome as conceitoNome,salaDeAula.Semestre as Semestre from SalaDeAula salaDeAula ,Disciplina disciplina ,Pessoa pessoa ,TipoPessoa tipoPessoa, PessoaTipoPessoa pessoaTipoPessoa ,Conceito conceito where disciplina.Id = salaDeAula.DisciplinaId   and pessoa.Id = salaDeAula.PessoaId  and pessoa.Id = pessoaTipoPessoa.pessoaId  and tipoPessoa.Id = pessoaTipoPessoa.tipoPessoaId  and salaDeAula.Nota > conceito.Minimo   and salaDeAula.Nota <= conceito.Maximo ");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                RepetenciaDeDisciplinaPorTipoPessoa = new RepetenciaDeDisciplinaPorTipoPessoa();
                RepetenciaDeDisciplinaPorTipoPessoa.PessoaId = item.ToInteger("PessoaId");
                RepetenciaDeDisciplinaPorTipoPessoa.PessoaNome = item.ToString("PessoaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.TipoPessoaId = item.ToInteger("TipoPessoaId");
                RepetenciaDeDisciplinaPorTipoPessoa.TipoPessoaNome = item.ToString("TipoPessoaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.DisciplinaNome = item.ToString("DisciplinaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.ConceitoNome = item.ToString("ConceitoNome");
                RepetenciaDeDisciplinaPorTipoPessoa.Semestre = item.ToString("Semestre");
                list.Add(RepetenciaDeDisciplinaPorTipoPessoa.ToDto());
            }

            return list;
        }

        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTipo(int id)
        {
            List<RepetenciaDeDisciplinaPorTipoPessoaDto> list = new List<RepetenciaDeDisciplinaPorTipoPessoaDto>();
            RepetenciaDeDisciplinaPorTipoPessoa RepetenciaDeDisciplinaPorTipoPessoa;
            SqlCommand cmd = new SqlCommand("SELECT pessoa.Id as PessoaId,pessoa.Nome as PessoaNome,tipoPessoa.Id as TipoPessoaId,tipoPessoa.Nome as TipoPessoaNome,disciplina.Nome as DisciplinaNome,conceito.Nome as conceitoNome,salaDeAula.Semestre as Semestre from SalaDeAula salaDeAula ,Disciplina disciplina ,Pessoa pessoa ,TipoPessoa tipoPessoa, PessoaTipoPessoa pessoaTipoPessoa ,Conceito conceito where disciplina.Id = salaDeAula.DisciplinaId   and pessoa.Id = salaDeAula.PessoaId  and pessoa.Id = pessoaTipoPessoa.pessoaId  and tipoPessoa.Id = pessoaTipoPessoa.tipoPessoaId  and salaDeAula.Nota > conceito.Minimo   and salaDeAula.Nota <= conceito.Maximo   and pessoaTipoPessoa.tipoPessoaId = @TipoPessoaId");
            List<SqlParameter>  pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("TipoPessoaId", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                RepetenciaDeDisciplinaPorTipoPessoa = new RepetenciaDeDisciplinaPorTipoPessoa();
                RepetenciaDeDisciplinaPorTipoPessoa.PessoaId = item.ToInteger("PessoaId");
                RepetenciaDeDisciplinaPorTipoPessoa.PessoaNome = item.ToString("PessoaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.TipoPessoaId = item.ToInteger("TipoPessoaId");
                RepetenciaDeDisciplinaPorTipoPessoa.TipoPessoaNome = item.ToString("TipoPessoaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.DisciplinaNome = item.ToString("DisciplinaNome");
                RepetenciaDeDisciplinaPorTipoPessoa.ConceitoNome = item.ToString("ConceitoNome");
                list.Add(RepetenciaDeDisciplinaPorTipoPessoa.ToDto());
            }

            return list;
        }
    }
}

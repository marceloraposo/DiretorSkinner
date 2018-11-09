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
        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorTodasDisciplinas()
        {
            List<QtdePessoaPorDisciplinaDto> list = new List<QtdePessoaPorDisciplinaDto>();
            QtdePessoaPorDisciplina QtdePessoaPorDisciplina;
            SqlCommand cmd = new SqlCommand("select disciplina.Id as DisciplinaId , disciplina.Nome as DisciplinaNome, count(salaDeAula.pessoaId) as Quantidade from SalaDeAula salaDeAula , Disciplina disciplina where disciplina.Id = salaDeAula.disciplinaId group by disciplina.Id, disciplina.Nome");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                QtdePessoaPorDisciplina = new QtdePessoaPorDisciplina();
                QtdePessoaPorDisciplina.DisciplinaId = item.ToInteger("DisciplinaId");
                QtdePessoaPorDisciplina.DisciplinaNome = item.ToString("DisciplinaNome");
                QtdePessoaPorDisciplina.Quantidade = item.ToInteger("Quantidade");
                //QtdePessoaPorDisciplina.PessoaId = item.ToInteger("PessoaId");
                //QtdePessoaPorDisciplina.PessoaNome = item.ToString("PessoaNome");
                list.Add(QtdePessoaPorDisciplina.ToDto());
            }

            return list;
        }

        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorDisciplina(int id)
        {
            List<QtdePessoaPorDisciplinaDto> list = new List<QtdePessoaPorDisciplinaDto>();
            QtdePessoaPorDisciplina QtdePessoaPorDisciplina;
            SqlCommand cmd = new SqlCommand("select disciplina.Id as DisciplinaId , disciplina.Nome as DisciplinaNome, count(salaDeAula.pessoaId) as Quantidade from SalaDeAula salaDeAula , Disciplina disciplina where disciplina.Id = salaDeAula.disciplinaId and salaDeAula.disciplinaId = @DisciplinaId group by disciplina.Id, disciplina.Nome");
            List<SqlParameter>  pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("DisciplinaId", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                QtdePessoaPorDisciplina = new QtdePessoaPorDisciplina();
                QtdePessoaPorDisciplina.DisciplinaId = item.ToInteger("DisciplinaId");
                QtdePessoaPorDisciplina.DisciplinaNome = item.ToString("DisciplinaNome");
                QtdePessoaPorDisciplina.Quantidade = item.ToInteger("Quantidade");
                //QtdePessoaPorDisciplina.PessoaId = item.ToInteger("PessoaId");
                //QtdePessoaPorDisciplina.PessoaNome = item.ToString("PessoaNome");
                list.Add(QtdePessoaPorDisciplina.ToDto());
            }

            return list;
        }
    }
}

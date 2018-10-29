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
        public List<DisciplinaDto> ListarDisciplinas()
        {
            List<DisciplinaDto> list = new List<DisciplinaDto>();
            Disciplina disciplina;
            SqlCommand cmd = new SqlCommand("select * from disciplina");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                disciplina = new Disciplina();
                disciplina.Id = item.ToInteger("Id");
                disciplina.Nome = item.ToString("Nome");
                disciplina.Codigo = item.ToString("codigo");
                disciplina.TipoDisciplina = new TipoDisciplina();
                disciplina.TipoDisciplina.Id = item.ToInteger("tipodisciplinaId");
                list.Add(disciplina.ToDto());
            }

            return list;
        }

        public List<DisciplinaDto> ListarDisciplinaPorTipo(TipoDisciplinaDto tipoDisciplinaDto)
        {
            List<DisciplinaDto> list = new List<DisciplinaDto>();
            Disciplina disciplina;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from disciplina where tipodisciplinaId = @tipodisciplinaId"));
            pars.Add(new SqlParameter("tipodisciplinaId", tipoDisciplinaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                disciplina = new Disciplina();
                disciplina.Id = item.ToInteger("Id");
                disciplina.Nome = item.ToString("Nome");
                disciplina.Codigo = item.ToString("codigo");
                disciplina.TipoDisciplina = new TipoDisciplina();
                disciplina.TipoDisciplina.Id = item.ToInteger("tipodisciplinaId");
                list.Add(disciplina.ToDto());
            }

            return list;
        }

        public DisciplinaDto ListarDisciplina(int id)
        {
            Disciplina disciplina = null;
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select * from disciplina where id = @id"));
            pars.Add(new SqlParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            //inicio
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            //fim
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                disciplina = new Disciplina();
                disciplina.Id = item.ToInteger("Id");
                disciplina.Nome = item.ToString("Nome");
                disciplina.Codigo = item.ToString("codigo");
                disciplina.TipoDisciplina = new TipoDisciplina();
                disciplina.TipoDisciplina.Id = item.ToInteger("tipodisciplinaId");
            }

            return disciplina == null ? null : disciplina.ToDto();
        }

        public void SalvarDisciplina(DisciplinaDto disciplina)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = new List<SqlParameter>();

            if (disciplina.Id > 0)
            {
                comando = string.Format("update disciplina set Nome = @Nome, Codigo = @Codigo,TipoDisciplinaId = @TipoDisciplinaId where Id = @Id");
                pars.Add(new SqlParameter("Nome", disciplina.Nome));
                pars.Add(new SqlParameter("Codigo", disciplina.Codigo));
                pars.Add(new SqlParameter("TipoDisciplinaId", disciplina.TipoDisciplinaId));
                pars.Add(new SqlParameter("Id", disciplina.Id));
            }
            else
            {
                comando = string.Format("insert into disciplina (Nome,Codigo,TipoDisciplinaId) values (@Nome,@Codigo,@TipoDisciplinaId)");
                pars.Add(new SqlParameter("Nome", disciplina.Nome));
                pars.Add(new SqlParameter("Codigo", disciplina.Codigo));
                pars.Add(new SqlParameter("TipoDisciplinaId", disciplina.TipoDisciplinaId));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarDisciplina(DisciplinaDto disciplina)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from disciplina where Id = @Id"));
            pars.Add(new SqlParameter("Id", disciplina.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

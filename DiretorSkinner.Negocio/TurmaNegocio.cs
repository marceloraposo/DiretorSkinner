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
        public List<TurmaDto> ListarTurmas()
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma; TurmaDto turmaDto;
            SqlCommand cmd = new SqlCommand("select * from turma");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Id = item.ToInteger("Id");
                turma.Codigo = item.ToString("Codigo");
                turma.DataIngresso = item.ToDateTime("DataIngresso");
                turmaDto = turma.ToDto();
                turmaDto.SalasDeAula = ListarSalaDeAulaPorTurma(new TurmaDto() { Id = turma.Id });
                list.Add(turmaDto);
            }

            return list;
        }

        public void SalvarTurma(TurmaDto turma)
        {
            string comando = string.Empty;
            List<SqlParameter> pars = new List<SqlParameter>();

            if (turma.Id > 0)
            {
                comando = string.Format("update turma set DataIngresso = @DataIngresso, Codigo = @Codigo where Id = @Id");
                pars.Add(new SqlParameter("Codigo", turma.Codigo));
                pars.Add(new SqlParameter("DataIngresso", turma.DataIngresso));
                pars.Add(new SqlParameter("Id", turma.Id));
            }
            else
            {
                comando = string.Format("insert into turma (Codigo,DataIngresso) values (@Codigo,@DataIngresso)");
                pars.Add(new SqlParameter("DataIngresso", turma.DataIngresso));
                pars.Add(new SqlParameter("Codigo", turma.Codigo));
            }
            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTurma(TurmaDto turma)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from turma where Id = @Id"));
            pars.Add(new SqlParameter("Id", turma.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

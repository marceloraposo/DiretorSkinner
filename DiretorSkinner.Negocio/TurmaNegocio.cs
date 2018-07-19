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
        public List<TurmaDto> ListarTurmas()
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma; TurmaDto turmaDto;
            SQLiteCommand cmd = new SQLiteCommand("select * from turma");
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
            List<SQLiteParameter> pars = new List<SQLiteParameter>();

            if (turma.Id > 0)
            {
                comando = string.Format("update turma set DataIngresso = @DataIngresso, Codigo = @Codigo where Id = @Id");
                pars.Add(new SQLiteParameter("Codigo", turma.Codigo));
                pars.Add(new SQLiteParameter("DataIngresso", turma.DataIngresso));
                pars.Add(new SQLiteParameter("Id", turma.Id));
            }
            else
            {
                comando = string.Format("insert into turma (Codigo,DataIngresso) values (@Codigo,@DataIngresso)");
                pars.Add(new SQLiteParameter("DataIngresso", turma.DataIngresso));
                pars.Add(new SQLiteParameter("Codigo", turma.Codigo));
            }
            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTurma(TurmaDto turma)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from turma where Id = @Id"));
            pars.Add(new SQLiteParameter("Id", turma.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

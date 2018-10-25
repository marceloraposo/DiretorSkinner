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
        public List<SalaDeAulaDto> ListarSalasDeAula()
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            SQLiteCommand cmd = new SQLiteCommand("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public SalaDeAulaDto ListarSalaDeAula(int id)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula; SalaDeAulaDto SalaDeAulaDto = null;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.Id = @Id");
            pars.Add(new SQLiteParameter("id", id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                SalaDeAulaDto = SalaDeAula.ToDto();
            }
            return SalaDeAulaDto;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorTurma(TurmaDto turmaDto)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.turmaId = @turmaId"));
            pars.Add(new SQLiteParameter("turmaId", turmaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorDisciplina(DisciplinaDto disciplinaDto)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.disciplinaId = @disciplinaId"));
            pars.Add(new SQLiteParameter("disciplinaId", disciplinaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorConceito(ConceitoDto conceitoDto)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p, Conceito c where p.Id = sda.pessoaId and sda.Nota >= c.Minimo and sda.Nota <= c.Maximo and c.Id =  @conceitoId"));
            pars.Add(new SQLiteParameter("conceitoId", conceitoDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorPessoa(PessoaDto pessoaDto)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.pessoaId = @pessoaId"));
            pars.Add(new SQLiteParameter("pessoaId", pessoaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorFiltros(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa, TurmaDto turma)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p, Conceito c where  p.Id = sda.pessoaId and sda.Nota >= c.Minimo and sda.Nota <= c.Maximo and sda.turmaId = ifnull(@turmaId,sda.turmaId) and sda.pessoaId = ifnull(@pessoaId,sda.pessoaId) and sda.disciplinaId = ifnull(@disciplinaId,sda.disciplinaId) and (ifnull(c.Id,c.Id) = ifnull(@conceitoId,c.Id) OR ifnull(c.Id,0) = ifnull(@conceitoId,0))"));
            if (pessoa == null)
                pars.Add(new SQLiteParameter("pessoaId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("pessoaId", pessoa.Id));

            if (conceito == null)
                pars.Add(new SQLiteParameter("conceitoId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("conceitoId", conceito.Id));

            if (disciplina == null)
                pars.Add(new SQLiteParameter("disciplinaId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("disciplinaId", disciplina.Id));

            if (turma == null)
                pars.Add(new SQLiteParameter("turmaId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("turmaId", turma.Id));


            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Id = item.ToInteger("id");
                SalaDeAula.Semestre = item.ToString("Semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Nota = item.ToDecimalOrNull("Nota");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Pessoa.Nome = item.ToString("Nome");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public void SalvarSalaDeAula(SalaDeAulaDto SalaDeAula)
        {
            //DeletarSalaDeAula(SalaDeAula);

            string comando = string.Empty;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            if (SalaDeAula.Id > 0)
            {
                comando = string.Format("update SalaDeAula set Nota = @Nota, PessoaId = @PessoaId, DisciplinaId = @DisciplinaId, Semestre = @Semestre where Id = @Id");
                pars.Add(new SQLiteParameter("Nota", SalaDeAula.Nota));
                pars.Add(new SQLiteParameter("pessoaId", SalaDeAula.PessoaId));
                pars.Add(new SQLiteParameter("disciplinaId", SalaDeAula.DisciplinaId));
                pars.Add(new SQLiteParameter("turmaId", SalaDeAula.TurmaId));
                pars.Add(new SQLiteParameter("semestre", SalaDeAula.Semestre));
                pars.Add(new SQLiteParameter("Id", SalaDeAula.Id));
            }
            else
            {
                comando = string.Format("insert into SalaDeAula (Nota,PessoaId,DisciplinaId,Semestre,TurmaId) values (@Nota,@pessoaId,@disciplinaId,@semestre,@turmaId)");
                pars.Add(new SQLiteParameter("Nota", SalaDeAula.Nota));
                pars.Add(new SQLiteParameter("pessoaId", SalaDeAula.PessoaId));
                pars.Add(new SQLiteParameter("disciplinaId", SalaDeAula.DisciplinaId));
                pars.Add(new SQLiteParameter("turmaId", SalaDeAula.TurmaId));
                pars.Add(new SQLiteParameter("semestre", SalaDeAula.Semestre));
            }

            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarSalaDeAula(SalaDeAulaDto SalaDeAula)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from SalaDeAula where Id = @Id"));
            //pars.Add(new SQLiteParameter("conceitoId", SalaDeAula.ConceitoId));
            //pars.Add(new SQLiteParameter("pessoaId", SalaDeAula.PessoaId));
            //pars.Add(new SQLiteParameter("disciplinaId", SalaDeAula.DisciplinaId));
            //pars.Add(new SQLiteParameter("semestre", SalaDeAula.Semestre));
            //pars.Add(new SQLiteParameter("turmaId", SalaDeAula.TurmaId));
            pars.Add(new SQLiteParameter("Id", SalaDeAula.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

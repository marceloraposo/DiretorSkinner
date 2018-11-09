using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<SalaDeAulaDto> ListarSalasDeAula()
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            SqlCommand cmd = new SqlCommand("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId");
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.Id = @Id");
            pars.Add(new SqlParameter("id", id));
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.turmaId = @turmaId"));
            pars.Add(new SqlParameter("turmaId", turmaDto.Id));
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.disciplinaId = @disciplinaId"));
            pars.Add(new SqlParameter("disciplinaId", disciplinaDto.Id));
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p, Conceito c where p.Id = sda.pessoaId and sda.Nota > c.Minimo and sda.Nota <= c.Maximo and c.Id =  @conceitoId"));
            pars.Add(new SqlParameter("conceitoId", conceitoDto.Id));
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p where p.Id = sda.pessoaId and sda.pessoaId = @pessoaId"));
            pars.Add(new SqlParameter("pessoaId", pessoaDto.Id));
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
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("select sda.Id,sda.semestre,sda.disciplinaId,sda.Nota,sda.pessoaId,sda.turmaId,p.Nome from SalaDeAula sda, Pessoa p, Conceito c where  p.Id = sda.pessoaId and sda.Nota > c.Minimo and sda.Nota <= c.Maximo and sda.turmaId = isnull(@turmaId,sda.turmaId) and sda.pessoaId = isnull(@pessoaId,sda.pessoaId) and sda.disciplinaId = isnull(@disciplinaId,sda.disciplinaId) and (isnull(c.Id,c.Id) = isnull(@conceitoId,c.Id) OR isnull(c.Id,0) = isnull(@conceitoId,0))"));
            if (pessoa == null)
                pars.Add(new SqlParameter("pessoaId", DBNull.Value));
            else
                pars.Add(new SqlParameter("pessoaId", pessoa.Id));

            if (conceito == null)
                pars.Add(new SqlParameter("conceitoId", DBNull.Value));
            else
                pars.Add(new SqlParameter("conceitoId", conceito.Id));

            if (disciplina == null)
                pars.Add(new SqlParameter("disciplinaId", DBNull.Value));
            else
                pars.Add(new SqlParameter("disciplinaId", disciplina.Id));

            if (turma == null)
                pars.Add(new SqlParameter("turmaId", DBNull.Value));
            else
                pars.Add(new SqlParameter("turmaId", turma.Id));


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
            List<SqlParameter> pars = new List<SqlParameter>();
            if (SalaDeAula.Id > 0)
            {
                comando = string.Format("update SalaDeAula set Nota = @Nota, PessoaId = @PessoaId, DisciplinaId = @DisciplinaId, Semestre = @Semestre where Id = @Id");
                pars.Add(new SqlParameter("Nota", SalaDeAula.Nota));
                pars.Add(new SqlParameter("pessoaId", SalaDeAula.PessoaId));
                pars.Add(new SqlParameter("disciplinaId", SalaDeAula.DisciplinaId));
                pars.Add(new SqlParameter("turmaId", SalaDeAula.TurmaId));
                pars.Add(new SqlParameter("semestre", SalaDeAula.Semestre));
                pars.Add(new SqlParameter("Id", SalaDeAula.Id));
            }
            else
            {
                comando = string.Format("insert into SalaDeAula (Nota,PessoaId,DisciplinaId,Semestre,TurmaId) values (@Nota,@pessoaId,@disciplinaId,@semestre,@turmaId)");
                pars.Add(new SqlParameter("Nota", SalaDeAula.Nota));
                pars.Add(new SqlParameter("pessoaId", SalaDeAula.PessoaId));
                pars.Add(new SqlParameter("disciplinaId", SalaDeAula.DisciplinaId));
                pars.Add(new SqlParameter("turmaId", SalaDeAula.TurmaId));
                pars.Add(new SqlParameter("semestre", SalaDeAula.Semestre));
            }

            SqlCommand cmd = new SqlCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarSalaDeAula(SalaDeAulaDto SalaDeAula)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            SqlCommand cmd = new SqlCommand(string.Format("delete from SalaDeAula where Id = @Id"));
            //pars.Add(new SqlParameter("conceitoId", SalaDeAula.ConceitoId));
            //pars.Add(new SqlParameter("pessoaId", SalaDeAula.PessoaId));
            //pars.Add(new SqlParameter("disciplinaId", SalaDeAula.DisciplinaId));
            //pars.Add(new SqlParameter("semestre", SalaDeAula.Semestre));
            //pars.Add(new SqlParameter("turmaId", SalaDeAula.TurmaId));
            pars.Add(new SqlParameter("Id", SalaDeAula.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

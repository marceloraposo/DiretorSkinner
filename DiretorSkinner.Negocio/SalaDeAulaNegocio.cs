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
            SQLiteCommand cmd = new SQLiteCommand("select * from SalaDeAula");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorTurma(TurmaDto turmaDto)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from SalaDeAula where turmaId = @turmaId"));
            pars.Add(new SQLiteParameter("turmaId", turmaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
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
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from SalaDeAula where disciplinaId = @disciplinaId"));
            pars.Add(new SQLiteParameter("disciplinaId", disciplinaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
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
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from SalaDeAula where conceitoId = @conceitoId"));
            pars.Add(new SQLiteParameter("conceitoId", conceitoDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
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
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from SalaDeAula where pessoaId = @pessoaId"));
            pars.Add(new SQLiteParameter("pessoaId", pessoaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                SalaDeAula = new SalaDeAula();
                SalaDeAula.Semestre = item.ToString("semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public List<SalaDeAulaDto> ListarSalaDeAula(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa, TurmaDto turma)
        {
            List<SalaDeAulaDto> list = new List<SalaDeAulaDto>();
            SalaDeAula SalaDeAula;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from SalaDeAula where turmaId = ifnull(@turmaId,turmaId) and pessoaId = ifnull(@pessoaId,pessoaId) and disciplinaId = ifnull(@disciplinaId,disciplinaId) and (ifnull(conceitoId,conceitoId) = ifnull(@conceitoId,conceitoId) OR ifnull(conceitoId,0) = ifnull(@conceitoId,0))"));
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
                SalaDeAula.Semestre = item.ToString("Semestre");
                SalaDeAula.Disciplina = new Disciplina();
                SalaDeAula.Disciplina.Id = item.ToInteger("disciplinaId");
                SalaDeAula.Conceito = new Conceito();
                SalaDeAula.Conceito.Id = item.ToInteger("conceitoId");
                SalaDeAula.Pessoa = new Pessoa();
                SalaDeAula.Pessoa.Id = item.ToInteger("pessoaId");
                SalaDeAula.Turma = new Turma();
                SalaDeAula.Turma.Id = item.ToInteger("turmaId");
                list.Add(SalaDeAula.ToDto());
            }

            return list;
        }

        public void SalvarSalaDeAula(SalaDeAulaDto SalaDeAula)
        {
            DeletarSalaDeAula(SalaDeAula);

            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            string comando = string.Format("insert into SalaDeAula (ConceitoId,PessoaId,DisciplinaId,Semestre,TurmaId) values (@conceitoId,@pessoaId,@disciplinaId,@semestre,@turmaId)");
            pars.Add(new SQLiteParameter("conceitoId", SalaDeAula.ConceitoId));
            pars.Add(new SQLiteParameter("pessoaId", SalaDeAula.PessoaId));
            pars.Add(new SQLiteParameter("disciplinaId", SalaDeAula.DisciplinaId));
            pars.Add(new SQLiteParameter("turmaId", SalaDeAula.TurmaId));
            pars.Add(new SQLiteParameter("semestre", SalaDeAula.Semestre));

            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarSalaDeAula(SalaDeAulaDto SalaDeAula)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from SalaDeAula where conceitoId = @conceitoId and pessoaId = @pessoaId and disciplinaId = @disciplinaId and semestre = @semestre"));
            pars.Add(new SQLiteParameter("conceitoId", SalaDeAula.ConceitoId));
            pars.Add(new SQLiteParameter("pessoaId", SalaDeAula.PessoaId));
            pars.Add(new SQLiteParameter("disciplinaId", SalaDeAula.DisciplinaId));
            pars.Add(new SQLiteParameter("semestre", SalaDeAula.Semestre));
            pars.Add(new SQLiteParameter("turmaId", SalaDeAula.TurmaId));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

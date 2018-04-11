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
            Turma turma;
            SQLiteCommand cmd = new SQLiteCommand("select * from turma");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Semestre = item.ToString("semestre");
                turma.Disciplina = new Disciplina();
                turma.Disciplina.Id = item.ToInteger("disciplinaId");
                turma.Conceito = new Conceito();
                turma.Conceito.Id = item.ToInteger("conceitoId");
                turma.Pessoa = new Pessoa();
                turma.Pessoa.Id = item.ToInteger("pessoaId");
                list.Add(turma.ToDto());
            }

            return list;
        }

        public List<TurmaDto> ListarTurmaPorDisciplina(DisciplinaDto disciplinaDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from turma where disciplinaId = @disciplinaId"));
            pars.Add(new SQLiteParameter("disciplinaId", disciplinaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Semestre = item.ToString("semestre");
                turma.Disciplina = new Disciplina();
                turma.Disciplina.Id = item.ToInteger("disciplinaId");
                turma.Conceito = new Conceito();
                turma.Conceito.Id = item.ToInteger("conceitoId");
                turma.Pessoa = new Pessoa();
                turma.Pessoa.Id = item.ToInteger("pessoaId");
                list.Add(turma.ToDto());
            }

            return list;
        }

        public List<TurmaDto> ListarTurmaPorConceito(ConceitoDto conceitoDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from turma where conceitoId = @conceitoId"));
            pars.Add(new SQLiteParameter("conceitoId", conceitoDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Semestre = item.ToString("semestre");
                turma.Disciplina = new Disciplina();
                turma.Disciplina.Id = item.ToInteger("disciplinaId");
                turma.Conceito = new Conceito();
                turma.Conceito.Id = item.ToInteger("conceitoId");
                turma.Pessoa = new Pessoa();
                turma.Pessoa.Id = item.ToInteger("pessoaId");
                list.Add(turma.ToDto());
            }

            return list;
        }

        public List<TurmaDto> ListarTurmaPorPessoa(PessoaDto pessoaDto)
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from turma where pessoaId = @pessoaId"));
            pars.Add(new SQLiteParameter("pessoaId", pessoaDto.Id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Semestre = item.ToString("semestre");
                turma.Disciplina = new Disciplina();
                turma.Disciplina.Id = item.ToInteger("disciplinaId");
                turma.Conceito = new Conceito();
                turma.Conceito.Id = item.ToInteger("conceitoId");
                turma.Pessoa = new Pessoa();
                turma.Pessoa.Id = item.ToInteger("pessoaId");
                list.Add(turma.ToDto());
            }

            return list;
        }

        public List<TurmaDto> ListarTurma(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa)
        {
            List<TurmaDto> list = new List<TurmaDto>();
            Turma turma;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("select * from turma where pessoaId = ifnull(@pessoaId,pessoaId) and disciplinaId = ifnull(@disciplinaId,disciplinaId) and (ifnull(conceitoId,conceitoId) = ifnull(@conceitoId,conceitoId) OR ifnull(conceitoId,0) = ifnull(@conceitoId,0))"));
            if(pessoa == null)
                pars.Add(new SQLiteParameter("pessoaId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("pessoaId", pessoa.Id));

            if(conceito == null)
                pars.Add(new SQLiteParameter("conceitoId", DBNull.Value));
            else
                pars.Add(new SQLiteParameter("conceitoId",conceito.Id));

            if(disciplina == null)
                pars.Add(new SQLiteParameter("disciplinaId",DBNull.Value));
            else
                pars.Add(new SQLiteParameter("disciplinaId", disciplina.Id));


            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                turma = new Turma();
                turma.Semestre = item.ToString("Semestre");
                turma.Disciplina = new Disciplina();
                turma.Disciplina.Id = item.ToInteger("disciplinaId");
                turma.Conceito = new Conceito();
                turma.Conceito.Id = item.ToInteger("conceitoId");
                turma.Pessoa = new Pessoa();
                turma.Pessoa.Id = item.ToInteger("pessoaId");
                list.Add(turma.ToDto());
            }

            return list;
        }

        public void SalvarTurma(TurmaDto turma)
        {
            string comando = string.Empty;
            List<SQLiteParameter> pars = new List<SQLiteParameter>();

            List<TurmaDto> turmaExistente = ListarTurma(new ConceitoDto() { Id = turma.ConceitoId }, new DisciplinaDto() { Id = turma.DisciplinaId }, new PessoaDto() { Id = turma.PessoaId });

            if (turma.ConceitoId > 0 && turma.DisciplinaId > 0 && turma.PessoaId > 0 && !string.IsNullOrEmpty(turma.Semestre) && turmaExistente.Count > 0)
            {
                comando = string.Format("update turma set semestre = @semestre,conceitoId = @conceitoId, pessoaId = @pessoaId,disciplinaId = @disciplinaId where conceitoId = @conceitoId and pessoaId = @pessoaId and disciplinaId = @disciplinaId");
                pars.Add(new SQLiteParameter("conceitoId", turma.ConceitoId));
                pars.Add(new SQLiteParameter("pessoaId", turma.PessoaId));
                pars.Add(new SQLiteParameter("disciplinaId", turma.DisciplinaId));
                pars.Add(new SQLiteParameter("semestre", turma.Semestre));
            }
            else
            {
                comando = string.Format("insert into turma (ConceitoId,PessoaId,DisciplinaId,Semestre) values (@conceitoId,@pessoaId,@disciplinaId,@semestre)");
                pars.Add(new SQLiteParameter("conceitoId", turma.ConceitoId));
                pars.Add(new SQLiteParameter("pessoaId", turma.PessoaId));
                pars.Add(new SQLiteParameter("disciplinaId", turma.DisciplinaId));
                pars.Add(new SQLiteParameter("semestre", turma.Semestre));
            }
            SQLiteCommand cmd = new SQLiteCommand(comando);
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }

        public void DeletarTurma(TurmaDto turma)
        {
            List<SQLiteParameter> pars = new List<SQLiteParameter>();
            SQLiteCommand cmd = new SQLiteCommand(string.Format("delete from turma where conceitoId = @conceitoId and pessoaId = @pessoaId and disciplinaId = @disciplinaId and semestre = @semestre"));
            pars.Add(new SQLiteParameter("conceitoId", turma.ConceitoId));
            pars.Add(new SQLiteParameter("pessoaId", turma.PessoaId));
            pars.Add(new SQLiteParameter("disciplinaId", turma.DisciplinaId));
            pars.Add(new SQLiteParameter("semestre", turma.Semestre));
            cmd.Parameters.AddRange(pars.ToArray());
            int retorno = Conexao.ExecuteNonQuery(cmd);
        }
    }
}

using DiretorSkinner.Tranporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretorSkinner.Negocio.Entidades
{
    public class SalaDeAula
    {
        private int id;
        private string semestre;
        private Pessoa pessoa;
        private Disciplina disciplina;
        private decimal? nota;
        private Turma turma;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Semestre
        {
            get
            {
                return semestre;
            }

            set
            {
                semestre = value;
            }
        }
        public Pessoa Pessoa
        {
            get
            {
                return pessoa;
            }

            set
            {
                pessoa = value;
            }
        }
        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }

            set
            {
                disciplina = value;
            }
        }
        public decimal? Nota
        {
            get
            {
                return nota;
            }

            set
            {
                nota = value;
            }
        }
        public Turma Turma
        {
            get
            {
                return turma;
            }

            set
            {
                turma = value;
            }
        }

        public SalaDeAulaDto ToDto()
        {
            SalaDeAulaDto dto = new SalaDeAulaDto();

            dto.Id = this.Id;
            dto.Semestre = this.Semestre;
            if (this.Pessoa != null)
            {
                dto.PessoaId = this.Pessoa.Id;
                dto.PessoaNome = this.Pessoa.Nome;
            }
            if (this.Disciplina != null)
                dto.DisciplinaId = this.Disciplina.Id;
            if (this.Nota != null)
                dto.Nota = this.Nota;
            if (this.Turma != null)
                dto.TurmaId = this.Turma.Id;

            return dto;
        }

        public SalaDeAula FromDto(SalaDeAulaDto dto)
        {
            SalaDeAula salaDeAula = new SalaDeAula();
            salaDeAula.Id = dto.Id;
            salaDeAula.Semestre = dto.Semestre;
            salaDeAula.Pessoa = new Pessoa() { Id = dto.PessoaId };
            salaDeAula.Disciplina = new Disciplina() { Id = dto.DisciplinaId };
            salaDeAula.Nota = dto.Nota;
            salaDeAula.Turma = new Turma() { Id = dto.TurmaId };

            return salaDeAula;
        }
    }
}

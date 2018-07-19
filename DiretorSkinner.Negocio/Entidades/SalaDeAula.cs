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
        private string semestre;
        private Pessoa pessoa;
        private Disciplina disciplina;
        private Conceito conceito;
        private Turma turma;

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
        public Conceito Conceito
        {
            get
            {
                return conceito;
            }

            set
            {
                conceito = value;
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

            dto.Semestre = this.Semestre;
            if (this.Pessoa != null)
                dto.PessoaId = this.Pessoa.Id;
            if (this.Disciplina != null)
                dto.DisciplinaId = this.Disciplina.Id;
            if (this.Conceito != null)
                dto.ConceitoId = this.Conceito.Id;
            if (this.Turma != null)
                dto.TurmaId = this.Turma.Id;

            return dto;
        }

        public SalaDeAula FromDto(SalaDeAulaDto dto)
        {
            SalaDeAula salaDeAula = new SalaDeAula();
            salaDeAula.Semestre = dto.Semestre;
            salaDeAula.Pessoa = new Pessoa() { Id = dto.PessoaId };
            salaDeAula.Disciplina = new Disciplina() { Id = dto.DisciplinaId };
            salaDeAula.Conceito = new Conceito() { Id = dto.ConceitoId };
            salaDeAula.Turma = new Turma() { Id = dto.TurmaId };

            return salaDeAula;
        }
    }
}

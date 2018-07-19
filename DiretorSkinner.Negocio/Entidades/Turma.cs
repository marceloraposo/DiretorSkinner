using DiretorSkinner.Tranporte;
using System;

namespace DiretorSkinner.Negocio.Entidades
{
    public class Turma
    {
        private int id;
        private string codigo;
        private DateTime dataIngresso;

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
        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }
        public DateTime DataIngresso
        {
            get
            {
                return dataIngresso;
            }

            set
            {
                dataIngresso = value;
            }
        }

        public TurmaDto ToDto()
        {
            TurmaDto dto = new TurmaDto();

            dto.Id = this.Id;
            dto.Codigo = this.Codigo;
            dto.DataIngresso = this.DataIngresso;

            return dto;
        }

        public Turma FromDto(TurmaDto dto)
        {
            Turma turma = new Turma();
            turma.Id = dto.Id;
            turma.Codigo = dto.Codigo;
            turma.DataIngresso = dto.DataIngresso;

            return turma;
        }
    }
}

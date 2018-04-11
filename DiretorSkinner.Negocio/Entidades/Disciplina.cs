using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class Disciplina
    {
        private int id;
        private string codigo;
        private string nome;
        private TipoDisciplina tipoDisciplina;

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
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }
        public TipoDisciplina TipoDisciplina
        {
            get
            {
                return tipoDisciplina;
            }

            set
            {
                tipoDisciplina = value;
            }
        }

        public DisciplinaDto ToDto()
        {
            DisciplinaDto dto = new DisciplinaDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            if (this.TipoDisciplina != null)
                dto.TipoDisciplinaId = this.TipoDisciplina.Id;

            return dto;
        }

        public Disciplina FromDto(DisciplinaDto dto)
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Id = dto.Id;
            disciplina.Codigo = dto.Codigo;
            disciplina.Nome = dto.Nome;
            disciplina.TipoDisciplina = new TipoDisciplina() { Id = dto.TipoDisciplinaId };

            return disciplina;
        }
    }
}

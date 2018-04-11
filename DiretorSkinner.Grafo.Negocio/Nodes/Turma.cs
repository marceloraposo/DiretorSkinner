using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Grafo.Negocio.Nodes
{
    public class Turma
    {
        private string semestre;
        private Pessoa pessoa;
        private Disciplina disciplina;
        private Conceito conceito;

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

        public TurmaDto ToDto()
        {
            TurmaDto dto = new TurmaDto();

            dto.Semestre = this.Semestre;
            if (this.Pessoa != null)
                dto.PessoaId = this.Pessoa.Id;
            if (this.Disciplina != null)
                dto.DisciplinaId = this.Disciplina.Id;
            if (this.Conceito != null)
                dto.ConceitoId = this.Conceito.Id;

            return dto;
        }

        public Turma FromDto(TurmaDto dto)
        {
            Turma turma = new Turma();
            turma.Semestre = dto.Semestre;
            turma.Pessoa = new Pessoa() { Id = dto.PessoaId };
            turma.Disciplina = new Disciplina() { Id = dto.DisciplinaId };
            turma.Conceito = new Conceito() { Id = dto.ConceitoId };

            return turma;
        }
    }
}

using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class QtdePessoaPorDisciplina
    {
        private int disciplinaId;
        private string disciplinaNome;
        private int pessoaId;
        private string pessoaNome;
        private int quantidade;

        public int DisciplinaId
        {
            get
            {
                return disciplinaId;
            }

            set
            {
                disciplinaId = value;
            }
        }
        public string DisciplinaNome
        {
            get
            {
                return disciplinaNome;
            }

            set
            {
                disciplinaNome = value;
            }
        }
        public int PessoaId
        {
            get
            {
                return pessoaId;
            }

            set
            {
                pessoaId = value;
            }
        }
        public string PessoaNome
        {
            get
            {
                return pessoaNome;
            }

            set
            {
                pessoaNome = value;
            }
        }

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public QtdePessoaPorDisciplinaDto ToDto()
        {
            QtdePessoaPorDisciplinaDto dto = new QtdePessoaPorDisciplinaDto();

            dto.DisciplinaId = this.DisciplinaId;
            dto.DisciplinaNome = this.DisciplinaNome;
            //dto.PessoaId = this.PessoaId;
            //dto.PessoaNome = this.PessoaNome;
            dto.Quantidade = this.Quantidade;

            return dto;
        }

        public QtdePessoaPorDisciplina FromDto(QtdePessoaPorDisciplinaDto dto)
        {
            QtdePessoaPorDisciplina qtdePessoaPorDisciplina = new QtdePessoaPorDisciplina();
            qtdePessoaPorDisciplina.DisciplinaId = dto.DisciplinaId;
            qtdePessoaPorDisciplina.DisciplinaNome = dto.DisciplinaNome;
            //qtdePessoaPorDisciplina.PessoaId = dto.PessoaId;
            //qtdePessoaPorDisciplina.PessoaNome = dto.PessoaNome;
            qtdePessoaPorDisciplina.Quantidade = dto.Quantidade;

            return qtdePessoaPorDisciplina;
        }
    }
}

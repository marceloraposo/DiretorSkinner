using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class PessoaPorConceito
    {
        private int id;
        private string nome;
        private string conceito;

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
        public string Conceito
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

        public PessoaPorConceitoDto ToDto()
        {
            PessoaPorConceitoDto dto = new PessoaPorConceitoDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Conceito = this.Conceito;

            return dto;
        }

        public PessoaPorConceito FromDto(PessoaPorConceitoDto dto)
        {
            PessoaPorConceito pessoaPorConceito = new PessoaPorConceito();
            pessoaPorConceito.Id = dto.Id;
            pessoaPorConceito.Nome = dto.Nome;
            pessoaPorConceito.Conceito = dto.Conceito;

            return pessoaPorConceito;
        }
    }
}

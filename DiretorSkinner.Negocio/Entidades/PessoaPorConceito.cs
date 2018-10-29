using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class PessoaPorConceito
    {
        private int id;
        private string codigo;
        private string nome;
        private Conceito conceito;
        private decimal media;

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
        public decimal Media
        {
            get
            {
                return media;
            }

            set
            {
                media = value;
            }
        }

        public PessoaPorConceitoDto ToDto()
        {
            PessoaPorConceitoDto dto = new PessoaPorConceitoDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            dto.Media = this.Media;
            if (this.Conceito != null)
            {
                dto.ConceitoId = this.Conceito.Id;
                dto.ConceitoNome = this.Conceito.Nome;
            }

            return dto;
        }

        public PessoaPorConceito FromDto(PessoaPorConceitoDto dto)
        {
            PessoaPorConceito pessoaPorConceito = new PessoaPorConceito();
            pessoaPorConceito.Id = dto.Id;
            pessoaPorConceito.Codigo = dto.Codigo;
            pessoaPorConceito.Media = dto.Media;
            pessoaPorConceito.Nome = dto.Nome;
            pessoaPorConceito.Conceito = new Conceito(){ Id = dto.ConceitoId, Nome = dto.Nome };

            return pessoaPorConceito;
        }
    }
}

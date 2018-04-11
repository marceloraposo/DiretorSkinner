using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class TipoPessoa
    {
        private int id;
        private string codigo;
        private string nome;
        private bool selecionado;

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
        public bool Selecionado
        {
            get
            {
                return selecionado;
            }

            set
            {
                selecionado = value;
            }
        }

        public TipoPessoaDto ToDto()
        {
            TipoPessoaDto dto = new TipoPessoaDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            dto.Selecionado = this.Selecionado;

            return dto;
        }

        public TipoPessoa FromDto(TipoPessoaDto dto)
        {
            TipoPessoa TipoPessoa = new TipoPessoa();
            TipoPessoa.Id = dto.Id;
            TipoPessoa.Codigo = dto.Codigo;
            TipoPessoa.Nome = dto.Nome;
            TipoPessoa.Selecionado = dto.Selecionado;

            return TipoPessoa;
        }
    }
}

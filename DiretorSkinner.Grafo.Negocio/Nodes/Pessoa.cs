using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;

namespace DiretorSkinner.Grafo.Negocio.Nodes
{
    public class Pessoa
    {
        private int id;
        private string codigo;
        private string nome;
        private string apelido;
        private List<TipoPessoa> tipoPessoas;

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
        public string Apelido
        {
            get
            {
                return apelido;
            }

            set
            {
                apelido = value;
            }
        }
        public List<TipoPessoa> TipoPessoas
        {
            get
            {
                return tipoPessoas;
            }

            set
            {
                tipoPessoas = value;
            }
        }

        public PessoaDto ToDto()
        {
            PessoaDto dto = new PessoaDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            dto.Apelido = this.Apelido;
            if (this.TipoPessoas != null)
            {
                dto.TipoPessoas = new List<TipoPessoaDto>();
                foreach (var item in this.TipoPessoas) {
                    dto.TipoPessoas.Add(item.ToDto());
                }
            }

            return dto;
        }

        public Pessoa FromDto(PessoaDto dto)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = dto.Id;
            pessoa.Codigo = dto.Codigo;
            pessoa.Nome = dto.Nome;
            pessoa.Apelido = dto.Apelido;
            if (dto.TipoPessoas != null)
            {
                pessoa.TipoPessoas = new List<TipoPessoa>();
                foreach (var item in dto.TipoPessoas)
                {
                    pessoa.TipoPessoas.Add(new TipoPessoa() { Id = item.Id, Codigo = item.Codigo, Nome = item.Nome });
                }
            }

            return pessoa;
        }

    }
}

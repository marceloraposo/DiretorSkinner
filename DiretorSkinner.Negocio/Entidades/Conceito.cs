using DiretorSkinner.Tranporte;
using System;

namespace DiretorSkinner.Negocio.Entidades
{
    public class Conceito
    {
        private int id;
        private string codigo;
        private string nome;
        private bool aprovado;
        private int minimo;
        private int maximo;

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
        public bool Aprovado
        {
            get { return aprovado; }
            set { aprovado = value; }
        }
        public int Minimo
        {
            get
            {
                return minimo;
            }

            set
            {
                minimo = value;
            }
        }
        public int Maximo
        {
            get { return maximo; }
            set { maximo = value; }
        }

        public ConceitoDto ToDto()
        {
            ConceitoDto dto = new ConceitoDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            dto.Aprovado = this.Aprovado;
            dto.Minimo = this.Minimo;
            dto.Maximo = this.Maximo;

            return dto;
        }

        public Conceito FromDto(ConceitoDto dto)
        {
            Conceito conceito = new Conceito();
            conceito.Id = dto.Id;
            conceito.Codigo = dto.Codigo;
            conceito.Nome = dto.Nome;
            conceito.Aprovado = dto.Aprovado;
            conceito.Minimo = dto.Minimo;
            conceito.Maximo = dto.Maximo;

            return conceito;
        }
    }
}

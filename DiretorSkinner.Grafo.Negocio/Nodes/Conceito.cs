using DiretorSkinner.Grafo.Tranporte;
using System;

namespace DiretorSkinner.Grafo.Negocio.Nodes
{
    public class Conceito
    {
        private int id;
        private string codigo;
        private string nome;
        private bool aprovado;

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

        public ConceitoDto ToDto()
        {
            ConceitoDto dto = new ConceitoDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;
            dto.Aprovado = this.Aprovado;

            return dto;
        }

        public Conceito FromDto(ConceitoDto dto)
        {
            Conceito conceito = new Conceito();
            conceito.Id = dto.Id;
            conceito.Codigo = dto.Codigo;
            conceito.Nome = dto.Nome;
            conceito.Aprovado = dto.Aprovado;

            return conceito;
        }
    }
}

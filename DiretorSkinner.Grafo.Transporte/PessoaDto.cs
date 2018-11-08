using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiretorSkinner.Grafo.Tranporte
{
    public class PessoaDto : RootDto
    {
        public PessoaDto()
        {
            this.TipoPessoas = new List<TipoPessoaDto>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public List<TipoPessoaDto> TipoPessoas { get; set; }
    }
}

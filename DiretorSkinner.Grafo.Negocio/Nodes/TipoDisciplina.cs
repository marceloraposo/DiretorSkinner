using DiretorSkinner.Grafo.Tranporte;

namespace DiretorSkinner.Grafo.Negocio.Nodes
{
    public class TipoDisciplina
    {
        private int id;
        private string codigo;
        private string nome;

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

        public TipoDisciplinaDto ToDto()
        {
            TipoDisciplinaDto dto = new TipoDisciplinaDto();

            dto.Id = this.Id;
            dto.Nome = this.Nome;
            dto.Codigo = this.Codigo;

            return dto;
        }

        public TipoDisciplina FromDto(TipoDisciplinaDto dto)
        {
            TipoDisciplina TipoDisciplina = new TipoDisciplina();
            TipoDisciplina.Id = dto.Id;
            TipoDisciplina.Codigo = dto.Codigo;
            TipoDisciplina.Nome = dto.Nome;

            return TipoDisciplina;
        }
    }
}

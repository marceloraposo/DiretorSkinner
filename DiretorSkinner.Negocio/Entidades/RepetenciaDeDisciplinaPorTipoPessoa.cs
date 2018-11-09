using DiretorSkinner.Tranporte;

namespace DiretorSkinner.Negocio.Entidades
{
    public class RepetenciaDeDisciplinaPorTipoPessoa
    {
        private int pessoaId;
        private string pessoaNome;
        private int tipoPessoaId;
        private string tipoPessoaNome;
        private string disciplinaNome;
        private string conceitoNome;
        private string semestre;

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
        public int TipoPessoaId
        {
            get
            {
                return tipoPessoaId;
            }

            set
            {
                tipoPessoaId = value;
            }
        }
        public string TipoPessoaNome
        {
            get
            {
                return tipoPessoaNome;
            }

            set
            {
                tipoPessoaNome = value;
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
        public string ConceitoNome
        {
            get
            {
                return conceitoNome;
            }

            set
            {
                conceitoNome = value;
            }
        }
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

        public RepetenciaDeDisciplinaPorTipoPessoaDto ToDto()
        {
            RepetenciaDeDisciplinaPorTipoPessoaDto dto = new RepetenciaDeDisciplinaPorTipoPessoaDto();

            dto.PessoaId = this.PessoaId;
            dto.PessoaNome = this.PessoaNome;
            dto.TipoPessoaId = this.TipoPessoaId;
            dto.TipoPessoaNome = this.TipoPessoaNome;
            dto.DisciplinaNome = this.DisciplinaNome;
            dto.ConceitoNome = this.ConceitoNome;
            dto.Semestre = this.Semestre;

            return dto;
        }

        public RepetenciaDeDisciplinaPorTipoPessoa FromDto(RepetenciaDeDisciplinaPorTipoPessoaDto dto)
        {
            RepetenciaDeDisciplinaPorTipoPessoa repetenciaDeDisciplinaPorTipoPessoa = new RepetenciaDeDisciplinaPorTipoPessoa();
            repetenciaDeDisciplinaPorTipoPessoa.PessoaId = dto.PessoaId;
            repetenciaDeDisciplinaPorTipoPessoa.PessoaNome = dto.PessoaNome;
            repetenciaDeDisciplinaPorTipoPessoa.TipoPessoaId = dto.TipoPessoaId;
            repetenciaDeDisciplinaPorTipoPessoa.TipoPessoaNome = dto.TipoPessoaNome;
            repetenciaDeDisciplinaPorTipoPessoa.DisciplinaNome = dto.DisciplinaNome;
            repetenciaDeDisciplinaPorTipoPessoa.ConceitoNome = dto.ConceitoNome;
            repetenciaDeDisciplinaPorTipoPessoa.Semestre = dto.Semestre;

            return repetenciaDeDisciplinaPorTipoPessoa;
        }
    }
}

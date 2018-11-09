namespace DiretorSkinner.Tranporte
{
    public class RepetenciaDeDisciplinaPorTipoPessoaDto : RootDto
    {
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public int TipoPessoaId { get; set; }
        public string TipoPessoaNome { get; set; }
        public string DisciplinaNome { get; set; }
        public string ConceitoNome { get; set; }
        public string Semestre { get; set; }

    }
}
namespace DiretorSkinner.Grafo.Tranporte
{
    public class SalaDeAulaDto : RootDto
    {
        public int Id { get; set; }
        public string Semestre { get; set; }
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public int DisciplinaId { get; set; }
        public decimal? Nota { get; set; }
        public int TurmaId { get; set; }
    }
}

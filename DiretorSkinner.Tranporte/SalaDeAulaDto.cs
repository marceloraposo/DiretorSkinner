namespace DiretorSkinner.Tranporte
{
    public class SalaDeAulaDto : RootDto
    {
        public string Semestre { get; set; }
        public int PessoaId { get; set; }
        public int DisciplinaId { get; set; }
        public int ConceitoId { get; set; }
        public int TurmaId { get; set; }
    }
}

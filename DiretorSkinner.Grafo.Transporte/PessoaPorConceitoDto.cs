namespace DiretorSkinner.Grafo.Tranporte
{
    public class PessoaPorConceitoDto : RootDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int ConceitoId { get; set; }
        public string ConceitoNome { get; set; }
        public decimal Media { get; set; }

    }
}
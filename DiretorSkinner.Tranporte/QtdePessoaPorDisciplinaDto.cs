namespace DiretorSkinner.Tranporte
{
    public class QtdePessoaPorDisciplinaDto : RootDto
    {
        public int DisciplinaId { get; set; }
        public string DisciplinaNome { get; set; }
        //public int PessoaId { get; set; }
        //public string PessoaNome { get; set; }
        public int Quantidade { get; set; }

    }
}
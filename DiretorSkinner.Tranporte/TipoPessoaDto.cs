﻿namespace DiretorSkinner.Tranporte
{
    public class TipoPessoaDto : RootDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool Selecionado { get; set; }
    }
}

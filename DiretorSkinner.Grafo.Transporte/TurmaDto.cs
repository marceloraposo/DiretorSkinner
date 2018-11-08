using System;
using System.Collections.Generic;

namespace DiretorSkinner.Grafo.Tranporte
{
    public class TurmaDto : RootDto
    {
        public TurmaDto()
        {
            this.SalasDeAula = new List<SalaDeAulaDto>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime DataIngresso { get; set; }
        public string DataIngressoValor
        {
            get
            {
                if (this.DataIngresso != null)
                {
                    return this.DataIngresso.ToShortDateString();
                }
                else
                {
                    return DateTime.Now.ToShortDateString();
                }
            }
        }
        public List<SalaDeAulaDto> SalasDeAula { get; set; }

    }
}

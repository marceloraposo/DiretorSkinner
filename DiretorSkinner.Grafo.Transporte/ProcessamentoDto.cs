using System;
using System.Runtime.Serialization;

namespace DiretorSkinner.Grafo.Tranporte
{
    [Serializable]
    [DataContract]
    public class ProcessamentoDto : RootDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public long Cpu { get; set; }

        public string CpuFormatado
        {
            get
            {
                return TimeSpan.FromMilliseconds(Cpu).ToString(@"mm\.ss\.ffffff");
            }
        }

        [DataMember]
        public long Memoria { get; set; }

        public string MemoriaFormatada
        {
            get
            {
                return Memoria == 0 ? "" : string.Format("{0}",(Memoria/1024));
            }
        }

        [DataMember]
        public long Tempo { get; set; }

        public string TempoFormatado
        {
            get
            {
                return TimeSpan.FromMilliseconds(Tempo).ToString(@"mm\.ss\.ffffff");
            }
        }

        public long TempoMedio
        {
            get
            {
                return Tamanho == 0 ? 0 : Tempo / Tamanho;
            }
        }

        public string TempoMedioFormatado
        {
            get
            {
                return TimeSpan.FromMilliseconds(TempoMedio).ToString(@"mm\.ss\.ffffff");
            }
        }

        [DataMember]
        public int Tamanho { get; set; }
    }
}

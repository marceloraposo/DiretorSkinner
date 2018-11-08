using System;
using System.Runtime.Serialization;

namespace DiretorSkinner.Grafo.Tranporte
{
    [Serializable]
    [DataContract]
    public class ConceitoDto : RootDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public bool Aprovado { get; set; }

        [DataMember]
        public int Minimo { get; set; }

        [DataMember]
        public int Maximo { get; set; }
    }
}

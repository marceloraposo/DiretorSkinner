using System;
using System.Runtime.Serialization;

namespace DiretorSkinner.Tranporte
{
    [Serializable]
    [DataContract]
    public class RootDto : ICloneable
    {
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

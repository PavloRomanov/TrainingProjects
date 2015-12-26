using System;
using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public abstract class ModelBase
    {
        [DataMember]
        public Guid Id { get; set; }

        public ModelBase(Guid id)
        {
            Id = id;
        }
    }
}

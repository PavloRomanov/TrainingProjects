using Model.Enum;
using System;
using System.Runtime.Serialization;


namespace Model.Entity
{
    [DataContract]
    public class Appeal : ModelBase
    {
        [DataMember]
        public ClientAppeal ClientAppeal { get; set; }
        [DataMember]
        public Guid IdManager { get; set; }

        [DataMember]
        public string Rez { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string References { get; set; }

        [DataMember]
        public Guid IdClient { get; set; }

        public Appeal(Guid id, Guid idclient, Guid idmanager, ClientAppeal appeal)
            : base(id)
        {
            IdClient = idclient;
            IdManager = idmanager;
            ClientAppeal = appeal;
        }
    }
}

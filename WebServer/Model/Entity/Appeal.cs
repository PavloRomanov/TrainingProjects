using System;
using System.Runtime.Serialization;


namespace Model.Entity
{
    public enum ClientAppeal
    {
        Low_speed_Internet = 1,
        No_internet_connection,
        Change_of_tariff_plan,
        Installation_of_additional_equipment,
        Another_question
    }

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

        public Appeal(Guid id, Guid idclient, Guid idmanager)
            : base(id)
        {
            IdClient = idclient;
            IdManager = idmanager;
        }
    }
}

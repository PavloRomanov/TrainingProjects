using System;
using System.Runtime.Serialization;

namespace Model.Entity
{
    public enum FormsClient
    {
        Are_you_satisfied_with_the_service = 1,
        Are_you_satisfied_with_the_speed_of_the_Internet,
        Do_you_like_the_service_manager,
        Do_you_use_the_Internet_and_TV,
        Do_you_want_to_participate_in_the_loyalty_program
    }
    [DataContract]
    public class Form : ModelBase
    {
        public FormsClient FormClient { get; set; }

        public Form(Guid id, Guid idclient, Guid idmanager)
            : base(id)
        {
            IdClient = idclient;
            IdManager = idmanager;
        }

        [DataMember]
        public Guid IdClient { get; set; }

        [DataMember]
        public Guid IdManager { get; set; }

        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Answer1 { get; set; }
        [DataMember]
        public string Answer2 { get; set; }
        [DataMember]
        public FormsClient F1 { get; set; }
         [DataMember]
         public FormsClient F2 { get; set; }
         /*[DataMember]
         public FormsClient F3 { get; set; }

         [DataMember]
         public FormsClient F4 { get; set; }
         [DataMember]
         public FormsClient F5 { get; set; }*/


    }
}

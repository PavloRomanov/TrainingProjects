using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Entity
{
    
    [DataContract]
    public class Form : ModelBase
    { 

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
        public string Comment1 { get; set; }
        [DataMember]
        public string Comment2 { get; set; }
        [DataMember]
        public string Comment3 { get; set; }
        [DataMember]
        public string Comment4 { get; set; }
        [DataMember]
        public string Comment5 { get; set; }

        [DataMember]
        public string Answer1 { get; set; }
       [DataMember]
        public string Answer2 { get; set; }
        [DataMember]
        public string Answer3 { get; set; }
        [DataMember]
        public string Answer4 { get; set; }
        [DataMember]
        public string Answer5 { get; set; }
        [DataMember]
        public FormsClient F1 { get; set; }
       [DataMember]
        public FormsClient F2 { get; set; }
         [DataMember]
         public FormsClient F3 { get; set; }
         [DataMember]
         public FormsClient F4 { get; set; }
         [DataMember]
         public FormsClient F5 { get; set; }


    }
}

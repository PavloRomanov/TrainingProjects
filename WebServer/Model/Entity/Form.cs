using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Entity
{
    
    [DataContract]
    public class Form : ModelBase
    { 

        public Form(Guid id, Guid idmanager, Guid idclient)
            : base(id)
        {
            IdClient = idclient;
            IdManager = idmanager;
            F1 = (FormsClient)1;
            F2 = (FormsClient)2;
            F3 = (FormsClient)3;
            F4 = (FormsClient)4;
            F5 = (FormsClient)5;
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

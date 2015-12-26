using System;
using System.Runtime.Serialization;


namespace Model.Entity
{
    [DataContract]
    public class Client : ModelBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        public Client(Guid id, string name, string surname, string address, string phone)
            : base(id)
        {            
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
        }

    }
}

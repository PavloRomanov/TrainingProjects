using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Model.Entity
{
    public enum WorkExperience
    {
        Experience1year = 1,
        Experience1to3year,
        Experience3to5year,
        Experiencemorethan5year
    }
    [DataContract]
    public class Manager : ModelBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public WorkExperience Work { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        public Manager(Guid id, string name, string surname, string address, string phone, string login, string password)
            : base(id)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
            Login = login;
            Password = password;         
        }
    }
}

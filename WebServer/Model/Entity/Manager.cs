using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Model.Entity
{
   
    [DataContract]
    public class Manager : ModelBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public StageExperience.WorkExperience Work { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        public Manager(Guid id, string name, string surname,/*int work,*/ string address, string phone, string login, string password)
            : base(id)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
            Login = login;
            Password = password;
           // Work = (StageExperience.WorkExperience) work;
        }
    }
}

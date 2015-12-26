using System;
using System.Runtime.Serialization;


namespace Model.Entity
{
    [DataContract]
    public class Appeal : ModelBase
    {
        public enum AppealClient
        {
            Low_speed_Internet = 1,
            No_internet_connection,
            Change_of_tariff_plan,
            Installation_of_additional_equipment,
            Another_question
        }

        [DataMember]
        private bool appeal; //was appeal
        [DataMember]
        private bool rez; // found a solution

        [DataMember]
        private string answer;

        [DataMember]
        private string specialist;

        [DataMember]
        private Client client;
        public Appeal(Guid id, Client _client)
            : base(id)
        {
            answer = "";
            specialist = "";
            rez = false;
            client = _client;
        }

        public bool Rezult()
        {
            return rez;
        }

        public bool WasAppeal()
        {
            return appeal;
        }
    }
}

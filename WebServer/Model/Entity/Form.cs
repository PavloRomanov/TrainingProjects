using System;
using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class Form : ModelBase
    {
        public enum FormClient
        {
            Are_you_satisfied_with_the_service = 1,
            Are_you_satisfied_with_the_speed_of_the_Internet,
            Do_you_like_the_service_manager,
            Do_you_use_the_Internet_and_TV,
            Do_you_want_to_participate_in_the_loyalty_program
        }

        public Form(Guid id)
            : base(id)
        {
            questionnaire = false;
        }

        [DataMember]
        public Guid Id { get; }
        [DataMember]
        private bool questionnaire;
        [DataMember]
        private Guid ClientId { get; set; }

        public bool Questionnaire()
        {
            return questionnaire;
        }
    }
}

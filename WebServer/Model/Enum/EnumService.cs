using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{
   public class EnumService
    {
        public static Dictionary<WorkExperience, int> GetAllWorkExperience()
        {
            var exp = new Dictionary<WorkExperience, int>();

            exp.Add(WorkExperience.Experience_1year, 1);
            exp.Add(WorkExperience.Experience_3year, 3);
            exp.Add(WorkExperience.Experience_5year, 5);
            exp.Add(WorkExperience.Experience_more5year, 6);
            return exp;
        }
        public static Dictionary<ClientAppeal, int> GetAllClientAppeals()
        {
            var exp = new Dictionary<ClientAppeal, int>();

            exp.Add(ClientAppeal.Another_question, 1);
            exp.Add(ClientAppeal.Change_of_tariff_plan, 2);
            exp.Add(ClientAppeal.Installation_of_additional_equipment, 3);
            exp.Add(ClientAppeal.Low_speed_Internet, 4);
            exp.Add(ClientAppeal.No_internet_connection, 5);
            return exp;
            
        }
    }
}

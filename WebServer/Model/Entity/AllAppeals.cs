using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public struct AllAppeals
    {
        public enum ClientAppeal
        {
            Low_speed_Internet = 1,
            No_internet_connection,
            Change_of_tariff_plan,
            Installation_of_additional_equipment,
            Another_question
        }

        public static Dictionary<ClientAppeal, int> GetALL()
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

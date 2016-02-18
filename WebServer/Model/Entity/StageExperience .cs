using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public struct StageExperience
    {

        public enum WorkExperience
        {
            Experience_1year = 1,
            Experience_3year,
            Experience_5year,
            Experience_more5year
        }
        

        public static Dictionary<WorkExperience,int> GetALL()
        {
            var exp = new Dictionary<WorkExperience,int>();
            /*for (int i = 1; i < 5; i++)
            {
                exp.Add(WorkExperience, i);
            }*/
            exp.Add(WorkExperience.Experience_1year,1);
            exp.Add(WorkExperience.Experience_3year,2);
            exp.Add(WorkExperience.Experience_5year,3);
            exp.Add(WorkExperience.Experience_more5year,4);
            return exp;
        }
    }
}

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
            Experience_3year =3,
            Experience_5year =5,
            Experience_more5year =6
        }
        

        public static Dictionary<WorkExperience,int> GetALL()
        {
            var exp = new Dictionary<WorkExperience,int>();
            
            exp.Add(WorkExperience.Experience_1year,1);
            exp.Add(WorkExperience.Experience_3year,3);
            exp.Add(WorkExperience.Experience_5year,5);
            exp.Add(WorkExperience.Experience_more5year,6);
            return exp;
        }
    }
}

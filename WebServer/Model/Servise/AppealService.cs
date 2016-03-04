using System;
using System.Runtime.Serialization;
using Model.Entity;

namespace Model.Servise
{
    public class AppealServiсe : BaseService<Appeal>, IAppealService
    {
        public AppealServiсe(string path)
            : base(path)
        {
        }
    }
}

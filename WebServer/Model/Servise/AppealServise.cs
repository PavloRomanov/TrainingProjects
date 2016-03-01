using System;
using System.Runtime.Serialization;
using Model.Entity;

namespace Model.Servise
{
    public class AppealServiсe : FileService<Appeal>
    {
        public AppealServiсe(string path)
            : base(path)
        {
        }
    }
}
